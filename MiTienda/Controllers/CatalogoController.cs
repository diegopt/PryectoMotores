using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiTienda.Models;

namespace MiTienda.Controllers
{
    public class CatalogoController : Controller
    {
        private contextoTienda db = new contextoTienda();
        // GET: Catalogo
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BuscaProd(string nomBuscar)
        {
            ViewBag.SearchKey = nomBuscar;
            using (db)
            {
                var query = from st in db.productos
                            where st.nombre.Contains(nomBuscar)

                            select st;
                var listProd = query.ToList();
                ViewBag.Listado = listProd;
            }
            return View();
        }

        public ActionResult prodCategoria(int idCat)
        {

            List<productos> mercancia = null;
            var query = from p in db.productos
                        where p.id_categoria == idCat
                        select p;

            if (idCat == 1)
            {
                List<productos> alterna = query.ToList();
                mercancia = alterna;
                ViewBag.Catego = "Motores de Corriente alterna";
            }
            if (idCat == 2)
            {
                List<productos> continua = query.ToList();
                mercancia = continua;
                ViewBag.Catego = "Motores de Corriente continua";

            }
            ViewBag.productos = mercancia;
            return View();

        }


        public ActionResult prodCompletos()
        {
            List<productos> mercancia = null;
            var query = from p in db.productos
                        select p;

            List<productos> completos = query.ToList();
            mercancia = completos;
            ViewBag.Catego = "Catálogo de Productos";

            ViewBag.productos = mercancia;
            return View();

        }

    }
}