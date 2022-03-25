using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Entidades
{
    public class Pedidos
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Cliente { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }
        public decimal ISV { get; set; }
        public decimal Total { get; set; }

        public Pedidos()
        {
        }

        public Pedidos(int id, string codigo, string cliente, string descripcion, decimal precio, int cantidad, decimal subtotal, decimal iSV, decimal total)
        {
            Id = id;
            Codigo = codigo;
            Cliente = cliente;
            Descripcion = descripcion;
            Precio = precio;
            Cantidad = cantidad;
            Subtotal = subtotal;
            ISV = iSV;
            Total = total;
        }
    }
}
