using StudentManagementSystem.Models;
using StudentManagementSystem.Service.DTO;
using StudentManagementSystem.Service.Services;
using System;
using System.Web.Mvc;

namespace StudentManagementSystem.Controllers
{
    public class AccountController : BaseController
    {
        private AccountService _service;

        public AccountController(UnitOfWorkServices unitOfWorkServices)
        {
            _service = unitOfWorkServices.AccountService;
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
            try
            {
                if (ModelState.IsValid)
                {
                    var userDTO = UserModel.ToDTO(userModel);
                    var isRegistered = _service.Register(userDTO);
                    ShowSuccessMessage($"Register is Done Successfully, Welcom {userModel.UserName}");
                    return Json(new { success = true });
                }
                return Json(new { success = false, message = "Failed to create user." });
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"There is an issue in {ex.Message}");
                return RedirectToAction("Error", "Home");
            }

        }

        [HttpPost]
        public ActionResult LogIn(UserModel userModel)
        {
            if (!ModelState.IsValid)
            {
                ShowErrorMessage("There is an issue with the entered data.");
                return View(userModel);
            }

            try
            {
                var isAuthenticated = _service.LogIn(userModel.UserName, userModel.Password);

                if (isAuthenticated)
                {
                    ShowSuccessMessage($"Login is successful, Welcome {userModel.UserName.Split('@')[0]}");
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ShowErrorMessage("Invalid username or password.");
                    return View(userModel);
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"There was an issue: {ex.Message}");
                return RedirectToAction("Error", "Home");
            }
        }


    }
}
