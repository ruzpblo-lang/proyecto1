using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto
{
    public class Pago
    {
        public int PagoId { get; }
        public int ExteriorId { get; } //PENIDIENTE
        public string Nombre { get; }
        public string FechaPago { get; }
        public double SueldoBase { get; }
    }
}
