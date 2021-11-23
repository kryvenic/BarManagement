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
    public partial class RegistrarPago : Form
    {
        private Form ventanaElegirPago;
        private int IdPedidoSeleccionado;
        internal static Action<int> EventoRegistrarPago;

        public RegistrarPago()
        {
            IdPedidoSeleccionado = 0;
            InitializeComponent();
            ventanaElegirPago = null;
            EventoRegistrarPago += RegistrarPagoEnBase;
        }

        private void RegistrarPagoEnBase(int pagoSeleccionado)
        {
            //Modificar a la base de datos
            try
            {
                using (InfobarEntities db = new InfobarEntities())
                {
                    Pedido oPedido = (from pedi in db.Pedido
                                      where pedi.Id_Pedido == IdPedidoSeleccionado
                                      select pedi).First();
                    oPedido.Id_TipoPago = pagoSeleccionado;
                    db.SaveChanges();
                }
                MessageBox.Show("Pago realizado!", "Pagado", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception)
            {
                MessageBox.Show("No se agrego correctamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPago_Click(object sender, EventArgs e)
        {
            //Si no esta abierto ya una ventana de elegir pago
            if (!Application.OpenForms.OfType<ElegirPago>().Any())
            {
                int selectedRowCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);

                //Seleccionar una sola
                if (selectedRowCount > 0 && selectedRowCount <= 1)
                {
                    //Verificar si no esta pagado
                    if (dataGridView1.SelectedRows[0].Cells["Pago"].Value.ToString().Equals("No Pagado"))
                    {
                        //Añade a la lista
                        IdPedidoSeleccionado = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                        ventanaElegirPago = new ElegirPago();
                        ventanaElegirPago.Show();
                    }
                    else
                    {
                        lblError.Text = "Error: El pedido ya esta pagado";
                    }
                }
                else
                {
                    lblError.Text = "Error: Solo puedes selecionar una fila";
                }



            }
        }

        private void chkTodas_CheckedChanged(object sender, EventArgs e)
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
                                               where pedi.Id_TipoPago == null
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
                            int indice = 0;
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
                                //Agregar fila
                                dataGridView1.Rows.Add(i.Pedido.Id_Pedido, tipopago, i.Pedido.Mesa, i.Pedido.Importe_Total, i.Usuario.Nombre, i.Pedido.Fecha);
                                //Cambiar color si esta pagado
                                if (!tipopago.Equals("No Pagado"))
                                {
                                    dataGridView1.Rows[indice].DefaultCellStyle.BackColor = Color.FromArgb(92, 239, 209);
                                }
                                indice++;
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

        private void chkFecha_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void ResetearGrid()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            CheckBoxs.DesHabilitarCheckboxs(groupBox1);
        }

        private void chkFecha_CheckedChanged_1(object sender, EventArgs e)
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
                        //Verificar si no se encontraron pedidos
                        if (pedidosYDetalles.Any())
                        {
                            //Añadir al datagrid
                            int indice = 0;
                            foreach (var i in pedidosYDetalles)
                            {
                                var tipopago = "";
                                if (i.PagoPedido == null)
                                {
                                    tipopago = "No Pagado";
                                }
                                
                                //Agregar fila
                                dataGridView1.Rows.Add(i.Pedido.Id_Pedido, tipopago, i.Pedido.Mesa, i.Pedido.Importe_Total, i.Usuario.Nombre, i.Pedido.Fecha.Value.ToString("dd/MM/yyyy"));
                                //Cambiar color si esta pagado
                                if (!tipopago.Equals("No Pagado"))
                                {
                                    dataGridView1.Rows[indice].DefaultCellStyle.BackColor = Color.FromArgb(92, 239, 209);
                                }
                                indice++;
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

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            int selectedRowCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
            //Seleccionar una sola
            if (selectedRowCount > 0 && selectedRowCount <= 1)
            {
                //Añade a la lista
                IdPedidoSeleccionado = int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
                string TipoPago = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                int Mesa = int.Parse(dataGridView1.SelectedRows[0].Cells[2].Value.ToString());
                float Total = float.Parse(dataGridView1.SelectedRows[0].Cells[3].Value.ToString());
                string Usuario = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                string Fecha = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                InfoBAR.openChildForm(
                    new DetallePedido(
                        IdPedidoSeleccionado, TipoPago, Usuario, Mesa, Fecha, Total,this)
                    );
            }
            else
            {
                //TODO Mensaje de que solo se puede seleccionar una sola fila
            }
        }

        private void btnRefr_Click(object sender, EventArgs e)
        {
            ResetearGrid();
        }

        private void RegistrarPago_FormClosed(object sender, FormClosedEventArgs e)
        {
            EventoRegistrarPago -= RegistrarPagoEnBase;
        }
    }
}
