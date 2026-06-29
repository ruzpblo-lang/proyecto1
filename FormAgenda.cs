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
            var lista = gestorcitas.GetFullCitas();
            dgvCitas.DataSource = null;
            dgvCitas.DataSource = lista;

            // --- AQUÍ ESTÁ EL CAMBIO ---
            if (dgvCitas.Columns["Cliente"] != null)
            {
                dgvCitas.Columns["Cliente"].HeaderText = "Citado";
            }
            // ----------------------------

            // Tus otras validaciones de ocultar columnas
            if (dgvCitas.Columns["ClienteId"] != null) dgvCitas.Columns["ClienteId"].Visible = false;
            if (dgvCitas.Columns["Empleado"] != null) dgvCitas.Columns["Empleado"].Visible = false;
            if (dgvCitas.Columns["FolioId"] != null) dgvCitas.Columns["FolioId"].Visible = false;
        }

        private void FiltrosCitas()
        {
            // 1. Validaciones iniciales
            if (gestorcitas == null || cmbFiltroTipo.SelectedItem == null) return;

            // 2. Traer la lista base
            List<FullCita> lista = gestorcitas.GetFullCitas();
            string seleccion = cmbFiltroTipo.SelectedItem.ToString();

            // 3. FILTRO POR TIPO (Usando .Contains para que sea flexible)
            if (seleccion == "Cliente")
            {
                // Trae todo lo que NO contenga "Proveedor" ni "Eric"
                lista = lista.Where(c => !c.Cliente.Contains("Proveedor") && !c.Cliente.Contains("Eric")).ToList();
            }
            else if (seleccion == "Empleado")
            {
                // Trae solo lo que contenga "Eric"
                lista = lista.Where(c => c.Cliente.Contains("Eric")).ToList();
            }
            else if (seleccion == "Proveedor")
            {
                // Trae solo lo que contenga "Proveedor"
                lista = lista.Where(c => c.Cliente.Contains("Proveedor")).ToList();
            }
            // Si es "Todos", no hacemos nada a la lista, se queda completa.

            // 4. FILTRO POR FECHA (Sobre el resultado anterior)
            DateTime inicio = dtpFechaInicio.Value.Date;
            DateTime fin = dtpFechaFinal.Value.Date;

            if (inicio <= fin)
            {
                lista = lista.Where(c => {
                    if (DateTime.TryParse(c.Horario, out DateTime fechaCita))
                    {
                        return fechaCita.Date >= inicio && fechaCita.Date <= fin;
                    }
                    return false;
                }).ToList();
            }

            // 5. ASIGNAR AL GRID (Una sola vez)
            dgvCitas.DataSource = null;
            dgvCitas.DataSource = lista;

            // Opcional: Si quieres que no se vea desfasado, agrega aquí las columnas ocultas
            if (dgvCitas.Columns["ClienteId"] != null) dgvCitas.Columns["ClienteId"].Visible = false;
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
