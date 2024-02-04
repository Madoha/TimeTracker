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

        public async Task<News> GetNewsByIdAsync(int id)
        {
            return await _context.News.Where(n => n.Id == id).FirstOrDefaultAsync();
        }

        public async Task<News> UpdateNewsAsync(News news)
        {
            await _context.News
                .Where(n => n.Id == news.Id)
                .ExecuteUpdateAsync(p => p
                    .SetProperty(d => d.Title, news.Title)
                    .SetProperty(d => d.Text, news.Text)
                    .SetProperty(d => d.IsActive, news.IsActive)
                    .SetProperty(d => d.Date, news.Date));

            return news;
        }

        public async Task DeleteNewsAsync(int id)
        {
            await _context.News.Where(n => n.Id == id).ExecuteDeleteAsync();
        }
    }
}
