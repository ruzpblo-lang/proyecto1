using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto
{
    public class Fullpagos
    {
       public Fullpagos(int id, string tipo, string concepto,string fecha,double monto)
        {
            ID = id;
            Tipo = tipo;
            Concepto = concepto;
            Fecha = fecha;
            Monto = monto;
        }

        public int ID { get;}
        public string Tipo { get;}
        public string Concepto { get;}
        public string Fecha { get;}
        public double Monto { get;}
    }
}
