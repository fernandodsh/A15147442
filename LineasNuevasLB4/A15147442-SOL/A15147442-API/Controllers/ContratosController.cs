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
    public class ContratosController : Controller
    {
        private LineaNuevaDbContext db = new LineaNuevaDbContext();

        // GET: Contratos
        public ActionResult Index()
        {
            return View(db.Contrato.ToList());
        }

        // GET: Contratos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contrato contrato = db.Contrato.Find(id);
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
                db.Contrato.Add(contrato);
                db.SaveChanges();
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
            Contrato contrato = db.Contrato.Find(id);
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
                db.Entry(contrato).State = EntityState.Modified;
                db.SaveChanges();
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
            Contrato contrato = db.Contrato.Find(id);
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
            Contrato contrato = db.Contrato.Find(id);
            db.Contrato.Remove(contrato);
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
            var contratoViewModel = new ContratoViewModel
            {
                Contrato = new Contrato()
            };

            return View(contratoViewModel);
        }

        [HttpPost]

        public ActionResult SaveContratos(Contrato contrato)
        {
            if (!ModelState.IsValid)
            {
                var contratoVm = new ContratoViewModel()
                {
                    Contrato = contrato
                };

                return View("New", contratoVm);
            }

            if (contrato.ContratoId == 0)
            {
                db.Contrato.Add(contrato);
            }
            else
            {
                var contratoInBd = db.Contrato.Single(c => c.ContratoId == contrato.ContratoId);

                contratoInBd.NombreDeLaEmpresa = contrato.NombreDeLaEmpresa;
                contratoInBd.FechaInicial = contrato.FechaInicial;
                contratoInBd.FechaFin = contrato.FechaFin;
            }

            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e.ToString());
            }

            return RedirectToAction("Index", "Contratos");
        }


        public ActionResult EditNewContratos(int id)
        {
            var contratoToEdit = db.Contrato.SingleOrDefault(c => c.ContratoId == id);

            if (contratoToEdit == null)
            {
                return HttpNotFound();
            }

            var contratoViewModel = new ContratoViewModel
            {
                Contrato = contratoToEdit
            };

            return View("New", contratoViewModel);
        }

    }
}
