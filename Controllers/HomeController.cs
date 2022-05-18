using ChatApp2Docs.Data;
using ChatApp2Docs.Models;
using ChatApp2Docs.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApp2Docs.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IChattingService _chattingService;
        public HomeController(ILogger<HomeController> logger, IChattingService chattingService)
        {
            _logger = logger;
            _chattingService = chattingService;
        }

        [Authorize]
        public IActionResult Index()
        {
            ViewBag.UserList = _chattingService.getUsersList();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
