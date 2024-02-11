using TimeTracker.Data;
using TimeTracker.Models;

namespace TimeTracker.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsersAsync();
        Task BlockUserAsync(string id);
        Task UnblockUserAsync(string id);

    }
}
