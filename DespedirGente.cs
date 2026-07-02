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
    public partial class DespedirGente : Form
    {
        public AppBancaria gestorbanco;
        public DespedirGente(AppBancaria gestor)
        {
            InitializeComponent();

            this.gestorbanco = gestor;
        }

        private void DespedirGente_Load(object sender, EventArgs e)
        {
            cmbEmpleado.DataSource = gestorbanco.GetTodosLosEmpleados();
            cmbEmpleado.DisplayMember = "Nombre";
            cmbEmpleado.ValueMember = "Id";

            cmbEstado.Items.Add("Activo");
            cmbEstado.Items.Add("Inactivo");

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (cmbEmpleado.SelectedIndex == -1 || string.IsNullOrWhiteSpace(cmbEstado.Text))
            {
                MessageBox.Show("Rellenar todos los espacios!!");
                return; // Detiene el código por completo
            }
            switch (MessageBox.Show("¿Confirmas la modificación del empleado?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.Yes:

                    int empleadoId = Convert.ToInt32(cmbEmpleado.SelectedValue);

                    string nuevoEstado = cmbEstado.Text;

                    int nuevoEstado2 = 0;

                    if (nuevoEstado == "Activo")
                    {
                        nuevoEstado2 = 1;
                    }
                    else if (nuevoEstado == "Inactivo")
                    {
                        nuevoEstado2 = 0;
                    }

                    gestorbanco.ModificarEstadoEmpleado(empleadoId, nuevoEstado2);


                    MessageBox.Show("¡Empleado de baja con éxito!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();

                    break;

                case DialogResult.No:
                    break;
            }
        }
    }
}
