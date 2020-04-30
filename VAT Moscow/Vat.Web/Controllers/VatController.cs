using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VAT;

namespace Vat.Web.Controllers
{
    public class VatController : Controller
    {
        IVatService _vatService;
        public VatController(IVatService vatService)
        {
            _vatService = vatService;
        }
        //public VatController()
        //{
        //    var context = new VatContext();
        //    _vatService = new VatService(new UnityOfWork(context), new VatRepository(context));
        //}
        // GET: Vat
        public ActionResult Index()
        {
            return View(_vatService.GetAll());
        }

        // GET: Vat/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Vat/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vat/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Vat/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Vat/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Vat/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Vat/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
