using ASP.NETMVCSchool.DTOs;
using ASP.NETMVCSchool.Models;
using ASP.NETMVCSchool.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NETMVCSchool.Controllers
{
    public class SubjectsController : Controller
    {
        private SubjectsService _service;
        public SubjectsController(SubjectsService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            var allSubjects = _service.GetAllSubjects();
            return View(allSubjects);
        }
        // akce Create pro zobrazení formuláře pro vytvoření nového předmětu
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        // akce Create volaná formulářem pro vytvoření nového předmětu
        [HttpPost]
        public IActionResult Create(SubjectDTO subjectDTO)
        {
            _service.CreateSubject(subjectDTO);
            return RedirectToAction("Index");
        }
        // akce Delete pro smazání předmětu
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var subject = _service.FindSubjectById(id);
            if (subject == null)
            {
                return View("NotFound");
            }
            _service.DeleteSubject(id);
            return RedirectToAction("Index");
        }
        // akce Edit pro zobrazení detailu předmětu
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var subject = _service.FindSubjectById(id);
            if (subject == null) return NotFound();
            return View(subject);
        }
        // akce Edit volaná formulářem pro úpravu předmětu
        [HttpPost]
        public IActionResult Edit(int id, SubjectDTO subjectDTO)
        {
            var existingSubject = _service.FindSubjectById(id);
            if (existingSubject == null) return NotFound();
            _service.UpdateSubject(id, subjectDTO);
            return RedirectToAction("Index");
        }
    }
}
