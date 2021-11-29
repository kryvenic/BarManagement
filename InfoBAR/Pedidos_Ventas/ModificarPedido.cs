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
    public partial class ModificarPedido : Form
    {
        private int IdPedidoAModificar;
        private string PathImagen;
        public ModificarPedido(int IdPedidoAModificar)
        {
            InitializeComponent();
            //Si no se selecciono correctamente el producto sera -1 o menor a 0, por lo que tira error
            if (IdPedidoAModificar <= 0)
            {
                MessageBox.Show("Id Invalido del producto a Modificar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                InfoBAR.openChildForm(new BuscarProducto());
            }
            else
            {
                //Traer datos usando el id pasado por parametro
                this.IdPedidoAModificar = IdPedidoAModificar;
                TraerListaDePedidos();
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
            if (gridPedido.Rows.Count > 0)
            {
                ModificarPedidoEnBase();
            }
            else
            {
                MessageBox.Show("No hay comidas/bebidas agregadas al pedido", "Error: No hay productos agregados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ModificarPedidoEnBase()
        {
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            result = MessageBox.Show("¿Quiere modificar el pedido?: ", "Confirmar modificacion", buttons, MessageBoxIcon.Question);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                //Modificar a la base de datos
                try
                {
                    using (InfobarEntities db = new InfobarEntities())
                    {
                        var detallesAEliminar = (from deta in db.Detalle_Pedido
                                                 where deta.Id_Pedido == IdPedidoAModificar
                                                 select deta).ToList();
                        if (detallesAEliminar != null && detallesAEliminar.Count > 0)
                        {
                            db.Detalle_Pedido.RemoveRange(detallesAEliminar);
                            db.SaveChanges();
                        }
                    }

                    using (InfobarEntities db = new InfobarEntities())
                    {
                        foreach (DataGridViewRow row in gridPedido.Rows)
                        {
                            Detalle_Pedido oDetalle = new Detalle_Pedido();
                            int IDProducto = int.Parse(row.Cells[0].Value.ToString());
                            int Cantidad = int.Parse(row.Cells[2].Value.ToString());
                            decimal Precio = decimal.Parse(row.Cells[3].Value.ToString());
                            decimal PrecioTotal = (decimal.Parse(row.Cells[3].Value.ToString()) * Cantidad);

                            oDetalle.Id_Pedido = IdPedidoAModificar;
                            // Celda del Id
                            oDetalle.Id_Prod = IDProducto;
                            // Cantidad
                            oDetalle.Cantidad = Cantidad;
                            // Importe
                            oDetalle.Precio = Precio;
                            oDetalle.PrecioTotal = PrecioTotal;
                            db.Detalle_Pedido.Add(oDetalle);
                        }
                        db.SaveChanges();

                    }

                    MessageBox.Show("Pedido modificado correctamente. ", "Modificar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    InfoBAR.openChildForm(new RegistrarPago());
                }
                catch (Exception)
                {
                    MessageBox.Show("No se agrego correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }



        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                gridProductos.Rows.Clear();
                //Buscar en la based de datos
                try
                {
                    using (InfobarEntities db = new InfobarEntities())
                    {
                        Producto oProducto = new Producto();

                        //Traer todos los productos con categoria
                        var list = from prod in db.Producto
                                   join tipo in db.TipoProducto on prod.Id_TipoProd equals tipo.Id_TipoProd
                                   where prod.Activado == 1
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
                            gridProductos.Rows.Add(i.Prod.Id_Producto, i.Prod.Descripcion, i.Tipo.Descripcion, i.Prod.Precio, imagen);
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
                ResetearGridProductos();
            }
        }

        private void ResetearGridProductos()
        {
            gridProductos.Rows.Clear();
            gridProductos.Refresh();
            CheckBoxs.DesHabilitarCheckboxs(groupBox1);
        }
        /// <summary>
        /// Sumatoria de todos los importes
        /// </summary>
        /// <returns></returns>
        private float CalcularImporteTotal()
        {
            float importeTotal = 0f;
            foreach (DataGridViewRow row in gridPedido.Rows)
            {
                importeTotal += float.Parse(row.Cells["Importe"].Value.ToString());
            }
            return importeTotal;
        }

        private void chkTipo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTipo.Checked)
            {
                gridProductos.Rows.Clear();
                //Buscar en la based de datos
                try
                {
                    using (InfobarEntities db = new InfobarEntities())
                    {
                        Producto oProducto = new Producto();

                        //Traer todos los productos con categoria
                        var list = from prod in db.Producto
                                   join tipo in db.TipoProducto on prod.Id_TipoProd equals tipo.Id_TipoProd
                                   where tipo.Id_TipoProd == (cboTipo.SelectedIndex + 1) && prod.Activado == 1
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
                            gridProductos.Rows.Add(i.Prod.Id_Producto, i.Prod.Descripcion, i.Tipo.Descripcion, i.Prod.Precio, imagen);
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
                ResetearGridProductos();
            }
        }


        private void gridPedido_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            lblTotal.Text = CalcularImporteTotal().ToString();
        }

        private void AgregarAlDatagridPedido(List<string> valoresPorFila)
        {
            if (txtCantidad.Text.Equals("")) return;
            gridPedido.Rows.Add(valoresPorFila[0], valoresPorFila[1], txtCantidad.Text, float.Parse(valoresPorFila[3]),
                float.Parse(valoresPorFila[3]) * float.Parse(txtCantidad.Text));
            lblTotal.Text = CalcularImporteTotal().ToString();
        }

        /// <summary>
        /// Verifica si el pedido ya ha sido agregado al datagrid pedido y devuelve
        /// el index para modificar luego la fila.
        /// </summary>
        /// <param name="compararId"></param>
        /// <returns></returns>
        private int IdEnDatagridPedido(int compararId)
        {
            foreach (DataGridViewRow row in gridPedido.Rows)
            {
                if (int.Parse(row.Cells[0].Value.ToString()) == compararId)
                {
                    return row.Index;
                }
            }
            return -1;
        }

        private void ActualizarDatagridPedido(int filaIndex, int cantidadNueva)
        {
            if (txtCantidad.Text.Equals("")) return;
            gridPedido.Rows[filaIndex].Cells["Cantidad"].Value = cantidadNueva;
            lblTotal.Text = CalcularImporteTotal().ToString();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
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
                    for (int j = 0; j < gridProductos.ColumnCount; j++)
                    {
                        //Añade
                        valoresPorFila.Add(gridProductos.SelectedRows[i].Cells[j].Value.ToString());
                    }
                    //Si el mismo producto ya esta en la lista, modificar solo su cantidad
                    int IndexFila = IdEnDatagridPedido(int.Parse(valoresPorFila[0]));
                    //El producto esta en la lista
                    if (IndexFila != -1)
                    {
                        ActualizarDatagridPedido(IndexFila, int.Parse(txtCantidad.Text));
                    }
                    else //No esta, agregar nuevo
                    {
                        AgregarAlDatagridPedido(valoresPorFila);

                    }
                    //Limpia la lista temporal
                    valoresPorFila.Clear();
                }
            }
        }
        private void TraerListaDePedidos()
        {

            using (InfobarEntities db = new InfobarEntities())
            {
                //Traer todas las ventas/pedidos por fechas desde hasta
                var detallePedido = from deta in db.Detalle_Pedido
                                    join prod in db.Producto on deta.Id_Prod equals prod.Id_Producto
                                    where deta.Id_Pedido == IdPedidoAModificar
                                    select new
                                    {
                                        Detalle = deta,
                                        Producto = prod,
                                    };
                //Detalle del pedido
                foreach (var p in detallePedido)
                {
                    gridPedido.Rows.Add(p.Producto.Id_Producto, p.Producto.Descripcion, p.Detalle.Cantidad, p.Detalle.Precio, p.Detalle.PrecioTotal);
                }
            }


        }
    }//Clase
}//Namespace
