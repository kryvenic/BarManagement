using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practico3
{
    public partial class PequenioFormulario : Form
    {
        public PequenioFormulario()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void LModificar_Click(object sender, EventArgs e)
        {

        }

        private void PequenioFormulario_Load(object sender, EventArgs e)
        {

        }

        private void BGuardar_Click(object sender, EventArgs e)
        {
            bool vacio = false;
            foreach(Control c in this.Controls)
            {
                if(c is TextBox && String.IsNullOrWhiteSpace(c.Text))
                {
                    vacio = true;
                }
            }
            if (vacio)
            {
                MessageBox.Show("Debes completar todos los campos", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                LModificar.Text = TApellido.Text + " " + TNombre.Text;
            }
        }

        private void TDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)){
                e.Handled = true;
            }
        }

        private void TApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void TNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void BEliminar_Click(object sender, EventArgs e)
        {
            LModificar.Text = "Modificar";
        }
    }
}
