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
    public partial class Altacuenta : Form
    {
        public AppBancaria gestorbanco;
        public Altacuenta(AppBancaria gestor)
        {
            InitializeComponent();
            this.gestorbanco = gestor;
        }

        private void Altacuenta_Load(object sender, EventArgs e)
        {
            cmbcliente.DataSource = gestorbanco.GetTodosLosClientes();
            cmbcliente.DisplayMember = "Nombre";
            cmbcliente.ValueMember = "ClienteId";


            cmbtipocuenta.Items.Add("Ahorro");
            cmbtipocuenta.Items.Add("Corriente");
            cmbtipocuenta.Items.Add("Nómina");
        }

        private void btnagregar_Click(object sender, EventArgs e)
        {
            switch (MessageBox.Show("¿Confirmas la creación de la cuenta?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.Yes:

                    // Capturamos los datos del formulario
                    int clienteId = Convert.ToInt32(cmbcliente.SelectedValue);
                    string tipoCuenta = cmbtipocuenta.SelectedItem.ToString();
                    decimal saldo = Convert.ToDecimal(txtsaldo.Text);
                    int estado = 1;

                    // Generamos un número de cuenta puramente numérico (ej: 8 dígitos aleatorios)
                    Random rand = new Random();
                    int numeroCuenta = rand.Next(10000000, 99999999);

                    // Mandamos los datos a tu método en el gestor del banco
                    gestorbanco.CrearCuenta(clienteId, numeroCuenta, tipoCuenta, saldo, estado);

                    MessageBox.Show("¡Cuenta generada con éxito!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    break;

                case DialogResult.No:
                    break;
            }
        }
    }
}
