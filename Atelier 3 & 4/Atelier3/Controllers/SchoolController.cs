using Atelier3.Models;
using Atelier3.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Atelier3.Controllers
{
    [Authorize]
    public class SchoolController : Controller
    {
        readonly IStudentRepository StudentRepository;
        readonly ISchoolRepository SchoolRepository;
        public SchoolController(IStudentRepository studentRepository, ISchoolRepository schoolRepository)
        {
            StudentRepository = studentRepository;
            SchoolRepository = schoolRepository;
        }
        // GET: SchoolController
        [AllowAnonymous]
        public ActionResult Index()
        {
            var schools = SchoolRepository.GetAll();
            return View(schools);
        }

        // GET: SchoolController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SchoolController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SchoolController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection, School s)
        {
            try
            {
                SchoolRepository.Add(s);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SchoolController/Edit/5
        public ActionResult Edit(int id)
        {
            var Schools = SchoolRepository.GetById(id);
            return View(Schools);
        }

        // POST: SchoolController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection, School s)
        {
            try
            {
                SchoolRepository.Edit(s);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SchoolController/Delete/5
        public ActionResult Delete(int id)
        {
            var Schools = SchoolRepository.GetById(id);
            return View(Schools);
        }

        // POST: SchoolController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection,School s)
        {
            try
            {
                SchoolRepository.Delete(s);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
