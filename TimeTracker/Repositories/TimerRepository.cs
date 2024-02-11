using Microsoft.AspNetCore.Identity;
using TimeTracker.Data;
using TimeTracker.Models;
using TimeTracker.Repositories.Interfaces;

namespace TimeTracker.Repositories
{
    public class TimerRepository : ITimerRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;
        public TimerRepository(ApplicationDbContext context,
            UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<User> SetBirthDate(string username,DateTime? birthDate)
        {
            var user = await _userManager.FindByEmailAsync(username);

            if (birthDate.HasValue)
            {
                user.BirthDate = birthDate.Value;
                await _context.SaveChangesAsync();
            }

            return user;
        }
    }
}
