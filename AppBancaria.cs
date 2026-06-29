using Microsoft.Data.Sqlite;
using SQLiteUtil;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto
{
    public partial class AppBancaria : Form
    {

        private SqliteConnection conn;

        public AppBancaria()
        {
            InitializeComponent();
            conn = new SqliteConnection("Data Source=Banco.db");
            conn.Open();
        }


        private void btnConsultarAgenda_Click(object sender, EventArgs e)
        {
          FormAgenda forms = new FormAgenda(this);
            forms.ShowDialog();
        }  

        private void btnGestionarPersonal_Click(object sender, EventArgs e)
        {
            FormPersonal forms = new FormPersonal(this);
            forms.ShowDialog();
        }

        private void btnFinanzas_Click(object sender, EventArgs e)
        {
            FormFinanza forms = new FormFinanza(this);
            forms.ShowDialog();
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            FormInventario forms = new FormInventario(this);
            forms.ShowDialog();
        }

        private void AppBancaria_Load(object sender, EventArgs e)
        {

        }
        public int ObtenerempleadoId(string nombre)
        {
            string query = "SELECT EmpleadoId FROM Empleados WHERE Nombre = $nombre LIMIT 1 ";
            var rs = conn.ExecuteReader(query,( "$nombre", nombre));
            if (rs.Read())
            {
                return  rs.GetInt("EmpleadoId");
            }
            return -1;
        }

        public void eliminarpago(int id, string tipo)
        {
            string query = "";
            if (tipo == "Nómina")
            {
                query = "DELETE FROM Nomina WHERE NominaID ? $id;";
            }
            else if (tipo == "Gasto Externo")
            {
                query = "DELETE FROM Pagos WHERE PagoId = $id;";
            }
            if (!string.IsNullOrEmpty(query))
            {
                conn.ExecuteNonQuery(query, ("$id", id));
            }    
        }

        public void Cambiarestado(int id, string tipo)
        {
            string query = "";
            if (tipo == "Nómina")
            {
                query = "UPDATE Nomina SET Estado = 'Realizado' WHERE NominaID = $id;";
            }
            else if (tipo == "Gasto Externo")
            { 
                query = "UPDATE Pagos SET Estado = 'Realizado' WHERE PAGOId = $id;";
            }
            if (!string.IsNullOrEmpty (query))
            {
                conn.ExecuteNonQuery(query,("$id",  id));
            }
        }
        public void AgregarNomina(int EmpleadoId, string fechapago, decimal sueldobase, string estado)
        {
            string queryInsert = @"INSERT INTO Nomina (EmpleadoID, FechaPago, SueldoBase,Estado)
                                   VALUES ($empleadoId, $fecha, $sueldo, $estado);";
            conn.ExecuteNonQuery(queryInsert,
                ("$empleadoId", EmpleadoId),
                ("$fecha", fechapago),
                ("$sueldo", sueldobase),
                ("$estado", estado)
                );
        }
        public void AgregarPagoexterno(int exteriorID,string nombre,string fechapago, decimal sueldobase, string estado)
        {
            string queryInsert = @"INSERT INTO Pagos (ExteriorID,Nombre, FechaPago, SueldoBase,Estado)
                                   VALUES ($exteriorId, $nombre, $fecha, $sueldo, $estado);";
            conn.ExecuteNonQuery(queryInsert,
                ("$exteriorId", exteriorID),
                ("$nombre", nombre),
                ("$fecha", fechapago),
                ("$sueldo", sueldobase),
                ("$estado", estado)
                );
        }
        public List<ShortCliente> ShortClientes()
        {
            List<ShortCliente> listacliente = new List<ShortCliente>();

            string query = "SELECT ClienteId, Nombre FROM [Clientes] WHERE Estado = 1;";

            var rs = conn.ExecuteReader(query);
            while (rs.Read())
            {
                listacliente.Add(new ShortCliente(
                    rs.GetInt("ClienteId"),
                    rs.GetString("Nombre")));
            }
            return listacliente;
        }

        public List<Cita> GetCitas()
        {
            List<Cita> CitasDipsonibles = new List<Cita>();

            string query = "SELECT cl.Nombre AS Cliente, (c.Fecha || ' ' || c.Hora) AS Horario, c.Estado" +
                            "\r\nFROM [Citas] c" +
                            "\r\nINNER JOIN [Clientes] cl ON c.ClienteId = cl.ClienteId";

            var rs = conn.ExecuteReader(query);
            while (rs.Read())
            {
                CitasDipsonibles.Add(new Cita(
                    rs.GetString("Cliente"),
                    rs.GetString("Horario"),
                    rs.GetString("Estado")));
            }

            return CitasDipsonibles;
        }

        public List<FullCita> GetFullCitas()
        {
            List<FullCita> CitasDipsonibles = new List<FullCita>();

            string query = "SELECT c.FolioId, c.ClienteId, " +
                            "\r\nCASE" +
                            "\r\nWHEN c.ClienteId > 0 THEN cl.Nombre" +
                            "\r\nWHEN c.ClienteId < 0 THEN 'Proveedor'" +
                            "\r\nWHEN c.ClienteId = 0 THEN e.Nombre" +
                            "\r\nEND AS Cliente," +
                            "\r\ne.Nombre AS Empleado," +
                            "\r\n(c.Fecha || ' ' || c.Hora) AS Horario," +
                            "\r\nc.Estado\r\nFROM [Citas] c" +
                            "\r\nLEFT JOIN [Clientes] cl ON c.ClienteId = cl.ClienteId" +
                            "\r\nINNER JOIN [Empleados] e ON c.EmpleadoId = e.EmpleadoId;";

            var rs = conn.ExecuteReader(query);
            while (rs.Read())
            {
                CitasDipsonibles.Add(new FullCita(
                    rs.GetInt("FolioId"),
                    rs.GetInt("ClienteId"),
                    rs.GetString("Cliente"),
                    rs.GetString("Empleado"),
                    rs.GetString("Horario"),
                    rs.GetString("Estado")));
            }

            return CitasDipsonibles;
        }

        public bool ConfirmarCita(int folioId)
        {
            string queryUpdate = "UPDATE Citas SET Estado = 'Confirmada' WHERE FolioId = @folioId;";

            // Se ejecuta directo usando tu formato de tuplas
            conn.ExecuteNonQuery(queryUpdate,
                ("@folioId", folioId)
            );

            return true;
        }

        public List<FullCita> GetCitaPorPaciente(int cuentaId)
        {
            List<FullCita> CitaPorPaciente = new List<FullCita>();
            string query = $"SELECT c.FolioId, c.ClienteId, cl.Nombre AS Cliente, e.Nombre AS Empleado, (c.Fecha || ' ' || c.Hora) AS Horario, c.Estado " +
                            $"\r\nFROM [Citas] c" +
                            $"\r\nINNER JOIN [Clientes] cl ON c.ClienteId = cl.ClienteId" +
                            $"\r\nINNER JOIN [Empleados] e ON c.EmpleadoId = e.EmpleadoId" +
                            $"\r\nWHERE c.ClienteId = {cuentaId};";

            var rs = conn.ExecuteReader(query);
            while (rs.Read())
            {
                CitaPorPaciente.Add(new FullCita(
                    rs.GetInt("FolioId"),
                    rs.GetInt("ClienteId"),
                    rs.GetString("Cliente"),
                    rs.GetString("Empleado"),
                    rs.GetString("Horario"),
                    rs.GetString("Estado")));
            }
            return CitaPorPaciente;
        }


        public List<FullEmpleado> GetTodosLosEmpleados()
        {
            List<FullEmpleado> listaCompleta = new List<FullEmpleado>();

            string query = "SELECT e.EmpleadoId, e.Nombre, e.Correo, e.TelNum, e.Estado, p.Categoria, p.Sueldo" +
                            "\r\nFROM Empleados e" +
                            "\r\nINNER JOIN Puestos p ON e.PuestoId = p.PuestoId;";

            var rs = conn.ExecuteReader(query);
            while (rs.Read())
            {

                string estadoTexto = "Inactivo";
                if (rs.GetInt("Estado") == 1)
                {
                    estadoTexto = "Activo";
                }
                listaCompleta.Add(new FullEmpleado(
                    rs.GetInt("EmpleadoId"),
                    rs.GetString("Nombre"),
                    rs.GetString("Correo"),
                    rs.GetString("TelNum"),
                    estadoTexto,
                rs.GetString("categoria")));


            }
            return listaCompleta;
        }           

        public List<Fullpagos> GetTodosLosPagos()
        {
            List<Fullpagos> listaPagos = new List<Fullpagos>();
            string query = @"SELECT N.NominaID as ID, 'Nómina' AS Tipo, E.Nombre AS Concepto, N.FechaPago AS Fecha, N.SueldoBase AS Monto, N.Estado AS Estado
                           FROM Nomina N
                           INNER JOIN Empleados E ON N.EmpleadoId = E.EmpleadoId
                           UNION ALL
                           SELECT P.PagoId AS ID, 'Gasto Externo' AS Tipo, P.Nombre AS Concepto,P.FechaPago AS Fecha, P.SueldoBase AS Monto, P.Estado AS Estado
                           FROM Pagos P;";
            var rs =conn.ExecuteReader(query);
            while (rs.Read())
            {

                listaPagos.Add(new Fullpagos(
                    rs.GetInt("ID"),
                    rs.GetString("Tipo"),
                    rs.GetString("Concepto"),
                    rs.GetString("Fecha"),
                    rs.GetDouble("Monto"),
                    rs.GetString("Estado")
                    ));
            }
            return listaPagos;
        }
        public List<Inventario> GetInventario()
        {
            List<Inventario> ListaInventario = new List<Inventario>();
            string query = "SELECT ObjetoId, Tipo, Cantidad FROM inventario";

            var rs =conn.ExecuteReader(query);
            
            while (rs.Read())
            {
                ListaInventario.Add(new Inventario(
                    rs.GetInt ("ObjetoId"),
                    rs.GetString("Tipo"),
                    rs.GetInt ("Cantidad")
                ));
            }
            return ListaInventario; 
        }

        public List<Cliente> GetInventarioCliente()
        {
            List<Cliente> clientes = new List<Cliente>();
            string query = "SELECT ClienteId, Nombre, Correo, TelNum, Estado FROM Clientes";

            var rs = conn.ExecuteReader(query);
            while(rs.Read())
            {
                string estadoTexto = "Inactivo";
                if (rs.GetInt("Estado") == 1)
                {
                    estadoTexto = "Activo";
                }
                clientes.Add(new Cliente(
                    rs.GetInt("ClienteId"),
                   
                    rs.GetString("Nombre"),
                    rs.GetString("Correo"),
                    rs.GetString("TelNum"),
                   estadoTexto
                    ));
            }
            return clientes;
        }

        
        internal object GetTodosLosPuestos()
        {
            List<Puesto> listaPuesto = new List<Puesto>();


            string query = "SELECT p.PuestoId, p.Categoria, P.Sueldo\r\nFROM Puestos p\r\n";


            var rs = conn.ExecuteReader(query);


            while (rs.Read())
            {
                listaPuesto.Add(new Puesto(
                    rs.GetInt("PuestoId"),
                    rs.GetString("Categoria"),
                    rs.GetDouble("Sueldo")));
            }

            return listaPuesto;
        }
        public object GetEmpleadosPorPuesto(string puestoSeleccionado)
        {
            List<Empleado> listaEmpleados = new List<Empleado>();

            string query = "SELECT e.EmpleadoId, e.Nombre, e.Correo, e.TelNum, e.PuestoId, e.Estado\r\nFROM Empleados e\r\nINNER JOIN Puestos p ON e.PuestoId = p.PuestoId\r\nWHERE p.Categoria = '" + puestoSeleccionado + "'\r\n";

            var rs = conn.ExecuteReader(query);

            while (rs.Read())
            {
                listaEmpleados.Add(new Empleado(
                    rs.GetInt("EmpleadoId"),
                    rs.GetString("Nombre"),
                    rs.GetString("Correo"),
                    rs.GetString("TelNum"),
                    rs.GetInt("PuestoId"),
                    rs.GetInt("Estado")));
            }

            return listaEmpleados;
        }

        internal void CrearEmpleado(string nombre, string correo, string telefono, int puestoId, int estado)
        {
            {
                int nuevoId = 1;

                string query = "SELECT IFNULL(MAX(EmpleadoId), 0) AS MaxId\r\nFROM Empleados";

                var rs = conn.ExecuteReader(query);

                while (rs.Read())
                {
                    nuevoId = rs.GetInt("MaxId") + 1;
                }
                string queryInsert = "INSERT INTO Empleados (EmpleadoId, Nombre, Correo, TelNum, PuestoId, Estado) \r\n" +
                               "VALUES ($empleadoId, $nombre, $correo, $telNum, $puestoId, $estado)";


                conn.ExecuteNonQuery(
                    queryInsert,
                    ("$empleadoId", nuevoId),
                    ("$nombre", nombre),
                    ("$correo", correo),
                    ("$telNum", telefono),
                    ("$puestoId", puestoId),
                    ("$estado", estado)
                );
            }
        }

        internal void ModificarEstadoEmpleado(int empleadoId, int nuevoEstado)
        {
            {
                string query = "UPDATE Empleados \r\nSET Estado = $nuevoEstado\r\nWHERE EmpleadoId = $empleadoId;";

                conn.ExecuteNonQuery(
                    query,
                    ("$nuevoEstado", nuevoEstado),
                    ("$empleadoId", empleadoId)
                );
            }
        }

        internal void AgregarBillete(object tipo, object cantidad)
        {
            string query = "UPDATE Inventario SET Cantidad = Cantidad + $cantidad WHERE [Tipo] = $tipo";
            conn.ExecuteNonQuery(query,
                ("$tipo", tipo),
                ("$cantidad",  cantidad));
        }
        internal void AgregarCliente(string nombre, string correo, string telefono)
        {
           

            string queryInsert = "INSERT into Clientes ( Nombre, Correo, TelNum, Estado) " +
                            "VALUES ( $nombre, $correo, $telNum, $estado)";
            conn.ExecuteNonQuery(
                queryInsert,
              
                ("$nombre", nombre),
                ("$correo", correo),
                ("$telNum", telefono),
                ("$estado", 1));
               


        }
public List<PrecioProveedor> MostrarProductosProveedores()
        {
            List<PrecioProveedor> preciosproveedores = new List<PrecioProveedor>();
            string query = "SELECT pp.PrecioId, pp.ObjetoId, pb.Tipo, pv.Nombre, pp.Precio " +
                            "FROM PreciosProveedor pp " +
                            "INNER JOIN ProductosBodega pb ON pp.ObjetoId = pb.ObjetoId " +
                            "INNER JOIN Proveedores pv ON pp.ProveedorId = pv.ProveedorID " +
                            "ORDER BY pb.Tipo ASC, pp.Precio ASC";

            var rs = conn.ExecuteReader(query);
            while (rs.Read())
            {
                preciosproveedores.Add(new PrecioProveedor(
                    rs.GetInt("PrecioId"),
                    rs.GetInt("ObjetoId"),
                    rs.GetString("Tipo"),
                    rs.GetString("Nombre"),
                    rs.GetDouble("Precio")
                    ));
            }
            return preciosproveedores;
        }

        internal void RegistrarPagosProducto(string tipo, string proveedor, decimal totalCompra)
        {
            string nombreServicio = "Compra de insumos de bodega";
            string queryServicio = "INSERT   OR IGNORE INTO CatalogoServicios (Nombre) VALUES ($nombre)";
            conn.ExecuteNonQuery(queryServicio, ("$nombre", nombreServicio));

            int ServicioId = 0;
            string queryGetId = "SELECT ServicioId FROM CatalogoServicios WHERE Nombre = $nombre";
            var rs = conn.ExecuteReader(queryGetId, ("$nombre", nombreServicio));

            while (rs.Read())
            {
                ServicioId = rs.GetInt("ServicioId");
            } 

            string fecha = DateTime.Now.ToString("yyyy-MM-dd");
            string concepto = tipo + "-" + proveedor;
            string queryInsert = "INSERT INTO Pagos (ServicioId, Nombre, FechaPago, SueldoBase, Estado) " +
                                 "VALUES ($servicioId, $nombre, $fechaPago, $sueldoBase, $estado)";

            conn.ExecuteNonQuery(queryInsert,
                ("servicioId", ServicioId),
                ("$nombre", concepto),
                ("$fechaPago", fecha),
                ("$sueldoBase", totalCompra),
                ("$estado", "Realizado")
                );
        }

        internal void AgregarProducto(int objetoId, int cantidad)
        {
            string query = "UPDATE ProductosBodega SET Cantidad = Cantidad + $cantidad WHERE ObjetoId = $objetoId";
            conn.ExecuteNonQuery(query,
                ("$objetoId", objetoId),
                ("$cantidad", cantidad));
        }

        public List<ProductoBodega> GetInventarioDeposito()
        {
            List<ProductoBodega> productosBodega = new List<ProductoBodega>();
            string query = "SELECT ObjetoId, Tipo, Cantidad FROM productosBodega";

            var rs = conn.ExecuteReader(query);
            while (rs.Read())
            {
                productosBodega.Add(new ProductoBodega(
                    rs.GetInt("ObjetoId"),
                    rs.GetString("Tipo"),
                    rs.GetInt("Cantidad")
                    ));
            }
            return productosBodega;
        }

        internal object GetProveedores()
        {
            List<Proveedor> listaProveedores = new List<Proveedor>();
            string query = "SELECT ProveedorId, Nombre FROM Proveedores;";

            var rs = conn.ExecuteReader(query);
            while (rs.Read())
            {
                listaProveedores.Add(new Proveedor(
                    rs.GetInt("ProveedorId"),
                    rs.GetString("Nombre")
                ));
            }

            return listaProveedores;
        }

        public bool AgendarCitaGerencia(int empleadoId, int clienteId, string fecha, string hora)
        {
            if (!VerificarDisponibilidadCita(fecha, hora))
            {
                return false;
            }

            string queryInsert = @"INSERT INTO Citas (EmpleadoId, ClienteId, Fecha, Hora, Estado) 
                                   VALUES ($empleadoId, $clienteId, $fecha, $hora, 'Pendiente');";

            conn.ExecuteNonQuery(queryInsert,
                ("$empleadoId", empleadoId),
                ("$clienteId", clienteId),
                ("$fecha", fecha),
                ("$hora", hora)
            );

            return true;
        }

        public bool VerificarDisponibilidadCita(string fecha, string hora)
        {
            string query = "SELECT COUNT(*) AS Total FROM Citas WHERE Fecha = $fecha AND Hora = $hora AND Estado != 'Cancelada'";

            var rs = conn.ExecuteReader(query,
                ("$fecha", fecha),
                ("$hora", hora));

            if (rs.Read())
            {
                int total = rs.GetInt("Total");
                return total == 0;
            }
            return false;
        }
        internal void ModificarEstadocLIENTE(int clienteId, int nuevoEstado)
        {
            {
                string query = "UPDATE [Clientes] SET [Estado] = $nuevoEstado WHERE [ClienteId] = $clienteId;";

                conn.ExecuteNonQuery(
                    query,
                    ("$nuevoEstado", nuevoEstado),
                    ("clienteId",clienteId)
                );
            }
        }

        public List<Cliente> GetTodosLosClientes()
        {
            List<Cliente> clientes = new List<Cliente>();
            // Seleccionamos solo los campos necesarios de la tabla Clientes
            string query = "SELECT ClienteId, Nombre, Correo, TelNum, Estado FROM Clientes WHERE Estado = 1";

            var rs = conn.ExecuteReader(query);
            while (rs.Read())
            {
                clientes.Add(new Cliente(
                    rs.GetInt("ClienteId"),
                   
                    rs.GetString("Nombre"),
                    rs.GetString("Correo"),
                    rs.GetString("TelNum"),
                    rs.GetString("Estado")
                ));
            }
            return clientes;
        }

        public void CrearCuenta(int clienteId, int numeroCuenta, string tipoCuenta, decimal saldo, int estado)
        {
            
            string query = $"INSERT INTO [Cuentas] ([ClienteId], [NumeroCuenta], [TipoCuenta], [Saldo], [Estado]) " +
                           $"VALUES ({clienteId}, {numeroCuenta}, '{tipoCuenta}', {saldo}, {estado});";

            conn.ExecuteNonQuery(query);
        }
        public List<Cuenta> GetCuentas()
        {
            List<Cuenta> cuentas = new List<Cuenta>();
            string query = "SELECT CuentaId, ClienteId, NumeroCuenta, TipoCuenta, Saldo, Estado FROM Cuentas";

            var rs = conn.ExecuteReader(query);
            while (rs.Read())
            {
                // Aplicamos exactamente tu misma lógica de conversión para el estado
                string estadoTexto = "Inactivo";
                if (rs.GetInt("Estado") == 1)
                {
                    estadoTexto = "Activo";
                }
                decimal saldoDecimal = Convert.ToDecimal(rs.GetString("Saldo"));
                // Agregamos el objeto Cuenta mapeando cada columna
                cuentas.Add(new Cuenta(
                    rs.GetInt("CuentaId"),
                    rs.GetInt("ClienteId"),
                    rs.GetInt("NumeroCuenta"),
                    rs.GetString("TipoCuenta"),
                    saldoDecimal,
                    estadoTexto
                ));
            }
            return cuentas;
        }

        public void ModificarEstadoCuenta(int cuentaId, int nuevoEstado)
        {
            
            string query = "UPDATE [Cuentas] SET [Estado] = $nuevoEstado WHERE [CuentaId] = $cuentaId;";

            
            conn.ExecuteNonQuery(
                query,
                ("$nuevoEstado", nuevoEstado),
                ("$cuentaId", cuentaId)
            );
        }

        public double ObtenerSaldo()
        {
            string query = @"
              SELECT
                  (SELECT IFNULL(SUM(Monto), 0) FROM Ingresos WHERE  Estado = 'Realizado') -
                  (SELECT IFNULL(SUM(SueldoBase), 0) FROM Nomina WHERE Estado = 'Realizado') -
                  (SELECT IFNULL(SUM(SueldoBase), 0) FROM Pagos WHERE Estado = 'Realizado') 
                   AS SaldoActual;";
            var rs = conn.ExecuteReader(query);
            if (rs.Read())
            {
                return rs.GetDouble("SaldoActual");
            }
            return 0;
        }

        public void Registraringreso(string concepto, double monto, string fecha)
        {
            string query = $@"
                INSERT INTO Ingresos (Concepto, Monto, FechaIngreso)
                Values ('{concepto}', {monto}, '{fecha}');";
            conn.ExecuteNonQuery(query);
        }
        public List<Reportemensual> Obtenerdatosgraf()
        {
            List<Reportemensual> lista = new List<Reportemensual>();
            string query = @"
                SELECT Mes,
                       SUM(IngresoTotal) AS TotalIngreso,
                       SUM(EgresoTotal) AS TotalEgreso
                FROM (
                   SELECT substr(FechaIngreso, 1, 7) AS Mes, Monto AS IngresoTotal, 0 AS EgresoTotal
                   FROM Ingresos
                UNION ALL
                   SELECT substr(Fechapago, 1, 7) AS Mes, 0 AS IngresoTotal, SueldoBase as EgresoTotal
                   FROM Nomina
                   WHERE Estado = 'Realizado'
                UNION ALL
                   SELECT substr(Fechapago, 1,7) AS Mes, 0 as IngresoTotal, SueldoBase as EgresoTotal
                   FROM Pagos
                   WHERE Estado = 'Realizado'
                      )
                 GROUP BY Mes
                 ORDER BY Mes;";
            var rs = conn.ExecuteReader(query);
            while (rs.Read())
            {
                Reportemensual fila = new Reportemensual();
                fila.Mes = rs.GetString("Mes");
                fila.Ingresos = rs.GetDouble("TotalIngreso");
                fila.Egresos = rs.GetDouble("TotalEgreso");
                lista.Add(fila);
            }
            return lista;
        }
        public List<Fullpagos> obtenertodoslosmovimientos()
        {
            List<Fullpagos> listamovimientos = new List<Fullpagos>();
            string query = @"
                 SELECT N.NominaID as ID, 'Nómina' AS Tipo, E.Nombre AS Concepto, N.FechaPago AS Fecha, N.SueldoBase AS Monto, N.Estado AS Estado
                 FROM Nomina N
                 INNER JOIN Empleados E ON N.EmpleadoId = E.EmpleadoId

                 UNION ALL
                 
                 SELECT P.PagoId AS ID,
                        CASE WHEN P.ServicioId IS NOT NULL THEN 'Servicio' ELSE 'Gasto Externo' END AS Tipo,
                        P.Nombre AS Concepto, P.FechaPago AS Fecha, P.SueldoBase AS Monto, P.Estado AS Estado
                 FROM Pagos P
                 
                 UNION ALL
                 
                 SELECT I.IngresoId AS ID, 'Ingreso' AS Tipo, I.Concepto AS Concepto, I.FechaIngreso AS Fecha, I.Monto AS Monto, I.Estado AS Estado
                 FROM Ingresos I;";
            var rs =conn.ExecuteReader(query);
            while(rs.Read())
            {
                listamovimientos.Add(new Fullpagos(
                rs.GetInt("ID"),
                rs.GetString("Tipo"),
                rs.GetString("Concepto"),
                rs.GetString("Fecha"),
                rs.GetDouble("Monto"),
                rs.GetString("Estado")
                ));
            }
            return listamovimientos;
        }

        public void agregarservicio(string Nombreservicio, string fecha, decimal monto, string estado)
        {
            string queryservicio = "INSERT OR IGNORE INTO CatalogoServicios (Nombre) VALUES ($nombre)";
            conn.ExecuteNonQuery(queryservicio, ("$nombre", Nombreservicio));
            int servicioID = 0;
            string querygetID = "SELECT ServicioId FROM CatalgoServicios WHERE Nombre = $nombre";
            var rs = conn.ExecuteReader(querygetID, ("$nombre",  Nombreservicio));
            if(rs.Read())
            {
                servicioID = rs.GetInt("ServicioId");
            }
            string queryinsert = @"INSERT INTO Pagos (ServicioId, Nombre, FechaPago, SueldoBase, Estado
                                   VALUES ($servicioId, $nombre, $fechaPago, $sueldobase, $estado)";

            conn.ExecuteNonQuery(queryinsert,
                ("$servicioId",  servicioID),
                ("$nombre", Nombreservicio),
                ("$fechaPago", fecha),
                ("$sueldoBase", monto),
                ("$estado", estado)
                );
        }
        public List<string> Getcatalogoservicios()
        {
            List<string> servicios = new List<string>();
            string query = "SELECT Nombre FROM CatalogoServicios ORDER BY Nombre ASC;";
            var rs = conn.ExecuteReader(query);
            while (rs.Read())
            {
                servicios.Add(rs.GetString("Nombre"));
            }
            return servicios;
        }
    }
}