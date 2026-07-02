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
    public partial class Clientesdown : Form
    {
        public AppBancaria gestorbanco;
        public Clientesdown(AppBancaria gestor)
        {
            InitializeComponent();
            this.gestorbanco = gestor;
        }
        

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (cmbEmpleado.SelectedIndex == -1 || string.IsNullOrWhiteSpace(cmbEstado.Text))
            {
              
                MessageBox.Show("Rellenar todos los espacios!!");

            
                return;
            }
            switch (MessageBox.Show("¿Confirmas la modificación del Cliente?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.Yes:

                    int empleadoId = Convert.ToInt32(cmbEmpleado.SelectedValue);

                    string nuevoEstado = cmbEstado.Text;

                    int nuevoEstado2 = 0;

                    if (nuevoEstado == "Activo")
                    {
                        nuevoEstado2 = 1;
                    }
                    else if (nuevoEstado == "Inactivo")
                    {
                        nuevoEstado2 = 0;
                    }

                    gestorbanco.ModificarEstadocLIENTE(empleadoId, nuevoEstado2);


                    MessageBox.Show("¡Cliente de baja con éxito!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();

                    break;

                case DialogResult.No:
                    break;
            }
        }

        private void Clientesdown_Load(object sender, EventArgs e)
        {
            cmbEmpleado.DataSource = gestorbanco.GetInventarioCliente();
            cmbEmpleado.DisplayMember = "Nombre";
            cmbEmpleado.ValueMember = "ClienteId";

            cmbEstado.Items.Add("Activo");
            cmbEstado.Items.Add("Inactivo");

        }
    }
    }

