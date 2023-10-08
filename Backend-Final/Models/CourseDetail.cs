﻿namespace Backend_Final.Models
{
    public class CourseDetail
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CourseId { get; set; }
        public Course? Course { get; set; }
    }
}
