using TimeTracker.Models.Enums.Finance;

namespace TimeTracker.Models.Entities
{
    public class Finance
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public Category Category { get; set; }
        public TransactionType TransactionType { get; set; }
        public User Author { get; set; }
        public string AuthorId { get; set; }
    }
}
