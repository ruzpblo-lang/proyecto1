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


            cmbCliente.DataSource = gestorbanco.GetTodosLosClientes();
            cmbCliente.DisplayMember = "Nombre";
            cmbCliente.ValueMember = "ClienteId";
            cmbCliente.SelectedIndex = -1;
            cmbEstado.Items.Add("Activo");
            cmbEstado.Items.Add("Inactivo");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (cmbCuenta.SelectedIndex == -1 || string.IsNullOrWhiteSpace(cmbEstado.Text))
            {
                // Muestra exactamente el mismo mensaje de validación
                MessageBox.Show("Rellenar todos los espacios!!");

                // Detiene el código por completo para que no avance
                return;
            }
            switch (MessageBox.Show("¿Confirmas la modificación de la cuenta?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.Yes:
                    int cuentaId = Convert.ToInt32(cmbCuenta.SelectedValue);

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
        

        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCliente.SelectedValue != null && cmbCliente.SelectedValue is int clienteId)
            {
                cmbCuenta.DataSource = gestorbanco.GetCuentasPorCliente(clienteId);
                cmbCuenta.DisplayMember = "NumeroCuenta";
                cmbCuenta.ValueMember = "CuentaId";
            }
        }
    }
}
