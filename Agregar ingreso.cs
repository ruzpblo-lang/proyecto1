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
    public partial class Agregar_ingreso : Form
    {
        public AppBancaria gestorbanco;
        public Agregar_ingreso(AppBancaria gestor)
        {
            InitializeComponent();
            this.gestorbanco = gestor;
        }

        private void btnpago_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtconcepto.Text))
            {
                MessageBox.Show("Porfavor ingrese el concepto del ingreso", "Campo incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if(!double .TryParse(txtmonto.Text, out double montoValido) || montoValido <= 0)
            {
                MessageBox.Show("Monto invalido porfavor ingrese una cantidad valida", "Error en Monto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string concepto = txtconcepto.Text;
            string fechaconformato = dateTimePicker1.Value.ToString("yyyy-MM-dd");

            gestorbanco.Registraringreso(concepto, montoValido, fechaconformato);
            MessageBox.Show("Ingreso registrado de manera exitosa", "Operacion exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();

        }
    }
}
