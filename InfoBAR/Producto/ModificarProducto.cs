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
    public partial class ModificarProducto : Form
    {
        private int IdProductoAModificar;
        private string PathImagen;
        public ModificarProducto(int IdProductoAModificar)
        {
            InitializeComponent();
            //Si no se selecciono correctamente el producto sera -1 o menor a 0, por lo que tira error
            if(IdProductoAModificar <= 0)
            {
                MessageBox.Show("Id Invalido del producto a Modificar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                InfoBAR.openChildForm(new BuscarProducto());
            }
            else
            {
                //Traer datos usando el id pasado por parametro
                this.IdProductoAModificar = IdProductoAModificar;
                TraerDatosDeBase();
            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Cancelar operacion? ", "Cancelar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (VerificarCampos.VerificarCamposVacios(this) && PathImagen.Equals(""))
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
                    //Modificar a la base de datos
                    try
                    {
                        using (InfobarEntities db = new InfobarEntities())
                        {
                            Producto oProducto = (from prod in db.Producto
                                                 where prod.Id_Producto == IdProductoAModificar
                                                 select prod).First();
                            oProducto.Id_Producto = int.Parse(TId.Text);
                            oProducto.Id_TipoProd = CCategoria.SelectedIndex + 1;
                            oProducto.Descripcion = TDescripcion.Text;
                            oProducto.Precio = decimal.Parse(TPrecio.Text);
                            oProducto.Imagen = PathImagen;
                            db.SaveChanges();
                        }

                        MessageBox.Show("Producto  " + TDescripcion.Text + " modificado correctamente ", "Modificar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        InfoBAR.openChildForm(new BuscarProducto());
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("No se agrego correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }

        private void TraerDatosDeBase()
        {
            try
            {
                using (InfobarEntities db = new InfobarEntities())
                {
                    Producto oProducto = new Producto();

                    //Traer todos los productos con categoria
                    var list = from prod in db.Producto
                               join tipo in db.TipoProducto on prod.Id_TipoProd equals tipo.Id_TipoProd
                               where prod.Id_Producto == IdProductoAModificar
                               select new
                               {
                                   //Necesario para hacer el foreach
                                   Prod = prod,
                                   Tipo = tipo
                               };

                    //Añadir al datagrid
                    foreach (var p in list)
                    {
                        Image imagen = null;
                        if (p.Prod.Imagen != null)
                        {
                            imagen = Image.FromFile(p.Prod.Imagen);
                            picImagen.Image = imagen;
                        }
                        PathImagen = p.Prod.Imagen;
                        TId.Text = p.Prod.Id_Producto.ToString();
                        TDescripcion.Text = p.Prod.Descripcion;
                        CCategoria.SelectedIndex = p.Tipo.Id_TipoProd - 1;
                        TPrecio.Text = p.Prod.Precio.ToString();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo traer de la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.InitialDirectory = @"C:\";
            open.Filter = "Image Files|*.jpeg;*.png;*.bmp;*.jpg";

            if (open.ShowDialog() == DialogResult.OK)
            {
                picImagen.Image = Image.FromFile(open.FileName);
                MessageBox.Show("Se ha agregado la imagen: " + open.FileName, " Subido exitosamente!");
                PathImagen = open.FileName;
            }
        }
    }
}
