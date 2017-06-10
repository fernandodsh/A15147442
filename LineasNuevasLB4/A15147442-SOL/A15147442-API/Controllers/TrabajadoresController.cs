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
    public class TrabajadoresController : Controller
    {
        private LineaNuevaDbContext db = new LineaNuevaDbContext();

        // GET: Trabajadores
        public ActionResult Index()
        {
            return View(db.Trabajador.ToList());
        }

        // GET: Trabajadores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trabajador trabajador = db.Trabajador.Find(id);
            if (trabajador == null)
            {
                return HttpNotFound();
            }
            return View(trabajador);
        }

        // GET: Trabajadores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Trabajadores/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TrabajadorId,Nombre,Apellido,DNI,FechaInicioContrato,TipoTrabajador")] Trabajador trabajador)
        {
            if (ModelState.IsValid)
            {
                db.Trabajador.Add(trabajador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trabajador);
        }

        // GET: Trabajadores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trabajador trabajador = db.Trabajador.Find(id);
            if (trabajador == null)
            {
                return HttpNotFound();
            }
            return View(trabajador);
        }

        // POST: Trabajadores/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TrabajadorId,Nombre,Apellido,DNI,FechaInicioContrato,TipoTrabajador")] Trabajador trabajador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trabajador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trabajador);
        }

        // GET: Trabajadores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trabajador trabajador = db.Trabajador.Find(id);
            if (trabajador == null)
            {
                return HttpNotFound();
            }
            return View(trabajador);
        }

        // POST: Trabajadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Trabajador trabajador = db.Trabajador.Find(id);
            db.Trabajador.Remove(trabajador);
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

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public ActionResult New()
        {
            var trabajadorViewModel = new TrabajadorViewModel
            {
                Trabajador = new Trabajador()
            };

            return View(trabajadorViewModel);
        }

        [HttpPost]

        public ActionResult SaveTrabajadores(Trabajador trabajador)
        {
            if (!ModelState.IsValid)
            {
                var trabajadorVm = new TrabajadorViewModel()
                {
                    Trabajador = trabajador
                };

                return View("New", trabajadorVm);
            }

            if (trabajador.TrabajadorId == 0)
            {
                db.Trabajador.Add(trabajador);
            }
            else
            {
                var trabajadorInBd = db.Trabajador.Single(c => c.TrabajadorId == trabajador.TrabajadorId);

                trabajadorInBd.Nombre = trabajador.Nombre;
                trabajadorInBd.Apellido = trabajador.Apellido;
                trabajadorInBd.DNI = trabajador.DNI;
                trabajadorInBd.FechaInicioContrato = trabajador.FechaInicioContrato;
                trabajadorInBd.TipoTrabajador = trabajador.TipoTrabajador;

            }

            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e.ToString());
            }

            return RedirectToAction("Index", "Trabajadores");
        }


        public ActionResult EditNewTrabajadores(int id)
        {
            var trabajadorToEdit = db.Trabajador.SingleOrDefault(c => c.TrabajadorId == id);

            if (trabajadorToEdit == null)
            {
                return HttpNotFound();
            }

            var trabajadorViewModel = new TrabajadorViewModel
            {
                Trabajador = trabajadorToEdit
            };

            return View("New", trabajadorViewModel);
        }
    }
}
