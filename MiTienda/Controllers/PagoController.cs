using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiTienda.Models;

namespace MiTienda.Controllers
{
   [Authorize]
    public class PagoController : Controller
    {
        private contextoTienda db = new contextoTienda();
        private string NumConfirPago;

        // GET: Pago
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult CrearOrden()
        {
            if (!User.Identity.IsAuthenticated)
            {
                Session["CrearOrden"] = "pend";
                return RedirectToAction("Login", "Account");
            }

            string correo = User.Identity.Name;

            string fechaCreacion = DateTime.Today.ToShortDateString();
            string fechaProbEntrega = DateTime.Today.AddDays(3).ToShortDateString();
            var cliente = (from c in db.clientes
                           where c.correo == correo
                           select c).ToList().FirstOrDefault();

           /* Session["dirCliente"] = cliente.calle + " " + cliente.colonia + " " + cliente.entidad_federativa;
            Session["fechaOrden"] = fechaCreacion;
            Session["fPEntreg"] = fechaProbEntrega;

            if (cliente.num_tarjeta.StartsWith("4"))
                Session["tTarj"] = "1";
            if (cliente.num_tarjeta.StartsWith("5"))
                Session["tTarj"] = "2";
            if (cliente.num_tarjeta.StartsWith("3"))
                Session["tTarj"] = "3";
            Session["tTarj"] = cliente.num_tarjeta;

    */

            return View();
        }
    }
}