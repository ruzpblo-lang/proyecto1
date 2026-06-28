PRAGMA foreign_keys = OFF;
DROP TABLE IF EXISTS [Citas];
DROP TABLE IF EXISTS [Nomina];
DROP TABLE IF EXISTS [Empleados];
DROP TABLE IF EXISTS [Puestos];
DROP TABLE IF EXISTS [Clientes];
DROP TABLE IF EXISTS [Pagos];
DROP TABLE IF EXISTS [Inventario];
DROP TABLE IF EXISTS [Proveedores];
DROP TABLE IF EXISTS [ProductosBodega];
DROP TABLE IF EXISTS [PreciosProveedor];
DROP TABLE IF EXISTS [CatalogoServicios];
DROP TABLE IF EXISTS [Ingresos];
DROP TABLE IF EXISTS [CortesMensuales];
DROP TABLE IF EXISTS [Cuentas];

PRAGMA foreign_keys = ON;

-- ========================================================
-- 1. CREACIÓN DE TABLAS
-- ========================================================

CREATE TABLE [Puestos] (
  [PuestoId] INTEGER PRIMARY KEY AUTOINCREMENT,
  [Categoria] TEXT UNIQUE NOT NULL,
  [Sueldo] DECIMAL NOT NULL,
  [Estado] INTEGER NOT NULL DEFAULT 1
);
  
CREATE TABLE [Empleados] (
  [EmpleadoId] INTEGER PRIMARY KEY AUTOINCREMENT,
  [Nombre] TEXT NOT NULL,
  [Correo] TEXT UNIQUE NOT NULL,
  [TelNum] TEXT UNIQUE NOT NULL,
  [PuestoId] INTEGER REFERENCES Puestos(PuestoId),
  [Estado] INTEGER NOT NULL
);
  
CREATE TABLE [Clientes] (
  [ClienteId] INTEGER PRIMARY KEY AUTOINCREMENT,
  [CuentaId] INTEGER NOT NULL, 
  [Nombre] TEXT NOT NULL,
  [Correo] TEXT UNIQUE NOT NULL,
  [TelNum] TEXT UNIQUE NOT NULL,
  [Estado] INTEGER NOT NULL,
  [Monto] DECIMAL NOT NULL DEFAULT 0
); 
  
CREATE TABLE [Citas] (
  [FolioId] INTEGER PRIMARY KEY AUTOINCREMENT,
  [EmpleadoId] INTEGER REFERENCES Empleados(EmpleadoId),
  [ClienteId] INTEGER NOT NULL, 
  [Fecha] TEXT NOT NULL,  
  [Hora] TEXT NOT NULL,   
  [Estado] TEXT NOT NULL DEFAULT 'Pendiente'
);
  
CREATE TABLE [Nomina] (
  [NominaId] INTEGER PRIMARY KEY AUTOINCREMENT,
  [EmpleadoId] INTEGER REFERENCES Empleados(EmpleadoId),
  [FechaPago] TEXT,
  [SueldoBase] DECIMAL,
  [Estado] TEXT NOT NULL DEFAULT 'Pendiente'
);

CREATE TABLE [CatalogoServicios] (
  [ServicioId] INTEGER PRIMARY KEY AUTOINCREMENT,
  [Nombre] TEXT UNIQUE NOT NULL
);

CREATE TABLE [Pagos] (
  [PagoId] INTEGER PRIMARY KEY AUTOINCREMENT,
  [ServicioId] INTEGER REFERENCES CatalogoServicios(ServicioId),
  [Nombre] TEXT NOT NULL,
  [FechaPago] TEXT NOT NULL,  
  [SueldoBase] DECIMAL NOT NULL,   
  [Estado] TEXT NOT NULL DEFAULT 'Pendiente'
);
  
CREATE TABLE [Inventario] (
  [ObjetoId] INTEGER PRIMARY KEY AUTOINCREMENT,
  [Tipo] TEXT UNIQUE NOT NULL, 
  [Cantidad] INTEGER NOT NULL DEFAULT 0
);
  
CREATE TABLE [Proveedores] (
  [ProveedorId] INTEGER PRIMARY KEY AUTOINCREMENT,
  [Nombre] TEXT UNIQUE NOT NULL
);
  
CREATE TABLE [ProductosBodega] (
  [ObjetoId] INTEGER PRIMARY KEY AUTOINCREMENT,
  [Tipo] TEXT UNIQUE NOT NULL,
  [Cantidad] INTEGER NOT NULL DEFAULT 0
);
  
CREATE TABLE [PreciosProveedor] (
  [PrecioID] INTEGER PRIMARY KEY AUTOINCREMENT,
  [ObjetoId] INTEGER NOT NULL REFERENCES ProductosBodega(ObjetoId),
  [ProveedorId] INTEGER NOT NULL REFERENCES Proveedores(ProveedorId),
  [Precio] DECIMAL NOT NULL DEFAULT 0
);

