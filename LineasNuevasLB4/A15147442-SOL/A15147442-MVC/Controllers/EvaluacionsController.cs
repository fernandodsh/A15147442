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
    public class EvaluacionsController : Controller
    {
        private LineaNuevaDbContext db = new LineaNuevaDbContext();

        // GET: Evaluacions
        public ActionResult Index()
        {
            var evaluacion = db.Evaluacion.Include(e => e.Cliente).Include(e => e.EquipoDeCelular).Include(e => e.LineaTelefonica).Include(e => e.Plan);
            return View(evaluacion.ToList());
        }

        // GET: Evaluacions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evaluacion evaluacion = db.Evaluacion.Find(id);
            if (evaluacion == null)
            {
                return HttpNotFound();
            }
            return View(evaluacion);
        }

        // GET: Evaluacions/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(db.Cliente, "ClienteId", "Nombre");
            ViewBag.EquipoCelularId = new SelectList(db.EquipoDeCelular, "EquipoCelularId", "Nombre");
            ViewBag.LineaId = new SelectList(db.LineaTelefonica, "LineaId", "Descripcion");
            ViewBag.PlanId = new SelectList(db.Plan, "PlanId", "Descripcion");
            return View();
        }

        // POST: Evaluacions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EvaluacionId,Descricpion,EquipoCelularId,EstadoDeEvaluacion,TipoDeEvaluacion,PlanId,LineaId,ClienteId")] Evaluacion evaluacion)
        {
            if (ModelState.IsValid)
            {
                db.Evaluacion.Add(evaluacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(db.Cliente, "ClienteId", "Nombre", evaluacion.ClienteId);
            ViewBag.EquipoCelularId = new SelectList(db.EquipoDeCelular, "EquipoCelularId", "Nombre", evaluacion.EquipoCelularId);
            ViewBag.LineaId = new SelectList(db.LineaTelefonica, "LineaId", "Descripcion", evaluacion.LineaId);
            ViewBag.PlanId = new SelectList(db.Plan, "PlanId", "Descripcion", evaluacion.PlanId);
            return View(evaluacion);
        }

        // GET: Evaluacions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evaluacion evaluacion = db.Evaluacion.Find(id);
            if (evaluacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(db.Cliente, "ClienteId", "Nombre", evaluacion.ClienteId);
            ViewBag.EquipoCelularId = new SelectList(db.EquipoDeCelular, "EquipoCelularId", "Nombre", evaluacion.EquipoCelularId);
            ViewBag.LineaId = new SelectList(db.LineaTelefonica, "LineaId", "Descripcion", evaluacion.LineaId);
            ViewBag.PlanId = new SelectList(db.Plan, "PlanId", "Descripcion", evaluacion.PlanId);
            return View(evaluacion);
        }

        // POST: Evaluacions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EvaluacionId,Descricpion,EquipoCelularId,EstadoDeEvaluacion,TipoDeEvaluacion,PlanId,LineaId,ClienteId")] Evaluacion evaluacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(evaluacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(db.Cliente, "ClienteId", "Nombre", evaluacion.ClienteId);
            ViewBag.EquipoCelularId = new SelectList(db.EquipoDeCelular, "EquipoCelularId", "Nombre", evaluacion.EquipoCelularId);
            ViewBag.LineaId = new SelectList(db.LineaTelefonica, "LineaId", "Descripcion", evaluacion.LineaId);
            ViewBag.PlanId = new SelectList(db.Plan, "PlanId", "Descripcion", evaluacion.PlanId);
            return View(evaluacion);
        }

        // GET: Evaluacions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evaluacion evaluacion = db.Evaluacion.Find(id);
            if (evaluacion == null)
            {
                return HttpNotFound();
            }
            return View(evaluacion);
        }

        // POST: Evaluacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Evaluacion evaluacion = db.Evaluacion.Find(id);
            db.Evaluacion.Remove(evaluacion);
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
