using Entidades;
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
    public partial class frmClientes : Form
    {
        private List<Cliente> ListadoClientes;
        int IdCliente;
        public frmClientes()
        {
            InitializeComponent();

            ListadoClientes = new List<Cliente>();
        }

        private void btnRegistrarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtNombre.Text == "")
                {
                    MessageBox.Show("Debe ingresar un nombre.");
                    txtNombre.BackColor = Color.Red;
                }
                else
                {
                    Cliente ObjetoCliente = new Cliente();
                    ObjetoCliente.Id = IdCliente;
                    ObjetoCliente.Nombre = txtNombre.Text;
                    ObjetoCliente.Apellido = txtApellido.Text;
                    ObjetoCliente.CorreoElectronico = txtCorreoElectronico.Text;
                    ObjetoCliente.FechaNacimiento = dtpFechaNacimiento.Value;
                    ObjetoCliente.Direccion = txtDireccion.Text;
                    ObjetoCliente.Telefono = txtTelefono.Text;

                    Negocio.Cliente objNegocio = new Negocio.Cliente();
                    int resultado = objNegocio.Guardar(ObjetoCliente);

                    if(resultado > 0)
                    {
                        MessageBox.Show("Se guardo el cliente.");
                    }
                    else
                    {
                        MessageBox.Show("No se pudo registrar.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
