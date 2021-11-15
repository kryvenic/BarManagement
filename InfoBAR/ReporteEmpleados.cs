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
    public partial class ReporteEmpleados : Form
    {
        public ReporteEmpleados()
        {
            InitializeComponent();
        }

        private void ResetearGrid()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            CheckBoxs.DesHabilitarCheckboxs(groupBox1);
        }

        private void chkTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTodos.Checked)
            {
                dataGridView1.Rows.Clear();
                //Buscar en la based de datos
                try
                {
                    using (InfobarEntities db = new InfobarEntities())
                    {
                        //Traer todos los usuarios por tipo
                        var list = from pedi in db.Pedido
                                   join usua in db.Usuario on pedi.Id_Usuario equals usua.Id
                                   join tipo in db.TipoUsuario on usua.Id_Tipo equals tipo.Id
                                   where tipo.Id == 3
                                   select new
                                   {
                                       Usuario = usua,
                                       Tipo = tipo,
                                       Pedi = pedi.Importe_Total.Value.sum
                                   };

                        //Añadir al datagrid
                        int indice = 0;
                        foreach (var u in list)
                        {
                            dataGridView1.Rows.Add(u.Usuario.Nombre, u.Tipo.Descripcion, u.Usuario.Nombre);
                            //Pone en rojo los usuarios desactivados
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
                    MessageBox.Show("No se pudo traer los empleados de la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                ResetearGrid();
            }
        }
    }
}
