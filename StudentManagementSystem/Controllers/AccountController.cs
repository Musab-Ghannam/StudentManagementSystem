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

        #region register
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
                    var userLog = UserModel.ToLogIn(userModel);
                    var isRegistered = _service.Register(userDTO);
                    if (isRegistered)
                    {
                        LogIn(userLog);
                        ShowSuccessMessage($"Register is Done Successfully, Welcom {userModel.UserName}");
                        return Json(new { success = true });
                    }
                    else
                    {
                        ShowErrorMessage("the user is already Registered");
                    }
                }
                return Json(new { success = false, message = "Failed to create user." });
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"There is an issue in {ex.Message}");
                return RedirectToAction("Error", "Home");
            }

        }

        #endregion

        [HttpPost]
        public ActionResult LogIn(UserLogIn userModel)
        {
            if (!ModelState.IsValid)
            {
                ShowErrorMessage("There is an issue with the entered data.");
                return View(userModel);
            }

            try
            {
                var authenticated = _service.LogIn(userModel.Email, userModel.Password);

                if (authenticated != null)
                {
                    Session["UserName"] = userModel.Email;
                    Session["UserId"] = authenticated.Id;
                    ShowSuccessMessage($"Login is successful, Welcome {userModel.Email.Split('@')[0]}");
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

        public ActionResult Logout()
        {
            try
            {

                Session.Remove("UserName");
                Session.Remove("UserId");

                return RedirectToAction("LogIn", "Account");
            }
            catch (Exception ex)
            {
                // Handle any errors that may occur during logout
                ShowErrorMessage($"An error occurred while logging out: {ex.Message}");
                return RedirectToAction("Error", "Home");  // Optionally redirect to an error page
            }
        }


    }
}
