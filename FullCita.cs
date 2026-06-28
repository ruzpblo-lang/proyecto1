using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto
{
    public class FullCita
    {
        public FullCita(int folioId, int clienteId, string cliente, string empleado, string horario, string estado)
        {
            FolioId = folioId;
            ClienteId = clienteId;
            Cliente = cliente;
            Empleado = empleado;
            Horario = horario;
            Estado = estado;
        }

        public int FolioId { get; }
        public int ClienteId { get; }
        public string Cliente { get; }
        public string Empleado { get; }
        public string Horario { get; }
        public string Estado { get; }
    }
}
