using Backend_Final.DAL;
using Backend_Final.Extensions;
using Backend_Final.Models;
using Backend_Final.ViewModels.AdminEvent;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
        public IActionResult Create() {
            ViewBag.Categories = _context.Category.ToList();
            ViewBag.Speakers = _context.Speakers.ToList();
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(EventCreateVM eventCreateVM,int?id,List<int>? speakerIds)
        {
            ViewBag.Categories = _context.Category.ToList();
            ViewBag.Speakers = _context.Speakers.ToList();
            if (!ModelState.IsValid) {
                ModelState.AddModelError("", "required!");
                return View(); 
            }
            Event events=new();
            if(_context.Event.Any(s=>s.Title== eventCreateVM.Title))
            {
                ModelState.AddModelError("Title", "Bu adli evnet artiq var!");
                return View();
            }
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
              SpeakerEvent speakerEvent = new();
                speakerEvent.SpeakerId = speakerId;
                speakerEvent.EventId = events.Id;


            _context.SpeakerEvent.Add(speakerEvent);
                _context.SaveChanges();
            }
            return RedirectToAction("index");
        }

        //Update
        public IActionResult Update(int?id) {
            var events=_context.Event.FirstOrDefault(e => e.Id == id);  
            EventUpdateVM vm = new();
            vm.Title = events.Title;
            vm.Desc = events.Desc;
            vm.OpenTime = events.OpenTime;
            vm.CloseTime = events.CloseTime;
            vm.Venue = events.Venue;
            
            ViewBag.Categories = _context.Category.ToList();
            ViewBag.Speakers = _context.Speakers.ToList();
            ViewBag.Event = _context.Event.Where(e=>e.Id==id).ToList();
            ViewBag.CategoryWithEvent=_context.Event.FirstOrDefault(e=>e.Id==id);
            ViewBag.SpeakerEvent = _context.SpeakerEvent.Where(se => se.EventId == id).ToList();
            return View(vm);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Update(EventUpdateVM eventUpdateVM,int id,int? categoryId, List<int>? speakerIds)
        {
            var events = _context.Event.FirstOrDefault(e => e.Id == id);
            ViewBag.Categories = _context.Category.ToList();
            ViewBag.Speakers = _context.Speakers.ToList();
            ViewBag.SpeakerEvent = _context.SpeakerEvent.Where(se=>se.EventId==id).ToList();
            ViewBag.Event = _context.Event.ToList();
            ViewBag.CategoryWithEvent = _context.Event.FirstOrDefault(e => e.Id == id);
            if (!ModelState.IsValid) {
                ModelState.AddModelError("", "required!");
                return View(); 
            }
            if(_context.Event.Any(s=>s.Title== eventUpdateVM.Title&&s.Id!=id))
            {
                ModelState.AddModelError("Title", "Bu adli evnet artiq var!");
                return View();
            }
            events.Title = eventUpdateVM.Title;
            events.Desc = eventUpdateVM.Desc;
            events.OpenTime = eventUpdateVM.OpenTime;
            events.CloseTime = eventUpdateVM.CloseTime;
            events.Venue = eventUpdateVM.Venue;
            events.CategoryId = categoryId;
            if (eventUpdateVM.Image.CheckSize(10000))
            {
                ModelState.AddModelError("Image", "Sheklin olcusu cox boyukdur!");
                return View();
            }
            if (!eventUpdateVM.Image.CheckImage())
            {
                ModelState.AddModelError("Image", "Yalniz shekil!");
                return View();
            }
            events.ImgUrl= eventUpdateVM.Image.SaveImage("img/event", _webHostEnvironment);
            _context.SaveChanges();
            var speakerEvent = _context.SpeakerEvent.Where(se=>se.EventId==id).ToList();
            foreach (var speakerId in speakerIds)
            {
                foreach (var speaker in speakerEvent)
                {
                    speaker.EventId = id;
                    speaker.SpeakerId = speakerId;
                }
                _context.SaveChanges();
            }
            return RedirectToAction("index");
        }





    }
}
