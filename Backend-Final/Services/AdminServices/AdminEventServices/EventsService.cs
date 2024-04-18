using Backend_Final.DAL;
using Backend_Final.Extensions;
using Backend_Final.Models;
using Backend_Final.Models.Emails;
using Backend_Final.ViewModels.AdminEvent;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MimeKit;
using System.ComponentModel.DataAnnotations;

namespace Backend_Final.Services.AdminServices.AdminEventServices
{
    public class EventsService : IEventService
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly EmailConfig _emailServices;
        //private ModelStateDictionary _modelState;

        //public void AddModelError(string key, string errorMessage)
        //{
        //    _modelState.AddModelError(key, errorMessage);
        //}


        public EventsService(AppDbContext context, IWebHostEnvironment webHostEnvironment, EmailConfig emailServices)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _emailServices = emailServices;

        }
        public ActionResult Create(EventCreateVM eventCreateVM, int? id, List<int>? speakerIds,Controller controller)
        {

            if (!controller.ModelState.IsValid)
            {
                return controller.View();
            }
            //-----------------------------------------------
            //-----------------------------------------------
            //-----------------------------------------------
            var userEmails = _context.Subscribers.ToList();
            List<string> emails = new List<string>();
            foreach (var userEmail in userEmails)
            {
                emails.Add(userEmail.Email);

            }
            EmailServices es = new(_emailServices);
            MimeMessage mimeMessage = new();

            var message = es.CreateEmail(
            eventCreateVM.Title,
           @$"There is created new Event in EduHome.The event's name is {eventCreateVM.Title}.
            I'll star in {eventCreateVM.OpenTime} and will end in {eventCreateVM.CloseTime}.And this is image {eventCreateVM.Image}
           Thank you for attention"
           ,
             emails,
             eventCreateVM.Image.SaveImage("img/event", _webHostEnvironment)[1]
             );
            es.SendEmail(message);
            //-----------------------------------------------
            //-----------------------------------------------
            //-----------------------------------------------
            Event events = new();
            if (_context.Event.Any(s => s.Title == eventCreateVM.Title))
            {
                controller.ModelState.AddModelError("Title", "Bu adli evnet artiq var!");
                return controller.View();
            }
            events.Title = eventCreateVM.Title;
            events.Desc = eventCreateVM.Desc;
            events.OpenTime = eventCreateVM.OpenTime;
            events.CloseTime = eventCreateVM.CloseTime;
            events.Venue = eventCreateVM.Venue;
            events.CategoryId = id;
            if (eventCreateVM.Image.CheckSize(10000))
            {
                controller.ModelState.AddModelError("Image", "Sheklin olcusu cox boyukdur!");
                return controller.View();
            }
            if (!eventCreateVM.Image.CheckImage())
            {
                controller.ModelState.AddModelError("Image", "Yalniz shekil!");
                return controller.View();
            }
            events.ImgUrl = eventCreateVM.Image.SaveImage("img/event", _webHostEnvironment)[0];
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
            return controller.RedirectToAction("index", "event");
        }

        public ActionResult Delete(int? id,Controller controller)
        {
            if (id == null) return controller.NotFound();
            var events = _context.Event.FirstOrDefault(e => e.Id == id);
            if (events == null) return controller.NotFound();
            _context.Event.Remove(events);
            _context.SaveChanges();
            return controller.RedirectToAction("Index","event");
        }

        public ActionResult Update(EventUpdateVM eventUpdateVM, int id, int? categoryId, List<int>? speakerIds,Controller controller)
        {
            if (id == null) return controller.NotFound();
            var events = _context.Event.FirstOrDefault(e => e.Id == id);
            if(events == null) return controller.NotFound();
            if (!controller.ModelState.IsValid)
            {
                controller.ModelState.AddModelError("", "required!");
                return controller.View();
            }
            if (_context.Event.Any(s => s.Title == eventUpdateVM.Title && s.Id != id))
            {
                controller.ModelState.AddModelError("Title", "Bu adli evnet artiq var!");
                return controller.View();
            }
            events.Title = eventUpdateVM.Title;
            events.Desc = eventUpdateVM.Desc;
            events.OpenTime = eventUpdateVM.OpenTime;
            events.CloseTime = eventUpdateVM.CloseTime;
            events.Venue = eventUpdateVM.Venue;
            events.CategoryId = categoryId;
            if (eventUpdateVM.Image.CheckSize(10000))
            {
                controller.ModelState.AddModelError("Image", "Sheklin olcusu cox boyukdur!");
                return controller.View();
            }
            if (!eventUpdateVM.Image.CheckImage())
            {
                controller.ModelState.AddModelError("Image", "Yalniz shekil!");
                return controller.View();
            }
            events.ImgUrl = eventUpdateVM.Image.SaveImage("img/event", _webHostEnvironment)[0];
            _context.SaveChanges();
            var speakerEvent = _context.SpeakerEvent.Where(se => se.EventId == id).ToList();
            foreach (var speaker in speakerEvent)
            {
                _context.SpeakerEvent.Remove(speaker);
                _context.SaveChanges();
            }

            foreach (var speakerId in speakerIds)
            {
                SpeakerEvent newSpeakerEvent = new();

                newSpeakerEvent.EventId = id;
                newSpeakerEvent.SpeakerId = speakerId;
                _context.SpeakerEvent.Add(newSpeakerEvent);
                _context.SaveChanges();

            }
            return controller.RedirectToAction("index");
        }
    }
}
