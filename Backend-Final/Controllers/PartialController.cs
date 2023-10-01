using Backend_Final.DAL;
using Backend_Final.Models;
using Backend_Final.ViewModels;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace Backend_Final.Controllers
{
    public class PartialController : Controller
    {
          private readonly AppDbContext _context;

        public PartialController(AppDbContext context)
        {
            _context = context;
        }
        #region Comment
        public IActionResult Comment()
        {
         
            return PartialView("_Comment");
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Comment(CommentVM commentVM)
        {
            var currentPage = Request.GetDisplayUrl;
            Comments comments = new Comments();
            comments.Name = commentVM.Name;
            comments.Email = commentVM.Email;
            comments.Subject = commentVM.Subject;
            comments.Message = commentVM.Message;
            _context.Comments.Add(comments);
            _context.SaveChanges();

            return Redirect(currentPage.ToString());
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
