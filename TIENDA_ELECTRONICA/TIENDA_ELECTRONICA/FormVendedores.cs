using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TIENDA_ELECTRONICA
{
    public partial class FormVendedores : Form
    {
        public FormVendedores()
        {
            InitializeComponent();

            llenarGrid();
        }

        public void llenarGrid()
        {
            Vendedor objVendedor = new Vendedor();
            DataTable mDatos = new DataTable();
            mDatos = objVendedor.ListarVendedor("");

            dgVendedores.AutoGenerateColumns = true;
            dgVendedores.DataSource = mDatos;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AgregarVendedor frm = new AgregarVendedor(this); // PASAMOS el formulario padre
            frm.Show();
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgVendedores.SelectedRows.Count > 0)
            {
                string id = dgVendedores.SelectedRows[0].Cells["IDVENDEDOR"].Value.ToString();
                FORMODIFICAR frm = new FORMODIFICAR(this, id);
                frm.Show();
            }
            else
            {
                MessageBox.Show("Selecciona un vendedor para modificar.");
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
                if (dgVendedores.CurrentRow != null)
                {
                    string idVendedor = dgVendedores.CurrentRow.Cells["IDVENDEDOR"].Value.ToString();

                    var confirmar = MessageBox.Show($"¿Estás seguro de eliminar al vendedor con ID: {idVendedor}?",
                                                    "Confirmar eliminación",
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Warning);

                    if (confirmar == DialogResult.Yes)
                    {
                        Vendedor objVendedor = new Vendedor();
                        objVendedor.EliminarVendedor(idVendedor);

                        MessageBox.Show("Vendedor eliminado correctamente.");
                        llenarGrid(); // Refresca la tabla
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona un vendedor primero.");
                }
            }
    }
}
