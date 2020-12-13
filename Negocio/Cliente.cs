using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Cliente
    {
        public int Guardar(Entidades.Cliente ObjetoCliente)
        {
            int resultado = 0;
            try
            {
                if(ObjetoCliente.Nombre.ToLower() == "matias")
                {
                    throw new Exception("No se admiten Matias");
                }

                Datos.Cliente objDatos = new Datos.Cliente();
                resultado = objDatos.Guardar(ObjetoCliente);
            }
            catch (Exception ex)
            {
                throw new Exception("Error capa de negocio " + ex.Message);
            }
            return resultado;
        }
    }
}
