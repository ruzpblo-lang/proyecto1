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
            string tiposeleccionado = cmbTipo.SelectedItem.ToString();
            if (tiposeleccionado == "Gasto Externo" && string.IsNullOrWhiteSpace(txtFecha.Text))
            {
                MessageBox.Show("Por rellene el campo Concepto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (string.IsNullOrWhiteSpace(txtFecha.Text) || string.IsNullOrWhiteSpace(txtMonto.Text))

            {
                MessageBox.Show("Por rellene los campos en blanco", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            switch (MessageBox.Show("Confirma los datos del pago?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.Yes:
                    string concepto = txtConcepto.Text;
                    string fecha = txtFecha.Text;
                    decimal monto = Convert.ToDecimal(txtMonto.Text);
                    string estado = cmbEstado.SelectedItem.ToString();

                if(tiposeleccionado == "Nómina")
                    {
                        FullEmpleado empleadoseleccionado = (FullEmpleado)cmbempleado.SelectedItem;
                        int EmpleadoId = empleadoseleccionado.ID;

                        List<Puesto> listapuestos = (List<Puesto>)gestorbanco.GetTodosLosPuestos();
                        Puesto puestodelempleado = listapuestos.FirstOrDefault(p => p.Categoria == empleadoseleccionado.Puesto);
                        decimal SueldoBase = puestodelempleado != null ? Convert.ToDecimal(puestodelempleado.Sueldo) : 0m;
                        int Horasextra = Convert.ToInt32(txtMonto.Text);
                        int tarifaHorasextra = 100;
                        decimal montoCalculado = SueldoBase + (Horasextra * tarifaHorasextra);
                        gestorbanco.AgregarNomina(EmpleadoId, fecha,montoCalculado,estado);
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

            List<FullEmpleado> todoslosempleados = gestorbanco.GetTodosLosEmpleados();
            var EmpleadosActivos = todoslosempleados.Where(emp => emp.Estado == "Activo").ToList();
            cmbempleado.DataSource = EmpleadosActivos;
            cmbempleado.DisplayMember = "Nombre";
            cmbempleado.ValueMember = "ID";
        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipo.SelectedItem.ToString() == "Nómina")
            {
                txtConcepto.Visible = false;
                cmbempleado.Visible = true;
                label2.Text = "Empleado";
                label4.Text = "Cantidad de horas extra";
            }

            if (cmbTipo.SelectedItem.ToString() == "Gasto Externo")
            {
                txtConcepto.Visible = true;
                cmbempleado.Visible = false;
                label2.Text = "Concepto";
                label4.Text = "Monto";
            }
        }
    }
}
