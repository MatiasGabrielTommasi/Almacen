using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Marca
    {
        public int IdMarca;
        public string NombreMarca;
        public Marca()
        {
            this.IdMarca = 0;
            this.NombreMarca = "Sin Marca";
        }
        public Marca(int Id, string Marca)
        {
            this.IdMarca = Id;
            this.NombreMarca = Marca;
        }
    }
}
