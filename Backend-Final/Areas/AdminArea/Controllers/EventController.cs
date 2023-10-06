using Backend_Final.DAL;
using Backend_Final.Extensions;
using Backend_Final.Models;
using Backend_Final.ViewModels.AdminEvent;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend_Final.Areas.AdminArea.Controllers
{
    [Area(nameof(AdminArea))]
    public class EventController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EventController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var events=_context.Event
                .Include(e=>e.Category)
                .ToList();
            return View(events);
        }
        //Delete
        public IActionResult Delete(int? id)
        {
            if (id == null) return View();
            var events=_context.Event.FirstOrDefault(e=>e.Id == id);
            if (events == null) return View();
            _context.Event.Remove(events);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
        //Create
        public ActionResult Create() {

            ViewBag.Categories = _context.Category.ToList();
            ViewBag.Speakers = _context.Speakers.ToList();
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public ActionResult Create(EventCreateVM eventCreateVM,int?id,List<int>? speakerIds)
        {
            ViewBag.Categories = _context.Category.ToList();
            ViewBag.Speakers = _context.Speakers.ToList();
            if (!ModelState.IsValid) {
                ModelState.AddModelError("", "required!");
                return View(); }
            Event events=new();
            events.Title = eventCreateVM.Title;
            events.Desc = eventCreateVM.Desc;
            events.OpenTime = eventCreateVM.OpenTime;
            events.CloseTime = eventCreateVM.CloseTime;
            events.Venue = eventCreateVM.Venue;
            events.CategoryId = id;
            if (eventCreateVM.Image.CheckSize(10000))
            {
                ModelState.AddModelError("Image", "Sheklin olcusu cox boyukdur!");
                return View();
            }
            if (!eventCreateVM.Image.CheckImage())
            {
                ModelState.AddModelError("Image", "Yalniz shekil!");
                return View();
            }
            events.ImgUrl= eventCreateVM.Image.SaveImage("img/event", _webHostEnvironment);
            _context.Event.Add(events);
            _context.SaveChanges();
            Speaker speaker;
            foreach (var speakerId in speakerIds)
            {
            speaker=_context.Speakers.FirstOrDefault(s=>s.Id==speakerId);
                Speaker newSpeaker = new();
                newSpeaker.Name = speaker.Name;
                newSpeaker.Specilty = speaker.Specilty;
                newSpeaker.ImgUrl = speaker.ImgUrl;
                //newSpeaker = events.Id;


            _context.Speakers.Add(newSpeaker);
                _context.SaveChanges();
            }
            return RedirectToAction("index");
        }

    }
}
