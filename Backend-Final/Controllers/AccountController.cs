using Backend_Final.DAL;
using Backend_Final.Models;
using Backend_Final.ViewModels.AccountVM;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend_Final.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AppDbContext _context;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager, AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _context = context;
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
            return RedirectToAction("Login");
        }
        #endregion
        public IActionResult VerifyEmail()
        {
            return View();
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
                if (item == "Admin") return RedirectToAction("index","dashboard",new { area="AdminArea" });
            }
            return RedirectToAction("index","home");
        }

        #endregion
    }
}
