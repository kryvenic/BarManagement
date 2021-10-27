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

            if (VerificarCampos.VerificarCamposVacios(this))
            {
                MessageBox.Show("Debe rellenar/completar todos los campos", "Error: Campos Vacios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
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

            using (InfobarEntities db = new InfobarEntities())
            {
                Producto oProducto = new Producto();
                oProducto.Descripcion = "Hamburguesa";
                oProducto.Id_TipoProd = 1;
                oProducto.Precio = 2;
                oProducto.Imagen = "C:/Hamburguesa.jpg";
                db.Productoes.Add(oProducto);
                db.SaveChanges();
            }
            
        }

        private void VaciarCampos()
        {
            TDescripcion.Text = "";
            txtprecio.Text = "";
            CCategoria.SelectedIndex = -1;
            picImagen.Image = null;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Cancelar operacion? ", "Cancelar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
