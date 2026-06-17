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
    public partial class FormFinanza : Form
    {
        public AppBancaria gestorbanco;
        public FormFinanza(AppBancaria gestor)
        {
            InitializeComponent();
            this.gestorbanco = gestor;
        }
        
        private void UpdateData()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = gestorbanco.GetTodosLosPagos();
        }

        private void FormFinanza_Load(object sender, EventArgs e)
        {
            UpdateData();
        }
    }
}
