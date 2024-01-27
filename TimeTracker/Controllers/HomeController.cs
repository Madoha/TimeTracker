using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TimeTracker.Repositories.Interfaces;

namespace TimeTracker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly INewsRepository _newsRepository;

        public HomeController(ILogger<HomeController> logger, INewsRepository newsRepository)
        {
            _logger = logger;
            _newsRepository = newsRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> News()
        {
            var listNews = await _newsRepository.GetOnlyActiveNewsAsync();

            return View(listNews);
        }
    }
}
