using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeTracker.Data;
using TimeTracker.Models.Entities;
using TimeTracker.Repositories.Interfaces;

namespace TimeTracker.Repositories
{
    public class NewsRepository : INewsRepository
    {
        private readonly ApplicationDbContext _context;
        public NewsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<News>> GetNewsAsync()
        {
            return await _context.News.AsNoTracking().ToListAsync();
        }

        public async Task<List<News>> GetOnlyActiveNewsAsync()
        {
            return await _context.News.Where(n => n.IsActive).AsNoTracking().ToListAsync();
        }

        public async Task<News> CreateNewsAsync(News news)
        {
            await _context.News.AddAsync(news);
            await _context.SaveChangesAsync();

            return news;
        }
    }
}
