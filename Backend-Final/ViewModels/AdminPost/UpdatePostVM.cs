﻿namespace Backend_Final.ViewModels.AdminPost
{
    public class UpdatePostVM
    {
        public IFormFile Image { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Author { get; set; }
    }
}
