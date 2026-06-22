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
    public partial class FormInventarioDeposito : Form
    {
        public AppBancaria gestorempresa = new AppBancaria();
        public FormInventarioDeposito(AppBancaria gestorempresa)
        {
            InitializeComponent();
            this.gestorempresa = gestorempresa;
        }

        private void FormInventarioDeposito_Load(object sender, EventArgs e)
        {
            dgvProductoDeposito.DataSource = gestorempresa.GetInventarioDeposito();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            AgregarProductos forms = new AgregarProductos(gestorempresa);
            forms.ShowDialog();
            dgvProductoDeposito.DataSource = gestorempresa.GetInventarioDeposito();
        }
    }
}
