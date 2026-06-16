using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto
{
    public class Cuenta
    {
        public Cuenta(int cuentaId, int clienteId, int estado)
        {
            CuentaId = cuentaId;
            ClienteId = clienteId;
            Estado = estado;
        }

        public int CuentaId { get; }
        public int ClienteId { get; }
        public int Estado {  get; }
    }
}
