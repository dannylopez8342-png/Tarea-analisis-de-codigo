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
    
    public partial class FormCliente : Form
    {

        
        public FormCliente()
        {
            InitializeComponent();

            llenarGrid();
        }

        public void llenarGrid()
        {
            Ciente objCiente = new Ciente();
            DataTable mDatos = new DataTable();
            mDatos = objCiente.ListarCliente("");

            dgCliente.AutoGenerateColumns = true;
            dgCliente.DataSource = mDatos;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            
            

                FormModificarCliente frm = new FormModificarCliente(this,"", false);
                frm.Show();
            
           
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgCliente.CurrentRow != null)
            {
                string IdCliente = dgCliente.CurrentRow.Cells["IdCliente"].Value.ToString();

                var confirmar = MessageBox.Show($"¿Estás seguro de eliminar al Cliente con ID: {IdCliente}?",
                                                "Confirmar eliminación",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Warning);

                if (confirmar == DialogResult.Yes)
                {
                    Ciente objCliente = new Ciente();
                    objCliente.EliminarCliente(IdCliente);

                    MessageBox.Show("Cliente eliminado correctamente.");
                    llenarGrid(); // Refresca la tabla
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un Cliente primero.");
            }
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgCliente.SelectedRows.Count > 0)
            {
                string id = dgCliente.SelectedRows[0].Cells["IdCliente"].Value.ToString();

                FormModificarCliente frm = new FormModificarCliente(this, id,true);
                frm.Show(); 
            }
            else
            {
                MessageBox.Show("Selecciona un Cliente para modificar.");
            }
        }

        private void FormCliente_Load(object sender, EventArgs e)
        {

        }
    }
}
