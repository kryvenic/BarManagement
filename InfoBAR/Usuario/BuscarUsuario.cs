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
    public partial class BuscarUsuario : Form
    {
        public BuscarUsuario()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                //Buscar en la base de datos
                try
                {
                    using (InfobarEntities db = new InfobarEntities())
                    {
                        Usuario oUsuario = new Usuario();

                        //Traer todos los usuarios
                        var lista = from usua in db.Usuario
                                   join tipo in db.TipoUsuario on usua.Id_Tipo equals tipo.Id
                                   select new
                                   {
                                       //Necesario para hacer el foreach
                                       Usuario = usua,
                                       Tipo = tipo
                                   };

                        //Añadir al datagrid
                        int indice = 0;
                        foreach (var i in lista)
                        {
                            dataGridView1.Rows.Add(i.Usuario.Id, i.Tipo.Descripcion, i.Usuario.Nombre);
                            if (i.Usuario.Activado == 0)
                            {
                                dataGridView1.Rows[indice].DefaultCellStyle.BackColor = Color.Red;
                            }
                        }
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("No se pudo traer los productos de la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                ResetearGrid();
            }
        }
        private void ResetearGrid()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            CheckBoxs.DesHabilitarCheckboxs(groupBox1);
        }

        private void chkTipo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTipo.Checked)
            {
                //Buscar en la based de datos
                try
                {
                    using (InfobarEntities db = new InfobarEntities())
                    {
                        //Traer todos los usuarios por tipo
                        var list = from usua in db.Usuario
                                   join tipo in db.TipoUsuario on usua.Id_Tipo equals tipo.Id
                                   where tipo.Id == (cboTipo.SelectedIndex + 1)
                                   select new
                                   {
                                       //Necesario para hacer el foreach
                                       Usuario = usua,
                                       Tipo = tipo
                                   };

                        //Añadir al datagrid
                        foreach (var i in list)
                        {
                            dataGridView1.Rows.Add(i.Usuario.Id, i.Tipo.Descripcion,i.Usuario.Nombre);
                        }
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("No se pudo traer los productos de la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                ResetearGrid();
            }
        }
    }

}
