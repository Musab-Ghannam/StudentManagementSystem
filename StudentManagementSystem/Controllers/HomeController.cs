using StudentManagementSystem.Models;
using StudentManagementSystem.Service.Services;
using System;
using System.Linq;
using System.Web.Mvc;

namespace StudentManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly HomeService _homeService;

        public HomeController(UnitOfWorkServices unitOfWorkServices)
        {
            _homeService = unitOfWorkServices.HomeService;
        }

        public ActionResult Index()
        {
            var studentsDto = _homeService.GetStudents();
            var studentModel = studentsDto.Select(StudentModel.ToModel).ToList();
            return View(studentModel);
        }

        #region Update
        public ActionResult GetStudentById(Guid? id)
        {
            var studentDTO = _homeService.GetStudentById(id);
            var studentModel = StudentModel.ToModel(studentDTO);
            return View(studentModel);
        }

        [Route("Home/Update/{studentNumber}")]
        [ValidateAntiForgeryToken]
        public ActionResult Update(StudentModelUpdate studentModelUpdate)
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
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(studentDTO);
                }
            }
            return View(studentModelUpdate);

        }
        #endregion


        #region Create
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentModelCreate studentModelCraete)
        {
            if (ModelState.IsValid)
            {

                var studentDTO = StudentModelCreate.ToDTO(studentModelCraete);
                bool isUpdated = _homeService.CraeteStudent(studentDTO);
                if (isUpdated)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(studentDTO);
                }
            }
            return View(studentModelCraete);

        }
        #endregion

        #region Delete
        [Route("Home/Delete/{studentNumber}")]
        public ActionResult Delete(Guid id)
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
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return RedirectToAction(nameof(Index));

        }
        #endregion
    }
}