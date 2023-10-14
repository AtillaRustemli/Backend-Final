using Backend_Final.DAL;
using Backend_Final.Extensions;
using Backend_Final.Models;
using Backend_Final.Models.Emails;
using Backend_Final.Services;
using Backend_Final.Services.AdminServices.AdminEventServices;
using Backend_Final.ViewModels.AdminEvent;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using System.Linq;

namespace Backend_Final.Areas.AdminArea.Controllers
{
    [Area(nameof(AdminArea))]
    public class EventController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly EmailConfig _emailServices;


        public EventController(AppDbContext context, IWebHostEnvironment webHostEnvironment, EmailConfig emailServices)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _emailServices = emailServices;
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
            EventService deleteEventService = new( _context,  _webHostEnvironment,  _emailServices,ModelState);
            var result=deleteEventService.Delete(id, this);
            return result;
        }
        //Create
        public IActionResult Create()
        {
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
            EventService createEventService = new(_context,_webHostEnvironment,_emailServices,ModelState);
            var result=createEventService.Create(eventCreateVM,id,speakerIds,this);
            return result;
        
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
            ViewBag.Categories = _context.Category.ToList();
            ViewBag.Speakers = _context.Speakers.ToList();
            ViewBag.SpeakerEvent = _context.SpeakerEvent.Where(se=>se.EventId==id).ToList();
            ViewBag.Event = _context.Event.ToList();
            ViewBag.CategoryWithEvent = _context.Event.FirstOrDefault(e => e.Id == id);
            EventService updateEventService = new(_context, _webHostEnvironment, _emailServices, ModelState);
            var result = updateEventService.Update(eventUpdateVM, id, categoryId, speakerIds,this);
            return result;
          
        }





    }
}
