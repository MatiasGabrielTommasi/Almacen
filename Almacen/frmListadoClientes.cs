using Entidades;
using System.Collections.Generic;
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
        private void CargarGrillaClientes()
        {
            List<Entidades.Cliente> ListaClientes = new List<Entidades.Cliente>();
            Negocio.Cliente objetoNegocio = new Negocio.Cliente();
            ListaClientes = objetoNegocio.Cargar();

            dgvClientes.AutoGenerateColumns = true;
            dgvClientes.DataSource = ListaClientes;
            dgvClientes.Refresh();
        }
    }
}
