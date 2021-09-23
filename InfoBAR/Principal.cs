using InfoBAR;
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
        private string usuario;
        public InfoBAR(string usuario)
        {
            this.usuario = usuario;
            
            InitializeComponent();
            
            LBienvenido.Text = "¡Bienvenido/a " + usuario + "!";
            foreach (Control c in panelSideMenu.Controls)
            {
                c.Visible = true;
            }
            hideSubMenu();
        }

        private void hideSubMenu()
        {
            panelProductoSubMenu.Visible = false;
            panelEmpleadosSubMenu.Visible = false;
            panelReportesSubMenu.Visible = false;
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
            //..
            //your codes
            //..
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

        private void button12_Click(object sender, EventArgs e)
        {
            openChildForm(new ReporteEmpleados());
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

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null) activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panelToolsSubMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void InfoBAR_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
