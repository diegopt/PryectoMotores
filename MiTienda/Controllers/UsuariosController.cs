using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiTienda.Models;

namespace MiTienda.Controllers
{
    [Authorize]
    public class UsuariosController : Controller
    {
        private contextoTienda db = new contextoTienda();
        // GET: Usuario
        public ActionResult Index(string email)
        {
            if (User.Identity.IsAuthenticated)
            {
                string correo = email;
                string rol = "";

                using (db)
                {
                    var query = from st in db.Empleado where st.correo == correo select st;

                    var lista = query.ToList();
                    if (lista.Count > 0)
                    {
                        var empleado = query.FirstOrDefault<Empleado>();
                        string[] nombres = empleado.nombre.ToString().Split(' ');
                        Session["name"] = nombres[0];
                        Session["usr"] = empleado.nombre;
                        rol = empleado.id_rol.ToString().TrimEnd();

                    }
                    else
                    {
                        var query1 = from st in db.usuarios where st.correo == correo select st;
                        var lista1 = query1.ToList();

                        if (lista1.Count > 0)
                        {
                            var cliente = query1.FirstOrDefault<usuarios>();
                            string[] nombres = cliente.nombre.ToString().Split(' ');
                            Session["name"] = nombres[0];
                            Session["usr"] = cliente.nombre;
                            rol = "cliente";
                        }
                    }


                }

                if (rol == "admin")
                {
                    return RedirectToAction("Index", "Administrador");
                }
                if (rol == "cmprs")
                {
                    return RedirectToAction("Index", "Compras");
                }
                if (rol == "cliente")
                {
                    return RedirectToAction("Index", "Home");
                }
                if (rol == "almcn")
                {
                    return RedirectToAction("Index", "Almacen");
                }

            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index", "Home");
        }
    }
}