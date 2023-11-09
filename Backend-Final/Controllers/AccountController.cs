using Backend_Final.DAL;
using Backend_Final.Models;
using Backend_Final.Models.Emails;
using Backend_Final.ViewModels.AccountVM;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Net;
using System.Net.Mail;

namespace Backend_Final.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AppDbContext _context;
        private readonly EmailConfig _emailConfig;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager, AppDbContext context, EmailConfig emailConfig)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _context = context;
            _emailConfig = emailConfig;
        }
        #region Register
        public IActionResult Registers()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Registers(RegisterVM registerVM)
        {
            var role = await _roleManager.FindByNameAsync("Member");
            if (!ModelState.IsValid) return View();
            AppUser appUser = new();
            appUser.UserName = registerVM.Username;
            appUser.Email = registerVM.Email;
            IdentityResult result = await _userManager.CreateAsync(appUser, registerVM.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("password", error.Description.ToString());
                }
                return View(registerVM);
            }
            await _userManager.AddToRoleAsync(appUser, role.ToString());
            await _userManager.UpdateAsync(appUser);
            _context.SaveChanges();

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(appUser);
            var url = Url.Action(nameof(VerifyEmail), "Account", new { email = appUser.Email, token }, Request.Scheme, Request.Host.ToString());
            MailMessage mailMessage = new();
            mailMessage.From =new MailAddress("atillaproject52@gmail.com","VerifyEmail");
            mailMessage.To.Add(appUser.Email);
            mailMessage.Subject="Verify your Email";
            string body=string.Empty;

            using(StreamReader streamReader = new("wwwroot/Templates/VerifyEmail.html"))
            {
                body= streamReader.ReadToEnd();
            }
            mailMessage.Body = body.Replace("{{link}}", url);
            mailMessage.IsBodyHtml = true;
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Port = 587;
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential(_emailConfig.From, _emailConfig.Password);
            smtpClient.Send(mailMessage);

            return RedirectToAction("Login");
        }
        #endregion
        public async Task<IActionResult> VerifyEmail(string email,string token)
        {
            AppUser user=await _userManager.FindByEmailAsync(email);
            if(user==null) return NotFound();
            if (user.EmailConfirmed)
            {
                return Json(new {result="success"});
            }
            await _userManager.ConfirmEmailAsync(user,token);
            await _signInManager.SignInAsync(user,true);
            return RedirectToAction("index","home");
        }

        #region Logout
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }
        #endregion

        #region Login
        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Login(LoginVM loginVM,string ReturnUrl)
        {
            var user =await _userManager.FindByEmailAsync(loginVM.UsernameOrEmail);
            if(user == null)
            {
                user= await _userManager.FindByNameAsync(loginVM.UsernameOrEmail);
               if (user == null)
                {
                    ModelState.AddModelError("", "Username/Email or Passwor is wrong");
                    return View();
                }
            }
            var result=await _signInManager.PasswordSignInAsync(user,loginVM.Password,loginVM.RemeberMe,true);
            if(result.IsLockedOut)
            {
                ModelState.AddModelError("", "Heabiniz blokanib!");
            }
            if(!result.Succeeded)
            {
                ModelState.AddModelError("", "Password is wrong!");
            }
            await _signInManager.SignInAsync(user,true);
            if(ReturnUrl!=null)
            {
                Redirect(ReturnUrl);
            }
            var role=await _userManager.GetRolesAsync(user);
            foreach(var item in role)
            {
                if (item == "Admin" && user.EmailConfirmed) return RedirectToAction("index", "dashboard", new { area = "AdminArea" });
               
            }
            if(!user.EmailConfirmed)
            {
                ModelState.AddModelError("Verify", "Hesabiniz Verify olunmayib!");
                await _signInManager.SignOutAsync();
                return View();
            }
            return RedirectToAction("index","home");
        }

        #endregion

        #region ForgetPassword

        public IActionResult ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordVM forgetPasswordVM)
        {
            AppUser user= await _userManager.FindByEmailAsync(forgetPasswordVM.appUser.Email);
            if (user == null)
            {
                ModelState.AddModelError("Error", "Qeyd etdiyiniz email tapilmadi.");
                return View();
            }
            var token=await _userManager.GeneratePasswordResetTokenAsync(user);
            var link = Url.Action(nameof(ResetPassword), "Account",new { email = user.Email, token = token },Request.Scheme,Request.Host.ToString());

            MailMessage mailMessage = new();
            mailMessage.From = new MailAddress(_emailConfig.From, _emailConfig.UserName);
            mailMessage.IsBodyHtml = true;
            mailMessage.To.Add(user.Email);
            mailMessage.Subject = "Reset Password";
            mailMessage.Body=$"<a href={link}>Click Here to start reseting Password</a>";

            SmtpClient smtpClient = new();
            smtpClient.Port = 587;
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential(_emailConfig.From, _emailConfig.Password);
            smtpClient.Send(mailMessage);

            return RedirectToAction("index","home");
        }

        public async Task<IActionResult> ResetPassword(string token,string email) 
        {
            AppUser user=await _userManager.FindByEmailAsync(email);
            if (user == null) return BadRequest();
            bool checkToken=await _userManager.VerifyUserTokenAsync(user,_userManager.Options.Tokens.PasswordResetTokenProvider,"ResetPassword",token);
            if (checkToken) return RedirectToAction("UsedLink");
            return View();
        }
        public IActionResult UsedLink()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> ResetPassword(ForgetPasswordVM forgetPasswordVM,string token,string email) 
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            AppUser user=await _userManager.FindByEmailAsync(email);
            if (user == null)  return NotFound();
            await _userManager.ResetPasswordAsync(user, token, forgetPasswordVM.Password);
            await _userManager.UpdateSecurityStampAsync(user);
            return RedirectToAction("index","home");
        }

        #endregion
    }
}
