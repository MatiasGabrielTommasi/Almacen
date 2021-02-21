using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Almacen
{
    public partial class frmListadoClientes : Form
    {
        public frmListadoClientes()
        {
            InitializeComponent();
            CargarGrillaClientes();
        }
        private void CargarGrillaClientes(string apellido = "", string telefono = "")
        {
            List<Entidades.Cliente> ListaClientes = new List<Entidades.Cliente>();
            Negocio.Cliente objetoNegocio = new Negocio.Cliente();
            ListaClientes = objetoNegocio.Buscar(apellido, telefono);

            dgvClientes.AutoGenerateColumns = true;
            dgvClientes.DataSource = ListaClientes;
            dgvClientes.Refresh();


            if (ListaClientes.Count == 0)
            {
                MessageBox.Show("No se encontro ningún cliente con los filtros indicados.");
            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string apellido = txtBuscarApellido.Text;
                string telefono = txtBuscarTelefono.Text;

                CargarGrillaClientes(apellido, telefono);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            try
            {
                //TODO Mostrar formulario nuevo cliente
                Cliente objCliente = new Cliente();
                frmClientes frm = new frmClientes(objCliente);
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //TODO Modificar o Eliminar Cliente
                Cliente objCliente = null;
                switch (e.ColumnIndex)
                {
                    case 0:
                        //Modificar
                        objCliente = (Cliente) dgvClientes.Rows[e.RowIndex].DataBoundItem;
                        frmClientes frm = new frmClientes(objCliente);
                        frm.Show();
                        break;
                    case 1:
                        //Eliminar
                        objCliente = (Cliente)dgvClientes.Rows[e.RowIndex].DataBoundItem;
                        string mensaje = "Está seguro de eliminar a " + objCliente.Nombre + " alguien de los registros?";
                        DialogResult confirmacion = MessageBox.Show(mensaje, "Atencion!", MessageBoxButtons.YesNo);
                        if(confirmacion == DialogResult.Yes)
                        {
                            Negocio.Cliente objNegocio = new Negocio.Cliente();
                            int resultado = objNegocio.Eliminar(objCliente.Id);
                            if(resultado == 0)
                            {
                                MessageBox.Show("No se pudo eliminar a " + objCliente.Nombre);
                            }
                            else
                            {
                                MessageBox.Show(objCliente.Nombre + " fue eliminado correctamente");
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
