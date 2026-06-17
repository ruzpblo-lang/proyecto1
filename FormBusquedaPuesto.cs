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
    public partial class FormBusquedaPuesto : Form
    {
        public AppBancaria gestorbanco;
        public FormBusquedaPuesto(AppBancaria gestor)
        {
            InitializeComponent();

            this.gestorbanco = gestor;
        }

        private void FormBusquedaDepartamento_Load(object sender, EventArgs e)
        {
            cmbbusqueda.Items.Clear();
            cmbbusqueda.DataSource = gestorbanco.GetTodosLosPuestos();
            cmbbusqueda.DisplayMember = "Categoria";
            cmbbusqueda.ValueMember = "PuestoId";
        }

        private void cmbbusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            string puestoSeleccionado = cmbbusqueda.Text;

            if (puestoSeleccionado == "Todos")
            {
                dgvDepartamentos.DataSource = gestorbanco.GetTodosLosEmpleados();
            }
            else
            {
                dgvDepartamentos.DataSource = gestorbanco.GetEmpleadosPorPuesto(puestoSeleccionado);
            }
        }
    }
}
