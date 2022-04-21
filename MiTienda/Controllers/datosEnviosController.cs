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
    public class datosEnviosController : Controller
    {
        private contextoTienda db = new contextoTienda();

        // GET: datosEnvios
        public ActionResult Index()
        {
            var datosEnvio = db.datosEnvio.Include(d => d.usuarios);
            return View(datosEnvio.ToList());
        }

        // GET: datosEnvios/Details/5
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

        // GET: datosEnvios/Create
        public ActionResult Create()
        {
            ViewBag.id_usuario = new SelectList(db.usuarios, "Id_usuario", "nombre");
            return View();
        }

        // POST: datosEnvios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_datosEnvio,calle,colonia,estado,municipio,num_exterior,num_interior,cp,telefono,id_usuario")] datosEnvio datosEnvio)
        {
            if (ModelState.IsValid)
            {
                db.datosEnvio.Add(datosEnvio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_usuario = new SelectList(db.usuarios, "Id_usuario", "nombre", datosEnvio.id_usuario);
            return View(datosEnvio);
        }

        // GET: datosEnvios/Edit/5
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
            ViewBag.id_usuario = new SelectList(db.usuarios, "Id_usuario", "nombre", datosEnvio.id_usuario);
            return View(datosEnvio);
        }

        // POST: datosEnvios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_datosEnvio,calle,colonia,estado,municipio,num_exterior,num_interior,cp,telefono,id_usuario")] datosEnvio datosEnvio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(datosEnvio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_usuario = new SelectList(db.usuarios, "Id_usuario", "nombre", datosEnvio.id_usuario);
            return View(datosEnvio);
        }

        // GET: datosEnvios/Delete/5
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

        // POST: datosEnvios/Delete/5
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
