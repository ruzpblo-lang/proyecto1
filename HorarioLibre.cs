using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto
{
    public class HorarioLibre
    {
        public HorarioLibre(int horarioId, string fecha, string hora)
        {
            HorarioId = horarioId;
            Fecha = fecha;
            Hora = hora;
        }

        public int HorarioId { get; }
        public string Fecha { get; }
        public string Hora {  get; }
    }
}
