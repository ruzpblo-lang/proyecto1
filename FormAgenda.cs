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
    public partial class FormAgenda : Form
    {
        public AppBancaria gestorcitas;
        public FormAgenda(AppBancaria gestorcitas   )
        {
            InitializeComponent();
            this.gestorcitas = gestorcitas;
            InciarFlitroTipo();
        }

        private void InciarFlitroTipo()
        {
            cmbFiltroTipo.DataSource = null;
            cmbFiltroTipo.Items.Clear();
            cmbFiltroTipo.Items.Add("Todos");
            cmbFiltroTipo.Items.Add("Cliente");
            cmbFiltroTipo.Items.Add("Empleado");
            cmbFiltroTipo.Items.Add("Proveedor");

            cmbFiltroTipo.SelectedIndex = 0;
        }

       /* private void UpdateData()
        {
            dgvpersonal.DataSource = null;
            dgvpersonal.DataSource = gestorbanco.GetTodosLosEmpleados();
        }*/

        private void FormAgenda_Load(object sender, EventArgs e)
        {
            RefreshCitas();
        }
        public void RefreshCitas()
        {
            dgvCitas.DataSource = null;
            dgvCitas.DataSource = gestorcitas.GetFullCitas();

            if (dgvCitas.Columns["ClienteId"] != null)
                dgvCitas.Columns["ClienteId"].Visible = false;

            if (dgvCitas.Columns["Empleado"] != null)
                dgvCitas.Columns["Empleado"].Visible = false;

            if (dgvCitas.Columns["FolioId"] != null)
                dgvCitas.Columns["FolioId"].Visible = false;
            
            if (dgvCitas.Columns["Empleado"] != null)
                dgvCitas.Columns["Empleado"].Visible = false;
        }

        private void FiltrosCitas()
        {
            if (gestorcitas == null || cmbFiltroTipo.SelectedItem == null) return;

            List<FullCita> listaFiltrada = gestorcitas.GetFullCitas();

            DateTime fechaInicio = dtpFechaInicio.Value.Date;
            DateTime fechaFinal = dtpFechaFinal.Value.Date;

            if (fechaInicio > fechaFinal)
            {
                return;
            
            
            }

            //PRIMER FILTRO POR TIPO
            
            string seleccion = cmbFiltroTipo.SelectedItem.ToString();

            if (seleccion == "Cliente")
            {
                dgvCitas.DataSource = listaFiltrada.Where(c => c.ClienteId > 0).ToList();
            }
            else if (seleccion == "Empleado")
            {
                dgvCitas.DataSource = listaFiltrada.Where(c => c.ClienteId == 0).ToList();
            }
            else if (seleccion == "Proveedor")
            {
                dgvCitas.DataSource = listaFiltrada.Where(c => c.ClienteId < 0).ToList();
            }
            else
            {
                // Si es "Todos", mostramos la lista sin alteraciones
                dgvCitas.DataSource = listaFiltrada;
            }

            //SEGUNDO FILTRO POR RANGO DE FECHAS
            listaFiltrada = listaFiltrada.Where(c => {
                if (DateTime.TryParse(c.Horario, out DateTime fechaCita))
                {
                    return fechaCita.Date >= fechaInicio && fechaCita.Date <= fechaFinal;
                }
                return false; // Si no puede parsear la fecha, descarta la fila
            }).ToList();

            dgvCitas.DataSource = listaFiltrada;
        }
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrosCitas();
        }
        private void dtpFechaInicio_ValueChanged(object sender, EventArgs e)
        {
            FiltrosCitas();
        }

        private void dtpFechaFinal_ValueChanged(object sender, EventArgs e)
        {
            FiltrosCitas();
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            if (dgvCitas.CurrentRow != null)
            {
                FullCita citaSeleccionada = (FullCita)dgvCitas.CurrentRow.DataBoundItem;
                FormInfoCita formInfoCita = new FormInfoCita(gestorcitas, citaSeleccionada);
                formInfoCita.ShowDialog();
                RefreshCitas();
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una cita de la tabla primero.");
            }
        }

        private void citarProvedoorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GerenteCitas ventanaAgregar = new GerenteCitas(gestorcitas, "Proveedor");

            ventanaAgregar.ShowDialog(this);

            //UpdateData();
        }

        private void citarEmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GerenteCitas ventanaAgregar = new GerenteCitas(gestorcitas, "Empleado");
            ventanaAgregar.ShowDialog(this);
        }

        private void citarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GerenteCitas ventanaAgregar = new GerenteCitas(gestorcitas, "Cliente");
            ventanaAgregar.ShowDialog(this);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

    }
}
