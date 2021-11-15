using InfoBAR.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
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
                        int indice = 0;
                        foreach (var u in list)
                        {
                            dataGridView1.Rows.Add(u.Usuario.Id, u.Tipo.Descripcion, u.Usuario.Nombre);
                            if (u.Usuario.Activado == 0)
                            {
                                dataGridView1.Rows[indice].DefaultCellStyle.BackColor = Color.Red;
                            }
                            indice++;
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

            result = MessageBox.Show("¿Esta seguro que quiere proceder a eliminar este/os usuario/s permanentemente?", "Confirmacion de eliminacion", buttons, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                #region Eliminar Permanentemente al Usuario
                try
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
                    MessageBox.Show("El usuario se dio de baja exitosamente. No se elimino permanentemente", "Baja exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetearGrid();
                }
                //Dar de baja
                catch (DbUpdateException)
                {
                    //El usuario tiene un pedido o venta asignado en la base de datos
                    using (InfobarEntities db = new InfobarEntities())
                    {
                        foreach (int id in UsuarioAElminar)
                        {
                            Usuario usuarioAElminar =
                                (from usua in db.Usuario
                                 where usua.Id == id
                                 select usua).First();
                            usuarioAElminar.Activado = 0;
                        }
                        db.SaveChanges();
                    }
                    MessageBox.Show("El usuario se dio de baja exitosamente. No se elimino permanentemente porque tiene una venta asignada", "Baja exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetearGrid();
                }
                catch (Exception)
                {
                    MessageBox.Show("No se pudo eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                #endregion
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
                        int indice = 0;
                        foreach (var i in lista)
                        {
                            dataGridView1.Rows.Add(i.Usuario.Id, i.Tipo.Descripcion, i.Usuario.Nombre);
                            if (i.Usuario.Activado == 0)
                            {
                                dataGridView1.Rows[indice].DefaultCellStyle.BackColor = Color.Red;
                            }
                            indice++;
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void btnActivar_Click(object sender, EventArgs e)
        {
            int selectedRowCount = dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);
            //Lista utilizada para luego eliminar cada producto desde la base de datos
            List<int> ProductosActivar = new List<int>();

            //Si hay filas seleccionadas -> Recolectar filas seleccionadas
            if (selectedRowCount > 0)
            {
                //Recorre cada fila
                for (int i = 0; i < selectedRowCount; i++)
                {
                    //Añade a la lista
                    ProductosActivar.Add(int.Parse(dataGridView1.SelectedRows[i].Cells[0].Value.ToString()));
                }
            }
            //Eliminar de la base de datos las filas seleccionadas
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            result = MessageBox.Show("¿Esta seguro que quiere activar el usuario? ", "Confirmar activacion", buttons, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                using (InfobarEntities db = new InfobarEntities())
                {
                    foreach (int id in ProductosActivar)
                    {
                        Usuario usuarioAEliminar =
                            (from usua in db.Usuario
                             where usua.Id == id
                             select usua).First();
                        usuarioAEliminar.Activado = 1;
                    }
                    db.SaveChanges();
                }
            }
            ResetearGrid();
        }

        private void button1_Click(object sender, EventArgs e)
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
            result = MessageBox.Show("¿Quiere darlo de baja? ", "Confirmacion de baja", buttons, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                #region Dar de Baja Usuario
                try
                {
                    //El usuario tiene un pedido o venta asignado en la base de datos
                    using (InfobarEntities db = new InfobarEntities())
                    {
                        foreach (int id in UsuarioAElminar)
                        {
                            Usuario usuarioAElminar =
                                (from usua in db.Usuario
                                 where usua.Id == id
                                 select usua).First();
                            usuarioAElminar.Activado = 0;
                        }
                        db.SaveChanges();
                    }
                    MessageBox.Show("El usuario se dio de baja exitosamente. No se elimino permanentemente", "Baja exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetearGrid();
                }
                catch (Exception)
                {
                    MessageBox.Show("No se pudo eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                #endregion
            }
        }
    }
}
