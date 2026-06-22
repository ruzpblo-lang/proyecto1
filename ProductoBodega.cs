using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto
{
    public class ProductoBodega
    {
        public int ObjetoId { get; }
        public string Tipo { get; }
        public int Cantidad { get; }
        public ProductoBodega(int objetoId, string tipo, int cantidad)
        {
            ObjetoId = objetoId;
            Tipo = tipo;
            Cantidad = cantidad;
        }
    }
}
