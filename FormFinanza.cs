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
        public List<Fullpagos> pagostemporales = new List<Fullpagos>();
        public FormFinanza(AppBancaria gestor)
        {
            InitializeComponent();
            this.gestorbanco = gestor;
        }
        
        private void CargarPeriodosExistentes()
        {
            List<Fullpagos> listacompleta = gestorbanco.GetTodosLosPagos();
            var listafiltradaBase = listacompleta.Where(p => !pagostemporales.Any(b => b.ID == p.ID && b.Tipo == p.Tipo));
            if (CmbEstado.SelectedItem != null && CmbEstado.SelectedItem.ToString() != "Todos")
            {
                string estadoactual = CmbEstado.SelectedItem.ToString();
                listafiltradaBase = listafiltradaBase.Where(p => p.Estado == estadoactual);
            }

            List<String> Periodos = listafiltradaBase
                .Select(p => DateTime.Parse(p.Fecha).ToString("MM-yyyy"))
                .Distinct()
                .OrderByDescending(m  => m)
                .ToList();
            string seleccionadoPreviamente = CmbMes.SelectedItem?.ToString();
            CmbMes.Items.Clear();

            foreach (string mes in Periodos)
            {
                CmbMes.Items.Add(mes);
            }
            if (CmbMes.Items.Count > 0)
            { 
                if(!string.IsNullOrEmpty(seleccionadoPreviamente) && CmbMes.Items.Contains(seleccionadoPreviamente))
                {
                    CmbMes.SelectedItem = seleccionadoPreviamente;
                }
                else
                {
                    CmbMes.SelectedIndex = 0;
                }
            }
        }
        private void UpdateData()
        {
            List <Fullpagos> listacompleta = gestorbanco.GetTodosLosPagos();
            var ListaFiltrada = listacompleta.Where(p => !pagostemporales.Any(b => b.ID == p.ID && b.Tipo == p.Tipo)).ToList();
            if (CmbEstado.SelectedItem != null && CmbEstado.SelectedItem.ToString() != "Todos")
            {
                string FiltroEstado = CmbEstado.SelectedItem.ToString();
                ListaFiltrada = ListaFiltrada.Where(p => p.Estado == FiltroEstado).ToList();
            }
            //filtro Estado
            if (CmbMes.SelectedItem != null)
            {
                string MesSeleccionado = CmbMes.SelectedItem.ToString();
                ListaFiltrada = ListaFiltrada.Where(p => DateTime.Parse(p.Fecha).ToString("MM-yyyy") == MesSeleccionado).ToList();
            }
            else
            {
                ListaFiltrada.Clear();
            }

            if (CmbTipopago.SelectedItem != null && CmbTipopago.SelectedItem.ToString() != "Todos")
            {
                string FiltroTipo = CmbTipopago.SelectedItem.ToString();
                ListaFiltrada = ListaFiltrada.Where(p => p.Tipo == FiltroTipo).ToList();
            }
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = ListaFiltrada;
            ActualizarLabeldinero();
        }
        private void ActualizarLabeldinero()
        {
            double presupuestoBase = gestorbanco.ObtenerSaldo();
            double TotalenBolsa = pagostemporales.Sum(p => Convert.ToDouble(p.Monto));
            double dinerorestante = presupuestoBase - TotalenBolsa;
            label2.Text = $"Dinero Actual: ${dinerorestante:N2}";
            if (dinerorestante < 0)
            {
                label2.ForeColor = Color.Red;
            }
            else
            {
                label2.ForeColor= Color.Black;
            }

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

            CargarPeriodosExistentes();
            UpdateData();
        }

        private void CmbTipopago_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateData();
        }

        private void CmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarPeriodosExistentes();
            UpdateData();
        }

        private void ingresosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AgregarPago_ ventanaAgregar = new AgregarPago_(this.gestorbanco);
            ventanaAgregar.ShowDialog();
            CargarPeriodosExistentes();
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
                int id  = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
                string tipo = dataGridView1.CurrentRow.Cells["Tipo"].Value.ToString();

                List<Fullpagos> listacompleta = gestorbanco.GetTodosLosPagos();
                Fullpagos pagoseleccionado = listacompleta.FirstOrDefault(p => p.ID == id && p.Tipo == tipo);
                if (pagoseleccionado != null)
                {
                    if(!pagostemporales.Any(b => b.ID == id && b.Tipo == tipo))
                    {
                        pagostemporales.Add(pagoseleccionado);
                        MessageBox.Show($"'{pagoseleccionado.Concepto}' agregado a la bolsa.", "Bolsa Temporal", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        UpdateData();
                    }
                    else
                    {
                        MessageBox.Show("Este pago ya está en la bolsa.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                }
            else
            {
                MessageBox.Show("Por favor, seleccione una fila de la tabla primero", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CmbMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateData();
        }

        private void btCM_Click(object sender, EventArgs e)
        {
            if(pagostemporales.Count == 0)
            {
                MessageBox.Show("No hay pagos en la bolsa temporal para procesar.", "Bolsa Vacía", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            double presupuestoBase = gestorbanco.ObtenerSaldo();
            double Totalenbolsa = pagostemporales.Sum(p => Convert.ToDouble(p.Monto));

            if (Totalenbolsa > presupuestoBase)
            {
                MessageBox.Show($"Operacion cancelada!! El total de fondos excede a la cantidad actual", "Operacion Cancelada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var pregunta = MessageBox.Show($"¿Desea procesar y marcar como 'Realizados' los {pagostemporales.Count} pagos de la bolsa?",
                                           "Confirmar operacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (pregunta == DialogResult.Yes)
            {
                foreach(var pago in pagostemporales)
                {
                    gestorbanco.Cambiarestado(pago.ID, pago.Tipo);
                }
                pagostemporales.Clear();
                MessageBox.Show("Todos los pagos se han procesado con éxito", "operacion exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarPeriodosExistentes();
                UpdateData();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Agregar_ingreso ventana = new Agregar_ingreso(this.gestorbanco);
            ventana.ShowDialog();
        }
    }
}
