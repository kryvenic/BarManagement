using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace InfoBAR
{
    public partial class GraficoPorTipo : Form
    {
        public GraficoPorTipo()
        {
            InitializeComponent();
        }

        private void ReporteGraficos_Load(object sender, EventArgs e)
        {

        }

        private void btnGrafico_Click(object sender, EventArgs e)
        {
            //Colores para los distintos tipos
            Color[] colores = { Color.FromArgb(100,65, 140, 240), Color.FromArgb(100, 252, 180, 65)};
            using (InfobarEntities db = new InfobarEntities())
            {
                //Traer todas las ventas/pedidos con tipo de pago y usuario
                var pedidosYDetalles = from pedi in db.Pedido
                                       join tipo in db.TipoPago on pedi.Id_TipoPago equals tipo.Id_TipoPago into PedidoPago
                                       from pdp in PedidoPago.DefaultIfEmpty()
                                       where pdp.Id_TipoPago != null
                                       group pdp by pdp.Id_TipoPago into pdt
                                       select new
                                       {
                                           Pedido = pdt.FirstOrDefault().Pedido,
                                           TipoPago = pdt.FirstOrDefault().Descripcion,
                                           Total = pdt.FirstOrDefault().Pedido.Sum(pedi => pedi.Importe_Total).ToString(),
                                       };
                //Verificar si no se encontraron pedidos
                if (pedidosYDetalles.Any())
                {
                    int f = 0;
                    //Añadir al datagrid
                    foreach (var i in pedidosYDetalles)
                    {
                        chart1.Series[0].Points.AddXY(i.TipoPago,i.Total);
                        chart1.Series[0].IsValueShownAsLabel = true;
                        chart1.Series[0].Points[f].Color = colores[f];
                        f++;
                    }

                }
                else
                {
                    MessageBox.Show("No se encontraron pedidos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }

        }
    }
}
