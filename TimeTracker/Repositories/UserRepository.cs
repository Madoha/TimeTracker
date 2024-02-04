using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TimeTracker.Data;
using TimeTracker.Models;
using TimeTracker.Repositories.Interfaces;

namespace TimeTracker.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _context.Users.OrderByDescending(u => u.Created).ToListAsync();
        }

        public async Task BlockUserAsync(string id)
        {
            var user = await _context.Users.FirstAsync(u => u.Id == id);

            user.LockoutEnd = DateTime.UtcNow.AddYears(1000);
            await _context.SaveChangesAsync();
        }

        public async Task UnblockUserAsync(string id)
        {
            var user = await _context.Users.FirstAsync(u => u.Id == id);

            user.LockoutEnd = null;
            await _context.SaveChangesAsync();
        }
    }
}
