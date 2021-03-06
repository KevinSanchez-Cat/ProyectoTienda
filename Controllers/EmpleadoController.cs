﻿using System;
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
    public class EmpleadoController : Controller
    {
        private ContextTienda db = new ContextTienda();

        // GET: Empleado
        public ActionResult Index()
        {
            var empleado = db.Empleado.Include(e => e.Departamento).Include(e => e.Direccion).Include(e => e.Puesto).Include(e => e.Usuario);
            return View(empleado.ToList());
        }

        // GET: Empleado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // GET: Empleado/Create
        public ActionResult Create()
        {
            ViewBag.id_departamento = new SelectList(db.Departamento, "id_departamento", "nombre_departamento");
            ViewBag.id_direccion = new SelectList(db.Direccion, "id_direccion", "estado");
            ViewBag.id_puesto = new SelectList(db.Puesto, "id_puesto", "nombre_puesto");
            ViewBag.id_usuario = new SelectList(db.Usuario, "Id_usuario", "nombre_usuario");
            return View();
        }

        // POST: Empleado/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_empleado,nombre_empleado,apellido_p,apellido_m,fecha_nac,estatus,salario,email,telefono,id_direccion,id_departamento,id_puesto,id_usuario,rfc")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Empleado.Add(empleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_departamento = new SelectList(db.Departamento, "id_departamento", "nombre_departamento", empleado.id_departamento);
            ViewBag.id_direccion = new SelectList(db.Direccion, "id_direccion", "estado", empleado.id_direccion);
            ViewBag.id_puesto = new SelectList(db.Puesto, "id_puesto", "nombre_puesto", empleado.id_puesto);
            ViewBag.id_usuario = new SelectList(db.Usuario, "Id_usuario", "nombre_usuario", empleado.id_usuario);
            return View(empleado);
        }

        // GET: Empleado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_departamento = new SelectList(db.Departamento, "id_departamento", "nombre_departamento", empleado.id_departamento);
            ViewBag.id_direccion = new SelectList(db.Direccion, "id_direccion", "estado", empleado.id_direccion);
            ViewBag.id_puesto = new SelectList(db.Puesto, "id_puesto", "nombre_puesto", empleado.id_puesto);
            ViewBag.id_usuario = new SelectList(db.Usuario, "Id_usuario", "nombre_usuario", empleado.id_usuario);
            return View(empleado);
        }

        // POST: Empleado/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_empleado,nombre_empleado,apellido_p,apellido_m,fecha_nac,estatus,salario,email,telefono,id_direccion,id_departamento,id_puesto,id_usuario,rfc")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_departamento = new SelectList(db.Departamento, "id_departamento", "nombre_departamento", empleado.id_departamento);
            ViewBag.id_direccion = new SelectList(db.Direccion, "id_direccion", "estado", empleado.id_direccion);
            ViewBag.id_puesto = new SelectList(db.Puesto, "id_puesto", "nombre_puesto", empleado.id_puesto);
            ViewBag.id_usuario = new SelectList(db.Usuario, "Id_usuario", "nombre_usuario", empleado.id_usuario);
            return View(empleado);
        }

        // GET: Empleado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // POST: Empleado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Empleado empleado = db.Empleado.Find(id);
            db.Empleado.Remove(empleado);
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
