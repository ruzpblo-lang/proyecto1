using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto
{
    public class ShortCliente
    {
        public ShortCliente(int cuentaId, string nombre)
        {
            CuentaId = cuentaId;
            Nombre = nombre;
        }

        public int CuentaId { get; }
        public string Nombre { get; }
    }
}
