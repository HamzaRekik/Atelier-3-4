using Atelier3.Models;
using Atelier3.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Atelier3.Controllers
{
    public class SchoolController : Controller
    {
        //injection de dependance
        readonly ISchoolRepository SchoolRepository;
        public SchoolController(ISchoolRepository schoolRepository)
        {
            SchoolRepository = schoolRepository;
        }

    
        // GET: SchoolController
        public ActionResult Index()
        {
            var Schools = SchoolRepository.GetAll();
            return View(Schools);
        }

        // GET: SchoolController/Details/5
        public ActionResult Details(int id)
        {
            var School = SchoolRepository.GetById(id);
            return View(School);
        }

        // GET: SchoolController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SchoolController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(School s)
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
            var School = SchoolRepository.GetById(id);

            return View(School);
        }

        // POST: SchoolController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(School s, IFormCollection collection)
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
            var School = SchoolRepository.GetById(id);
            return View(School);
        }

        // POST: SchoolController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(School s, IFormCollection collection)
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
