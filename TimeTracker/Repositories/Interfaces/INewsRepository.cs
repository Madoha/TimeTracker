using TimeTracker.Models.Entities;

namespace TimeTracker.Repositories.Interfaces
{
    public interface INewsRepository
    {
        Task<List<News>> GetNewsAsync();
    }
}
