using Microsoft.Build.Framework.XamlTypes;
using StudentManagementSystem.Autharization;
using StudentManagementSystem.Models;
using StudentManagementSystem.Service.Services;
using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace StudentManagementSystem.Controllers
{
    [CustomAuthorize]
    public class HomeController : BaseController
    {
        private readonly HomeService _homeService;

        public HomeController(UnitOfWorkServices unitOfWorkServices)
        {
            _homeService = unitOfWorkServices.HomeService;
        }

        public ActionResult Index()
        {
            try
            {
                var studentsDto = _homeService.GetStudents();
                var studentModel = studentsDto.Select(StudentModel.ToModel).ToList();
                return View(studentModel);
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"There is an issue in {ex.Message}");
                return RedirectToAction("Error", "Home");
            }

        }

        #region Update
        public ActionResult GetStudentById(Guid? id)
        {
            try
            {
                var studentDTO = _homeService.GetStudentById(id);
                var studentModel = StudentModel.ToModel(studentDTO);
                return View(studentModel);

            }
            catch (Exception ex)
            {
                ShowErrorMessage($"There is an issue in {ex.Message}");
                return RedirectToAction("Error", "Home");
            }

        }

        [Route("Home/Update/{studentNumber}")]
        [ValidateAntiForgeryToken]
        public ActionResult Update(StudentModelUpdate studentModelUpdate)
        {
            try
            {
                CheckModelState();
                if (ModelState.IsValid)
                {
                    var studentExist = _homeService.GetStudentById(studentModelUpdate.StudentNumber);
                    if (studentExist is null)
                    {
                        return View(studentModelUpdate);
                    }
                    var studentDTO = StudentModelUpdate.Updated(studentExist, studentModelUpdate);
                    bool isUpdated = _homeService.UpdateStudent(studentDTO);
                    if (isUpdated)
                    {
                        ShowSuccessMessage("Student Data Updated Successfully");
                        return RedirectToAction(nameof(GetStudentById), new { id = studentModelUpdate.StudentNumber });
                    }
                    else
                    {
                        ShowErrorMessage("There is an issue");
                        return View(studentModelUpdate);
                    }
                }
                return RedirectToAction(nameof(GetStudentById), new { id = studentModelUpdate.StudentNumber });

            }
            catch (Exception ex)
            {
                ShowErrorMessage($"There is an issue in {ex.Message}");
                return RedirectToAction("Error", "Home");
            }


        }
        #endregion

        #region Create
        public ActionResult Create()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"There is an issue in {ex.Message}");
                return RedirectToAction("Error", "Home");
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentModelCreate studentModelCreate)
        {
            try
            {
            
                CheckModelState();

                if (ModelState.IsValid)
                {
                    if (studentModelCreate.Pic != null && studentModelCreate.Pic.ContentLength > 0)
                    {
                        string fileExtension = Path.GetExtension(studentModelCreate.Pic.FileName).ToLower();
                        string fileName = Guid.NewGuid().ToString() + fileExtension;

                        string uploadDirectory = Server.MapPath("~/Uploads/Images");
                        if (!Directory.Exists(uploadDirectory))
                        {
                            Directory.CreateDirectory(uploadDirectory);
                        }

                        // Full path to save the image
                        string filePath = Path.Combine(uploadDirectory, fileName);

       
                        studentModelCreate.Pic.SaveAs(filePath);

                        studentModelCreate.StudentPic = "/Uploads/Images/" + fileName;

                    }
                    var studentDTO = StudentModelCreate.ToDTO(studentModelCreate);
                    bool isCreated = _homeService.CraeteStudent(studentDTO);
                    if (isCreated)
                    {
                        ShowSuccessMessage("Student Data Created Successfully");
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ShowErrorMessage("There is an issue");
                        return View(studentDTO);
                    }
                }
                return View(studentModelCreate);

            }
            catch (Exception ex)
            {
                ShowErrorMessage($"There is an issue in {ex.Message}");
                return RedirectToAction("Error", "Home");
            }


        }
        #endregion

        #region Delete
        [Route("Home/Delete/{studentNumber}")]
        public ActionResult Delete(Guid id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var studentExist = _homeService.GetStudentById(id);
                    if (studentExist is null)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    studentExist.IsDeleted = true;
                    bool isDeleted = _homeService.Delete(studentExist);
                    if (isDeleted)
                    {
                        ShowSuccessMessage("Student is Deleted");
                        return RedirectToAction(nameof(Index));

                    }
                    else
                    {
                        ShowErrorMessage("There is an issue");
                        return RedirectToAction(nameof(Index));
                    }
                }
                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                ShowErrorMessage($"There is an issue in {ex.Message}");
                return RedirectToAction("Error", "Home");

            }


        }
        #endregion

        #region Error
        public ActionResult Error()
        {
            return View();
        }
        #endregion

        private void CheckModelState()
        {
            if (!ModelState.IsValid)
            {
                // Iterate over each ModelState entry (field)
                foreach (var item in ModelState)
                {
                    // Check if the field has any errors
                    if (item.Value.Errors.Count > 0)
                    {
                        // Iterate over each error associated with the field
                        foreach (var error in item.Value.Errors)
                        {
                            // Show each error message
                            ShowErrorMessage($"Error in {item.Key}: {error.ErrorMessage}");
                        }
                    }
                }
            }
        }
    }
}