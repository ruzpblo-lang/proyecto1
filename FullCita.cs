using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto
{
    public class FullCita
    {
        // Actualizamos el constructor para incluir el parámetro clienteId
      

            public FullCita(int folioId, string cliente, string empleado, string horario, string estado)

            {

                FolioId = folioId;

                Cliente = cliente;

                Empleado = empleado;

                Horario = horario;

                Estado = estado;

            }

            public int FolioId { get; }
        public int ClienteId { get; set; } // Esta es la propiedad que Alan necesita para sus filtros
        public string Cliente { get; }
        public string Empleado { get; }
        public string Horario { get; }
        public string Estado { get; }
    }
}