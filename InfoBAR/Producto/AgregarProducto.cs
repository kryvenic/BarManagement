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

        private string PathImagen;
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
                PathImagen = open.FileName;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            errorProvider2.Clear();
            errorProvider3.Clear();
            errorProvider4.Clear();

            //Verificar cada campo si los tipos de datos son correctos
            if (!ValidandoNumerosYLetras()) return;

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
                    //Agregar a la base de datos
                    try
                    {
                        using (InfobarEntities db = new InfobarEntities())
                        {
                            Producto oProducto = new Producto();
                            oProducto.Id_Producto = int.Parse(txtId.Text);
                            oProducto.Id_TipoProd = CCategoria.SelectedIndex + 1;
                            oProducto.Descripcion = TDescripcion.Text;
                            oProducto.Precio = int.Parse(txtprecio.Text);
                            oProducto.Imagen = PathImagen;
                            oProducto.Activado = 1;
                            db.Producto.Add(oProducto);
                            db.SaveChanges();
                        }

                        MessageBox.Show("Producto: " + TDescripcion.Text + " agregado correctamente ", "Agregar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        VaciarCampos();
                    }
                    catch (System.Data.Entity.Infrastructure.DbUpdateException)
                    {
                        MessageBox.Show("El ID del producto ya podria existir en la base de datos (Error de guardado)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("No se agrego correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                }
            }
        }

        private void VaciarCampos()
        {
            txtId.Text = "";
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

        private void AgregarProducto_Load(object sender, EventArgs e)
        {

        }

        private bool ValidandoNumerosYLetras()
        {
            bool correcto = true;
            if (!VerificarCampos.SonNumeros(txtId))
            {
                errorProvider1.SetError(txtId, "Debe ingresar solo numeros.");
                correcto = false;
            }

            if (!VerificarCampos.SonNumeros(txtprecio))
            {
                errorProvider4.SetError(txtprecio, "Debe ingresar solo numeros.");
                correcto =  false;
            }

            if (CCategoria.SelectedIndex == -1)
            {
                errorProvider3.SetError(CCategoria, "No se selecciono categoria.");
                correcto = false;
            }
            return correcto;
        }
    }
}
