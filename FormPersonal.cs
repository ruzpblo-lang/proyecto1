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

        private void agregarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormInventarioCuenta forms = new FormInventarioCuenta(gestorbanco);
            forms.ShowDialog();
        }

        private void bajaClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clientesdown forms = new Clientesdown(gestorbanco);
            forms.ShowDialog();

        }

        private void mostrarClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ESTADO_CLIENTES forms = new ESTADO_CLIENTES(gestorbanco);
            forms.ShowDialog();
        }

        private void agregarCuentaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Altacuenta forms = new Altacuenta(gestorbanco);
            forms.ShowDialog();
        }

        private void bajaCuentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cuentasdown forms = new cuentasdown(gestorbanco);
            forms.ShowDialog();
        }

        private void mostrarCuentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mostrarcuentas forms = new Mostrarcuentas(gestorbanco);
            forms.ShowDialog();
        }
    }
    }

