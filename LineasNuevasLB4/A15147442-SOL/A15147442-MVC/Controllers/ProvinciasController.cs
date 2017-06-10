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
using A15147442_ENT.IRepositories;

namespace A15147442_MVC.Controllers
{
    public class ProvinciasController : Controller
    {
        //private LineaNuevaDbContext db = new LineaNuevaDbContext();
        private readonly IUnityOfWork UnityOfWork;

        public ProvinciasController(IUnityOfWork unityOfWork)
        {
            UnityOfWork = unityOfWork;
        }

        public ProvinciasController()
        {

        }

        // GET: Provincias
        public ActionResult Index()
        {
            //return View(db.Provincia.ToList());
            return View(UnityOfWork.Provincias.GetAll());
        }

        // GET: Provincias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Provincia provincia = db.Provincia.Find(id);
            Provincia provincia = UnityOfWork.Provincias.Get(id);
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
                //db.Provincia.Add(provincia);
                UnityOfWork.Provincias.Add(provincia);

                //db.SaveChanges();
                UnityOfWork.SaveChanges();
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
            //Provincia provincia = db.Provincia.Find(id);
            Provincia provincia = UnityOfWork.Provincias.Get(id);
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
                //db.Entry(provincia).State = EntityState.Modified;
                UnityOfWork.StateModified(provincia);

                //db.SaveChanges();
                UnityOfWork.SaveChanges();
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
            //Provincia provincia = db.Provincia.Find(id);
            Provincia provincia = UnityOfWork.Provincias.Get(id);
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
            //Provincia provincia = db.Provincia.Find(id);
            Provincia provincia = UnityOfWork.Provincias.Get(id);

            //db.Provincia.Remove(provincia);
            UnityOfWork.Provincias.Delete(provincia);

            //db.SaveChanges();
            UnityOfWork.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
                UnityOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
