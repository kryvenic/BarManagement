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
    public partial class EliminarProducto : Form
    {
        public EliminarProducto()
        {
            InitializeComponent();
            ((DataGridViewImageColumn)dataGridView1.Columns[4]).ImageLayout = DataGridViewImageCellLayout.Stretch;
        }

        private void button1_Click(object sender, EventArgs e)
        {

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
                        int indice = 0; // Indice para las filas
                        //Añadir al datagrid
                        foreach (var i in list)
                        {
                            Image imagen = null;
                            if (i.Prod.Imagen != null)
                            {
                                imagen = Image.FromFile(i.Prod.Imagen);
                            }
                                dataGridView1.Rows.Add(i.Prod.Id_Producto, 
                                    i.Prod.Descripcion, i.Tipo.Descripcion, i.Prod.Precio, imagen);
                            if(i.Prod.Activado == 0)
                            {
                                dataGridView1.Rows[indice].DefaultCellStyle.BackColor = Color.Red;
                            }
                            indice += 1;
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
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                CheckBoxs.DesHabilitarCheckboxs(groupBox1);
            }
        }

        private void ResetearGrid()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            CheckBoxs.DesHabilitarCheckboxs(groupBox1);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int selectedRowCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
            //Lista utilizada para luego eliminar cada producto desde la base de datos
            List<int> ProductosAEliminar = new List<int>();

            //Si hay filas seleccionadas -> Recolectar filas seleccionadas
            if (selectedRowCount > 0)
            {
                //Recorre cada fila
                for (int i = 0; i < selectedRowCount; i++)
                {
                    //Añade a la lista
                    ProductosAEliminar.Add(int.Parse(dataGridView1.SelectedRows[i].Cells[0].Value.ToString()));
                }
            }
            //Eliminar de la base de datos las filas seleccionadas
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            result = MessageBox.Show("¿Esta seguro que quiere eliminar el/los producto/s? \n" +
                "Las bajas no se hacen la base de datos", "Confirmar baja", buttons, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                    using (InfobarEntities db = new InfobarEntities())
                    {
                        foreach (int id in ProductosAEliminar)
                        {
                            Producto productoAEliminar =
                                (from prod in db.Producto
                                 where prod.Id_Producto == id
                                 select prod).First();
                            productoAEliminar.Activado = 0;
                        }
                        db.SaveChanges();
                    }
                ResetearGrid();
            }

        }

        private void btnActivar_Click(object sender, EventArgs e)
        {
            int selectedRowCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
            //Lista utilizada para luego eliminar cada producto desde la base de datos
            List<int> ProductosActivar = new List<int>();

            //Si hay filas seleccionadas -> Recolectar filas seleccionadas
            if (selectedRowCount > 0)
            {
                //Recorre cada fila
                for (int i = 0; i < selectedRowCount; i++)
                {
                    //Añade a la lista
                    ProductosActivar.Add(int.Parse(dataGridView1.SelectedRows[i].Cells[0].Value.ToString()));
                }
            }
            //Eliminar de la base de datos las filas seleccionadas
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            result = MessageBox.Show("¿Esta seguro que quiere activar el producto? ", "Confirmar activacion", buttons, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                using (InfobarEntities db = new InfobarEntities())
                {
                    foreach (int id in ProductosActivar)
                    {
                        Producto productoAEliminar =
                            (from prod in db.Producto
                             where prod.Id_Producto == id
                             select prod).First();
                        productoAEliminar.Activado = 1;
                    }
                    db.SaveChanges();
                }
            }
            ResetearGrid();
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
                        int indice = 0; // Indice para las filas
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
    }
}
