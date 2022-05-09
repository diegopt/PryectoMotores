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
    public class ProductosController : Controller
    {
        private contextoTienda db = new contextoTienda();

        // GET: Productos
        public ActionResult Index()
        {
            var productos = db.productos.Include(p => p.categorias);
            return View(productos.ToList());
        }

        // GET: Productos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            productos productos = db.productos.Find(id);
            if (productos == null)
            {
                return HttpNotFound();
            }
            return View(productos);
        }

        // GET: Productos/Create
        public ActionResult Create()
        {
            ViewBag.id_categoria = new SelectList(db.categorias, "Id_categoria", "nombre");
            return View();
        }

        // POST: Productos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_producto,nombre,descripcion,precio,imagen,existencia,stock,id_categoria")] productos productos)
        {
            if (ModelState.IsValid)
            {
                db.productos.Add(productos);
                db.SaveChanges();

                int id = productos.Id_producto;
                var prod = db.productos.Find(id);
                DateTime hoy = DateTime.Now;
                prod.ult_actualizacion = hoy;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.id_categoria = new SelectList(db.categorias, "Id_categoria", "nombre", productos.id_categoria);
            return View(productos);
        }

        // GET: Productos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            productos productos = db.productos.Find(id);
            if (productos == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_categoria = new SelectList(db.categorias, "Id_categoria", "nombre", productos.id_categoria);
            return View(productos);
        }

        // POST: Productos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_producto,nombre,descripcion,precio,ult_actualizacion,imagen,existencia,stock,id_categoria")] productos productos)
        {
            if (ModelState.IsValid)
            {
                int id = productos.Id_producto;
                var prod = db.productos.Find(id);
                var precio_ant = prod.precio;
                var precio_act = productos.precio;
                //db.Entry(producto).State = EntityState.Modified;
                prod.nombre = productos.nombre;
                prod.descripcion = productos.descripcion;
                prod.precio = productos.precio;
                prod.imagen = productos.imagen;
                prod.existencia = productos.existencia;
                prod.stock = productos.stock;
                prod.id_categoria = productos.id_categoria;

                if (precio_act != precio_ant)
                {
                    DateTime hoy = DateTime.Now;
                    prod.ult_actualizacion = hoy;
                }

                db.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewBag.id_categoria = new SelectList(db.categorias, "Id_categoria", "nombre", productos.id_categoria);
            return View(productos);
        }

        // GET: Productos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            productos productos = db.productos.Find(id);
            if (productos == null)
            {
                return HttpNotFound();
            }
            return View(productos);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            productos productos = db.productos.Find(id);
            db.productos.Remove(productos);
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