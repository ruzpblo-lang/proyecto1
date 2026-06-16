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

        private void button1_Click(object sender, EventArgs e)
        {
            FormsInventarioBanco forms = new FormsInventarioBanco(gestorempresa);
            forms.ShowDialog();
        }   
    }
}
