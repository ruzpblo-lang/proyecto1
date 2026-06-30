using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto
{
    public class FullCuenta
    {
       
            public int CuentaId { get; set; }
            public string NombreCliente { get; set; }
            public int NumeroCuenta { get; set; }
            public string TipoCuenta { get; set; }
            public decimal Saldo { get; set; }
            public string Estado { get; set; }

            public FullCuenta(int cuentaId, string nombreCliente, int numeroCuenta, string tipoCuenta, decimal saldo, string estado)
            {
                CuentaId = cuentaId;
                NombreCliente = nombreCliente;
                NumeroCuenta = numeroCuenta;
                TipoCuenta = tipoCuenta;
                Saldo = saldo;
                Estado = estado;
            }
        }
    }
