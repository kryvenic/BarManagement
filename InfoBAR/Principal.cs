using InfoBAR;
using InfoBAR.Utilidades;
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
    public partial class InfoBAR : Form
    {
        public static Panel panelContenedorPrincipal;

        public InfoBAR()
        {
            InitializeComponent();
            //Mensaje de bienvenida con el nombre del usuario
            LBienvenido.Text = "¡Bienvenido/a " + Global.Usuario + "!";
            //Se desactivan las opciones que no corresponden a cada usuario
            if (Global.TipoUsuario != 1)
            {
                foreach (Control c in panelSideMenu.Controls)
                {
                    if (!c.Name.Equals("panelLogo") && !c.Name.Equals("btnAyuda") && !c.Name.Equals("btnExit"))
                    {
                        OcultarOpcion(c.Name, c);
                    }
                }
            }
            hideSubMenu();

            panelContenedorPrincipal = panelChildForm;
        }

        private void hideSubMenu()
        {
            panelProductoSubMenu.Visible = false;
            panelEmpleadosSubMenu.Visible = false;
            panelReportesSubMenu.Visible = false;
        }

        /// <summary>
        /// Oculta las opciones dependiendo de los usuarios Empleado y Gerente
        /// </summary>
        /// <param name="btnName"></param>
        /// <param name="c"></param>
        private void OcultarOpcion(string btnName, Control c)
        {
            switch (Global.TipoUsuario)
            {
                case 2:
                    if (btnName.Equals("btnUsuarios") || btnName.Equals("btnRegistrar") || btnName.Equals("btnPago") || btnName.Equals("btnProductos"))
                    {
                        c.Visible = false;
                    }
                    break;
                case 3:
                    if (btnName.Equals("btnUsuarios") || btnName.Equals("btnReportes") || btnName.Equals("btnProductos"))
                    {
                        c.Visible = false;
                    }
                    break;
            }
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }

        private void btnProductos_click(object sender, EventArgs e)
        {
            showSubMenu(panelProductoSubMenu);
        }

        #region ProductoSubMenu
        private void button2_Click(object sender, EventArgs e)
        {
            openChildForm(new AgregarProducto());
            hideSubMenu();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openChildForm(new EliminarProducto());
            hideSubMenu();
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            openChildForm(new BuscarProducto());
            hideSubMenu();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }
        #endregion

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            showSubMenu(panelEmpleadosSubMenu);
        }

        #region Usuario
        private void button8_Click(object sender, EventArgs e)
        {
            openChildForm(new AgregarUsuario());
            hideSubMenu();
        }

        private void btnEliminarUsuario_Click(object sender, EventArgs e)
        {
            openChildForm(new EliminarUsuario());
            hideSubMenu();
        }

        private void btnBuscarUsuario_Click(object sender, EventArgs e)
        {
            openChildForm(new BuscarUsuario());
            hideSubMenu();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }
        #endregion

        private void btnTools_Click(object sender, EventArgs e)
        {
            showSubMenu(panelReportesSubMenu);
        }
        #region ToolsSubMenu
        private void button13_Click(object sender, EventArgs e)
        {
            openChildForm(new ReporteVentas());
            hideSubMenu();
        }


        private void button10_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //..
            //your codes
            //..
            hideSubMenu();
        }
        #endregion

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            openChildForm(new AgregarPedido());
            hideSubMenu();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private static Form activeForm = null;
        internal static void openChildForm(Form childForm)
        {
            if (activeForm != null) activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelContenedorPrincipal.Controls.Add(childForm);
            panelContenedorPrincipal.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if(activeForm != null) activeForm.Close();
            hideSubMenu();
        }

        private void panelToolsSubMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void InfoBAR_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panelChildForm_Paint(object sender, PaintEventArgs e)
        {
        }

        private void horafecha_Tick(object sender, EventArgs e)
        {
            lblhora.Text = DateTime.Now.ToShortTimeString();
            lblfecha.Text = DateTime.Now.ToLongDateString();
        }

        private void btnPago_Click(object sender, EventArgs e)
        {
            openChildForm(new RegistrarPago());
            hideSubMenu();
        }
    }
}
