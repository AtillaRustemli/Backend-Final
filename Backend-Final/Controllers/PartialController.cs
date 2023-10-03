using Backend_Final.DAL;
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
        public async Task<IActionResult> Comment(CommentVM commentVM)
        {
            string rootPath = _hostingEnvironment.ContentRootPath;
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Bosh qoymayin!");
            }
            Comments comments = new Comments();
            comments.Name = commentVM.Name;
            comments.Email = commentVM.Email;
            comments.Subject = commentVM.Subject;
            comments.Message = commentVM.Message;
            _context.Comments.Add(comments);
            _context.SaveChanges();

            return Redirect(rootPath);
        }
        #endregion

        #region Subscribe
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Subscribe(SubscribeVM subscribeVM,string currentUrl)
        {
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
