using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
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
            try
            {
                using (InfobarEntities db = new InfobarEntities())
                {
                    //Traer todas las ventas/pedidos con tipo de pago
                    var pedidosYDetalles = from pedi in db.Pedido
                                           where pedi.Id_TipoPago != null
                                           group pedi by DbFunctions.TruncateTime(pedi.Fecha.Value) into pdf
                                           select new
                                           {
                                               Fecha = DbFunctions.TruncateTime(pdf.Key.Value),
                                               Suma = pdf.Sum(pedi => pedi.Importe_Total).ToString(),
                                           };


                    //Verificar si no se encontraron pedidos
                    if (pedidosYDetalles.Any())
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
                                chart1.Series[0]["PixelPointWidth"] = "50";

                            }
                            catch (System.ArgumentException)
                            {
                                //Si ya existe, referenciarla
                                chart1.Series[0].Points.AddXY(i.Fecha.Value.Date, double.Parse(i.Suma));
                                chart1.Series[0]["PixelPointWidth"] = "50";

                            }

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
                MessageBox.Show("No se pudo traer los pedidos de la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void btnMostrartipo_Click(object sender, EventArgs e)
        {
            try
            {
                using (InfobarEntities db = new InfobarEntities())
                {
                    //Traer todas las ventas/pedidos con tipo de pago
                    var sumasPorTipoPago = from pedi in db.Pedido
                                           where pedi.Id_TipoPago != null
                                           group pedi by new { Fecha = DbFunctions.TruncateTime(pedi.Fecha.Value), pedi.Id_TipoPago } into pdp
                                           select new
                                           {
                                               Suma = pdp.Sum(pedi => pedi.Importe_Total).ToString(),
                                               Fecha = pdp.Key.Fecha,
                                               Pedido = pdp
                                           };

                    var tiposPagos = from tipo in db.TipoPago
                                     select tipo.Descripcion;

                    //Verificar si no se encontraron pedidos
                    if (sumasPorTipoPago.Any() && tiposPagos.Any())
                    {
                        chart1.Series.Clear();
                        //Añadir tipos de pagos disponibles
                        foreach(string i in tiposPagos)
                        {
                            chart1.Series.Add(i);
                        }
                        //Añadir al chart
                        foreach (var i in sumasPorTipoPago)
                        {
                            string fecha = i.Fecha.Value.ToString("dd/MM/yyyy");

                            try
                            {
                                int tipo = i.Pedido.FirstOrDefault().Id_TipoPago.Value - 1;
                                chart1.Series[tipo].Points.AddXY(i.Fecha.Value.Date, double.Parse(i.Suma));
                                chart1.Series[tipo].SmartLabelStyle.Enabled = true;
                                chart1.Series[tipo].IsValueShownAsLabel = true;
                                chart1.Series[tipo]["PixelPointWidth"] = "30";

                            }
                            catch (System.ArgumentException)
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
            catch (Exception)
            {
                MessageBox.Show("No se pudo traer los pedidos de la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
