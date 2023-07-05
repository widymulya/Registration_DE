using Microsoft.AspNetCore.Mvc;
using Registration_DE.Models;
using Registration_DE.Repository;

namespace Registration_DE.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IRegisterRepo _regService;

        public RegisterController(IRegisterRepo regService)
        {
            _regService = regService;
        }

        public IActionResult Index()
        {
            Register register = new Register();
            return View(register);
        }

        public IActionResult Save(Register data)
        {
            if (ModelState.IsValid)
            {
                data.IsApproved = 0;
                _regService.SaveData(data);
            }

            var errors = ModelState.Values.SelectMany(v => v.Errors);
            ViewData["message"] = "";
            if (!errors.Any())
                ViewData["message"] = "Sign Up successfull!";
            else
                ViewData["message"] = "Error in Sign Up process!";

            return View("Index", data);
        }
    }
}
