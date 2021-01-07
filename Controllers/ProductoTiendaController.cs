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
    public class ProductoTiendaController : Controller
    {
        private ContextTienda db = new ContextTienda();

        // GET: ProductoTienda
        public ActionResult Index()
        {
            var productoTienda = db.ProductoTienda.Include(p => p.Producto);
            return View(productoTienda.ToList());
        }

        // GET: ProductoTienda/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductoTienda productoTienda = db.ProductoTienda.Find(id);
            if (productoTienda == null)
            {
                return HttpNotFound();
            }
            return View(productoTienda);
        }

        // GET: ProductoTienda/Create
        public ActionResult Create()
        {
            ViewBag.Id_producto = new SelectList(db.Producto, "Id_producto", "nombre_producto");
            return View();
        }

        // POST: ProductoTienda/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_producto,numBusqueda,calificacion,numVisitas,destacado")] ProductoTienda productoTienda)
        {
            if (ModelState.IsValid)
            {
                db.ProductoTienda.Add(productoTienda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_producto = new SelectList(db.Producto, "Id_producto", "nombre_producto", productoTienda.Id_producto);
            return View(productoTienda);
        }

        // GET: ProductoTienda/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductoTienda productoTienda = db.ProductoTienda.Find(id);
            if (productoTienda == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_producto = new SelectList(db.Producto, "Id_producto", "nombre_producto", productoTienda.Id_producto);
            return View(productoTienda);
        }

        // POST: ProductoTienda/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_producto,numBusqueda,calificacion,numVisitas,destacado")] ProductoTienda productoTienda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productoTienda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_producto = new SelectList(db.Producto, "Id_producto", "nombre_producto", productoTienda.Id_producto);
            return View(productoTienda);
        }

        // GET: ProductoTienda/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductoTienda productoTienda = db.ProductoTienda.Find(id);
            if (productoTienda == null)
            {
                return HttpNotFound();
            }
            return View(productoTienda);
        }

        // POST: ProductoTienda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductoTienda productoTienda = db.ProductoTienda.Find(id);
            db.ProductoTienda.Remove(productoTienda);
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
