using Backend_Final.DAL;
using Backend_Final.Models;
using Backend_Final.ViewModels.AdminUser;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Backend_Final.Areas.AdminArea.Controllers
{
    [Area(nameof(AdminArea))]
    public class UserController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;


        public UserController(AppDbContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
         var user= _userManager.Users.ToList();
            return View(user);
        }
        //Create
        #region Create
        public IActionResult Create()
        {
            ViewBag.Roles=_roleManager.Roles.ToList();
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(CreateUserVM createUserVM,List<string> roles)
        {
            ViewBag.Roles = _roleManager.Roles.ToList();
            if(!ModelState.IsValid)
            {
                return View();
            }
            AppUser user=new();
            user.Email = createUserVM.Email;
            user.UserName = createUserVM.Username;
            var result=await _userManager.CreateAsync(user,createUserVM.Password);
            await _userManager.AddToRolesAsync(user, roles);
            if(!result.Succeeded) {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description.ToString());

                }
                return View();
            }

            return RedirectToAction("Index");
        }
        #endregion 
        //Delete
        #region Delete
        public async Task<IActionResult> Delete(string?id)
        {
            if(id == null) return NotFound();
            var user =await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();
            await _userManager.DeleteAsync(user);
            return RedirectToAction($"index");
        }
        #endregion
        //Update
        #region Update
        public async Task<IActionResult> Update(string?id)
        {
            var user = await _userManager.FindByIdAsync(id);
            UpdateUserVM updateUserVM=new();
            updateUserVM.AppUser = user;
            updateUserVM.UserRole=await _userManager.GetRolesAsync(user);
            updateUserVM.Roles=_roleManager.Roles.ToList();
            return View(updateUserVM);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Update(UpdateUserVM updateUserVM,List<string> roles,string?id)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            var user =await _userManager.FindByIdAsync(id);
            var oldRoles =await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user,oldRoles);
            await _userManager.AddToRolesAsync(user,roles);
            user.Email = updateUserVM.AppUser.Email;
            user.UserName = updateUserVM.AppUser.UserName;

            return RedirectToAction("Index");
        }
        #endregion

    }
}
