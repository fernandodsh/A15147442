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
    public class DepartamentosController : Controller
    {
        //private LineaNuevaDbContext db = new LineaNuevaDbContext();
        private readonly IUnityOfWork UnityOfWork;

        public DepartamentosController(IUnityOfWork unityOfWork)
        {
            UnityOfWork = unityOfWork;
        }

        public DepartamentosController()
        {

        }

        // GET: Departamentos
        public ActionResult Index()
        {
            //return View(db.Departamento.ToList());
            return View(UnityOfWork.Departamentos.GetAll());
        }

        // GET: Departamentos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Departamento departamento = db.Departamento.Find(id);
            Departamento departamento = UnityOfWork.Departamentos.Get(id);
            if (departamento == null)
            {
                return HttpNotFound();
            }
            return View(departamento);
        }

        // GET: Departamentos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Departamentos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DepartamentoId,Descripcion")] Departamento departamento)
        {
            if (ModelState.IsValid)
            {
                //db.Departamento.Add(departamento);
                UnityOfWork.Departamentos.Add(departamento);

                //db.SaveChanges();
                UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(departamento);
        }

        // GET: Departamentos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Departamento departamento = db.Departamento.Find(id);
            Departamento departamento = UnityOfWork.Departamentos.Get(id);
            if (departamento == null)
            {
                return HttpNotFound();
            }
            return View(departamento);
        }

        // POST: Departamentos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DepartamentoId,Descripcion")] Departamento departamento)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(departamento).State = EntityState.Modified;
                UnityOfWork.StateModified(departamento);

                //db.SaveChanges();
                UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(departamento);
        }

        // GET: Departamentos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Departamento departamento = db.Departamento.Find(id);
            Departamento departamento = UnityOfWork.Departamentos.Get(id);

            if (departamento == null)
            {
                return HttpNotFound();
            }
            return View(departamento);
        }

        // POST: Departamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Departamento departamento = db.Departamento.Find(id);
            Departamento departamento = UnityOfWork.Departamentos.Get(id);
            //db.Departamento.Remove(departamento);
            UnityOfWork.Departamentos.Delete(departamento);

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
