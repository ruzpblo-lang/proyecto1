using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto
{
    public class Puesto
    {
        public Puesto(int puestoId, string categoria, double sueldo)
        {
            PuestoId = puestoId;
            Categoria = categoria;
            Sueldo = sueldo;
        }

        public int PuestoId { get; }
        public string Categoria { get; }
        public double Sueldo { get; }

    }
}
