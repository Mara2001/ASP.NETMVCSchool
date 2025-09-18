using ASP.NETMVCSchool.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NETMVCSchool.Controllers
{
    public class StudentsController : Controller
    {
        private StudentService _service;

        public StudentsController(StudentService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
