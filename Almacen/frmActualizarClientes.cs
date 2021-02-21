using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Almacen
{
    public partial class frmActualizarClientes : Form
    {
        private int IdCliente;
        public frmActualizarClientes()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string apellido = txtBuscarApellido.Text;
                string telefono = txtBuscarTelefono.Text;

                Entidades.Cliente objetoCliente = new Entidades.Cliente();
                Negocio.Cliente objetoNegocio = new Negocio.Cliente();
                //objetoCliente = objetoNegocio.Buscar(apellido, telefono);

                if(objetoCliente == null)
                {
                    MessageBox.Show("No se encontro ningún cliente con los filtros indicados.");
                }
                else
                {
                    CargarDatosCliente(objetoCliente);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void CargarDatosCliente(Entidades.Cliente cliente)
        {
            try
            {
                txtApellido.Text = cliente.Apellido;
                txtNombre.Text = cliente.Nombre;
                txtDireccion.Text = cliente.Direccion;
                txtTelefono.Text = cliente.Telefono;
                txtCorreoElectronico.Text = cliente.CorreoElectronico;
                IdCliente = cliente.Id;
                dtpFechaNacimiento.Value = cliente.FechaNacimiento;
                lblFechaRegistro.Text = "Cliente registrado el día " + cliente.FechaRegistro.ToString("dd/MM/yyyy");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnActualizarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                Entidades.Cliente cliente = new Entidades.Cliente();
                cliente.Id = IdCliente;
                cliente.Nombre = txtNombre.Text;
                cliente.Apellido = txtApellido.Text;
                cliente.FechaNacimiento = dtpFechaNacimiento.Value;
                cliente.CorreoElectronico = txtCorreoElectronico.Text;
                cliente.Direccion = txtDireccion.Text;
                cliente.Telefono = txtTelefono.Text;

                Negocio.Cliente objetoNegocio = new Negocio.Cliente();
                int resultado = objetoNegocio.Actualizar(cliente);

                if(resultado > 0)
                {
                    MessageBox.Show("Datos del cliente actualizados correctamente.");
                    LimpiarCamposCliente();
                }
                else
                {
                    MessageBox.Show("No fuie posible actualizar los datos del cliente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void LimpiarCamposCliente()
        {
            try
            {
                string _v = string.Empty;
                txtApellido.Text = "";
                txtNombre.Text = string.Empty;
                txtDireccion.Text = _v;
                txtTelefono.Text = _v;
                txtCorreoElectronico.Text = _v;
                IdCliente = 0;
                dtpFechaNacimiento.Value = DateTime.Now;
                lblFechaRegistro.Text = _v;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
