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
    public class GaleriaController : Controller
    {
        private ContextTienda db = new ContextTienda();

        // GET: Galeria
        public ActionResult Index()
        {
            return View(db.Galeria.ToList());
        }

        // GET: Galeria/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Galeria galeria = db.Galeria.Find(id);
            if (galeria == null)
            {
                return HttpNotFound();
            }
            return View(galeria);
        }

        // GET: Galeria/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Galeria/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_galeria,nombre_galeria")] Galeria galeria)
        {
            if (ModelState.IsValid)
            {
                db.Galeria.Add(galeria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(galeria);
        }

        // GET: Galeria/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Galeria galeria = db.Galeria.Find(id);
            if (galeria == null)
            {
                return HttpNotFound();
            }
            return View(galeria);
        }

        // POST: Galeria/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_galeria,nombre_galeria")] Galeria galeria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(galeria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(galeria);
        }

        // GET: Galeria/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Galeria galeria = db.Galeria.Find(id);
            if (galeria == null)
            {
                return HttpNotFound();
            }
            return View(galeria);
        }

        // POST: Galeria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Galeria galeria = db.Galeria.Find(id);
            db.Galeria.Remove(galeria);
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
