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
    public partial class FormsInventarioBanco : Form
    {
        public AppBancaria gestorempresa;
        public FormsInventarioBanco(AppBancaria gestorempresa)
        {
            InitializeComponent();
            this.gestorempresa = gestorempresa;
        }

        private void FormInventarioBancoboton_Load(object sender, EventArgs e)
        {
            dgvInventario.DataSource = gestorempresa.GetInventario();
        }
    }
}
