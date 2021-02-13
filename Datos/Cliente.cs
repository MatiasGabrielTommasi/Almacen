using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class Cliente
    {
        public List<Entidades.Cliente> Cargar()
        {
            List<Entidades.Cliente> listado = new List<Entidades.Cliente>();
            string strSql = "select * from Clientes";
            SqlConnection objCon = new SqlConnection("server=192.168.0.40;DataBase=Almacen;Integrated Security=true");
            SqlCommand cmd = new SqlCommand(strSql, objCon);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable objDt = new DataTable();
            try
            {
                objCon.Open();
                adapter.Fill(objDt);
                objCon.Close();
                cmd.Dispose();

                foreach (DataRow row in objDt.Rows)
                {
                    Entidades.Cliente cliente = new Entidades.Cliente();
                    cliente.Apellido = row["apellido"].ToString();
                    cliente.CorreoElectronico = row["correo_electronico"].ToString();
                    cliente.Direccion = row["direccion"].ToString();
                    cliente.Id = Convert.ToInt32(row["id_cliente"].ToString());
                    cliente.Nombre = row["nombre"].ToString();
                    cliente.Telefono = row["telefono"].ToString();

                    if(row["fecha_nacimiento"] != DBNull.Value)
                    {
                        cliente.FechaNacimiento = Convert.ToDateTime(row["fecha_nacimiento"].ToString());
                    }  
                    
                    cliente.FechaRegistro = Convert.ToDateTime(row["fecha_registro"].ToString());

                    listado.Add(cliente);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Datos: " + ex.Message);
            }
            return listado;
        }
        public Entidades.Cliente Buscar(string apellido, string telefono)
        {
            Entidades.Cliente cliente = null;
            string strSql = "procClientesBuscar";
            SqlConnection objCon = new SqlConnection("server=192.168.0.40;DataBase=Almacen;Integrated Security=true");
            SqlCommand cmd = new SqlCommand(strSql, objCon);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@apellido", apellido);
            cmd.Parameters.AddWithValue("@telefono", telefono);

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable objDt = new DataTable();
            try
            {
                objCon.Open();
                adapter.Fill(objDt);
                objCon.Close();
                cmd.Dispose();

                foreach (DataRow row in objDt.Rows)
                {
                    cliente = new Entidades.Cliente();
                    cliente.Apellido = row["apellido"].ToString();
                    cliente.CorreoElectronico = row["correo_electronico"].ToString();
                    cliente.Direccion = row["direccion"].ToString();
                    cliente.Id = Convert.ToInt32(row["id_cliente"].ToString());
                    cliente.Nombre = row["nombre"].ToString();
                    cliente.Telefono = row["telefono"].ToString();

                    if (row["fecha_nacimiento"] != DBNull.Value)
                    {
                        cliente.FechaNacimiento = Convert.ToDateTime(row["fecha_nacimiento"].ToString());
                    }

                    cliente.FechaRegistro = Convert.ToDateTime(row["fecha_registro"].ToString());
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Datos: " + ex.Message);
            }
            return cliente;
        }
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
        public int Actualizar(Entidades.Cliente obj)
        {
            int resultado = 0;
            string strSql = "procClientesActualizar";
            SqlConnection conexion = new SqlConnection("server=192.168.0.40;DataBase=Almacen;Integrated Security=true");
            SqlCommand command = new SqlCommand(strSql, conexion);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@id_cliente", obj.Id);
            command.Parameters.AddWithValue("@apellido", obj.Apellido);
            command.Parameters.AddWithValue("@nombre", obj.Nombre);
            command.Parameters.AddWithValue("@telefono", obj.Telefono);
            command.Parameters.AddWithValue("@correo_electronico", obj.CorreoElectronico);
            command.Parameters.AddWithValue("@direccion", obj.Direccion);
            command.Parameters.AddWithValue("@fecha_nacimiento", obj.FechaNacimiento);

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
                if (conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                }
                command.Dispose();
            }
            return resultado;
        }
    }
}
