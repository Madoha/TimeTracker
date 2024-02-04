using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;
using System.Security.Claims;
using TimeTracker.DTOs;
using TimeTracker.Models.Entities;
using TimeTracker.Repositories.Interfaces;

namespace TimeTracker.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly INewsRepository _newsRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        public AdminController(INewsRepository newsRepository, 
            IMapper mapper,
            IUserRepository userRepository)
        {
            _newsRepository = newsRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }
        // GET: AdminController
        public ActionResult Index()
        {
            bool isAdmin = User.IsInRole("Admin");

            return View();
        }

        [HttpGet("/admin/users")]
        public async Task<IActionResult> Users()
        {
            var users = await _userRepository.GetUsersAsync();

            return View(users);
        }

        public async Task<ActionResult> News()
        {
            var listNews = await _newsRepository.GetNewsAsync();

            return View(listNews);
        }

        [Route("/admin/news/createNews")]
        [HttpGet]
        public async Task<IActionResult> CreateNews()
        {
            return View();
        }

        [HttpPost("/admin/news/createNews")]
        public async Task<IActionResult> Create(NewsDto newsDto)
        {
            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState);

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!string.IsNullOrEmpty(userId))
            {
                var news = _mapper.Map<News>(newsDto);
                news.AuthorId = userId;
                news.Date = DateTime.SpecifyKind(news.Date, DateTimeKind.Utc);

                var result = await _newsRepository.CreateNewsAsync(news);
            }

            return Redirect("/admin/news");
        }

        [HttpGet("/admin/news/edit/{id}")]
        public async Task<IActionResult> EditNews(int id)
        {
            var news = await _newsRepository.GetNewsByIdAsync(id);

            return View(news);
        }

        [HttpPost("/admin/news/edit/{id}")]
        public async Task<IActionResult> Edit(News news)
        {
            news.Date = DateTime.SpecifyKind(news.Date, DateTimeKind.Utc);

            await _newsRepository.UpdateNewsAsync(news);

            return Redirect("/admin/news");
        }

        [HttpGet("/admin/news/delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _newsRepository.DeleteNewsAsync(id);
            return Redirect("/admin/news");
        }

        [HttpGet("/admin/users/block/{id}")]
        public async Task<IActionResult> BlockUser(string id)
        {
            await _userRepository.BlockUserAsync(id);

            return Redirect("/admin/users");
        }

        [HttpGet("/admin/users/unblock/{id}")]
        public async Task<IActionResult> UnblockUser(string id)
        {
            await _userRepository.UnblockUserAsync(id);

            return Redirect("/admin/users");
        }
        //// GET: AdminController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: AdminController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: AdminController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: AdminController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: AdminController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: AdminController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: AdminController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
