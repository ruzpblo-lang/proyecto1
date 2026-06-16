using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto
{
    public class Cliente
    {
        public Cliente(int clienteId, string nombre, string correo, string telNum, int estado)
        {
            ClienteId = clienteId;
            Nombre = nombre;
            Correo = correo;
            TelNum = telNum;
            Estado = estado;
        }

        public int ClienteId { get; }
        public string Nombre { get; }
        public string Correo { get; }
        public string TelNum { get; }
        public int Estado { get; }
    }
}
