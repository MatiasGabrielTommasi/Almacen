using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Marca
    {
        public int Guardar(Entidades.Marca obj)
        {
            int resultado = 0;
            string strSql = string.Format("insert into Marcas(marca) values ('{0}')", obj.NombreMarca);// "insert into Marcas(marca) values ('marca')";
            SqlConnection conexion = new SqlConnection(ConnectionStringAlmacen.strConnexion);
            SqlCommand command = new SqlCommand(strSql, conexion);
            try
            {
                conexion.Open();
                resultado = command.ExecuteNonQuery();
                conexion.Close();
                command.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Datos: " + ex.Message);
            }
            finally
            {
                if(conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                }
                command.Dispose();
            }
            return resultado;
        }
    }
}
