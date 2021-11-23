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
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                result = MessageBox.Show("¿Esta seguro que quiere registrar este pedido como pago?" , "Registrar pedido", buttons, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    //Invoca al evento pasando el tipo de pago seleccionado
                    RegistrarPago.EventoRegistrarPago.Invoke(cboTipo.SelectedIndex + 1);
                    this.Close();
                }
            }
            else if(cboTipo.SelectedIndex > 1)
            {
                MessageBox.Show("Solo puede elegir 1 pedido para pagar a la vez", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
