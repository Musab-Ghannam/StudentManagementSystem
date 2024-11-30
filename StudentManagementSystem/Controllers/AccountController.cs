using StudentManagementSystem.Models;
using StudentManagementSystem.Service.Services;
using System.Web.Mvc;

namespace StudentManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        private AccountService _service;

        public AccountController()
        {
            _service = new AccountService();
        }
        public ActionResult LogIn()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserModel userModel)
        {
            if (ModelState.IsValid)
            {
               var userEntity =  UserModel.ToDTO(userModel);
            
                return Json(new { success = true });
            }
            return Json(new { success = false, message = "Failed to create user." });
        }
    }
}
