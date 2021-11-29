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
    public partial class GraficoTodas : Form
    {
        public GraficoTodas()
        {
            InitializeComponent();
        }

        private void ReporteGraficos_Load(object sender, EventArgs e)
        {

        }

        private void btnGrafico_Click(object sender, EventArgs e)
        {

            using (InfobarEntities db = new InfobarEntities())
            {
                //Traer todas las ventas/pedidos con tipo de pago y usuario
                var pedidosYDetalles = from pedi in db.Pedido
                                       group pedi by EntityFunctions.TruncateTime(pedi.Fecha.Value) into pdf
                                       select new
                                       {
                                           Fecha = EntityFunctions.TruncateTime(pdf.Key.Value),
                                           Suma = pdf.Sum(pedi => pedi.Importe_Total).ToString(),
                                       };
                var tiposPagos = from tipo in db.TipoPago
                                 select tipo.Descripcion;
               
                //Verificar si no se encontraron pedidos
                if (pedidosYDetalles.Any() && tiposPagos.Any())
                {
                    chart1.Series.Clear();
                    chart1.Series.Add("Todas las ventas");
                    //Añadir al chart
                    foreach (var i in pedidosYDetalles)
                    {
                        string fecha = i.Fecha.Value.ToString("dd/MM/yyyy");
                        
                        try
                        {
                            chart1.Series[0].Points.AddXY(i.Fecha.Value.Date, double.Parse(i.Suma));
                            chart1.Series[0].SmartLabelStyle.Enabled = true;
                            chart1.Series[0].IsValueShownAsLabel = true;

                        } catch (System.ArgumentException)
                        {
                            //Si ya existe, referenciarla
                            chart1.Series[0].Points.AddXY(i.Fecha.Value.Date, double.Parse(i.Suma));
                        }
                        
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
