﻿using Backend_Final.DAL;
using Backend_Final.Models;
using Backend_Final.ViewModels;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting.Internal;
using System.Linq;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Backend_Final.Controllers
{
    public class PartialController : Controller
    {
          private readonly AppDbContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;

        public PartialController(AppDbContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }
        #region Comment
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Comment(CommentVM commentVM,string currentUrl,string controllerName)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            Comments comments = new Comments();
            comments.Name = commentVM.Name;
            comments.Email = commentVM.Email;
            comments.Subject = commentVM.Subject;
            comments.Message = commentVM.Message;
            if (controllerName.ToLower() == "event")
            {
                comments.BlogComment = null;
                comments.CourseComment = null;
                comments.EventComment = "Event's comment";
            }
            else if (controllerName.ToLower() == "blog")
            {
                comments.EventComment = null;
                comments.CourseComment = null;
                comments.BlogComment = "Blog's comment";
            }
            else if (controllerName.ToLower() == "course")
            {
                comments.BlogComment = null;
                comments.EventComment = null;
                comments.CourseComment = "Course's comment";
            }
            _context.Comments.Add(comments);
            _context.SaveChanges();

            return Redirect(currentUrl);
        }
        #endregion

        #region Subscribe
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Subscribe(SubscribeVM subscribeVM,string currentUrl)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var subscribedEmails = _context.Subscribers.Any(s=>s.Email==subscribeVM.Email);
            if (subscribedEmails)
            {
                ModelState.AddModelError("Email", "Tekrar email!!");
                return Redirect(currentUrl);
            }
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Email", "Yalniz email!!");
                return Redirect(currentUrl);
            }
            Subscribers subscribers = new();
            subscribers.Email = subscribeVM.Email;
            _context.Subscribers.Add(subscribers);
            _context.SaveChanges();
            return Redirect(currentUrl);
        }
        #endregion
    }
}
