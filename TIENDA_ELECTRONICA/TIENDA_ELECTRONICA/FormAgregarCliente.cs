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
    public partial class FormAgregarCliente : Form
    {

        private FormCliente formCliente;
        public FormAgregarCliente(FormCliente formulario)
        {
            InitializeComponent();

            formCliente = formulario;

        }

        private void FormAgregarCliente_Load(object sender, EventArgs e)
        {

        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("¿Estás seguro de cancelar?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btn_Aceptar_Click(object sender, EventArgs e)
        {
            Ciente objCliente = new Ciente();

            try
            {
                objCliente.AgregarCliente(
                    txtIdCliente.Text.Trim(),
                    txtNombre.Text.Trim(),
                    txtApellido.Text.Trim(),
                    txtTelefono.Text.Trim(),
                    txtCorreo.Text.Trim(),
                    txtDireccion.Text.Trim()
                );

                MessageBox.Show("Cliente agregado correctamente");

                formCliente.llenarGrid(); // 🔄 Refresca la tabla
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
