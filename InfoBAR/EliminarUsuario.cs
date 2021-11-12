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
    public partial class EliminarUsuario : Form
    {
        public EliminarUsuario()
        {
            InitializeComponent();
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
                dataGridView1.Rows.Clear();
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
                        foreach (var u in list)
                        {
                            dataGridView1.Rows.Add(u.Usuario.Id, u.Tipo.Descripcion, u.Usuario.Nombre);
                        }
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("No se pudo traer los usuarios de la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                ResetearGrid();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int selectedRowCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
            //Lista utilizada para luego eliminar cada producto desde la base de datos
            List<int> UsuarioAElminar = new List<int>();

            //Si hay filas seleccionadas -> Recolectar filas seleccionadas
            if (selectedRowCount > 0)
            {
                //Recorre cada fila
                for (int i = 0; i < selectedRowCount; i++)
                {
                    //Añade a la lista
                    UsuarioAElminar.Add(int.Parse(dataGridView1.SelectedRows[i].Cells[0].Value.ToString()));
                }
            }
            //Eliminar de la base de datos las filas seleccionadas
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            result = MessageBox.Show("¿Esta seguro que quiere eliminar este/os usuario/s? \n" +
                "Se elminara permanentemente", "Confirmar baja", buttons, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                using (InfobarEntities db = new InfobarEntities())
                {
                    foreach (int id in UsuarioAElminar)
                    {
                        Usuario usuarioAElminar =
                            (from usua in db.Usuario
                             where usua.Id == id
                             select usua).First();
                        db.Usuario.Remove(usuarioAElminar);
                    }
                    db.SaveChanges();
                }
                ResetearGrid();
            }
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
                        foreach (var i in lista)
                        {
                            dataGridView1.Rows.Add(i.Usuario.Id, i.Tipo.Descripcion, i.Usuario.Nombre);
                        }
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("No se pudo traer los usuarios", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                ResetearGrid();
            }
        }
    }
}
