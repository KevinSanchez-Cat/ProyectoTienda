using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoTienda.Models;

namespace ProyectoTienda.Controllers
{
    public class PaqueteriaController : Controller
    {
        private ContextTienda db = new ContextTienda();

        // GET: Paqueteria
        public ActionResult Index()
        {
            var paqueteria = db.Paqueteria.Include(p => p.Direccion);
            return View(paqueteria.ToList());
        }

        // GET: Paqueteria/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paqueteria paqueteria = db.Paqueteria.Find(id);
            if (paqueteria == null)
            {
                return HttpNotFound();
            }
            return View(paqueteria);
        }

        // GET: Paqueteria/Create
        public ActionResult Create()
        {
            ViewBag.id_direccion = new SelectList(db.Direccion, "id_direccion", "estado");
            return View();
        }

        // POST: Paqueteria/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_paqueteria,nombre_paqueteria,telefono,sitio_web,rfc,contacto,telefono_contacto,id_direccion")] Paqueteria paqueteria)
        {
            if (ModelState.IsValid)
            {
                db.Paqueteria.Add(paqueteria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_direccion = new SelectList(db.Direccion, "id_direccion", "estado", paqueteria.id_direccion);
            return View(paqueteria);
        }

        // GET: Paqueteria/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paqueteria paqueteria = db.Paqueteria.Find(id);
            if (paqueteria == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_direccion = new SelectList(db.Direccion, "id_direccion", "estado", paqueteria.id_direccion);
            return View(paqueteria);
        }

        // POST: Paqueteria/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_paqueteria,nombre_paqueteria,telefono,sitio_web,rfc,contacto,telefono_contacto,id_direccion")] Paqueteria paqueteria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paqueteria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_direccion = new SelectList(db.Direccion, "id_direccion", "estado", paqueteria.id_direccion);
            return View(paqueteria);
        }

        // GET: Paqueteria/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paqueteria paqueteria = db.Paqueteria.Find(id);
            if (paqueteria == null)
            {
                return HttpNotFound();
            }
            return View(paqueteria);
        }

        // POST: Paqueteria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Paqueteria paqueteria = db.Paqueteria.Find(id);
            db.Paqueteria.Remove(paqueteria);
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
