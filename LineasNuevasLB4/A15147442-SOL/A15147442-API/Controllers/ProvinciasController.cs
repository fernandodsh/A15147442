using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using A15147442_ENT.Entities;
using A15147442_PER;
using A15147442_API.ViewModels;
using System.Data.Entity.Validation;

namespace A15147442_API.Controllers
{
    public class ProvinciasController : Controller
    {
        private LineaNuevaDbContext db = new LineaNuevaDbContext();

        // GET: Provincias
        public ActionResult Index()
        {
            return View(db.Provincia.ToList());
        }

        // GET: Provincias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Provincia provincia = db.Provincia.Find(id);
            if (provincia == null)
            {
                return HttpNotFound();
            }
            return View(provincia);
        }

        // GET: Provincias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Provincias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProvinciaId,Descripcion")] Provincia provincia)
        {
            if (ModelState.IsValid)
            {
                db.Provincia.Add(provincia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(provincia);
        }

        // GET: Provincias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Provincia provincia = db.Provincia.Find(id);
            if (provincia == null)
            {
                return HttpNotFound();
            }
            return View(provincia);
        }

        // POST: Provincias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProvinciaId,Descripcion")] Provincia provincia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(provincia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(provincia);
        }

        // GET: Provincias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Provincia provincia = db.Provincia.Find(id);
            if (provincia == null)
            {
                return HttpNotFound();
            }
            return View(provincia);
        }

        // POST: Provincias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Provincia provincia = db.Provincia.Find(id);
            db.Provincia.Remove(provincia);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
//////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public ActionResult New()
        {
            var provinciaViewModel = new ProvinciaViewModel
            {
                Provincia = new Provincia()
            };

            return View(provinciaViewModel);
        }

        [HttpPost]

        public ActionResult SaveProvincias(Provincia provincia)
        {
            if (!ModelState.IsValid)
            {
                var provinciaVm = new ProvinciaViewModel()
                {
                    Provincia = provincia
                };

                return View("New", provinciaVm);
            }

            if (provincia.ProvinciaId == 0)
            {
                db.Provincia.Add(provincia);
            }
            else
            {
                var provinciaInBd = db.Provincia.Single(c => c.ProvinciaId == provincia.ProvinciaId);

                provinciaInBd.Descripcion = provincia.Descripcion;

            }

            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e.ToString());
            }

            return RedirectToAction("Index", "Provincias");
        }


        public ActionResult EditNewProvincias(int id)
        {
            var provinciaToEdit = db.Provincia.SingleOrDefault(c => c.ProvinciaId == id);

            if (provinciaToEdit == null)
            {
                return HttpNotFound();
            }

            var provinciaViewModel = new ProvinciaViewModel
            {
                Provincia = provinciaToEdit
            };

            return View("New", provinciaViewModel);
        }
    }
}
