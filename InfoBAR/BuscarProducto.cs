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
    public partial class BuscarProducto : Form
    {
        public BuscarProducto()
        {
            InitializeComponent();
            ((DataGridViewImageColumn)dataGridView1.Columns[3]).ImageLayout = DataGridViewImageCellLayout.Stretch;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
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

                        //Añadir al datagrid
                        foreach(var i in list)
                        {
                            Image imagen = null;
                            if(i.Prod.Imagen != null)
                            {
                                imagen = Image.FromFile(i.Prod.Imagen);
                            }
                            dataGridView1.Rows.Add(i.Prod.Descripcion, i.Tipo.Descripcion, i.Prod.Precio,imagen);
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

                        //Añadir al datagrid
                        foreach (var i in list)
                        {
                            Image imagen = null;
                            if (i.Prod.Imagen != null)
                            {
                                imagen = Image.FromFile(i.Prod.Imagen);
                            }
                            dataGridView1.Rows.Add(i.Prod.Descripcion, i.Tipo.Descripcion, i.Prod.Precio, imagen);
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
    }
}
