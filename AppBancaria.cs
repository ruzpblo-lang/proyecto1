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
            FormAgenda forms = new FormAgenda();
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
