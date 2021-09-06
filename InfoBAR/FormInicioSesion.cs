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
    public partial class FormInicioSesion : Form
    {
        private string usuario;
        private string contra;

        public FormInicioSesion()
        {
            InitializeComponent();
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "Usuario")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.Black;
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "Usuario";
                txtUsuario.ForeColor = Color.Silver;
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            usuario = txtUsuario.Text;
            contra = txtContra.Text;

            switch (usuario)
            {
                case "admin":
                    if (contra.Equals("admin"))
                    {
                        Ingresar();
                    }
                    else
                    {
                        MessageBox.Show("Usuario y/o contraseña incorrecta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case "empleado":
                    if (contra.Equals("empleado"))
                    {
                        Ingresar();
                    }
                    else
                    {
                        MessageBox.Show("Usuario y/o contraseña incorrecta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                case "gerente":
                    if (contra.Equals("gerente"))
                    {
                        Ingresar();
                    }
                    else
                    {
                        MessageBox.Show("Usuario y/o contraseña incorrecta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                default:
                    MessageBox.Show("Usuario y/o contraseña incorrecta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }

        }

        private void Ingresar()
        {
            Form fm = new InfoBAR
            {

                Visible = true
            };
            fm.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

     
        private void txtContra_Leave(object sender, EventArgs e)
        {
            
            if (txtContra.Text.Equals(""))
            {
                txtContra.Text = "Contraseña";
                txtContra.ForeColor = Color.Silver;
            }
        }

        private void txtContra_Enter(object sender, EventArgs e)
        {
            if (txtContra.Text.Equals("Contraseña"))
            {
                txtContra.Text = "";
                txtContra.ForeColor = Color.Black;
            }
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
