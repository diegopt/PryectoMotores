using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiTienda.Models
{
    public class ProdCarro
    {
        private contextoTienda db = new contextoTienda();
        private List<productos> products;
        public ProdCarro()
        {
            products = db.productos.ToList();
        }

        public List<productos> findAll()
        {
            return this.products;
        }

        public productos find(int id)
        {
            productos pp = this.products.Single(p => p.Id_producto.Equals(id));
            return pp;
        }
    }
}