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
    public partial class ElegirPago : Form
    {
        public ElegirPago()
        {
            InitializeComponent();
        }

        private void btnPago_Click(object sender, EventArgs e)
        {
            if(cboTipo.SelectedIndex > -1)
            {
                //Invoca al evento pasando el tipo de pago seleccionado
                RegistrarPago.EventoRegistrarPago(cboTipo.SelectedIndex + 1);
                this.Close();
            }
        }
    }
}
