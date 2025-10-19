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
    public partial class FrmIniciocs : Form
    {
        public FrmIniciocs()
        {
            InitializeComponent();
        }

        private void vendedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormVendedores frm = new FormVendedores();
            frm.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCliente frm = new FormCliente();
            frm.Show();
        }
    }
}
