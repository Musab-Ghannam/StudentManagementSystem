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
        public ActionResult Index()
        {
            var studentDTo = _homeService.GetStudents();
            var studentModel = studentDTo.Select(StudentModel.ToModel).ToList();
            return View(studentModel);
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