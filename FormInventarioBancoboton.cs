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

            cmbBIllete.Items.Clear();

            cmbBIllete.Items.Add("Billete de 1000");
            cmbBIllete.Items.Add("Billete de 500");
            cmbBIllete.Items.Add("Billete de 200");
            cmbBIllete.Items.Add("Billete de 100");
            cmbBIllete.Items.Add("Moneda de 10");
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(txtCantidad.Text == "")
            {
                MessageBox.Show("Escirbe una cantidad: ");
                    return;
            }
            string Tipo = cmbBIllete.SelectedItem.ToString();
            int Cantidad = Convert.ToInt32(txtCantidad.Text);
            gestorempresa.AgregarBillete(Tipo, Cantidad);
            /*   FormInventario agregarBilletes = new FormInventario(gestorempresa);
               agregarBilletes.ShowDialog();*/
            dgvInventario.DataSource = gestorempresa.GetInventario();//Update
        }
    }
}
