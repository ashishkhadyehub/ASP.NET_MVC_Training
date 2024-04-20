using Microsoft.AspNetCore.Mvc;
using Training.Models;
using Training.Repositories.Implementations;
using Training.Repositories.Interfaces;

namespace Training.UI.Controllers
{
    public class StudentController : Controller
    {
        private readonly IGenericRepo<Student> _studentRepository;

        public StudentController(IGenericRepo<Student> studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<IActionResult> Index()
        {
            var students = await _studentRepository.GetAll();
            return View(students);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            await _studentRepository.Save(student);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var student = await _studentRepository.GetById(id);
            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Student student)
        {
            await _studentRepository.Edit(student);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(Student student)
        {
            await _studentRepository.RemoveData(student);
            return RedirectToAction("Index");
        }
    }
}
