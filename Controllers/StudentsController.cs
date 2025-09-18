using ASP.NETMVCSchool.DTOs;
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
            var allStudents = _service.GetAllStudents();
            return View(allStudents);
        }
        // akce Create pro zobrazení formuláře pro vytvoření nového studenta
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        // akce Create volaná formulářem pro vytvoření nového studenta
        [HttpPost]
        public IActionResult Create(StudentDTO student)
        {
            _service.CreateStudent(student);
            return RedirectToAction("Index");          
        }
        // akce Edit pro zobrazení detailu studenta
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var student = _service.GetStudentById(id);
            if (student == null) return NotFound();
            return View(student);
        }
        // akce Edit volaná formulářem pro úpravu studenta
        [HttpPost]
        public IActionResult Edit(int id, StudentDTO student)
        {
            _service.UpdateStudent(id, student);
            return RedirectToAction("Index");
        }
    }
}
