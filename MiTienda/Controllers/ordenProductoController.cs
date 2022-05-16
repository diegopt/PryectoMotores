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
    public class ordenProductoController : Controller
    {
        private contextoTienda db = new contextoTienda();

        // GET: ordenProducto
        public ActionResult Index()
        {
            var ordenProducto = db.ordenProducto.Include(o => o.ordenCliente).Include(o => o.productos);
            return View(ordenProducto.ToList());
        }

        // GET: ordenProducto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ordenProducto ordenProducto = db.ordenProducto.Find(id);
            if (ordenProducto == null)
            {
                return HttpNotFound();
            }
            return View(ordenProducto);
        }

        // GET: ordenProducto/Create
        public ActionResult Create()
        {
            ViewBag.Id_ordenCliente = new SelectList(db.ordenCliente, "Id_ordenCliente", "Id_ordenCliente");
            ViewBag.id_producto = new SelectList(db.productos, "Id_producto", "nombre");
            return View();
        }

        // POST: ordenProducto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_ordenCliente,id_producto,cantidad")] ordenProducto ordenProducto)
        {
            if (ModelState.IsValid)
            {
                db.ordenProducto.Add(ordenProducto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_ordenCliente = new SelectList(db.ordenCliente, "Id_ordenCliente", "Id_ordenCliente", ordenProducto.Id_ordenCliente);
            ViewBag.id_producto = new SelectList(db.productos, "Id_producto", "nombre", ordenProducto.id_producto);
            return View(ordenProducto);
        }

        // GET: ordenProducto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ordenProducto ordenProducto = db.ordenProducto.Find(id);
            if (ordenProducto == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_ordenCliente = new SelectList(db.ordenCliente, "Id_ordenCliente", "Id_ordenCliente", ordenProducto.Id_ordenCliente);
            ViewBag.id_producto = new SelectList(db.productos, "Id_producto", "nombre", ordenProducto.id_producto);
            return View(ordenProducto);
        }

        // POST: ordenProducto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_ordenCliente,id_producto,cantidad")] ordenProducto ordenProducto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ordenProducto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_ordenCliente = new SelectList(db.ordenCliente, "Id_ordenCliente", "Id_ordenCliente", ordenProducto.Id_ordenCliente);
            ViewBag.id_producto = new SelectList(db.productos, "Id_producto", "nombre", ordenProducto.id_producto);
            return View(ordenProducto);
        }

        // GET: ordenProducto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ordenProducto ordenProducto = db.ordenProducto.Find(id);
            if (ordenProducto == null)
            {
                return HttpNotFound();
            }
            return View(ordenProducto);
        }

        // POST: ordenProducto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ordenProducto ordenProducto = db.ordenProducto.Find(id);
            db.ordenProducto.Remove(ordenProducto);
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
