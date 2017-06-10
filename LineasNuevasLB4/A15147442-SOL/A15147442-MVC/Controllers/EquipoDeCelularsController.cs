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

namespace A15147442_MVC.Controllers
{
    public class EquipoDeCelularsController : Controller
    {
        private LineaNuevaDbContext db = new LineaNuevaDbContext();

        // GET: EquipoDeCelulars
        public ActionResult Index()
        {
            return View(db.EquipoDeCelular.ToList());
        }

        // GET: EquipoDeCelulars/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipoDeCelular equipoDeCelular = db.EquipoDeCelular.Find(id);
            if (equipoDeCelular == null)
            {
                return HttpNotFound();
            }
            return View(equipoDeCelular);
        }

        // GET: EquipoDeCelulars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EquipoDeCelulars/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EquipoCelularId,Nombre,Marca")] EquipoDeCelular equipoDeCelular)
        {
            if (ModelState.IsValid)
            {
                db.EquipoDeCelular.Add(equipoDeCelular);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(equipoDeCelular);
        }

        // GET: EquipoDeCelulars/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipoDeCelular equipoDeCelular = db.EquipoDeCelular.Find(id);
            if (equipoDeCelular == null)
            {
                return HttpNotFound();
            }
            return View(equipoDeCelular);
        }

        // POST: EquipoDeCelulars/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EquipoCelularId,Nombre,Marca")] EquipoDeCelular equipoDeCelular)
        {
            if (ModelState.IsValid)
            {
                db.Entry(equipoDeCelular).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(equipoDeCelular);
        }

        // GET: EquipoDeCelulars/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipoDeCelular equipoDeCelular = db.EquipoDeCelular.Find(id);
            if (equipoDeCelular == null)
            {
                return HttpNotFound();
            }
            return View(equipoDeCelular);
        }

        // POST: EquipoDeCelulars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EquipoDeCelular equipoDeCelular = db.EquipoDeCelular.Find(id);
            db.EquipoDeCelular.Remove(equipoDeCelular);
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
    }
}
