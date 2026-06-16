using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto
{
    public class Cita
    {
        public int FolioId { get; }
        public int EmpleadoId { get; }
        public int ClienteId { get; }
        public int HorarioId { get; }
        public string Estado { get; } //Pendiente
    }
}
