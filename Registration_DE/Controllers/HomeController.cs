using Microsoft.AspNetCore.Mvc;
using Registration_DE.Models;
using Registration_DE.Repository;
using System.Diagnostics;

namespace Registration_DE.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRegisterRepo _regService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IRegisterRepo register)
        {
            _regService = register;
            _logger = logger;
        }

        public IActionResult Index()
        {
            LoginData loginData = new LoginData();
            return View(loginData);
        }

        public IActionResult Login(LoginData loginData)
        {
            if (_regService.Login(loginData))
                return View("Main");
            else
            {
                loginData.Message = "User not found";
                return View("Index", loginData);
            }
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