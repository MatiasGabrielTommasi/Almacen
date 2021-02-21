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
        Cliente objCliente;
        public frmClientes(Cliente objCliente)
        {
            InitializeComponent();

            this.objCliente = objCliente;
            if(objCliente.Id > 0)
            {
                CargarDatosCliente();
            }
        }

        private void CargarDatosCliente()
        {
            try
            {
                txtApellido.Text = this.objCliente.Apellido;
                txtCorreoElectronico.Text = this.objCliente.CorreoElectronico;
                txtDireccion.Text = this.objCliente.Direccion;
                txtNombre.Text = this.objCliente.Nombre;
                txtTelefono.Text = this.objCliente.Telefono;
                dtpFechaNacimiento.Value = this.objCliente.FechaNacimiento;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
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
                    objCliente.Nombre = txtNombre.Text;
                    objCliente.Apellido = txtApellido.Text;
                    objCliente.CorreoElectronico = txtCorreoElectronico.Text;
                    objCliente.FechaNacimiento = dtpFechaNacimiento.Value;
                    objCliente.Direccion = txtDireccion.Text;
                    objCliente.Telefono = txtTelefono.Text;

                    Negocio.Cliente objNegocio = new Negocio.Cliente();
                    int resultado = 0;
                    
                    if(objCliente.Id == 0)
                    {
                        resultado = objNegocio.Guardar(objCliente);
                    }
                    else
                    {
                        resultado = objNegocio.Actualizar(objCliente);
                    }

                    if(resultado > 0)
                    {
                        MessageBox.Show("Se guardo el cliente.");
                        this.Close();
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
