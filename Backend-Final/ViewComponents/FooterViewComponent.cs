using Backend_Final.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Backend_Final.ViewComponents
{
    public class FooterViewComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            HomeVM vm = new();
            return View(await Task.FromResult(vm));
        }
    }
}
