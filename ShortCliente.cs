using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto
{
    public class ShortCliente
    {
        public ShortCliente(int clienteId, string nombre)
        {
            ClienteId = clienteId;
            Nombre = nombre;
        }

        public int ClienteId { get; }
        public string Nombre { get; }
    }
}
