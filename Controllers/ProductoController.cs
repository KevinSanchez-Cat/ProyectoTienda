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
    public class ProductoController : Controller
    {
        private ContextTienda db = new ContextTienda();

        // GET: Producto
        public ActionResult Index()
        {
            var producto = db.Producto.Include(p => p.Categoria).Include(p => p.Galeria).Include(p => p.marca).Include(p => p.Producto2).Include(p => p.Usuario);
            return View(producto.ToList());
        }

        // GET: Producto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // GET: Producto/Create
        public ActionResult Create()
        {
            ViewBag.id_categoria = new SelectList(db.Categoria, "id_categoria", "nombre_categoria");
            ViewBag.id_galeria = new SelectList(db.Galeria, "id_galeria", "nombre_galeria");
            ViewBag.id_marca = new SelectList(db.marca, "Id_marca", "nombre_marca");
            ViewBag.id_producto_relacionado = new SelectList(db.Producto, "Id_producto", "nombre_producto");
            ViewBag.id_usuario = new SelectList(db.Usuario, "Id_usuario", "nombre_usuario");
            return View();
        }

        // POST: Producto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_producto,nombre_producto,descripcion_producto,precio,coste,imagen_producto,id_categoria,id_marca,id_producto_relacionado,clave_unica,id_galeria,id_usuario")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                db.Producto.Add(producto);
                db.SaveChanges();

                int id = producto.Id_producto;
                var prod = db.Producto.Find(id);
                DateTime hoy = DateTime.Now;
                prod.ultima_actualizacion = hoy;

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_categoria = new SelectList(db.Categoria, "id_categoria", "nombre_categoria", producto.id_categoria);
            ViewBag.id_galeria = new SelectList(db.Galeria, "id_galeria", "nombre_galeria", producto.id_galeria);
            ViewBag.id_marca = new SelectList(db.marca, "Id_marca", "nombre_marca", producto.id_marca);
            ViewBag.id_producto_relacionado = new SelectList(db.Producto, "Id_producto", "nombre_producto", producto.id_producto_relacionado);
            ViewBag.id_usuario = new SelectList(db.Usuario, "Id_usuario", "nombre_usuario", producto.id_usuario);
            return View(producto);
        }

        // GET: Producto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_categoria = new SelectList(db.Categoria, "id_categoria", "nombre_categoria", producto.id_categoria);
            ViewBag.id_galeria = new SelectList(db.Galeria, "id_galeria", "nombre_galeria", producto.id_galeria);
            ViewBag.id_marca = new SelectList(db.marca, "Id_marca", "nombre_marca", producto.id_marca);
            ViewBag.id_producto_relacionado = new SelectList(db.Producto, "Id_producto", "nombre_producto", producto.id_producto_relacionado);
            ViewBag.id_usuario = new SelectList(db.Usuario, "Id_usuario", "nombre_usuario", producto.id_usuario);
            return View(producto);
        }

        // POST: Producto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_producto,nombre_producto,descripcion_producto,precio,coste,imagen_producto,id_categoria,ultima_actualizacion,id_marca,id_producto_relacionado,clave_unica,id_galeria,id_usuario")] Producto producto)
        {
            if (ModelState.IsValid)
            {




                db.Entry(producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_categoria = new SelectList(db.Categoria, "id_categoria", "nombre_categoria", producto.id_categoria);
            ViewBag.id_galeria = new SelectList(db.Galeria, "id_galeria", "nombre_galeria", producto.id_galeria);
            ViewBag.id_marca = new SelectList(db.marca, "Id_marca", "nombre_marca", producto.id_marca);
            ViewBag.id_producto_relacionado = new SelectList(db.Producto, "Id_producto", "nombre_producto", producto.id_producto_relacionado);
            ViewBag.id_usuario = new SelectList(db.Usuario, "Id_usuario", "nombre_usuario", producto.id_usuario);
            return View(producto);
        }

        // GET: Producto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // POST: Producto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Producto producto = db.Producto.Find(id);
            db.Producto.Remove(producto);
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
