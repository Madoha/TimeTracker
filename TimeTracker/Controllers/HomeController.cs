using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using TimeTracker.Models;
using TimeTracker.Repositories.Interfaces;

namespace TimeTracker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly INewsRepository _newsRepository;
        private readonly ITimerRepository _timerRepository;

        public HomeController(ILogger<HomeController> logger, INewsRepository newsRepository, ITimerRepository timerRepository)
        {
            _logger = logger;
            _newsRepository = newsRepository;
            _timerRepository = timerRepository;
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

        [HttpGet("/home/timer/motivate")]
        [Authorize]
        public async Task<IActionResult> Timer()
        {
            var username = User.Claims.SingleOrDefault(x => x.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name")).Value;
            var user = await _timerRepository.SetBirthDate(username, null);
            return View(user);
        }

        [HttpPost("/home/timer/motivate")]
        [Authorize]
        public async Task<IActionResult> Timer(DateTime date)
        {

            var username = User.Claims.SingleOrDefault(x => x.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name")).Value;

            var result = await _timerRepository.SetBirthDate(username, date);
            return View(result);
        }
    }
}
