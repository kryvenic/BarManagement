using InfoBAR.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InfoBAR
{
    public partial class ReporteVentas : Form
    {
        private int IdPedidoSeleccionado;
        public ReporteVentas()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Todas las ventas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTodas.Checked)
            {
                dataGridView1.Rows.Clear();
                //Buscar en la based de datos
                try
                {
                    using (InfobarEntities db = new InfobarEntities())
                    {
                        //Traer todas las ventas/pedidos con tipo de pago y usuario
                        var pedidosYDetalles = from pedi in db.Pedido
                                               join tipo in db.TipoPago on pedi.Id_TipoPago equals tipo.Id_TipoPago into PedidoPago
                                               from pdp in PedidoPago.DefaultIfEmpty()
                                               join user in db.Usuario on pedi.Id_Usuario equals user.Id
                                               select new
                                               {
                                                   Pedido = pedi,
                                                   PagoPedido = pdp,
                                                   Usuario = user
                                               };
                        //Verificar si no se encontraron pedidos
                        if (pedidosYDetalles.Any())
                        {
                            //Añadir al datagrid
                            foreach (var i in pedidosYDetalles)
                            {
                                var tipopago = "";
                                if (i.PagoPedido == null)
                                {
                                    tipopago = "No Pagado";
                                }
                                else
                                {
                                    tipopago = i.PagoPedido.Descripcion;
                                }
                                dataGridView1.Rows.Add(i.Pedido.Id_Pedido, tipopago, i.Pedido.Mesa, i.Pedido.Importe_Total, i.Usuario.Nombre, i.Pedido.Fecha);
                            }
                        }
                        else
                        {
                            MessageBox.Show("No se encontraron pedidos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        private void chkTipo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTipo.Checked)
            {
                dataGridView1.Rows.Clear();
                //Buscar en la base de datos
                try
                {
                    using (InfobarEntities db = new InfobarEntities())
                    {
                        //Traer todas las ventas/pedidos por tipo de pago
                        var pedidosYDetalles = from pedi in db.Pedido
                                               join tipo in db.TipoPago on pedi.Id_TipoPago equals tipo.Id_TipoPago into PedidoPago
                                               from pdp in PedidoPago.DefaultIfEmpty()
                                               join user in db.Usuario on pedi.Id_Usuario equals user.Id
                                               where pdp.Id_TipoPago == cboTipo.SelectedIndex + 1
                                               select new
                                               {
                                                   Pedido = pedi,
                                                   PagoPedido = pdp,
                                                   Total = pdp.Pedido.Sum(pedi => pedi.Importe_Total).ToString(),
                                                   Usuario = user
                                               };
                        //Verificar si no se encontraron pedidos
                        if(pedidosYDetalles.Any())
                        {
                            //Añadir al datagrid
                            foreach (var i in pedidosYDetalles)
                            {
                                var tipopago = "";
                                if (i.PagoPedido == null)
                                {
                                    tipopago = "No Pagado";
                                }
                                else
                                {
                                    tipopago = i.PagoPedido.Descripcion;
                                }
                                dataGridView1.Rows.Add(i.Pedido.Id_Pedido, tipopago, i.Pedido.Mesa, i.Pedido.Importe_Total, i.Usuario.Nombre, i.Pedido.Fecha);
                            }
                            //Mostrar total
                            lblRecaudado.Text = pedidosYDetalles.FirstOrDefault().Total;
                        }
                        else
                        {
                            MessageBox.Show("No se encontraron pedidos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Por Fecha
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkFecha_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFecha.Checked)
            {
                dataGridView1.Rows.Clear();
                //Buscar en la base de datos
                try
                {
                    using (InfobarEntities db = new InfobarEntities())
                    {
                        //Traer todas las ventas/pedidos por fecha
                        var pedidosYDetalles = from pedi in db.Pedido
                                               join tipo in db.TipoPago on pedi.Id_TipoPago equals tipo.Id_TipoPago into PedidoPago
                                               from pdp in PedidoPago.DefaultIfEmpty()
                                               join user in db.Usuario on pedi.Id_Usuario equals user.Id
                                               where pedi.Fecha == dateFecha.Value.Date
                                               select new
                                               {
                                                   Pedido = pedi,
                                                   PagoPedido = pdp,
                                                   Usuario = user
                                               };

                        var total = from pedi in db.Pedido
                                    where pedi.Fecha == dateFecha.Value.Date && pedi.Id_TipoPago != null
                                    group pedi by pedi.Fecha into pdf
                                    select new
                                    {
                                        Total = pdf.Sum(pedi => pedi.Importe_Total).ToString()
                                    };
                        //Verificar si no se encontraron pedidos
                        if (pedidosYDetalles.Any())
                        {
                            //Añadir al datagrid
                            foreach (var i in pedidosYDetalles)
                            {
                                var tipopago = "";
                                if (i.PagoPedido == null)
                                {
                                    tipopago = "No Pagado";
                                }
                                else
                                {
                                    tipopago = i.PagoPedido.Descripcion;
                                }
                                dataGridView1.Rows.Add(i.Pedido.Id_Pedido, tipopago, i.Pedido.Mesa, i.Pedido.Importe_Total, i.Usuario.Nombre,i.Pedido.Fecha);
                            }
                            lblRecaudado.Text = total.FirstOrDefault().Total;
                        }
                        else
                        {
                            MessageBox.Show("No se encontraron pedidos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void chkPeriodo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPeriodo.Checked)
            {
                dataGridView1.Rows.Clear();
                //Buscar en la base de datos
                try
                {
                    using (InfobarEntities db = new InfobarEntities())
                    {
                        //Traer todas las ventas/pedidos por fechas desde hasta
                        var pedidosYDetalles = from pedi in db.Pedido
                                               join tipo in db.TipoPago on pedi.Id_TipoPago equals tipo.Id_TipoPago into PedidoPago
                                               from pdp in PedidoPago.DefaultIfEmpty()
                                               join user in db.Usuario on pedi.Id_Usuario equals user.Id
                                               where (dateDesde.Value.Date <= pedi.Fecha &&
                                               dateHasta.Value.Date >= pedi.Fecha)
                                               select new
                                               {
                                                   Pedido = pedi,
                                                   PagoPedido = pdp,
                                                   Total = pdp.Pedido.Sum(pedi => pedi.Importe_Total).ToString(),
                                                   Usuario = user
                                               };
                        //Verificar si no se encontraron pedidos
                        if (pedidosYDetalles.Any())
                        {
                            //Añadir al datagrid
                            foreach (var i in pedidosYDetalles)
                            {
                                var tipopago = "";
                                if (i.PagoPedido == null)
                                {
                                    tipopago = "No Pagado";
                                }
                                else
                                {
                                    tipopago = i.PagoPedido.Descripcion;
                                }
                                dataGridView1.Rows.Add(i.Pedido.Id_Pedido, tipopago, i.Pedido.Mesa, i.Pedido.Importe_Total, i.Usuario.Nombre, i.Pedido.Fecha);
                            }
                            //Mostrar recaudacion
                            lblRecaudado.Text = pedidosYDetalles.FirstOrDefault().Total;
                        }
                        else
                        {
                            MessageBox.Show("No se encontraron pedidos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            int selectedRowCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
            //Seleccionar una sola
            if (selectedRowCount > 0 && selectedRowCount <= 1)
            {
                //Añade a la lista
                IdPedidoSeleccionado = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                string TipoPago = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                int Mesa = int.Parse( dataGridView1.SelectedRows[0].Cells[2].Value.ToString());
                float Total = float.Parse(dataGridView1.SelectedRows[0].Cells[3].Value.ToString());
                string Usuario = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                string Fecha = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                InfoBAR.openChildForm(
                    new DetallePedido(
                        IdPedidoSeleccionado,TipoPago,Usuario,Mesa,Fecha,Total,this)
                    );
            }
            else
            {
                //TODO Mensaje de que solo se puede seleccionar una sola fila
            }
        }

        private void btnGrafico_Click(object sender, EventArgs e)
        {
            Form graficos = new ReporteGraficos();
            graficos.Show();
        }
    }
}
