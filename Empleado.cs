using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto
{
    public class Empleado
    {
        public Empleado(int empleadoId, string nombre, string correo, string telNum, int puestoId, int estado)
        {
            EmpleadoId = empleadoId;
            Nombre = nombre;
            Correo = correo;
            TelNum = telNum;
            PuestoId = puestoId;
            Estado = estado;
        }

        public int EmpleadoId { get; }
        public string Nombre { get; }
        public string Correo { get; }
        public string TelNum { get; }
        public int PuestoId { get; }
        public int Estado { get; }
    }
}
