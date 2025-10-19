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
    public partial class FORMODIFICAR : Form
    {
        private string idVendedor;
        private string _idOriginal;
        private FormVendedores _formVendedores;

        public FORMODIFICAR(FormVendedores formVendedores, string id)
        {
            InitializeComponent();

            this._formVendedores = formVendedores;
            this.idVendedor = id;

            CargarDatosVendedor();
        }

        private void CargarDatosVendedor()
        {
            Vendedor objVendedor = new Vendedor();
            DataTable dt = objVendedor.ListarVendedor(idVendedor);

            if (dt.Rows.Count > 0)
            {
                txtIdVendedor.Text = dt.Rows[0]["IDVENDEDOR"].ToString();
                txtNombre.Text = dt.Rows[0]["Nombre"].ToString();
                txtApellido.Text = dt.Rows[0]["Apellido"].ToString();
                txtTelefono.Text = dt.Rows[0]["Telefono"].ToString();
                txtCorreo.Text = dt.Rows[0]["Correo"].ToString();
                txtFechaIngreso.Text = dt.Rows[0]["FechaIngreso"].ToString();

                txtIdVendedor.ReadOnly = true; // ID no editable

                _idOriginal = dt.Rows[0]["IDVENDEDOR"].ToString();
            }
        }

        private void FORMODIFICAR_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(_idOriginal))
            {
                MessageBox.Show("Error: ID original no cargado correctamente.");
                return;
            }

            Vendedor v = new Vendedor();

            DateTime fechaIngreso;
            if (!DateTime.TryParse(txtFechaIngreso.Text, out fechaIngreso))
            {
                MessageBox.Show("Fecha inválida");
                return;
            }

            v.ModificarVendedor(
                _idOriginal,
                txtNombre.Text,
                txtApellido.Text,
                txtTelefono.Text,
                txtCorreo.Text,
                fechaIngreso
            );

            _formVendedores.llenarGrid();
            this.Close();
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("¿Estás seguro de cancelar?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void txtIdVendedor_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
