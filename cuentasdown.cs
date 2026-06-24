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
    public partial class cuentasdown : Form
    {
        public AppBancaria gestorbanco;
        public cuentasdown(AppBancaria gestor)
        {
            InitializeComponent();
            this.gestorbanco = gestor;
        }

        private void cuentasdown_Load(object sender, EventArgs e)
        {
          

            cmbEmpleado.DataSource = gestorbanco.GetCuentas();
            cmbEmpleado.DisplayMember = "NumeroCuenta";
            cmbEmpleado.ValueMember = "CuentaId";

            cmbEstado.Items.Add("Activo");
            cmbEstado.Items.Add("Inactivo");

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            switch (MessageBox.Show("¿Confirmas la modificación de la cuenta?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.Yes:
                    // 1. CORRECCIÓN: Obtener el ID de la cuenta, no del empleado
                    int cuentaId = Convert.ToInt32(cmbEmpleado.SelectedValue);

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

                    
                    gestorbanco.ModificarEstadoCuenta(cuentaId, nuevoEstado2);

                    MessageBox.Show("¡Cuenta modificada con éxito!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    break;

                case DialogResult.No:
                    break;
            }
        }
    }
}
