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
    public partial class AgregarCliente : Form
    {
        public AppBancaria gestorempresa;
        public AgregarCliente(AppBancaria gestorempresa)
        {
            InitializeComponent();
            this.gestorempresa = gestorempresa;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
               string.IsNullOrWhiteSpace(txtCorreo.Text) ||
               string.IsNullOrWhiteSpace(txtTelefono.Text))
              
            {
                MessageBox.Show("Rellenar todos los espacios!!");
                return;
            }
            switch (MessageBox.Show("Confirmas los datos del cliente?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.Yes:
                    string nombre = txtNombre.Text;
                    string correo = txtCorreo.Text;
                    string telefono = txtTelefono.Text;
                    

                    gestorempresa.AgregarCliente(nombre, correo, telefono);
                    this.Close();

                    break;
                case DialogResult.No:
                    break;
            }
        }

        private void AgregarCliente_Load(object sender, EventArgs e)
        {

        }
    }
}
