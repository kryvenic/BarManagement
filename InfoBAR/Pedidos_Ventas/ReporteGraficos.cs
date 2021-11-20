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
    public partial class ReporteGraficos : Form
    {
        public ReporteGraficos()
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
                                           group pedi by pedi.Fecha into pdf
                                           where (dateDesde.Value.Date <= pdf.Key &&
                                               dateHasta.Value.Date >= pdf.Key)
                                           select new
                                           {
                                               Fecha = pdf,
                                               Suma = pdf.Sum(pedi => pedi.Importe_Total).ToString()
                                           };
                int f = 0;
                    //Verificar si no se encontraron pedidos
                    if (pedidosYDetalles.Any())
                    {
                        chart1.Series.Clear();
                        //Añadir al datagrid
                        foreach (var i in pedidosYDetalles)
                        {
                            chart1.Series.Add("Recaudado " + i.Fecha.Key + " " + i.Suma).Points.AddXY(i.Fecha.Key, i.Suma);
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