CREATE TABLE [Ingresos] (
  [IngresoId] INTEGER PRIMARY KEY AUTOINCREMENT,
  [Concepto] TEXT NOT NULL,
  [Monto] DECIMAL NOT NULL,
  [FechaIngreso] TEXT NOT NULL,
  [Origen] TEXT NOT NULL DEFAULT 'Central',
  [Estado] TEXT NOT NULL DEFAULT 'Realizado'
);

CREATE TABLE [CortesMensuales] (
  [CorteId] INTEGER PRIMARY KEY AUTOINCREMENT,
  [MesAnio] TEXT UNIQUE NOT NULL,
  [TotalIngresos] DECIMAL NOT NULL DEFAULT 0,
  [TotalEgresos] DECIMAL NOT NULL DEFAULT 0,
  [SaldoNeto] DECIMAL NOT NULL DEFAULT 0,
  [EstadoBalance] TEXT NOT NULL,
  [FechaCierre] TEXT NOT NULL
);

CREATE TABLE [Cuentas] (
  [CuentaId] INTEGER PRIMARY KEY AUTOINCREMENT,
  [ClienteId] INTEGER NOT NULL REFERENCES Clientes(ClienteId),
  [NumeroCuenta] INTEGER UNIQUE NOT NULL,
  [TipoCuenta] TEXT NOT NULL,
  [Saldo] DECIMAL NOT NULL DEFAULT 0,
  [Estado] INTEGER NOT NULL DEFAULT 1
);


-- ========================================================
-- 2. INSERCIÓN DE DATOS SIMULADOS
-- ========================================================

INSERT INTO [Puestos] (Categoria, Sueldo, Estado) VALUES
('Cajero Bancario', 12000.00, 1),
('Gerente de Sucursal', 35000.00, 1),
('Asesor Financiero', 18000.00, 1),
('Administrador de Base de Datos', 25000.00, 1);

INSERT INTO [Empleados] (Nombre, Correo, TelNum, PuestoId, Estado) VALUES
('Eric Cordero', 'eric.cordero@banco.mx', '9991112233', 4, 1),
('Byron', 'byron.cajero@banco.mx', '9992223344', 1, 1),
('Valeria Gomez', 'valeria.gerente@banco.mx', '9993334455', 2, 1);

INSERT INTO [Clientes] (CuentaId, Nombre, Correo, TelNum, Estado, Monto) VALUES
(50001, 'Ana Perez', 'ana.perez@correo.com', '9994445566', 1, 67.00),
(50002, 'Juan Lopez', 'juan.lopez@correo.com', '9995556677', 1, 41.00),
(50003, 'Maria Fernandez', 'maria.f@correo.com', '9996667788', 1, 777.00);

INSERT INTO [Citas] (EmpleadoId, ClienteId, Fecha, Hora, Estado) VALUES
(3, 1, '2026-06-08', '09:00', 'Confirmada'), 
(3, 2, '2026-06-08', '10:30', 'Pendiente'),  
(2, 3, '2026-06-10', '14:00', 'Pendiente');  

INSERT INTO [Nomina] (EmpleadoId, FechaPago, SueldoBase) VALUES
(1, '2026-06-15', 12500.00), 
(2, '2026-06-15', 6000.00),  
(3, '2026-06-15', 17500.00); 

INSERT INTO [CatalogoServicios] (Nombre) VALUES
('CFE - Servicio Eléctrico'),
('JAPAY - Agua Potable'),
('Infinitum - Internet Corporativo'),
('Arrendamiento de Sucursal');

INSERT INTO [Pagos] (ServicioId, Nombre, FechaPago, SueldoBase, Estado) VALUES
(1, 'Pago de recibo de luz periodo Mayo-Junio', '2026-06-05', 4500.50, 'Realizado'),
(NULL, 'Cometra - Transporte de Valores (Gasto Externo)', '2026-06-06', 12500.00, 'Pendiente'),
(NULL, 'Compra de papelería urgente de emergencia', '2026-06-12', 350.00, 'Realizado');

INSERT INTO [Ingresos] (Concepto, Monto, FechaIngreso, Origen) VALUES
('Asignación de Saldo Mensual Junio', 50000.00, '2026-06-01', 'Central'),
('Comisiones por apertura de cuentas', 3500.00, '2026-06-15', 'Interno');

INSERT INTO [Inventario] (Tipo, Cantidad) VALUES
('Billete de 1000', 50),
('Billete de 500', 200),
('Billete de 200', 150),
('Billete de 100', 300),
('Moneda de 10', 500);

INSERT INTO [Proveedores] (Nombre) VALUES
('Office Depot'),
('Garrafones del Sureste'),
('Papelera Yucateca');

INSERT INTO [ProductosBodega] (Tipo, Cantidad) VALUES
('Garrafon de agua 20L', 15),
('Paquete de hojas blancas', 30),
('Folder tamano carta', 100),
('Plumas color negro', 50);

INSERT INTO [PreciosProveedor] (ObjetoId, ProveedorId, Precio) VALUES
(1, 2, 45.00), 
(1, 1, 48.50), 
(2, 1, 65.00), 
(2, 3, 60.00), 
(3, 1, 3.50),  
(3, 3, 3.00),  
(4, 1, 6.00);