using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto
{
    public class Inventario
    {
        public Inventario(int objetoId, string tipo, int cantidad)
        {
            ObjetoId = objetoId;
            Tipo = tipo;
            Cantidad = cantidad;
        }

        public int ObjetoId { get; }
        public string Tipo { get; }
        public int Cantidad { get; }
    }
}
