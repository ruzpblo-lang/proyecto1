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
    public partial class ESTADO_CLIENTES : Form
    {
        public AppBancaria gestorbanco;
        public ESTADO_CLIENTES(AppBancaria gestor)
        {
            InitializeComponent();
            this.gestorbanco = gestor;
        }

        private void ESTADO_CLIENTES_Load(object sender, EventArgs e)
        {
            dgvpersonal.DataSource = gestorbanco.GetInventarioCliente();
        }
    }
}
