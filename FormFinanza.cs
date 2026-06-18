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

        private void ingresosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AgregarPago_ ventanaAgregar = new AgregarPago_(this.gestorbanco);
            ventanaAgregar.ShowDialog();
            UpdateData();
        }

        private void egresosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
                string tipo = dataGridView1.CurrentRow.Cells["Tipo"].Value.ToString();
                string concepto = dataGridView1.CurrentRow.Cells["Concepto"].Value.ToString();

                var resultado = MessageBox.Show($"Seguro que desea eliminar este pago de {tipo} '{concepto}'?",
                                                "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (resultado == DialogResult.Yes)
                {
                    gestorbanco.eliminarpago(id, tipo);
                    MessageBox.Show("Pago eliminado exitosamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UpdateData();
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una fila de la tabla primero", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void marcarComoCompletadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null )
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
                string tipo = dataGridView1.CurrentRow.Cells["Tipo"].Value.ToString();

                gestorbanco.Cambiarestado(id, tipo);
                MessageBox.Show("El estado se ha actualizado a 'Realizado'", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UpdateData();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una fila de la tabla primero", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
