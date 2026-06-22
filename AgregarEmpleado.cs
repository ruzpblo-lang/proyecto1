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
    public partial class AgregarEmpleado : Form
    {
        public AppBancaria gestorbanco;
        public AgregarEmpleado(AppBancaria gestor)
        {
            InitializeComponent();

            this.gestorbanco = gestor;
        }

        private void AgregarEmpleado_Load(object sender, EventArgs e)
        {
            cmbpuesto.DataSource = gestorbanco.GetTodosLosPuestos();
            cmbpuesto.DisplayMember = "Categoria";
            cmbpuesto.ValueMember = "PuestoId";
        }

        private void btnagregar_Click(object sender, EventArgs e)
        {

            switch (MessageBox.Show("¿Confirmas la creación del empleado?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.Yes:

                    string nombre = txtNombre.Text;
                    string correo = txtCorreo.Text;
                    string telefono = txtTelefono.Text;

                    
                    int puestoId = Convert.ToInt32(cmbpuesto.SelectedValue);
                    int estado = 1;

                    gestorbanco.CrearEmpleado(nombre, correo, telefono, puestoId, estado);

                    MessageBox.Show("¡Empleado generado con éxito!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    break;

                case DialogResult.No:
                    break;
            }
        }
    }
}
