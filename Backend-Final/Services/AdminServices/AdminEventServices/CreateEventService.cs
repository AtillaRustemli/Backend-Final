﻿using Backend_Final.DAL;
using Backend_Final.Extensions;
using Backend_Final.Models;
using Backend_Final.Models.Emails;
using Backend_Final.ViewModels.AdminEvent;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MimeKit;

namespace Backend_Final.Services.AdminServices.AdminEventServices
{
    public class CreateEventService
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly EmailConfig _emailServices;
        private ModelStateDictionary _modelState;

        public void AddModelError(string key, string errorMessage)
        {
            _modelState.AddModelError(key, errorMessage);
        }


        public CreateEventService(AppDbContext context, IWebHostEnvironment webHostEnvironment, EmailConfig emailServices, ModelStateDictionary modelState)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _emailServices = emailServices;
            _modelState = modelState;
        }
        public ActionResult Create(EventCreateVM eventCreateVM, int? id, List<int>? speakerIds,Controller controller)
        {

            if (!_modelState.IsValid)
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
            I'll star in {eventCreateVM.OpenTime} and will end in {eventCreateVM.CloseTime}.
           Thank you for attention"
           ,
             emails);
            es.SendEmail(message);
            //-----------------------------------------------
            //-----------------------------------------------
            //-----------------------------------------------
            Event events = new();
            if (_context.Event.Any(s => s.Title == eventCreateVM.Title))
            {
                _modelState.AddModelError("Title", "Bu adli evnet artiq var!");
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
                _modelState.AddModelError("Image", "Sheklin olcusu cox boyukdur!");
                return controller.View();
            }
            if (!eventCreateVM.Image.CheckImage())
            {
                _modelState.AddModelError("Image", "Yalniz shekil!");
                return controller.View();
            }
            events.ImgUrl = eventCreateVM.Image.SaveImage("img/event", _webHostEnvironment);
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
    }
}
