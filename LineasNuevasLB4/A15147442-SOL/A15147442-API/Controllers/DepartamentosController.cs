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
    public class DepartamentosController : Controller
    {
        private LineaNuevaDbContext db = new LineaNuevaDbContext();

        // GET: Departamentos
        public ActionResult Index()
        {
            return View(db.Departamento.ToList());
        }

        // GET: Departamentos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departamento departamento = db.Departamento.Find(id);
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
                db.Departamento.Add(departamento);
                db.SaveChanges();
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
            Departamento departamento = db.Departamento.Find(id);
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
                db.Entry(departamento).State = EntityState.Modified;
                db.SaveChanges();
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
            Departamento departamento = db.Departamento.Find(id);
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
            Departamento departamento = db.Departamento.Find(id);
            db.Departamento.Remove(departamento);
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

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public ActionResult New()
        {
            var departamentoViewModel = new DepartamentoViewModel
            {
                Departamento = new Departamento()
            };

            return View(departamentoViewModel);
        }

        [HttpPost]

        public ActionResult SaveDepartamentos(Departamento departamento)
        {
            if (!ModelState.IsValid)
            {
                var departamentoVm = new DepartamentoViewModel()
                {
                    Departamento = departamento
                };

                return View("New", departamentoVm);
            }

            if (departamento.DepartamentoId == 0)
            {
                db.Departamento.Add(departamento);
            }
            else
            {
                var departamentoInBd = db.Departamento.Single(c => c.DepartamentoId == departamento.DepartamentoId);

                departamentoInBd.Descripcion = departamento.Descripcion;

            }

            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e.ToString());
            }

            return RedirectToAction("Index", "Departamentos");
        }


        public ActionResult EditNewDepartamentos(int id)
        {
            var departamentoToEdit = db.Departamento.SingleOrDefault(c => c.DepartamentoId == id);

            if (departamentoToEdit == null)
            {
                return HttpNotFound();
            }

            var departamentoViewModel = new DepartamentoViewModel
            {
                Departamento = departamentoToEdit
            };

            return View("New", departamentoViewModel);
        }
    }
}
