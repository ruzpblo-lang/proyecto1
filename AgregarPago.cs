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
            string fecha = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            if (tiposeleccionado == "Gasto Externo")
            {
            if (string.IsNullOrWhiteSpace(txtConcepto.Text) || string.IsNullOrWhiteSpace(txtMonto.Text))
            {
                MessageBox.Show("Por rellene los campos en blanco", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }
            }
            else if (tiposeleccionado == "Nómina")
            {
                if (string.IsNullOrWhiteSpace(txtbxHorasdobles.Text) || string.IsNullOrWhiteSpace(txtBoxhorastriples.Text))

                {
                    MessageBox.Show("Por rellene los campos en blanco", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else if (tiposeleccionado == "Servicio")
            {
                if (string.IsNullOrWhiteSpace(txtMonto.Text) || Cmbservicio.SelectedItem == null)

                {
                    MessageBox.Show("Por rellene los campos en blanco", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            switch (MessageBox.Show("Confirma los datos del pago?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.Yes:
                    string estado = cmbEstado.SelectedItem.ToString();

                if(tiposeleccionado == "Nómina")
                    {
                        FullEmpleado empleadoseleccionado = (FullEmpleado)cmbempleado.SelectedItem;
                        int EmpleadoId = empleadoseleccionado.ID;

                        List<Puesto> listapuestos = (List<Puesto>)gestorbanco.GetTodosLosPuestos();
                        Puesto puestodelempleado = listapuestos.FirstOrDefault(p => p.Categoria == empleadoseleccionado.Puesto);
                        decimal Sueldobase =puestodelempleado != null ? Convert.ToDecimal(puestodelempleado.Sueldo) : 0m;

                        int.TryParse(txtbxHorasdobles.Text, out int horasdoble);
                        int.TryParse(txtBoxhorastriples.Text, out int horastriples);

                        decimal valorHoranormal = Sueldobase / 240m;
                        decimal pagohorasdobles = valorHoranormal * 2m * horasdoble;
                        decimal pagohorastriples = valorHoranormal * 3m * horastriples;
                        decimal montocalculado = Sueldobase + pagohorasdobles + pagohorastriples;
                        montocalculado = Math.Round(montocalculado,2);
                        gestorbanco.AgregarNomina(EmpleadoId, fecha, montocalculado, estado);
                    }

                else if(tiposeleccionado == "Gasto Externo")
                    {
                        string concepto = txtConcepto.Text;
                        decimal monto = Convert.ToDecimal(txtMonto.Text);
                        Random rand = new Random();
                        int exterior = rand.Next(1, 9999);
                        gestorbanco.AgregarPagoexterno(exterior,concepto, fecha,monto, estado);
                    }
                else if (tiposeleccionado == "Servicio")
                    {
                        string concepto = Cmbservicio.SelectedItem.ToString();
                        decimal monto = Convert.ToDecimal(txtMonto.Text);
                        gestorbanco.agregarservicio(concepto,fecha, monto, estado);
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
            cmbTipo.Items.Add("Servicio");
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

            Cmbservicio.Items.Clear();
            List<string> serviciosDB = gestorbanco.Getcatalogoservicios();
            foreach(string servicio in serviciosDB)
            {
                Cmbservicio.Items.Add(servicio);
            }
            if (Cmbservicio.Items.Count > 0)
            {
                Cmbservicio.SelectedIndex = 0;
            }
            Cmbservicio.Visible = false;
        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipo.SelectedItem.ToString() == "Nómina")
            {
                txtConcepto.Visible = false;
                cmbempleado.Visible = true;
                Cmbservicio.Visible = false;
                label2.Text = "Empleado";
                txtBoxhorastriples.Visible = true;
                label4.Visible = false;
                txtbxHorasdobles.Visible = true;
                horasdoblestxt.Visible = true;
                Horastriplestxt.Visible = true;
            }

            if (cmbTipo.SelectedItem.ToString() == "Gasto Externo")
            {
                txtConcepto.Visible = true;
                cmbempleado.Visible = false;
                Cmbservicio.Visible = false;
                label2.Text = "Concepto";
                label4.Text = "Monto";
                txtbxHorasdobles.Visible = false;
                horasdoblestxt.Visible = false;
                Horastriplestxt.Visible = false;
                txtBoxhorastriples.Visible = false;
                label4.Visible = true;
            }
            if (cmbTipo.SelectedItem.ToString() == "Servicio")
            {
                txtConcepto.Visible = false;
                cmbempleado.Visible = false;
                Cmbservicio.Visible = true;
                label2.Text = "Servicio";
                label4.Text = "Monto";
                label4.Visible = true;
                txtbxHorasdobles.Visible = false;
                horasdoblestxt.Visible = false;
                Horastriplestxt.Visible = false;
                txtBoxhorastriples.Visible = false;
            }
        }
    }
}
