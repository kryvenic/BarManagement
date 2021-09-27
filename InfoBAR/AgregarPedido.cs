using InfoBAR.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InfoBAR
{
    public partial class AgregarPedido : Form
    {
        public AgregarPedido()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void AgregarPedido_Load(object sender, EventArgs e)
        {
            ValoresEstaticos.AgregarProductosDatagrid(dataGridView1);
        }

        private void btnEnlistar_Click(object sender, EventArgs e)
        {
            if (!VerificarCampos.VerificarCamposVacios(groupPedido))
            {
                dataGridView1.Rows.Add(txtNombre.Text, cboTipo.Text, txtCantidad.Text);
            }
            else
            {
                MessageBox.Show("Debe rellenar/completar todos los campos", "Error: Campos Vacios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if(dataGridView1.Rows.Count > 0)
            {
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                result = MessageBox.Show("¿Quiere agregar el pedido?", "Confirmar pedido", buttons, MessageBoxIcon.Question);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    dataGridView1.Rows.Clear();
                    MessageBox.Show("Pedido agregado correctamente ", "Agregar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("No hay comidas/bebidas agregadas al pedido", "Error: No hay productos agregados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
