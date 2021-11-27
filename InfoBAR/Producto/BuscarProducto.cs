using InfoBAR.Utilidades;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Linq;

namespace InfoBAR
{
    public partial class BuscarProducto : Form
    {

        private int IdProductoAModificar;
        public BuscarProducto()
        {
            IdProductoAModificar = -1;
            InitializeComponent();
            ((DataGridViewImageColumn)dataGridView1.Columns[4]).ImageLayout = DataGridViewImageCellLayout.Stretch;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                dataGridView1.Rows.Clear();
                //Buscar en la based de datos
                try
                {
                    using (InfobarEntities db = new InfobarEntities())
                    {
                        Producto oProducto = new Producto();

                        //Traer todos los productos con categoria
                        var list = from prod in db.Producto
                                   join tipo in db.TipoProducto on prod.Id_TipoProd equals tipo.Id_TipoProd
                                   select new
                                   {
                                       //Necesario para hacer el foreach
                                       Prod = prod,
                                       Tipo = tipo
                                   };
                        int indice = 0;
                        //Añadir al datagrid
                        foreach (var i in list)
                        {
                            Image imagen = null;
                            if (i.Prod.Imagen != null)
                            {
                                imagen = Image.FromFile(i.Prod.Imagen);
                            }
                            dataGridView1.Rows.Add(i.Prod.Id_Producto, i.Prod.Descripcion, i.Tipo.Descripcion, i.Prod.Precio, imagen);
                            if (i.Prod.Activado == 0)
                            {
                                dataGridView1.Rows[indice].DefaultCellStyle.BackColor = Color.Red;
                            }
                        }
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("No se pudo traer los productos de la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                ResetearGrid();
            }
        }

        private void chkTipo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTipo.Checked)
            {
                dataGridView1.Rows.Clear();
                //Buscar en la based de datos
                try
                {
                    using (InfobarEntities db = new InfobarEntities())
                    {
                        Producto oProducto = new Producto();

                        //Traer todos los productos con categoria
                        var list = from prod in db.Producto
                                   join tipo in db.TipoProducto on prod.Id_TipoProd equals tipo.Id_TipoProd
                                   where tipo.Id_TipoProd == (cboTipo.SelectedIndex + 1)
                                   select new
                                   {
                                       //Necesario para hacer el foreach
                                       Prod = prod,
                                       Tipo = tipo
                                   };
                        int indice = 0;
                        //Añadir al datagrid
                        foreach (var i in list)
                        {
                            Image imagen = null;
                            if (i.Prod.Imagen != null)
                            {
                                imagen = Image.FromFile(i.Prod.Imagen);
                            }
                            dataGridView1.Rows.Add(i.Prod.Id_Producto, i.Prod.Descripcion, i.Tipo.Descripcion, i.Prod.Precio, imagen);
                            if (i.Prod.Activado == 0)
                            {
                                dataGridView1.Rows[indice].DefaultCellStyle.BackColor = Color.Red;
                            }
                        }
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("No se pudo traer los productos de la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                ResetearGrid();
            }
        }

        private void ResetearGrid()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            CheckBoxs.DesHabilitarCheckboxs(groupBox1);
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {


        }

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            dataGridView1.Rows.Clear();
            if (e.KeyCode == Keys.Enter)
            {
                BuscarPorNombre();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int selectedRowCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
            //Seleccionar una sola
            if (selectedRowCount > 0 && selectedRowCount <= 1)
            {
                //Añade a la lista
                IdProductoAModificar = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                InfoBAR.openChildForm(new ModificarProducto(IdProductoAModificar));
            }
            else
            {
                //TODO Mensaje de que solo se puede seleccionar una sola fila
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            if (txtNombre.TextLength != 0)
            {
                BuscarPorNombre();
            }
        }

        private void BuscarPorNombre()
        {
            //Buscar en la based de datos
            try
            {
                using (InfobarEntities db = new InfobarEntities())
                {
                    Producto oProducto = new Producto();
                    //Traer el producto con el nombre
                    var prodBuscado = (from prod in db.Producto
                                       join tipo in db.TipoProducto on prod.Id_TipoProd equals tipo.Id_TipoProd
                                       where prod.Descripcion.Contains(txtNombre.Text)
                                       select new
                                       {
                                           Prod = prod,
                                           Tipo = tipo
                                       }).FirstOrDefault();
                    if (prodBuscado == null)
                    {
                        MessageBox.Show("No se encontro el producto", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    //Añadir al datagrid
                    Image imagen = null;
                    if (prodBuscado.Prod.Imagen != null)
                    {
                        imagen = Image.FromFile(prodBuscado.Prod.Imagen);
                    }
                    dataGridView1.Rows.Add(prodBuscado.Prod.Id_Producto, prodBuscado.Prod.Descripcion,
                        prodBuscado.Tipo.Descripcion, prodBuscado.Prod.Precio, imagen);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo traer los productos de la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
