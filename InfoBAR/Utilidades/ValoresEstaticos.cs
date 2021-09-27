using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InfoBAR.Utilidades
{
    class ValoresEstaticos
    {

        public static void AgregarProductosDatagrid(DataGridView dataGridView)
        {
            dataGridView.Rows.Add("Hamburguesa Especial", "Comidas","2");
        }
    }
}
