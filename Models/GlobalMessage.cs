using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace ChatApp2Docs.Models
{
    public class GlobalMessage
    {
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public DateTime Time { get; set; }
        [Required]
        public string SenderId { get; set; }
        public IdentityUser Sender { get; set; }
    }
}
