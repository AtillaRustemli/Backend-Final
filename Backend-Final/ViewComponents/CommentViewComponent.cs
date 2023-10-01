using Backend_Final.DAL;
using Backend_Final.Models;
using Backend_Final.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace Backend_Final.ViewComponents
{
    public class CommentViewComponent:ViewComponent
    {
        private readonly AppDbContext _context;

        public CommentViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
           var comments=_context.Comments.FirstOrDefault();
            ViewBag.Comments = _context.CommentTitle.FirstOrDefault();

            return View(await Task.FromResult(comments));
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IViewComponentResult> InvokeAsync(CommentVM commentVM)
        {
            Comments comments = new Comments();
            comments.Name = commentVM.Name;
            comments.Email = commentVM.Email;
            comments.Subject = commentVM.Subject;
            comments.Message = commentVM.Message;
            _context.Comments.Add(comments);
            _context.SaveChanges();

            return View(await Task.FromResult(comments));
        }
    }
}
