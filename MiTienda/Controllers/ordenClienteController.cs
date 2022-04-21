using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MiTienda.Models;

namespace MiTienda.Controllers
{
    public class ordenClienteController : Controller
    {
        private contextoTienda db = new contextoTienda();

        // GET: ordenCliente
        public ActionResult Index()
        {
            var ordenCliente = db.ordenCliente.Include(o => o.datosEnvio).Include(o => o.paqueterias).Include(o => o.usuarios).Include(o => o.ordenProducto);
            return View(ordenCliente.ToList());
        }

        // GET: ordenCliente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ordenCliente ordenCliente = db.ordenCliente.Find(id);
            if (ordenCliente == null)
            {
                return HttpNotFound();
            }
            return View(ordenCliente);
        }

        // GET: ordenCliente/Create
        public ActionResult Create()
        {
            ViewBag.id_datosEnvio = new SelectList(db.datosEnvio, "Id_datosEnvio", "calle");
            ViewBag.id_paqueteria = new SelectList(db.paqueterias, "Id_paqueteria", "nombre");
            ViewBag.id_usuario = new SelectList(db.usuarios, "Id_usuario", "nombre");
            ViewBag.Id_ordenCliente = new SelectList(db.ordenProducto, "Id_ordenCliente", "Id_ordenCliente");
            return View();
        }

        // POST: ordenCliente/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_ordenCliente,fecha_creacion,num_confirmacion,total,num_guia,fecha_envio,fecha_entrega,id_usuario,id_datosEnvio,id_paqueteria")] ordenCliente ordenCliente)
        {
            if (ModelState.IsValid)
            {
                db.ordenCliente.Add(ordenCliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_datosEnvio = new SelectList(db.datosEnvio, "Id_datosEnvio", "calle", ordenCliente.id_datosEnvio);
            ViewBag.id_paqueteria = new SelectList(db.paqueterias, "Id_paqueteria", "nombre", ordenCliente.id_paqueteria);
            ViewBag.id_usuario = new SelectList(db.usuarios, "Id_usuario", "nombre", ordenCliente.id_usuario);
            ViewBag.Id_ordenCliente = new SelectList(db.ordenProducto, "Id_ordenCliente", "Id_ordenCliente", ordenCliente.Id_ordenCliente);
            return View(ordenCliente);
        }

        // GET: ordenCliente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ordenCliente ordenCliente = db.ordenCliente.Find(id);
            if (ordenCliente == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_datosEnvio = new SelectList(db.datosEnvio, "Id_datosEnvio", "calle", ordenCliente.id_datosEnvio);
            ViewBag.id_paqueteria = new SelectList(db.paqueterias, "Id_paqueteria", "nombre", ordenCliente.id_paqueteria);
            ViewBag.id_usuario = new SelectList(db.usuarios, "Id_usuario", "nombre", ordenCliente.id_usuario);
            ViewBag.Id_ordenCliente = new SelectList(db.ordenProducto, "Id_ordenCliente", "Id_ordenCliente", ordenCliente.Id_ordenCliente);
            return View(ordenCliente);
        }

        // POST: ordenCliente/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_ordenCliente,fecha_creacion,num_confirmacion,total,num_guia,fecha_envio,fecha_entrega,id_usuario,id_datosEnvio,id_paqueteria")] ordenCliente ordenCliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ordenCliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_datosEnvio = new SelectList(db.datosEnvio, "Id_datosEnvio", "calle", ordenCliente.id_datosEnvio);
            ViewBag.id_paqueteria = new SelectList(db.paqueterias, "Id_paqueteria", "nombre", ordenCliente.id_paqueteria);
            ViewBag.id_usuario = new SelectList(db.usuarios, "Id_usuario", "nombre", ordenCliente.id_usuario);
            ViewBag.Id_ordenCliente = new SelectList(db.ordenProducto, "Id_ordenCliente", "Id_ordenCliente", ordenCliente.Id_ordenCliente);
            return View(ordenCliente);
        }

        // GET: ordenCliente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ordenCliente ordenCliente = db.ordenCliente.Find(id);
            if (ordenCliente == null)
            {
                return HttpNotFound();
            }
            return View(ordenCliente);
        }

        // POST: ordenCliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ordenCliente ordenCliente = db.ordenCliente.Find(id);
            db.ordenCliente.Remove(ordenCliente);
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
