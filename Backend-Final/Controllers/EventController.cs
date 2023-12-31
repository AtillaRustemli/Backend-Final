﻿using Backend_Final.DAL;
using Backend_Final.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend_Final.Controllers
{
    public class EventController : Controller
    {
        private readonly AppDbContext _context;

        public EventController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            EventVM vm = new();
            vm.Event = _context.Event.OrderByDescending(s=>s.Id).ToList();
            vm.Speaker = _context.Speakers.ToList();
            return View(vm);
        }
        public IActionResult Detail(int? id,string? search)
        {
            ViewBag.Categories=_context.Category.ToList();
            ViewBag.Events=_context.Event.ToList();
            ViewBag.Tags=_context.Tag.ToList();
            ViewBag.Posts=_context.Post.ToList();
            if (id == null) return NotFound();
            var events= _context.Event
                .Include(e=>e.SpeakerEvent)
                .ThenInclude(e=>e.Speaker)
                .Include(e=>e.Category)
                .Include(e=>e.Post)
                .Include(e=>e.Tag)
                .FirstOrDefault(e=>e.Id==id);
            if(events == null) return NotFound();
            return View(events);

         }
        public IActionResult Search(string? search)
        {
            var events = _context.Event
                    .Where(p => p.Title.ToLower().Contains(search.ToLower()))
                    .OrderByDescending(p => p.Id)
                    .Take(5)
                    .ToList();

            return PartialView("_Search", new SearchVM(null,events,null));
        }
    }

}
