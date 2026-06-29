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
    public partial class FormInfoCita : Form
    {
        public AppBancaria gestorcitas;
        private FullCita cita;
        public FormInfoCita(AppBancaria gestor, FullCita cita)
        {
            this.gestorcitas = gestor;
            this.cita = cita;
            InitializeComponent();
        }

        private void FormInfoCita_Load(object sender, EventArgs e)
        {
            if (cita != null)
            {
                txtFolio.Text = cita.FolioId.ToString();
                txtHorario.Text = cita.Horario;
                txtEstado.Text = cita.Estado;

                if (cita.FolioId != 0)
                {
                    txtAsistente.Text = cita.Cliente;

                    if (cita.Empleado == cita.Cliente || string.IsNullOrEmpty(cita.Empleado))
                    {
                        txtEmpleado.Text = "No aplica";
                    }
                    else
                    {
                        txtEmpleado.Text = cita.Empleado;
                    }
                }
            }
            else
            {
                MessageBox.Show("No se encontraron datos para esta cita.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }

            if (txtEstado.Text.Trim().Equals("Pendiente", StringComparison.OrdinalIgnoreCase))
            {
                btnFinalizar.Enabled = true;
            }
            else
            {
                btnFinalizar.Enabled = false;
                btnFinalizar.Text = "Cita ya Confirmada";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int folioId = int.Parse(txtFolio.Text);
            bool exito = gestorcitas.ConfirmarCita(folioId);

            if (exito)
            {
                MessageBox.Show("¡La cita ha sido confirmada con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("No se pudo actualizar el estado de la cita.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
