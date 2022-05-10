﻿using System;
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
    public class clientesController : Controller
    {
        private contextoTienda db = new contextoTienda();

        // GET: clientes
        public ActionResult Index()
        {
            return View(db.clientes.ToList());
        }

        // GET: clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clientes clientes = db.clientes.Find(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            return View(clientes);
        }

        // GET: clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: clientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_cliente,nombre,apellido_p,apellido_m,correo,contraseña,fecha_nacimiento,rfc,telefono")] clientes clientes)
        {
            clientes cliente = new clientes();
            int id = 0;
            if(!(db.clientes.Max(c => (int?)c.Id_cliente)==null))
            {
                id = db.clientes.Max(c => c.Id_cliente);
            }
            else
            {
                id = 0;
            }
            id++;


            if (ModelState.IsValid)
            {
                db.clientes.Add(clientes);
                db.SaveChanges();
                string rol = "cliente";
                clientes.rol = rol;
                db.SaveChanges();
                //return RedirectToAction("Index");
            }

            if (Session["CrearOrden"] != null)
            {
                if (Session["CrearOrden"].Equals("pend"))
                {
                    return RedirectToAction("CrearOrden", "Pago");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

            

            return View(clientes);
        }

        // GET: clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clientes clientes = db.clientes.Find(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            return View(clientes);
        }

        // POST: clientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_cliente,nombre,apellido_p,apellido_m,correo,contraseña,fecha_nacimiento,rfc,telefono,rol")] clientes clientes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clientes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clientes);
        }

        // GET: clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clientes clientes = db.clientes.Find(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            return View(clientes);
        }

        // POST: clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            clientes clientes = db.clientes.Find(id);
            db.clientes.Remove(clientes);
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
            string idUser = User.Identity.AuthenticationType;
            return RedirectToAction("Delete", "Account", routeValues: new { id = idUser });
        }
    }
}
