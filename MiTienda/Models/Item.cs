using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiTienda.Models
{
    public class Item
    {
        public productos Product
        {
            get;
            set;
        }

        public int Cantidad
        {
            get;
            set;
        }
    }
}