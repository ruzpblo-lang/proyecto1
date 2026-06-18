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
            List <Fullpagos> listacompleta = gestorbanco.GetTodosLosPagos();
            //filtro tipo
            var ListaFiltrada = gestorbanco.GetTodosLosPagos(); 
            if (CmbTipopago.SelectedItem != null && CmbTipopago.SelectedItem.ToString() != "Todos")
            {
                string FiltroTipo = CmbTipopago.SelectedItem.ToString();
                ListaFiltrada = ListaFiltrada.Where(p => p.Tipo == FiltroTipo).ToList();
            }
            //filtro Estado
            if (CmbEstado.SelectedItem != null && CmbEstado.SelectedItem.ToString() != "Todos")
            {
                string FiltroEstado = CmbEstado.SelectedItem.ToString();
                ListaFiltrada = ListaFiltrada.Where(p => p.Estado == FiltroEstado).ToList();
            }
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = ListaFiltrada;
        }

        private void FormFinanza_Load(object sender, EventArgs e)
        {
            //Filtrado por tipo
            CmbTipopago.Items.Clear();
            CmbTipopago.Items.Add("Todos");
            CmbTipopago.Items.Add("Nómina");
            CmbTipopago.Items.Add("Gasto Externo");
            CmbTipopago.SelectedIndex = 0;

            CmbEstado.Items.Clear();
            CmbEstado.Items.Add("Todos");
            CmbEstado.Items.Add("Pendiente");
            CmbEstado.Items.Add("Realizado");
            CmbEstado.SelectedIndex = 0;

            UpdateData();
        }

        private void CmbTipopago_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateData();
        }

        private void CmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateData();
        }
    }
}
