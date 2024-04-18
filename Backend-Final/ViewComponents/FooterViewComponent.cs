using Backend_Final.DAL;
using Backend_Final.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Backend_Final.ViewComponents
{
    public class FooterViewComponent:ViewComponent
    {
        private readonly AppDbContext _context;

        public FooterViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            HomeVM vm = new();
            vm.SettingsKeyValue = _context.SettingsKeyValue.ToDictionary(k=>k.Key,v=>v.Value);
            return View(await Task.FromResult(vm));
        }
    }
}
