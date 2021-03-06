using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChatApp2Docs.Models
{
    public class Message
    {
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public DateTime Time { get; set; }
        [Required]
        [Column(Order=0)]
        public string SenderId { get; set; }
        public IdentityUser Sender { get; set; }
        [Required]
        [Column(Order = 1)]
        public string ReceiverId { get; set; }
        public IdentityUser Receiver { get; set; }
    }
}
