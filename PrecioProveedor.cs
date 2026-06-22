using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto
{
    public class PrecioProveedor
    {
        public int PrecioId { get; }
        public int ObjetoId { get; }
        public string Tipo { get; }
        public string Proveedor { get; }
        public double Precio { get; }
        public PrecioProveedor(int precioId, int objetoId, string tipo, string proveedor, double precio)
        {
            PrecioId = precioId;
            ObjetoId = objetoId;
            Tipo = tipo;
            Proveedor = proveedor;
            Precio = precio;
        }
    }
}
