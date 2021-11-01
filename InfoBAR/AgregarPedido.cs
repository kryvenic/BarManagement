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
            ValoresEstaticos.AgregarProductosDatagrid(gridPedido);
        }

        private void btnEnlistar_Click(object sender, EventArgs e)
        {
            int selectedRowCount = gridProductos.Rows.GetRowCount(DataGridViewElementStates.Selected);
            //Hay filas seleccionadas
            if (selectedRowCount > 0)
            {
                //Recorre cada fila
                for (int i = 0; i < selectedRowCount; i++)
                {
                    //Guarda los valores por fila
                    List<string> valoresPorFila = new List<string>();
                    //Recorre cada valor de celda
                    for(int j = 0; j < gridProductos.ColumnCount; j++)
                    {
                        //Añade
                        valoresPorFila.Add(gridProductos.SelectedRows[i].Cells[j].Value.ToString());
                    }
                    AgregarAlDatagrid(valoresPorFila);
                    //Limpia la lista
                    valoresPorFila.Clear();
                }
            }
        }

        private void AgregarAlDatagrid(List<string> valoresPorFila)
        {
            if (txtCantidad.Text.Equals("")) return;
            gridPedido.Rows.Add(valoresPorFila[0], valoresPorFila[1], txtCantidad.Text,
                float.Parse(valoresPorFila[3]) * float.Parse(txtCantidad.Text));
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if(gridPedido.Rows.Count > 0)
            {
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                result = MessageBox.Show("¿Quiere agregar el pedido?", "Confirmar pedido", buttons, MessageBoxIcon.Question);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    gridPedido.Rows.Clear();
                    MessageBox.Show("Pedido agregado correctamente ", "Agregar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("No hay comidas/bebidas agregadas al pedido", "Error: No hay productos agregados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
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
                        foreach (var i in list)
                        {
                            Image imagen = null;
                            if (i.Prod.Imagen != null)
                            {
                                imagen = Image.FromFile(i.Prod.Imagen);
                            }
                            gridProductos.Rows.Add(i.Prod.Id_Producto,i.Prod.Descripcion, i.Tipo.Descripcion, i.Prod.Precio, imagen);
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
                            gridProductos.Rows.Add(i.Prod.Id_Producto,i.Prod.Descripcion, i.Tipo.Descripcion, i.Prod.Precio, imagen);
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

        private void chkNombre_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ResetearGrid()
        {
            gridPedido.Rows.Clear();
            gridPedido.Refresh();
            CheckBoxs.DesHabilitarCheckboxs(groupBox1);
        }
    }
}
