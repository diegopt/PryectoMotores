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
    [Authorize]
    public class datosEnvioController : Controller
    {
        private contextoTienda db = new contextoTienda();

        // GET: datosEnvio
        public ActionResult Index()
        {
            var datosEnvio = db.datosEnvio.Include(d => d.clientes);
            return View(datosEnvio.ToList());
        }

        // GET: datosEnvio/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            datosEnvio datosEnvio = db.datosEnvio.Find(id);
            if (datosEnvio == null)
            {
                return HttpNotFound();
            }
            return View(datosEnvio);
        }

        // GET: datosEnvio/Create
        public ActionResult Create()
        {
            ViewBag.id_cliente = new SelectList(db.clientes, "Id_cliente", "nombre");
            return View();
        }

        // POST: datosEnvio/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_datosEnvio,calle,colonia,estado,municipio,num_exterior,num_interior,cp,telefono,id_cliente")] datosEnvio datosEnvio)
        {
            if (ModelState.IsValid)
            {
                db.datosEnvio.Add(datosEnvio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_cliente = new SelectList(db.clientes, "Id_cliente", "nombre", datosEnvio.id_cliente);
            return View(datosEnvio);
        }

        // GET: datosEnvio/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            datosEnvio datosEnvio = db.datosEnvio.Find(id);
            if (datosEnvio == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_cliente = new SelectList(db.clientes, "Id_cliente", "nombre", datosEnvio.id_cliente);
            return View(datosEnvio);
        }

        // POST: datosEnvio/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_datosEnvio,calle,colonia,estado,municipio,num_exterior,num_interior,cp,telefono,id_cliente")] datosEnvio datosEnvio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(datosEnvio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_cliente = new SelectList(db.clientes, "Id_cliente", "nombre", datosEnvio.id_cliente);
            return View(datosEnvio);
        }

        // GET: datosEnvio/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            datosEnvio datosEnvio = db.datosEnvio.Find(id);
            if (datosEnvio == null)
            {
                return HttpNotFound();
            }
            return View(datosEnvio);
        }

        // POST: datosEnvio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            datosEnvio datosEnvio = db.datosEnvio.Find(id);
            db.datosEnvio.Remove(datosEnvio);
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
