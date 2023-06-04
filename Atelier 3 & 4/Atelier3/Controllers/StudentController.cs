using Atelier3.Models;
using Atelier3.Models.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting.Internal;

namespace Atelier3.Controllers
{
    public class StudentController : Controller
    {
        //injection de dépendance
        readonly IStudentRepository StudentRepository;
        readonly ISchoolRepository SchoolRepository;
        private readonly IWebHostEnvironment hostingEnvironment;
        public StudentController(IStudentRepository studentRepository, ISchoolRepository schoolRepository)
        {
            StudentRepository = studentRepository;
            SchoolRepository = schoolRepository;
        }
        // GET: StudentController
        public ActionResult Index()
        {
            var students = StudentRepository.GetAll();
            return View(students);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            var students = StudentRepository.GetById(id);
                return View(students);
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            ViewBag.SchoolID = new SelectList(SchoolRepository.GetAll(), "SchoolID","SchoolName");
            return View();
        }

        
        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateViewModel model,Student s)
        {
            try
            {
                ViewBag.SchoolID = new SelectList(SchoolRepository.GetAll(), "SchoolID", "SchoolName");
                StudentRepository.Add(s);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.SchoolID = new SelectList(SchoolRepository.GetAll(), "SchoolID", "SchoolName");
            var Students = StudentRepository.GetById(id);
            return View(Students);
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection,Student s)
        {
            try
            {
                ViewBag.SchoolID = new SelectList(SchoolRepository.GetAll(), "SchoolID", "SchoolName");
                StudentRepository.Edit(s);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            var students = StudentRepository.GetById(id);
            return View(students);
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection, Student s)
        {
            try
            {
                 StudentRepository.Delete(s);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
