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
        public AppBancaria gestorbanco;
        public FormPersonal(AppBancaria gestor)
        {
            InitializeComponent();

            this.gestorbanco = gestor;

        }
        private void UpdateData()
        {
            dgvpersonal.DataSource = null;
            dgvpersonal.DataSource = gestorbanco.GetTodosLosEmpleados();
        }

        private void FormPersonal_Load(object sender, EventArgs e)
        {
            dgvpersonal.DataSource = gestorbanco.GetTodosLosEmpleados();
        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AgregarEmpleado ventanaAgregar = new AgregarEmpleado(gestorbanco);

            ventanaAgregar.ShowDialog();

            UpdateData();
        }

        private void btnbusqueda_Click(object sender, EventArgs e)
        {
             
        
            FormBusquedaPuesto ventanaAgregar = new FormBusquedaPuesto(gestorbanco);

            ventanaAgregar.ShowDialog();





        
    }

        private void quitarToolStripMenuItem_Click(object sender, EventArgs e)
        {
           DespedirGente ventanaAgregar = new DespedirGente(gestorbanco);

            ventanaAgregar.ShowDialog();

            UpdateData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    }

