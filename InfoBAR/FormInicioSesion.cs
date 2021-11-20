using InfoBAR.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
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
            VerificarContraEIngresar();
        }

        private async void VerificarContraEIngresar()
        {
            usuario = txtUsuario.Text;
            contra = txtContra.Text;

            Application.UseWaitCursor = true;
            try
            {
                using (InfobarEntities db = new InfobarEntities())
                {
                    //Traer el producto con el nombre
                    var usuarBuscado = await (from user in db.Usuario
                                              join tipo in db.TipoUsuario on user.Id_Tipo equals tipo.Id
                                              where user.Nombre.Contains(usuario)
                                              select new
                                              {
                                                  Usuario = user,
                                                  Tipo = tipo
                                              }).FirstOrDefaultAsync();
                    Application.UseWaitCursor = false;
                    //No encontrado
                    if (usuarBuscado == null)
                    {
                        MessageBox.Show("Usuario y/o contraseña incorrecta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    //Usuario Desactivado
                    if (usuarBuscado.Usuario.Activado == 0)
                    {
                        MessageBox.Show("Usuario desactivado. No puede ingresar al sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    //Validar contraseña
                    if (contra.Equals(usuarBuscado.Usuario.Clave))
                    {
                        Global.TipoUsuario = usuarBuscado.Tipo.Id;
                        Ingresar();
                    }
                    else
                    {
                        MessageBox.Show("Usuario y/o contraseña incorrecta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error de conexion.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            

        }

        private void Ingresar()
        {
            Global.Usuario = usuario;
            Form fm = new InfoBAR()
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

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                VerificarContraEIngresar();
            }
        }

        private void txtContra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                VerificarContraEIngresar();
            }
        }

        private void iconPictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                if (txtContra.PasswordChar == '*')
                {
                    txtContra.PasswordChar = '\0';
                }
            }
            else
            {
                txtContra.PasswordChar = '*';
            }
        }

        private void txtContra_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
