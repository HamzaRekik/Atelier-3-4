using Atelier3.Models;
using Atelier3.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Atelier3.Controllers
{
    public class StudentController : Controller
    {
        // Injection des dépendances par le constructeur
        readonly IStudentRepository StudentRepository;
        readonly ISchoolRepository SchoolRepository;
        public StudentController(IStudentRepository StudentRepository, ISchoolRepository schoolrepository)
        {
            this.StudentRepository = StudentRepository;
            this.SchoolRepository = schoolrepository;
        }
        public ActionResult Index()
        {
            ViewBag.SchoolID = new SelectList(SchoolRepository.GetAll(), "SchoolID", "SchoolName");
            return View(StudentRepository.GetAll());
        }
        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            return View(StudentRepository.GetById(id));
        }
        // GET: StudentController/Create
        public ActionResult Create()
        {
            ViewBag.SchoolID = new SelectList(SchoolRepository.GetAll(), "SchoolID", "SchoolName");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student s)
        {
            try
            {
                ViewBag.SchoolID = new SelectList(SchoolRepository.GetAll(), "SchoolID", "SchoolName", s.SchoolID);
                StudentRepository.Add(s);
                ViewBag.SchoolID = new SelectList(SchoolRepository.GetAll(), "SchoolID", "SchoolName");
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
            var s = StudentRepository.GetById(id);
            ViewBag.SchoolID = new SelectList(SchoolRepository.GetAll(), "SchoolID", "SchoolName");

            return View(s);
        }
        [HttpPost]
        // POST: EmployeeController/Edit/5
        public ActionResult Edit(Student std)
        {
            try
            {
                ViewBag.SchoolID = new SelectList(SchoolRepository.GetAll(), "SchoolID", "SchoolName", std.SchoolID);
                StudentRepository.Edit(std);
                ViewBag.SchoolID = new SelectList(SchoolRepository.GetAll(), "SchoolID", "SchoolName");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Search(string name, int? schoolid)
        {
            var result = StudentRepository.GetAll();
            if (!string.IsNullOrEmpty(name))
                result = StudentRepository.FindByName(name);
            else
            if (schoolid != null)
                result = StudentRepository.GetStudentsBySchoolID(schoolid);
            ViewBag.SchoolID = new SelectList(SchoolRepository.GetAll(), "SchoolID", "SchoolName");
            return View("Index", result);
        }



        public ActionResult Delete(int id)
        {
            var Student = StudentRepository.GetById(id);
            return View(Student);
        }
        [HttpPost]
        public ActionResult Delete(Student s)
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
