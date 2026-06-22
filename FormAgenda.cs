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
    public partial class FormAgenda : Form
    {
        public AppBancaria gestorcitas;
        public FormAgenda(AppBancaria gestorcitas   )
        {
            InitializeComponent();
            this.gestorcitas = gestorcitas;

            cmbCliente.DisplayMember = "Nombre";
            cmbCliente.ValueMember = "ClienteId";
            cmbCliente.DataSource = gestorcitas.ShortClientes();
        }

        private void FormAgenda_Load(object sender, EventArgs e)
        {
            dgvCitas.DataSource = gestorcitas.GetFullCitas();

            if (dgvCitas.Columns["FolioId"] != null)
                dgvCitas.Columns["FolioId"].Visible = false;

            if (dgvCitas.Columns["Empleado"] != null)
                dgvCitas.Columns["Empleado"].Visible = false;
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCliente.SelectedValue != null && cmbCliente.SelectedValue is int)
            {
                int idSeleccionado = (int)cmbCliente.SelectedValue;
                dgvCitas.DataSource = null;
                dgvCitas.DataSource = gestorcitas.GetCitaPorPaciente(idSeleccionado);
            }
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            if (dgvCitas.CurrentRow != null)
            {
                FullCita citaSeleccionada = (FullCita)dgvCitas.CurrentRow.DataBoundItem;
                int idCita = citaSeleccionada.FolioId;

                FormInfoCita formInfoCita = new FormInfoCita();
                formInfoCita.ShowDialog();

                //¿MessageBox.Show($"Abriendo detalles para el Folio de Cita: {idCita}");
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una cita de la tabla primero.");
            }
        }
    }
}
