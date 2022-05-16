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
    public class metodoPagoController : Controller
    {
        private contextoTienda db = new contextoTienda();

        // GET: metodoPago
        public ActionResult Index()
        {
            var metodoPago = db.metodoPago.Include(m => m.clientes);
            return View(metodoPago.ToList());
        }

        // GET: metodoPago/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            metodoPago metodoPago = db.metodoPago.Find(id);
            if (metodoPago == null)
            {
                return HttpNotFound();
            }
            return View(metodoPago);
        }

        // GET: metodoPago/Create
        public ActionResult Create()
        {
            ViewBag.id_cliente = new SelectList(db.clientes, "Id_cliente", "nombre");
            return View();
        }

        // POST: metodoPago/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_pago,numeracion,fecha,cvv,id_cliente")] metodoPago metodoPago)
        {
            if (ModelState.IsValid)
            {
                db.metodoPago.Add(metodoPago);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_cliente = new SelectList(db.clientes, "Id_cliente", "nombre", metodoPago.id_cliente);
            return View(metodoPago);
        }

        // GET: metodoPago/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            metodoPago metodoPago = db.metodoPago.Find(id);
            if (metodoPago == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_cliente = new SelectList(db.clientes, "Id_cliente", "nombre", metodoPago.id_cliente);
            return View(metodoPago);
        }

        // POST: metodoPago/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_pago,numeracion,fecha,cvv,id_cliente")] metodoPago metodoPago)
        {
            if (ModelState.IsValid)
            {
                db.Entry(metodoPago).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_cliente = new SelectList(db.clientes, "Id_cliente", "nombre", metodoPago.id_cliente);
            return View(metodoPago);
        }

        // GET: metodoPago/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            metodoPago metodoPago = db.metodoPago.Find(id);
            if (metodoPago == null)
            {
                return HttpNotFound();
            }
            return View(metodoPago);
        }

        // POST: metodoPago/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            metodoPago metodoPago = db.metodoPago.Find(id);
            db.metodoPago.Remove(metodoPago);
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
