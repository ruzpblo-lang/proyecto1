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
    public partial class Mostrarcuentas : Form
    {
        public AppBancaria gestorbanco;
        public Mostrarcuentas(AppBancaria gestor)
        {
            InitializeComponent();
            this.gestorbanco = gestor;
        }

        private void Mostrarcuentas_Load(object sender, EventArgs e)
        {
            dgvCuentas.DataSource = gestorbanco.GetCuentasConCliente();

            dgvCuentas.Columns["CuentaId"].Visible = false;

            dgvCuentas.Columns["NombreCliente"].HeaderText = "Cliente";
            dgvCuentas.Columns["NumeroCuenta"].HeaderText = "No. Cuenta";
            dgvCuentas.Columns["TipoCuenta"].HeaderText = "Tipo de Cuenta";
        }
    }
}
