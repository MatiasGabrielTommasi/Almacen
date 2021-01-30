using System;
using System.Data.SqlClient;

namespace Datos
{
    public class Cliente
    {
        public int Guardar(Entidades.Cliente obj)
        {
            int resultado = 0;
            //string strSql = "insert into Clientes (apellido, nombre, telefono, correo_electronico, direccion, fecha_nacimiento)" +
            //                " values ('" + obj.Apellido + "', '" + obj.Nombre + "', '" + obj.Telefono + "', '" + obj.CorreoElectronico +
            //                            "', '" + obj.Direccion + "', '" + obj.FechaNacimiento.ToString("yyyy/MM/dd") + "')";
            //SqlConnection conexion = new SqlConnection("server=.;DataBase=Almacen;user id=sa; password =123456");

            string strSql = string.Format("insert into Clientes(apellido, nombre, telefono, correo_electronico, direccion, fecha_nacimiento)" +
                                        " values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')",
                                        obj.Apellido, obj.Nombre, obj.Telefono, obj.CorreoElectronico, obj.Direccion, obj.FechaNacimiento.ToString("yyyy/MM/dd"));

            SqlConnection conexion = new SqlConnection("server=192.168.0.40;DataBase=Almacen;Integrated Security=true");
            SqlCommand command = new SqlCommand(strSql, conexion);
            try
            {
                conexion.Open();
                resultado = command.ExecuteNonQuery();//GC (Garbage Collector)
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
