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
    public partial class AgregarPago_ : Form
    {
        public AppBancaria gestorbanco;
        public AgregarPago_(AppBancaria gestor)
        {
            InitializeComponent();
            this.gestorbanco = gestor;
        }


        private void btnagregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtConcepto.Text) || string.IsNullOrWhiteSpace(txtFecha.Text) || string.IsNullOrWhiteSpace(txtMonto.Text))
            {
                MessageBox.Show("Porfavor rellene los campos en blanco", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            switch (MessageBox.Show("Confirma los datos del pago?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.Yes:
                    string tiposeleccionado = cmbTipo.SelectedItem.ToString();
                    string concepto = txtConcepto.Text;
                    string fecha = txtFecha.Text;
                    decimal monto = Convert.ToDecimal(txtMonto.Text);
                    string estado = cmbEstado.SelectedItem.ToString();

                if(tiposeleccionado == "Nómina")
                    {
                        int EmpleadoId = gestorbanco.ObtenerempleadoId(concepto);
                        if (EmpleadoId == -1 )
                        {
                            MessageBox.Show("No se encontró ningún empleado con ese nombre. Verifica la ortografía.", "Empleado no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return; 
                        }
                        gestorbanco.AgregarNomina(EmpleadoId, fecha,monto,estado);
                     }

                if(tiposeleccionado == "Gasto Externo")
                    {
                        Random rand = new Random();
                        int exterior = rand.Next(1, 9999);
                        gestorbanco.AgregarPagoexterno(exterior,concepto, fecha,monto, estado);
                    }
                 MessageBox.Show("Registro completado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 this.Close();
                 break;
            }
        }
        private void AgregarPago__Load(object sender, EventArgs e)
        {
            cmbTipo.Items.Clear();
            cmbTipo.Items.Add("Nómina");
            cmbTipo.Items.Add("Gasto Externo");
            cmbTipo.SelectedIndex = 0;

            cmbEstado.Items.Clear();
            cmbEstado.Items.Add("Pendiente");
            cmbEstado.Items.Add("Realizado");
            cmbEstado.SelectedIndex = 0;
        }
    }
}
