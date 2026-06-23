using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto
{
    public partial class GerenteCitas : Form
    {
        // Variables globales del formulario
        public AppBancaria gestorbanco;
        private string tipoDeCita;

        // Constructor modificado para recibir el gestor y el tipo de asistente
        public GerenteCitas(AppBancaria gestor, string tipoAsistente)
        {
            InitializeComponent();
            this.gestorbanco = gestor;
            this.tipoDeCita = tipoAsistente; // Recibirá "Empleado", "Proveedor" o "Cliente"
            this.Text = "Citar " + tipoDeCita;
        }

        // Evento Load del formulario - Lógica de llenado integrada
        private void GerenteCitas_Load(object sender, EventArgs e)
        {
            // 1. Llenar el ComboBox de los Asistentes (el de arriba)
            cmbAsistentes.DataSource = null;

            if (tipoDeCita == "Cliente")
            {
                cmbAsistentes.DataSource = gestorbanco.ShortClientes();
                cmbAsistentes.DisplayMember = "Nombre";
                cmbAsistentes.ValueMember = "ClienteId";
            }
            else if (tipoDeCita == "Empleado")
            {
               
                cmbAsistentes.DisplayMember = "Nombre";
                cmbAsistentes.ValueMember = "ID";
                cmbAsistentes.DataSource = gestorbanco.GetTodosLosEmpleados();
            }
            else if (tipoDeCita == "Proveedor")
            {
                cmbAsistentes.DataSource = gestorbanco.GetProveedores();
                cmbAsistentes.DisplayMember = "Nombre";
                cmbAsistentes.ValueMember = "ProveedorId";
            }

            // 2. Llenar el ComboBox de las Horas (el de abajo)
            cmbHoras.Items.Clear();
            string[] horarios = { "09:00", "09:30", "10:00", "10:30", "11:00", "11:30", "12:00", "13:00", "13:30", "14:00", "14:30", "15:00" };
            cmbHoras.Items.AddRange(horarios);

            if (cmbHoras.Items.Count > 0)
            {
                cmbHoras.SelectedIndex = 0; // Selecciona la primera hora por defecto para que no aparezca vacío
            }
        }

        // Evento clic del botón de guardar
       /* private void btnGuardar_Click(object sender, EventArgs e)
        {
            int idSeleccionado = Convert.ToInt32(cmbAsistentes.SelectedValue);

            // Corrección: Se cambió "year-MM-dd" por "yyyy-MM-dd"
            string fechaSeleccionada = dtpFecha.Value.ToString("yyyy-MM-dd");
            string horaSeleccionada = cmbHoras.SelectedItem.ToString();

            int empleadoId = 0;
            int clienteId = 0;

            // Adaptamos los IDs a tu tabla original sin modificarla
            if (tipoDeCita == "Empleado")
            {
                empleadoId = idSeleccionado;
                clienteId = 0; // 0 porque no hay cliente involucrado
            }
            else if (tipoDeCita == "Cliente")
            {
                empleadoId = 0; // 0 porque no es cita con empleado
                clienteId = idSeleccionado;
            }
            else if (tipoDeCita == "Proveedor")
            {
                empleadoId = -1; // Usamos -1 como "truco" para saber que es proveedor
                clienteId = idSeleccionado; // Guardamos el ID del proveedor aquí
            }

            // Intentamos agendar
            bool exito = gestorbanco.AgendarCitaGerencia(empleadoId, clienteId, fechaSeleccionada, horaSeleccionada);

            if (exito)
            {
                MessageBox.Show("Cita agendada correctamente sin choques de horario.");
                this.Close();
            }
            else
            {
                MessageBox.Show("El gerente ya tiene una cita en ese horario. Por favor elige otro.");
            }
        }*/

        private void button1_Click(object sender, EventArgs e)
        {
            int idSeleccionado = Convert.ToInt32(cmbAsistentes.SelectedValue);
            string fechaSeleccionada = dtpFecha.Value.ToString("yyyy-MM-dd");
            string horaSeleccionada = cmbHoras.SelectedItem.ToString();

            // Ponemos un 1 por defecto para que la Llave Foránea (FOREIGN KEY) no falle.
            // Asumimos que el empleado con ID 1 existe en tu base de datos.
            int empleadoId = 1;
            int clienteId = 0;

            // Adaptamos los IDs a tu tabla original sin modificarla
            if (tipoDeCita == "Empleado")
            {
                empleadoId = idSeleccionado; // Cita normal con empleado
                clienteId = 0;
            }
            else if (tipoDeCita == "Cliente")
            {
                // Se queda empleadoId = 1 para no romper SQL
                clienteId = idSeleccionado; // ID Positivo = Cliente
            }
            else if (tipoDeCita == "Proveedor")
            {
                // Se queda empleadoId = 1 para no romper SQL
                clienteId = -idSeleccionado; // ID NEGATIVO = Proveedor (¡Aquí está la magia!)
            }

            // Intentamos agendar
            bool exito = gestorbanco.AgendarCitaGerencia(empleadoId, clienteId, fechaSeleccionada, horaSeleccionada);

            if (exito)
            {
                MessageBox.Show("Cita agendada correctamente sin choques de horario.");
                ((FormAgenda)this.Owner).RefreshCitas();

                this.Close();

                this.Close();
            }
            else
            {
                MessageBox.Show("El gerente ya tiene una cita en ese horario. Por favor elige otro.");
            }

        }
    }
}