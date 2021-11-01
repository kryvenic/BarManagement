using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InfoBAR.Utilidades
{
    class CheckBoxs
    {
        public static void DesHabilitarCheckboxs(Form formulario)
        {
            foreach (Control c in formulario.Controls)
            {
                if (c is CheckBox)
                {
                    ((CheckBox)c).Checked = false;
                }

            }

        }

        public static void DesHabilitarCheckboxs(GroupBox groupBox)
        {
            foreach (Control c in groupBox.Controls)
            {
                if (c is CheckBox)
                {
                    ((CheckBox)c).Checked = false;
                }

            }

        }
    }
}
