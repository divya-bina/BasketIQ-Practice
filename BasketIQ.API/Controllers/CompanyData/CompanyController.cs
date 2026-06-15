using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasketIQ.API.Controllers.CompanyData
{
    public class CompanyController : Controller
    {



        // GET: CompanyDataController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CompanyDataController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CompanyDataController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CompanyDataController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CompanyDataController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CompanyDataController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CompanyDataController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CompanyDataController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
