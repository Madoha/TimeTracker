using TimeTracker.Models;

namespace TimeTracker.DTOs
{
    public class NewsDto
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public bool IsActive { get; set; }
    }
}
