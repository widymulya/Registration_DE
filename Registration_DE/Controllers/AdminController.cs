using Microsoft.AspNetCore.Mvc;
using Registration_DE.Models;
using Registration_DE.Repository;

namespace Registration_DE.Controllers
{
    public class AdminController : Controller
    {
        private readonly IRegisterRepo _regService;

        public AdminController(IRegisterRepo regService)
        {
            _regService = regService;
        }

        public IActionResult Index()
        {           
            RegisterVM registerVM = new RegisterVM {
                ListRegister = _regService.GetRegister()
            };

            return View(registerVM);
        }

        public IActionResult Approve(int Id)
        {
            var data = _regService.GetRegister().FirstOrDefault(a => a.ID == Id);

            if (data != null)
            {
                Authorize(data, 1);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Reject(int Id)
        {
            var data = _regService.GetRegister().FirstOrDefault(a => a.ID == Id);

            if (data != null)
            {
               Authorize(data, 2);
            }

            return RedirectToAction("Index");
        }

        private void Authorize(Register data, int status)
        {
            data.IsApproved = status;
            _regService.UpdateData(data);
        }

    }
}
