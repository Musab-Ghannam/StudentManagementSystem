using StudentManagementSystem.Models;
using StudentManagementSystem.Service.Services;
using System;
using System.Linq;
using System.Web.Mvc;

namespace StudentManagementSystem.Controllers
{
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
        public ActionResult Create(StudentModelCreate studentModelCraete)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var studentDTO = StudentModelCreate.ToDTO(studentModelCraete);
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
                return View(studentModelCraete);

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
    }
}