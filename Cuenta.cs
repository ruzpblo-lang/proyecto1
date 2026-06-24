using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto
{
    public class Cuenta
    {
    public Cuenta(int cuentaId, int clienteId, int numeroCuenta, string tipoCuenta, decimal saldo, string estado)
        {
            CuentaId = cuentaId;
            ClienteId = clienteId;
            NumeroCuenta = numeroCuenta;
            TipoCuenta = tipoCuenta;
            Saldo = saldo;
            Estado = estado;
        }

    // 2. Propiedades de la cuenta actualizadas
    public int CuentaId { get; }
    public int ClienteId { get; }
    public int NumeroCuenta { get; }
    public string TipoCuenta { get; }
    public decimal Saldo { get; }
    public string Estado { get; } // Ahora es string para recibir "Activo" o "Inactivo"
}
}
