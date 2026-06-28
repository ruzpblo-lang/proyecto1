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
        public AppBancaria gestorbanco;
        private string tipoDeCita;

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

            // ----  COMBO BOX ASISNTENTES  -----
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

            // --- COMBO BOX EMPLEADO ASGINADO ---

            cmbEmpleadoAsig.DataSource = null;
            cmbEmpleadoAsig.Items.Clear();

            if (tipoDeCita == "Empleado")
            {
                cmbEmpleadoAsig.Enabled = false; // Deshabilitamos el control
                cmbEmpleadoAsig.Items.Add("No aplica");
                cmbEmpleadoAsig.SelectedIndex = 0;
            }
            else
            {
                cmbEmpleadoAsig.Enabled = true;
                cmbEmpleadoAsig.DataSource = gestorbanco.GetTodosLosEmpleados();
                cmbEmpleadoAsig.DisplayMember = "Nombre";
                cmbEmpleadoAsig.ValueMember = "ID";
            }


            // COMBO BOX HORAS
            cmbHoras.Items.Clear();
            string[] horarios = { "09:00", "09:30", "10:00", "10:30", "11:00", "11:30", "12:00", "13:00", "13:30", "14:00", "14:30", "15:00" };
            cmbHoras.Items.AddRange(horarios);

            if (cmbHoras.Items.Count > 0)
            {
                cmbHoras.SelectedIndex = 0; // Selecciona la primera hora por defecto para que no aparezca vacío
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int idAsistenteSeleccionado = Convert.ToInt32(cmbAsistentes.SelectedValue);

            string fechaSeleccionada = dtpFecha.Value.ToString("yyyy-MM-dd");
            string horaSeleccionada = cmbHoras.SelectedItem.ToString();

            int empleadoId = 1;
            int clienteId = 0;

            if (tipoDeCita == "Empleado")
            {
                empleadoId = idAsistenteSeleccionado; // Cita normal con empleado
                clienteId = 0;
            }
            else if (tipoDeCita == "Cliente")
            {
                empleadoId = Convert.ToInt32(cmbEmpleadoAsig.SelectedValue);
                clienteId = idAsistenteSeleccionado;
            }
            else if (tipoDeCita == "Proveedor")
            {
                empleadoId = Convert.ToInt32(cmbEmpleadoAsig.SelectedValue);
                clienteId = -idAsistenteSeleccionado; // ID NEGATIVO = Proveedor 
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