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
    public partial class FormPersonal : Form
    {
        public AppBancaria gestorempresa;
        public FormPersonal(AppBancaria gestor)
        {
            InitializeComponent();

            this.gestorempresa = gestor;
        }

        private void FormPersonal_Load(object sender, EventArgs e)
        {
            dgvpersonal.DataSource = gestorempresa.GetTodosLosEmpleados();
        }
    }
}
