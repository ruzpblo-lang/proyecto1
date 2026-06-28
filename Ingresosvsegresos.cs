using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

            foreach (var registro in datosDB)
            {
                chart1.Series["Ingresos"].Points.AddXY(registro.Mes, registro.Ingresos);
                chart1.Series["Egresos"].Points.AddXY(registro.Mes, registro.Egresos);
            }

        }

        private void Ingresosvsegresos_Load(object sender, EventArgs e)
        {
            iniciadorgraf();
        }
    }
}
