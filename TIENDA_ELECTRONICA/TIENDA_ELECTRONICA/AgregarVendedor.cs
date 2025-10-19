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
    public partial class AgregarVendedor : Form
    {
        private FormVendedores formVendedores;


        public AgregarVendedor(FormVendedores Formulario)
        {
            InitializeComponent();
            formVendedores = Formulario;

        }

        private void AgregarVendedor_Load(object sender, EventArgs e)
        {

        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            Vendedor objVendedor = new Vendedor();

            // Validar fecha si usas TextBox
            DateTime fechaIngreso;
            if (!DateTime.TryParse(txtFechaIngresoBox.Text, out fechaIngreso))
            {
                MessageBox.Show("Fecha inválida");
                return;
            }

            try
            {
                objVendedor.AgregarVendedor(
                    txtIdVendedorBox.Text.Trim(),
                    txtNombreBox.Text.Trim(),
                    txtApellidoBox.Text.Trim(),
                    txTelefonoBox.Text.Trim(),
                    txtCorreoBox.Text.Trim(),
                    fechaIngreso
                );

                MessageBox.Show("Vendedor agregado correctamente");
                formVendedores.llenarGrid(); // 🔄 Recarga la tabla en el formulario principal
                this.Close();

               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("¿Estás seguro de cancelar?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
