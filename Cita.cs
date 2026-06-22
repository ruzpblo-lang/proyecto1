using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto
{
    public class Cita
    {
        public Cita(string cliente, string horario, string estado)
        {
            Cliente = cliente;
            Horario = horario;
            Estado = estado;
        }

        public string Cliente { get; }
        public string Horario { get; }
        public string Estado { get; } //Pendiente
    }
}
