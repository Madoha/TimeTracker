﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeTracker.Models.Entities
{
    public class News
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // auto-increment option
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public string AuthorId { get; set; }
        public User Author { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsActive { get; set; }
    }
}
