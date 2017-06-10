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
    public class DistritosController : Controller
    {
        private LineaNuevaDbContext db = new LineaNuevaDbContext();

        // GET: Distritos
        public ActionResult Index()
        {
            return View(db.Distrito.ToList());
        }

        // GET: Distritos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Distrito distrito = db.Distrito.Find(id);
            if (distrito == null)
            {
                return HttpNotFound();
            }
            return View(distrito);
        }

        // GET: Distritos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Distritos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DistritoId,Descripcion")] Distrito distrito)
        {
            if (ModelState.IsValid)
            {
                db.Distrito.Add(distrito);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(distrito);
        }

        // GET: Distritos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Distrito distrito = db.Distrito.Find(id);
            if (distrito == null)
            {
                return HttpNotFound();
            }
            return View(distrito);
        }

        // POST: Distritos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DistritoId,Descripcion")] Distrito distrito)
        {
            if (ModelState.IsValid)
            {
                db.Entry(distrito).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(distrito);
        }

        // GET: Distritos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Distrito distrito = db.Distrito.Find(id);
            if (distrito == null)
            {
                return HttpNotFound();
            }
            return View(distrito);
        }

        // POST: Distritos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Distrito distrito = db.Distrito.Find(id);
            db.Distrito.Remove(distrito);
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

        /////////////////////////////////////////////////////////////////////////////////////

        public ActionResult New()
        {
            var distritoViewModel = new DistritoViewModel()
            {
                Distrito = new Distrito()
            };

            return View(distritoViewModel);
        }

        [HttpPost]

        public ActionResult SaveDistritos(Distrito distrito)
        {
            if (!ModelState.IsValid)
            {
                var distritoVm = new DistritoViewModel()
                {
                    Distrito = distrito
                };

                return View("New", distritoVm);
            }

            if (distrito.DistritoId == 0)
            {
                db.Distrito.Add(distrito);
            }
            else
            {
                var distritoInBd = db.Distrito.Single(c => c.DistritoId == distrito.DistritoId);

                distritoInBd.Descripcion = distrito.Descripcion;
                

            }

            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e.ToString());
            }

            return RedirectToAction("Index", "Distritos");
        }


        public ActionResult EditNewDistritos(int id)
        {
            var distritoToEdit = db.Distrito.SingleOrDefault(c => c.DistritoId == id);

            if (distritoToEdit == null)
            {
                return HttpNotFound();
            }

            var distritoViewModel = new DistritoViewModel
            {
                Distrito = distritoToEdit
            };

            return View("New", distritoViewModel);
        }
    }
}
