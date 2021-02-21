using Entidades;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Almacen
{
    public partial class frmMarca : Form
    {
        public frmMarca()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Marca ObjetoMarca = new Marca();
                ObjetoMarca.NombreMarca = txtMarca.Text;

                Negocio.Marca objN = new Negocio.Marca();
                int resultado = objN.Guardar(ObjetoMarca);

                if(resultado > 0)
                {
                    MessageBox.Show("Se registro la Marca correctamente");
                }
                else
                {
                    MessageBox.Show("No se pudo guardar la Marca");
                }
            }
            catch (Exception ex)
            {
            }
        }
        private void CargarGrillaMarcas()
        {
            try
            {
                //Negocio.Marca objN = new Negocio.Marca();
                //List<Marca> resultado = objN.Cargar(ObjetoMarca);
                dgvMarcas.AutoGenerateColumns = true;
                dgvMarcas.DataSource = null;
                dgvMarcas.Refresh();
            }
            catch (Exception ex)
            {
            }
        }
    }
}
