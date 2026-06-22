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
    public partial class FormInventario : Form
    {
        public AppBancaria gestorempresa;
        public FormInventario(AppBancaria gestorempresa)
        {
            InitializeComponent();
            this.gestorempresa = gestorempresa;
        }

        private void btnInventarioBanco_Click(object sender, EventArgs e)
        {
            FormsInventarioBanco forms = new FormsInventarioBanco(gestorempresa);
            forms.ShowDialog();
        }

        private void btnInventarioCuenta_Click(object sender, EventArgs e)
        {
            FormInventarioCuenta forms = new FormInventarioCuenta(gestorempresa);
            forms.ShowDialog();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInventarioDeposito_Click(object sender, EventArgs e)
        {
            FormInventarioDeposito forms = new FormInventarioDeposito(gestorempresa);
            forms.ShowDialog();
        }
    }
}
