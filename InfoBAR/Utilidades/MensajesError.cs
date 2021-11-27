using InfoBAR.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InfoBAR.Utilidades
{
    public class MensajesError
    {
        public static void MostrarError(Label lblError, string mensaje)
        {
            Image imagen = Resources.error;
            lblError.Image = imagen;
            lblError.ImageAlign = ContentAlignment.MiddleLeft;
            lblError.Text = mensaje;
            SystemSounds.Exclamation.Play();
        }

        public static void BorrarError(Label lblError)
        {
            lblError.Image = null;
            lblError.Text = "";
        }
    }
}
