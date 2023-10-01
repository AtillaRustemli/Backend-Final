using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;

namespace Backend_Final.ViewModels
{
    public class SubscribeVM
    {
    
        [Required,DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
