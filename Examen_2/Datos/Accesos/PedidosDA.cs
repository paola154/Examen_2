using Datos.Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Accesos
{
    public class PedidosDA
    {
        readonly string cadena = "Server=localhost; Port=3306; Database=Examen2; Uid=root; Pwd=Paola_2001.20;";

        MySqlConnection conn;
        MySqlCommand cmd;

        

        public int InsertarPedidos(Pedidos pedidos)
        {
            int idPedido = 0;
            try
            {
                string sql = "INSERT INTO pedidos (Codigo, Cliente, Descripcion, Precio, Cantidad, Subtotal, Impuesto, Total) VALUES (@Codigo, @Cliente, @Descripcion, @Precio, @Cantidad, @Subtotal, @Impuesto, @Total); select last_insert_id();";

                conn = new MySqlConnection(cadena);
                conn.Open();

                cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@Codigo", pedidos.Codigo);
                cmd.Parameters.AddWithValue("@Cliente", pedidos.Cliente);
                cmd.Parameters.AddWithValue("@Descripcion", pedidos.Descripcion);
                cmd.Parameters.AddWithValue("@Precio", pedidos.Precio);
                cmd.Parameters.AddWithValue("@Cantidad", pedidos.Cantidad);
                cmd.Parameters.AddWithValue("@Subtotal", pedidos.Subtotal);
                cmd.Parameters.AddWithValue("@Impuesto", pedidos.ISV);
                cmd.Parameters.AddWithValue("@Total", pedidos.Total);
                idPedido = Convert.ToInt32(cmd.ExecuteScalar());


                conn.Close();
            }
            catch (Exception ex)
            {
            }
            return idPedido;
        }
    }
}
