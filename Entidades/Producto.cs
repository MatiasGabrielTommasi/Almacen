using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Producto
    {
        public int IdProducto;
        public string NombreProducto;
        public decimal Precio;
        public int IdMarca;
        public Marca MarcaProducto;

        public Producto(string NombreProducto, decimal PrecioProducto)
        {
            this.NombreProducto = NombreProducto;
            this.Precio = PrecioProducto;
        }
    }
}
