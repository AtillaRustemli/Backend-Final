using Backend_Final.DAL;
using Backend_Final.Extensions;
using Backend_Final.Models;
using Backend_Final.ViewModels.AdminSettingKeyValuVM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.ProjectModel;
using System.IO;
using System.Text;

namespace Backend_Final.Areas.AdminArea.Controllers
{
    [Area(nameof(AdminArea))]
    public class SettingKeyValueController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public SettingKeyValueController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var settingKV = _context.SettingsKeyValue.ToList();
            return View(settingKV);
        }

        //Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(CreateSettingVM createSettingVM)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            SettingsKeyValue settingsKeyValue = new();
            settingsKeyValue.Key = createSettingVM.Key;
            if(createSettingVM.Value != null) {
                settingsKeyValue.Value=createSettingVM.Value;
            }
            else if(createSettingVM.ImgValue != null)
            {
                if (!createSettingVM.ImgValue.CheckImage())
                {
                    ModelState.AddModelError("image", "Yalniz shekil!!!");
                    return View();
                }
                if (createSettingVM.ImgValue.CheckSize(1000))
                {
                    ModelState.AddModelError("image", "Sheklin olcusu cox boyukdur!!!");
                    return View();
                }
                settingsKeyValue.Value = createSettingVM.ImgValue.SaveImage("img/logo", _webHostEnvironment);
            }
            _context.SettingsKeyValue.Add(settingsKeyValue);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        //Update 

        public IActionResult Update(int?id)
        {
            FormFile formFile;
            if (id == null) return NotFound();
            var settings=_context.SettingsKeyValue.FirstOrDefault(s=>s.Id==id);

            byte[] fileBytes = Encoding.UTF8.GetBytes(settings.Value);
            using (var stream = new MemoryStream(fileBytes))
            {
                formFile = new FormFile(stream, 0, fileBytes.Length, "file", "file.txt");
            }
            if (settings == null) return NotFound();
            UpdateSettingVM updateSettingVM = new();
            updateSettingVM.Key = settings.Key;
            if (settings.Value.Contains("png") || settings.Value.Contains("jpg"))
            {
                updateSettingVM.Value = formFile.ToString();
            }
            else
            {
            updateSettingVM.Value = settings.Value;

            }
            return View(updateSettingVM);
        }
    }
}
