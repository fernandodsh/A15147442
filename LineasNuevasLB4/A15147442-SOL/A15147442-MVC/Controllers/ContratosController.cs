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
    public class ContratosController : Controller
    {
        //private LineaNuevaDbContext db = new LineaNuevaDbContext();
        private readonly IUnityOfWork UnityOfWork;

        public ContratosController(IUnityOfWork unityOfWork)
        {
            UnityOfWork = unityOfWork;
        }

        public ContratosController()
        {

        }

        // GET: Contratos
        public ActionResult Index()
        {
            //return View(db.Contrato.ToList());
            return View(UnityOfWork.Contratos.GetAll());
        }

        // GET: Contratos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Contrato contrato = db.Contrato.Find(id);
            Contrato contrato = UnityOfWork.Contratos.Get(id);
            if (contrato == null)
            {
                return HttpNotFound();
            }
            return View(contrato);
        }

        // GET: Contratos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contratos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ContratoId,NombreDeLaEmpresa,FechaInicial,FechaFin")] Contrato contrato)
        {
            if (ModelState.IsValid)
            {
                //db.Contrato.Add(contrato);
                UnityOfWork.Contratos.Add(contrato);

                //db.SaveChanges();
                UnityOfWork.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contrato);
        }

        // GET: Contratos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Contrato contrato = db.Contrato.Find(id);
            Contrato contrato = UnityOfWork.Contratos.Get(id);
            if (contrato == null)
            {
                return HttpNotFound();
            }
            return View(contrato);
        }

        // POST: Contratos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ContratoId,NombreDeLaEmpresa,FechaInicial,FechaFin")] Contrato contrato)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(contrato).State = EntityState.Modified;
                UnityOfWork.StateModified(contrato);

                //db.SaveChanges();
                UnityOfWork.SaveChanges();
                
                return RedirectToAction("Index");
            }
            return View(contrato);
        }

        // GET: Contratos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Contrato contrato = db.Contrato.Find(id);
            Contrato contrato = UnityOfWork.Contratos.Get(id);
            if (contrato == null)
            {
                return HttpNotFound();
            }
            return View(contrato);
        }

        // POST: Contratos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Contrato contrato = db.Contrato.Find(id);
            Contrato contrato = UnityOfWork.Contratos.Get(id);

            //db.Contrato.Remove(contrato);
            UnityOfWork.Contratos.Delete(contrato);

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
