using TimeTracker.Models;

namespace TimeTracker.Repositories.Interfaces
{
    public interface ITimerRepository
    {
        Task<User> SetBirthDate(string username, DateTime? brithDate);
    }
}
