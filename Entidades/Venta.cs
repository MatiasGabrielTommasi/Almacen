using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Venta
    {
        public int IdVenta;
        public DateTime Fecha;
        public Cliente ClienteVenta;
        public List<Producto> ListaProductos;

        public Venta()
        {
            this.ListaProductos = new List<Producto>();
        }

        public void RegistrarVenta(Cliente ClienteVenta)
        {
            this.Fecha = DateTime.Now;
            this.ClienteVenta = ClienteVenta;
        }
    }
}
