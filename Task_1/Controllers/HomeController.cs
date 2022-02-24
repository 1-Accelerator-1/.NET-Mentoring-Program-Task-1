using ClassLibrary;
using Microsoft.AspNetCore.Mvc;
using System;
using Task_1.ViewModels;

namespace Task_1.Controllers
{
    public class HomeController : Controller
    {
        private IStringService _stringService;

        public HomeController(IStringService stringService)
        {
            _stringService = stringService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new UserViewModel());
        }

        [HttpPost]
        public IActionResult EnterUsername(UserViewModel userViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", userViewModel);
            }

            try
            {
                userViewModel.Greetings = _stringService.GetFormattedString(userViewModel.Username);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return View("Index", userViewModel);
        }
    }
}
