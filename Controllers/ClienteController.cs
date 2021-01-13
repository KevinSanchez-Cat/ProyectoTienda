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
    public class ClienteController : Controller
    {
        private ContextTienda db = new ContextTienda();

        // GET: Cliente
        public ActionResult Index()
        {
            var cliente = db.Cliente.Include(c => c.Direccion).Include(c => c.Tarjeta).Include(c => c.Usuario);
            return View(cliente.ToList());
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            ViewBag.id_direccion = new SelectList(db.Direccion, "id_direccion", "estado");
            ViewBag.id_tarjeta = new SelectList(db.Tarjeta, "id_tarjeta", "numTarjeta");
            ViewBag.id_usuario = new SelectList(db.Usuario, "Id_usuario", "nombre_usuario");
            return View();
        }

        // POST: Cliente/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
       // public ActionResult Create([Bind(Include = "id_cliente,nombre_cliente,apellido_p,apellido_m,id_direccion,telefono,email,id_tarjeta,id_usuario,nombre_usuario,contrasenia")] Cliente cliente)
        public ActionResult Create(string nombre_cliente, string apellido_p, string apellido_m, string id_direccion,string telefono, string email, int id_tarjeta,int  id_usuario, string nombre_usuario, string contrasenia )
        {


            Cliente cliente = new Cliente();

            int id = 0;
            if (!(db.Cliente.Max(c => (int?)c.id_cliente == null))){
                id = db.Cliente.Max(c=>c.id_cliente);
            }
            else
            {
                id = 0;
            }
            id++;
            /*
             * if(Tarjeta(num_tarj_cred_ppal, tipoTarj,Mes, Anio, CVV){
             * 
             * if(validaPago(nombre,calle_t,colonia_t,estado_t, num_tarj_cred_ppal,Mes,Anio, CVV)){
             * cliente.Id_cliente=id;
             * cliente.nombre=nombre;
             * cliente.email=Session["correo"].ToString();
             * }
             * 
             * 
             * }
             * 
             * 
             * 
             */



            if (ModelState.IsValid)
            {
                db.Cliente.Add(cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_direccion = new SelectList(db.Direccion, "id_direccion", "estado", cliente.id_direccion);
            ViewBag.id_tarjeta = new SelectList(db.Tarjeta, "id_tarjeta", "numTarjeta", cliente.id_tarjeta);
            ViewBag.id_usuario = new SelectList(db.Usuario, "Id_usuario", "nombre_usuario", cliente.id_usuario);
            return View(cliente);
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_direccion = new SelectList(db.Direccion, "id_direccion", "estado", cliente.id_direccion);
            ViewBag.id_tarjeta = new SelectList(db.Tarjeta, "id_tarjeta", "numTarjeta", cliente.id_tarjeta);
            ViewBag.id_usuario = new SelectList(db.Usuario, "Id_usuario", "nombre_usuario", cliente.id_usuario);
            return View(cliente);
        }

        // POST: Cliente/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_cliente,nombre_cliente,apellido_p,apellido_m,id_direccion,telefono,email,id_tarjeta,id_usuario,nombre_usuario,contrasenia")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_direccion = new SelectList(db.Direccion, "id_direccion", "estado", cliente.id_direccion);
            ViewBag.id_tarjeta = new SelectList(db.Tarjeta, "id_tarjeta", "numTarjeta", cliente.id_tarjeta);
            ViewBag.id_usuario = new SelectList(db.Usuario, "Id_usuario", "nombre_usuario", cliente.id_usuario);
            return View(cliente);
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cliente cliente = db.Cliente.Find(id);
            db.Cliente.Remove(cliente);
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
        public ActionResult Invalida()
        {
            return View();
        }
        public ActionResult BorraUser()
        {
            string idUser = User.Identity.GetUserId();

            return RedirectToAction("Delete", "Account", routeValues: new { id = idUser });
        }
    }
}
