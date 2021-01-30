using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Marca
    {
        public int Guardar(Entidades.Marca objMarca)
        {
            int resultado = 0;
            try
            {
                Datos.Marca objDA = new Datos.Marca();
                resultado = objDA.Guardar(objMarca);
            }
            catch (Exception ex)
            {
                throw new Exception("Error capa de negocio: " + ex.Message);
            }
            return resultado;
        }
    }
}
