using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Proyecto
{

    public partial class Ingresosvsegresos : Form
    {
        public AppBancaria gestorbanco;

        public Ingresosvsegresos(AppBancaria gestorbanco)
        {
            InitializeComponent();
            this.gestorbanco = gestorbanco;
        }

        private void iniciadorgraf()
        {
            chart1.Series.Clear(); //limpia las serie 1 que trae por defecto
            Series serieingresos = new Series("Ingresos");
            serieingresos.ChartType = SeriesChartType.Column; //tipo de representacion columna,fila etc
            serieingresos.Color = Color.FromArgb(46, 204, 113);//Color de la columna
            serieingresos.IsValueShownAsLabel = true; //mostrar el valor de la columna flotante arriba

            Series serieEgresos = new Series("Egresos");
            serieEgresos.ChartType = SeriesChartType.Column;
            serieEgresos.Color = Color.FromArgb(231, 76, 60);
            serieEgresos.IsValueShownAsLabel = true;

            chart1.Series.Add(serieingresos); //agregar las series a la grafica
            chart1.Series.Add(serieEgresos);

            List<Reportemensual> datosDB = gestorbanco.Obtenerdatosgraf();
        }
        private void Cargarañiosexistentes()
        {
            List<Fullpagos> listacompleta = gestorbanco.obtenertodoslosmovimientos();
            List<string> años = listacompleta
                .Select(p => DateTime.Parse(p.Fecha))
                .OrderByDescending(f  => f)
                .Select( f => f.ToString("yyyy"))
                .Distinct()
                .ToList();

            string seleccionadopreviamente = Cmbano.SelectedItem?.ToString();
            Cmbano.Items.Clear();
            Cmbano.Items.Add("Todos");

            foreach (string año in años)
            {
                Cmbano.Items.Add(año);
            }
            if (Cmbano.Items.Count > 0 )
            {
                if (!string.IsNullOrEmpty(seleccionadopreviamente) && Cmbano.Items.Contains(seleccionadopreviamente))
                {
                    Cmbano.SelectedItem = seleccionadopreviamente;
                }
                else
                {
                    Cmbano.SelectedIndex = 0;
                }
            }
        }
        private void Actualizargrafica()
        {
            chart1.Series["Ingresos"].Points.Clear();
            chart1.Series["Egresos"].Points.Clear();
            List<Fullpagos> listacompleta = gestorbanco.obtenertodoslosmovimientos();

            if (Cmbano.SelectedItem != null && Cmbano.SelectedItem.ToString() != "Todos")
            {
                string añoseleccionado = Cmbano.SelectedItem.ToString();
                listacompleta = listacompleta.Where(p => DateTime.Parse(p.Fecha).ToString("yyyy") == añoseleccionado).ToList();
            }
            var datosgroup = listacompleta
                .Select(p => new
                {
                    Fechaobj = DateTime.Parse(p.Fecha),
                    p.Tipo,
                    Monto = Convert.ToDouble(p.Monto)
                })
                .GroupBy(p => p.Fechaobj.ToString("MM-yyyy"))
                .OrderBy(g => DateTime.Parse("01-" + g.Key));
            foreach (var grupo in datosgroup)
            {
                string Mesejex = grupo.Key;
                double totalingresos = grupo.Where(p => p.Tipo == "Ingreso").Sum(p => p.Monto);
                double totalegresos = grupo.Where(p => p.Tipo == "Nómina" || p.Tipo == "Gasto Externo" || p.Tipo == "Servicio").Sum(p => p.Monto);

                chart1.Series["Ingresos"].Points.AddXY(Mesejex, totalingresos);
                chart1.Series["Egresos"].Points.AddXY(Mesejex, totalegresos);
            }
        }

        private void Ingresosvsegresos_Load(object sender, EventArgs e)
        {
            iniciadorgraf();
            Cargarañiosexistentes();
            Actualizargrafica();
        }

        private void Cmbano_SelectedIndexChanged(object sender, EventArgs e)
        {
            Actualizargrafica();
        }
    }
}
