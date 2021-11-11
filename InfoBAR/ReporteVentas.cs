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
    public partial class ReporteVentas : Form
    {
        public ReporteVentas()
        {
            InitializeComponent();
        }

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
                        //Traer todos los productos con categoria
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
                            dataGridView1.Rows.Add(i.Pedido.Id_Pedido, tipopago, i.Pedido.Mesa, i.Pedido.Importe_Total, i.Usuario.Nombre);
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
