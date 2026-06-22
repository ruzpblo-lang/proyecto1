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

            cmbCliente.DisplayMember = "Nombre";
            cmbCliente.ValueMember = "ClienteId";
            cmbCliente.DataSource = gestorcitas.ShortClientes();
           

          
        }

       /* private void UpdateData()
        {
            dgvpersonal.DataSource = null;
            dgvpersonal.DataSource = gestorbanco.GetTodosLosEmpleados();
        }*/

        private void FormAgenda_Load(object sender, EventArgs e)
        {
            dgvCitas.DataSource = gestorcitas.GetCitas();
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

        }

        private void citarProvedoorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GerenteCitas ventanaAgregar = new GerenteCitas(gestorcitas, "Proveedor");

            ventanaAgregar.ShowDialog();

            //UpdateData();
        }

        private void citarEmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GerenteCitas ventanaAgregar = new GerenteCitas(gestorcitas, "Empleado");
            ventanaAgregar.ShowDialog();
        }

        private void citarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GerenteCitas ventanaAgregar = new GerenteCitas(gestorcitas, "Cliente");
            ventanaAgregar.ShowDialog();
        }
    }
}
