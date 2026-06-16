
DROP TABLE IF EXISTS [Citas];
DROP TABLE IF EXISTS [Nomina];
DROP TABLE IF EXISTS [Empleados];
DROP TABLE IF EXISTS [Puestos];
DROP TABLE IF EXISTS [HorariosLibres];
DROP TABLE IF EXISTS [Clientes];
DROP TABLE IF EXISTS [Pagos];
DROP TABLE IF EXISTS [Inventario];

CREATE TABLE [Puestos] (
  [PuestoId] INTEGER PRIMARY KEY AUTOINCREMENT,
  [Categoria] TEXT UNIQUE NOT NULL,
  [Sueldo] DECIMAL NOT NULL);
  
CREATE TABLE [Empleados] (
  [EmpleadoId] INTEGER PRIMARY KEY AUTOINCREMENT,
  [Nombre] TEXT NOT NULL,
  [Correo] TEXT UNIQUE NOT NULL,
  [TelNum] TEXT UNIQUE NOT NULL,
  [PuestoId] INTEGER REFERENCES Puestos(PuestoId),
  [Estado] INTEGER NOT NULL);
  
  CREATE TABLE [Clientes] (
  [ClienteId] INTEGER PRIMARY KEY AUTOINCREMENT,
  [CuentaId] INTEGER NOT NULL, 
  [Nombre] TEXT NOT NULL,
  [Correo] TEXT UNIQUE NOT NULL,
  [TelNum] TEXT UNIQUE NOT NULL,
  [Estado] INTEGER NOT NULL ); -- Por si tiene de baja la cuenta 
  
  CREATE TABLE [HorariosLibres] (
  [HorarioId] INTEGER PRIMARY KEY AUTOINCREMENT,
  [Fecha] TEXT NOT NULL, 
  [Hora] TEXT NOT NULL   
);

CREATE TABLE [Citas] (
  [FolioId] INTEGER PRIMARY KEY AUTOINCREMENT,
  [EmpleadoId] INTEGER REFERENCES Empleados(EmpleadoId),
  [CuentaId] INTEGER NOT NULL, 
  [HorarioId] INTEGER REFERENCES HorariosLibres(HorarioId),
  [Estado] TEXT NOT NULL DEFAULT 'Pendiente'
);

  
  CREATE TABLE Nomina (
    [NominaId] INTEGER PRIMARY KEY AUTOINCREMENT,
    [EmpleadoId] INTEGER REFERENCES Empleados(EmpleadoId),
    [FechaPago] TEXT,
    [SueldoBase] DECIMAL);

  CREATE TABLE Pagos (
    [PagoId] INTEGER PRIMARY KEY AUTOINCREMENT,
    [ExteriorId] INTEGER NOT NULL,
    [Nombre] TEXT NOT NULL,
    [FechaPago] TEXT,
    [SueldoBase] DECIMAL);
  
  CREATE TABLE [Inventario] (
  [ObjetoId] INTEGER PRIMARY KEY AUTOINCREMENT,
  [Tipo] TEXT UNIQUE NOT NULL, 
  [Cantidad] INTEGER NOT NULL DEFAULT 0
);

-- Datos ramdoms generados por IA

INSERT INTO [Puestos] (Categoria, Sueldo) VALUES
('Cajero Bancario', 12000.00),
('Gerente de Sucursal', 35000.00),
('Asesor Financiero', 18000.00),
('Administrador de Base de Datos', 25000.00);

INSERT INTO [Empleados] (Nombre, Correo, TelNum, PuestoId, Estado) VALUES
('Eric Cordero', 'eric.cordero@banco.mx', '9991112233', 4, 1),
('Byron', 'byron.cajero@banco.mx', '9992223344', 1, 1),
('Valeria Gomez', 'valeria.gerente@banco.mx', '9993334455', 2, 1);

INSERT INTO [Clientes] (CuentaId, Nombre, Correo, TelNum, Estado) VALUES
(50001, 'Ana Perez', 'ana.perez@correo.com', '9994445566', 1),
(50002, 'Juan Lopez', 'juan.lopez@correo.com', '9995556677', 1),
(50003, 'Maria Fernandez', 'maria.f@correo.com', '9996667788', 1);

INSERT INTO [HorariosLibres] (Fecha, Hora) VALUES
('2026-06-08', '09:00'),
('2026-06-08', '10:30'),
('2026-06-09', '12:00'),
('2026-06-10', '14:00');

INSERT INTO [Citas] (EmpleadoId, CuentaId, HorarioId, Estado) VALUES
(3, 50001, 1, 'Confirmada'), 
(3, 50002, 2, 'Pendiente'),  
(2, 50003, 3, 'Pendiente');  

INSERT INTO [Nomina] (EmpleadoId, FechaPago, SueldoBase) VALUES
(1, '2026-06-15', 12500.00), 
(2, '2026-06-15', 6000.00),  
(3, '2026-06-15', 17500.00); 

INSERT INTO [Pagos] (ExteriorId, Nombre, FechaPago, SueldoBase) VALUES
(801, 'CFE Servicio Eléctrico', '2026-06-05', 4500.50),
(802, 'Cometra - Transporte de Valores', '2026-06-06', 12500.00);

INSERT INTO [Inventario] (Tipo, Cantidad) VALUES
('Billete de 1000', 50),
('Billete de 500', 200),
('Billete de 200', 150),
('Billete de 100', 300),
('Moneda de 10', 500);