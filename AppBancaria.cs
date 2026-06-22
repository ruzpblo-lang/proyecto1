using Microsoft.Data.Sqlite;
using SQLiteUtil;
    using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
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
            FormFinanza forms = new FormFinanza();
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

            string query = "SELECT c.FolioId, cl.Nombre AS Cliente, e.Nombre AS Empleado, (c.Fecha || ' ' || c.Hora) AS Horario, c.Estado\r\nFROM [Citas] c\r\nINNER JOIN [Clientes] cl ON c.ClienteId = cl.ClienteId\r\nINNER JOIN [Empleados] e ON c.EmpleadoId = e.EmpleadoId";

            var rs = conn.ExecuteReader(query);
            while (rs.Read())
            {
                CitasDipsonibles.Add(new FullCita(
                    rs.GetInt("FolioId"),
                    rs.GetString("Cliente"),
                    rs.GetString("Empleado"),
                    rs.GetString("Horario"),
                    rs.GetString("Estado")));
            }

            return CitasDipsonibles;
        }

        public List<Cita> GetCitaPorPaciente(int cuentaId)
        {
            List<Cita> CitaPorPaciente = new List<Cita>();
            string query = $"SELECT cl.Nombre AS Cliente, (c.Fecha || ' ' || c.Hora) AS Horario, c.Estado" +
                            $"\r\nFROM [Citas] c" +
                            $"\r\nINNER JOIN [Clientes] cl ON c.ClienteId = cl.ClienteId\r\nWHERE c.ClienteId = {cuentaId};";

            var rs = conn.ExecuteReader(query);
            while (rs.Read())
            {
                CitaPorPaciente.Add(new Cita(
                    rs.GetString("Cliente"),
                    rs.GetString("Horario"),
                    rs.GetString("Estado")));
            }
            return CitaPorPaciente;
        }
        public List<FullEmpleado> GetTodosLosEmpleados()
        {
            List<FullEmpleado> listaCompleta = new List<FullEmpleado>();

            string query = "SELECT e.EmpleadoId, e.Nombre, e.Correo, e.TelNum, e.Estado, p.Categoria, p.Sueldo\r\nFROM Empleados e\r\nINNER JOIN Puestos p ON e.PuestoId = p.PuestoId;";

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
                    estadoTexto));


            }
            return listaCompleta;
        }           
        public List<Inventario> GetInventario()
        {
            List<Inventario> ListaInventario = new List<Inventario>();
            string query = "SELECT ObjetoId, Tipo, Cantidad FROM inventario";

            var rs =conn.ExecuteReader(query);
            
            while (rs.Read())
            {
                ListaInventario.Add(new Inventario(
                    rs.GetInt32(0),
                    rs.GetString("Tipo"),
                    rs.GetInt32(2)
                ));
            }
            return ListaInventario; 
        }
    } }
