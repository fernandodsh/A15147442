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
    public class CentroDeAtencionController : Controller
    {
        //private LineaNuevaDbContext db = new LineaNuevaDbContext();
        private readonly IUnityOfWork UnityOfWork;

        public CentroDeAtencionController(IUnityOfWork unityOfWork)
        {
            UnityOfWork = unityOfWork;
        }

        public CentroDeAtencionController()
        {

        }

        // GET: CentroDeAtencion
        public ActionResult Index()
        {
            //return View(db.CentroDeAtencion.ToList());
            return View(UnityOfWork.CentroDeAtenciones.GetAll());

        }

        // GET: CentroDeAtencion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //CentroDeAtencion centroDeAtencion = db.CentroDeAtencion.Find(id);
            CentroDeAtencion centroDeAtencion = UnityOfWork.CentroDeAtenciones.Get(id);
            if (centroDeAtencion == null)
            {
                return HttpNotFound();
            }
            return View(centroDeAtencion);
        }

        // GET: CentroDeAtencion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CentroDeAtencion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CentroId,Centro")] CentroDeAtencion centroDeAtencion)
        {
            if (ModelState.IsValid)
            {
                //db.CentroDeAtencion.Add(centroDeAtencion);
                UnityOfWork.CentroDeAtenciones.Add(centroDeAtencion);

                //db.SaveChanges();
                UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(centroDeAtencion);
        }

        // GET: CentroDeAtencion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //CentroDeAtencion centroDeAtencion = db.CentroDeAtencion.Find(id);
            CentroDeAtencion centroDeAtencion = UnityOfWork.CentroDeAtenciones.Get(id);
            if (centroDeAtencion == null)
            {
                return HttpNotFound();
            }
            return View(centroDeAtencion);
        }

        // POST: CentroDeAtencion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CentroId,Centro")] CentroDeAtencion centroDeAtencion)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(centroDeAtencion).State = EntityState.Modified;
                UnityOfWork.StateModified(centroDeAtencion);

                //db.SaveChanges();
                UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(centroDeAtencion);
        }

        // GET: CentroDeAtencion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //CentroDeAtencion centroDeAtencion = db.CentroDeAtencion.Find(id);
            CentroDeAtencion centroDeAtencion = UnityOfWork.CentroDeAtenciones.Get(id);
            if (centroDeAtencion == null)
            {
                return HttpNotFound();
            }
            return View(centroDeAtencion);
        }

        // POST: CentroDeAtencion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //CentroDeAtencion centroDeAtencion = db.CentroDeAtencion.Find(id);
            CentroDeAtencion centroDeAtencion = UnityOfWork.CentroDeAtenciones.Get(id);

            //db.CentroDeAtencion.Remove(centroDeAtencion);
            UnityOfWork.CentroDeAtenciones.Delete(centroDeAtencion);

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
