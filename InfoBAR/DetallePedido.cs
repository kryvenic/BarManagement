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
    public partial class DetallePedido: Form
    {
        private Form formularioParaVolver;
        private int IdPedidoSeleccionado;
        public DetallePedido(int IdPedidoSeleccionado, string TipoPago, string Usuario, int Mesa, string Fecha
            ,float ImporteTotal, Form formularioParaVolver)
        {
            InitializeComponent();
            //Si no se selecciono correctamente el producto sera -1 o menor a 0, por lo que tira error
            if (IdPedidoSeleccionado <= 0)
            {
                MessageBox.Show("Id Invalido del producto a Modificar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                InfoBAR.openChildForm(formularioParaVolver);
            }
            else
            {
                this.formularioParaVolver = formularioParaVolver;
                //Traer datos usando el id pasado por parametro
                this.IdPedidoSeleccionado = IdPedidoSeleccionado;
                lblId.Text = IdPedidoSeleccionado.ToString();
                lblPago.Text = TipoPago;
                lblMesa.Text = Mesa.ToString();
                lblTotal.Text = ImporteTotal.ToString();
                lblUsuario.Text = Usuario;
                lblFecha.Text = Fecha;
                lblNumero.Text = this.IdPedidoSeleccionado.ToString();
                TraerListaDeProductos();
            }
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            InfoBAR.openChildForm(formularioParaVolver);
        }

        private void TraerListaDeProductos()
        {

            using (InfobarEntities db = new InfobarEntities())
            {
                //Traer todas las ventas/pedidos por fechas desde hasta
                var detallePedido = from deta in db.Detalle_Pedido
                                       join prod in db.Producto on deta.Id_Prod equals prod.Id_Producto
                                       where deta.Id_Pedido == IdPedidoSeleccionado
                                       select new
                                       {
                                           Detalle = deta,
                                           Producto = prod
                                       };
                //Detalle del pedido
                foreach (var p in detallePedido)
                {
                    dataGridView1.Rows.Add(p.Producto.Descripcion, p.Detalle.Cantidad, p.Detalle.Precio, p.Detalle.PrecioTotal);
                }
            }


        }
    }
}
