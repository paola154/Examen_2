using Datos.Accesos;
using Datos.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen_2
{
    public partial class FrmPedidos : Form
    {
        public FrmPedidos()
        {
            InitializeComponent();
        }

        ProductoDA productoDA = new ProductoDA();
        
        Producto producto;
        PedidosDA pedidosDA = new PedidosDA();

        List<Pedidos> detallePedido = new List<Pedidos>();

        decimal subTotal = decimal.Zero;
        decimal isv = decimal.Zero;
        decimal totalAPagar = decimal.Zero;

        private void FrmPedidos_Load(object sender, EventArgs e)
        {
            PedidosDataGridView.DataSource = detallePedido;
        }

        
        private void CodigoProductoTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                producto = new Producto();
                producto = productoDA.GetProductoPorCodigo(CodigoProductoTextBox.Text);
                DescripcionProductoTextBox.Text = producto.Descripcion;
                CantidadTextBox.Focus();
            }
            else
            {
                producto = null;
                DescripcionProductoTextBox.Clear();
                CantidadTextBox.Clear();
            }
        }

        private void CantidadTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && !string.IsNullOrEmpty(CantidadTextBox.Text))
            {
                Pedidos detalle = new Pedidos();
                detalle.Cliente = ClienteTextBox.Text;
                detalle.Codigo = producto.Codigo;
                detalle.Descripcion = producto.Descripcion;
                detalle.Cantidad = Convert.ToInt32(CantidadTextBox.Text);
                detalle.Precio = producto.Precio;
                detalle.Subtotal = producto.Precio * Convert.ToInt32(CantidadTextBox.Text);
                
                
                subTotal += detalle.Subtotal;
                isv = subTotal * 0.15M;
                totalAPagar = subTotal + isv;

                detalle.ISV = detalle.Subtotal * 0.15M;
                detalle.Total = detalle.Subtotal + detalle.ISV; 

                SubtotalTextBox.Text = subTotal.ToString();
                ImpuestoTextBox.Text = isv.ToString();
                TotalTextBox.Text = totalAPagar.ToString();

                detallePedido.Add(detalle);
                PedidosDataGridView.DataSource = null;
                PedidosDataGridView.DataSource = detallePedido;
            }

        }

        private void LimpiarControles()
        {
            CodigoProductoTextBox.Clear();
            DescripcionProductoTextBox.Clear();
            CantidadTextBox.Clear();
            ClienteTextBox.Clear();

        }

        private void LimpiarButton_Click(object sender, EventArgs e)
        {
            LimpiarControles();
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            Pedidos pedidos = new Pedidos();
            pedidos.Codigo = CodigoProductoTextBox.Text;
            pedidos.Cliente = ClienteTextBox.Text;
            pedidos.Descripcion = DescripcionProductoTextBox.Text;
            pedidos.Precio = producto.Precio;
            pedidos.Cantidad = Convert.ToInt32(CantidadTextBox.Text);
            pedidos.Subtotal = Convert.ToDecimal(SubtotalTextBox.Text);
            pedidos.ISV = Convert.ToDecimal(ImpuestoTextBox.Text);
            pedidos.Total = Convert.ToDecimal(TotalTextBox.Text);
            


            int idPedido = 0;

            idPedido = pedidosDA.InsertarPedidos(pedidos);

            if (idPedido != 0)
            {
                foreach (var item in detallePedido)
                {
                    item.Id = idPedido;
                    pedidosDA.InsertarPedidos(item);
                }
            }
        }
    }
}
