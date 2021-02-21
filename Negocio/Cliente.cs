using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Cliente
    {
        public List<Entidades.Cliente> Cargar()
        {
            List<Entidades.Cliente> listado = new List<Entidades.Cliente>();
            try
            {
                Datos.Cliente objetoDatos = new Datos.Cliente();
                listado = objetoDatos.Cargar();
            }
            catch (Exception ex)
            {
                throw new Exception("Error capa de negocio " + ex.Message);
            }
            return listado;
        }
        public List<Entidades.Cliente> Buscar(string apellido, string telefono)
        {
            List<Entidades.Cliente> cliente = new List<Entidades.Cliente>();
            try
            {
                Datos.Cliente objetoDatos = new Datos.Cliente();
                cliente = objetoDatos.Buscar(apellido, telefono);
            }
            catch (Exception ex)
            {
                throw new Exception("Error capa de negocio " + ex.Message);
            }
            return cliente;
        }
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
        public int Actualizar(Entidades.Cliente ObjetoCliente)
        {
            int resultado = 0;
            try
            {
                Datos.Cliente objDatos = new Datos.Cliente();
                resultado = objDatos.Actualizar(ObjetoCliente);
            }
            catch (Exception ex)
            {
                throw new Exception("Error capa de negocio " + ex.Message);
            }
            return resultado;
        }
        public int Eliminar(int Id)
        {
            int resultado = 0;
            try
            {
                Datos.Cliente objDatos = new Datos.Cliente();
                resultado = objDatos.Eliminar(Id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error capa de negocio " + ex.Message);
            }
            return resultado;
        }
    }
}
