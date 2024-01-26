using TimeTracker.Models.Entities;

namespace TimeTracker.Repositories.Interfaces
{
    public interface INewsRepository
    {
        Task<List<News>> GetNewsAsync();
        Task<List<News>> GetOnlyActiveNewsAsync();
        Task<News> CreateNewsAsync(News news);
    }
}
