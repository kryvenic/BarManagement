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
    public partial class AgregarProducto : Form
    {
        public AgregarProducto()
        {
            InitializeComponent();
        }

        private void btnImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.InitialDirectory = @"C:\";
            open.Filter = "Image Files|*.jpeg;*.png;*.bmp;*.jpg";

            if (open.ShowDialog() == DialogResult.OK)
            {
                picImagen.Image = Image.FromFile(open.FileName);
                MessageBox.Show("Se ha agregado la imagen: " + open.FileName, "Subido exitosamente!");
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            result = MessageBox.Show("¿Quiere agregar el producto?: " + TDescripcion.Text, "Confirmar alta", buttons, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                MessageBox.Show("Producto: " + TDescripcion.Text + " agregado correctamente ", "Agregar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                VaciarCampos();
            }
        }

        private void VaciarCampos()
        {
            TDescripcion.Text = "";
            CCategoria.SelectedIndex = -1;
            picImagen.Image = null;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Cancelar operacion? " + TDescripcion.Text, "Cancelar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
