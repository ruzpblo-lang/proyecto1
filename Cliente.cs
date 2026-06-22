using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto
{
    public class Cliente
    {
        public Cliente(int clienteId, int cuentaId,string nombre, string correo, string telNum, int estado, double monto)
        {
            ClienteId = clienteId;
            CuentaId = cuentaId;
            Nombre = nombre;
            Correo = correo;
            TelNum = telNum;
            Estado = estado;
            Monto = monto;
        }

        public int ClienteId { get; }
        public int CuentaId { get; }
        public string Nombre { get; }
        public string Correo { get; }
        public string TelNum { get; }
        public int Estado { get; }
        public double Monto { get; }
    }
}
