using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto
{
    public class Nomina
    {
        public Nomina(int nominaId, int empleadoId, string fehca, double suedloBase)
        {
            NominaId = nominaId;
            EmpleadoId = empleadoId;
            Fehca = fehca;
            SuedloBase = suedloBase;
        }

        public int NominaId { get; }
        public int EmpleadoId { get; }
        public string Fehca { get; }
        public double SuedloBase { get; }

    }
}
