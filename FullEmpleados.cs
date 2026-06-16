using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto
{
    public  class FullEmpleado
    {
        public FullEmpleado(int iD, string nombre, string correo, string telNum, string estado)
        {
            ID = iD;
            Nombre = nombre;
            Correo = correo;
            TelNum = telNum;
            Estado = estado;
           
          
        }

        public int ID { get; }
        public string Nombre { get; }
        public string Correo { get; }
        public string TelNum { get; }
        public string Estado { get; }
        public string Puesto { get; }
     
      

    }
}
