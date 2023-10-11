using Backend_Final.ViewModels.AdminRole;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Backend_Final.Areas.AdminArea.Controllers
{
    [Area(nameof(AdminArea))]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
           var roles=_roleManager.Roles.ToList();
            return View(roles);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(CreateRoleVM createRoleVM)
        {
            if(!ModelState.IsValid) return View();
            IdentityRole role = new();
            role.Name = createRoleVM.Name;
            role.NormalizedName= createRoleVM.Name.ToUpper();
            role.ConcurrencyStamp=Guid.NewGuid().ToString();
            await _roleManager.CreateAsync(role);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(string?id)
        {
            if (id == null) return NotFound();
            var role=await _roleManager.FindByIdAsync(id);
            UpdateRoleVM updateRoleVM =new();
            updateRoleVM.Name = role.Name;
            return View(updateRoleVM);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Update(UpdateRoleVM updateRoleVM,string?id)
        {
            if(!ModelState.IsValid) return View();
            var role =await _roleManager.FindByIdAsync(id);
            role.Name = updateRoleVM.Name;
            role.NormalizedName= updateRoleVM.Name.ToUpper();
            role.ConcurrencyStamp=Guid.NewGuid().ToString();
            if (_roleManager.Roles.Any(r => r.Name == updateRoleVM.Name && r.Id != id))
            {
                ModelState.AddModelError("name", "Bu adli role artiq movcuddur!");
                return View();
            }
            await _roleManager.UpdateAsync(role);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(string? id)
        {
            if (id == null) return NotFound();
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null) return NotFound();
            await _roleManager.DeleteAsync(role);
            return RedirectToAction("index");
        }

        public async Task<IActionResult> Detail(string id)
        {
            if(id == null) return NotFound();
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null) return NotFound();
            return View(role);
        }
    }
}
