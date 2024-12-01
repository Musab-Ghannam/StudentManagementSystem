using StudentManagementSystem.Models;
using StudentManagementSystem.Service.Services;
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
        public ActionResult Index(int page = 1, int pageSize = 5)
        {
            var studentsDto = _homeService.GetStudents(page, pageSize);
            var studentModel = studentsDto.Select(StudentModel.ToModel).ToList();
            return View(studentModel);
        }

        [HttpGet]
        public ActionResult GetStudents(int page = 1, int pageSize = 5)
        {
            var studentDTo = _homeService.GetStudents(page, pageSize);
            var paginatedStudents = studentDTo.ToList();
            var studentModel = paginatedStudents.Select(StudentModel.ToModel).ToList();
            return Json(new { students = paginatedStudents, total = studentDTo.Count() }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}