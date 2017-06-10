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
    public class TrabajadorsController : Controller
    {
        //private LineaNuevaDbContext db = new LineaNuevaDbContext();
        private readonly IUnityOfWork UnityOfWork;

        public TrabajadorsController(IUnityOfWork unityOfWork)
        {
            UnityOfWork = unityOfWork;
        }

        public TrabajadorsController()
        {

        }

        // GET: Trabajadors
        public ActionResult Index()
        {
            //return View(db.Trabajador.ToList());
            return View(UnityOfWork.Trabajadores.GetAll());
        }

        // GET: Trabajadors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Trabajador trabajador = db.Trabajador.Find(id);
            Trabajador trabajador = UnityOfWork.Trabajadores.Get(id);
            if (trabajador == null)
            {
                return HttpNotFound();
            }
            return View(trabajador);
        }

        // GET: Trabajadors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Trabajadors/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TrabajadorId,Nombre,Apellido,DNI,FechaInicioContrato,TipoTrabajador")] Trabajador trabajador)
        {
            if (ModelState.IsValid)
            {
                //db.Trabajador.Add(trabajador);
                UnityOfWork.Trabajadores.Add(trabajador);

                //db.SaveChanges();
                UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trabajador);
        }

        // GET: Trabajadors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Trabajador trabajador = db.Trabajador.Find(id);
            Trabajador trabajador = UnityOfWork.Trabajadores.Get(id);
            if (trabajador == null)
            {
                return HttpNotFound();
            }
            return View(trabajador);
        }

        // POST: Trabajadors/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TrabajadorId,Nombre,Apellido,DNI,FechaInicioContrato,TipoTrabajador")] Trabajador trabajador)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(trabajador).State = EntityState.Modified;
                UnityOfWork.StateModified(trabajador);

                //db.SaveChanges();
                UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trabajador);
        }

        // GET: Trabajadors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Trabajador trabajador = db.Trabajador.Find(id);
            Trabajador trabajador = UnityOfWork.Trabajadores.Get(id);
            if (trabajador == null)
            {
                return HttpNotFound();
            }
            return View(trabajador);
        }

        // POST: Trabajadors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Trabajador trabajador = db.Trabajador.Find(id);
            Trabajador trabajador = UnityOfWork.Trabajadores.Get(id);

            //db.Trabajador.Remove(trabajador);
            UnityOfWork.Trabajadores.Delete(trabajador);
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
