using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InfoBAR.Utilidades
{
    class VerificarCampos
    {
        public static bool VerificarCamposVacios(Form formulario)
        {
            bool estanVacios = false;
            foreach (Control c in formulario.Controls)
            {
                if (c is TextBox && c.Text.Equals(""))
                {
                    estanVacios = true;
                }

                if (c is ComboBox)
                {
                    ComboBox combo = (ComboBox)c;
                    if (combo.SelectedIndex == -1)
                    {
                        estanVacios = true;
                    }
                }
            }

            return estanVacios;
        }

        public static bool VerificarCamposVacios(GroupBox groupBox)
        {
            bool estanVacios = false;
            foreach (Control c in groupBox.Controls)
            {
                if (c is TextBox && c.Text.Equals(""))
                {
                    estanVacios = true;
                }

                if (c is ComboBox)
                {
                    ComboBox combo = (ComboBox)c;
                    if (combo.SelectedIndex == -1)
                    {
                        estanVacios = true;
                    }
                }
            }

            return estanVacios;
        }


        public static bool SonNumeros(TextBox textBox)
        {
            return int.TryParse(textBox.Text, out _); ;
        }

        public static void LongitudMaximaDeCampo(KeyPressEventArgs e,ErrorProvider provider, TextBox box, int lenght)
        {
            if (box.Text.Length > lenght && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                provider.SetError(box, "Longitud maxima de " + lenght + " caracteres.");
            }
        }
    }
}
