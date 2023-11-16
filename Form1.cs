using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Markup;

namespace math_lab3_new
{
    public partial class Form1 : Form
    {
        List<MyPoint> points = new List<MyPoint> { new MyPoint(0,3), new MyPoint(1, 2), new MyPoint(3, 1), new MyPoint(4, 2.5), new MyPoint(6, 4), new MyPoint(8, 2), new MyPoint(11, 3) };
        public Form1()
        {
            InitializeComponent();
            string format = "{00.00;-00.00}";

            var pointsCubic = getCubicInterpolation();

            SeriesCollection series = new SeriesCollection(); //отображение данных на график. Линии и т.д.
            ChartValues<double> zp = new ChartValues<double>(); //Значения которые будут на линии, будет создания чуть позже.
            List<double> date = new List<double>(); //здесь будут храниться значения для оси X
            foreach (var item in pointsCubic) //Заполняем коллекции
            {
                zp.Add(item.Y);
                date.Add(item.X);
            }
            cartesianChart1.AxisX.Clear(); //Очищаем ось X от значений по умолчанию
            cartesianChart1.AxisX.Add(new Axis //Добавляем на ось X значения, через блок инициализатора.
            {
                Title = "X",
                Labels = date.Select(x => decimal.Round((decimal)x, 2).ToString()).ToArray()
            }); 

            LineSeries line = new LineSeries(); //Создаем линию, задаем ей значения из коллекции
            line.Title = "Y";
            line.Values = zp;

            series.Add(line); //Добавляем линию на график
            cartesianChart1.Series = series; //Отрисовываем график в интерфейсе


            var pointsLagrange = getLagrangeInterpolation();

            SeriesCollection series2 = new SeriesCollection(); //отображение данных на график. Линии и т.д.
            ChartValues<double> zp2 = new ChartValues<double>(); //Значения которые будут на линии, будет создания чуть позже.
            List<double> date2 = new List<double>(); //здесь будут храниться значения для оси X
            foreach (var item in pointsLagrange) //Заполняем коллекции
            {
                zp2.Add(item.Y);
                date2.Add(item.X);
            }
            cartesianChart2.AxisX.Clear(); //Очищаем ось X от значений по умолчанию
            cartesianChart2.AxisX.Add(new Axis //Добавляем на ось X значения, через блок инициализатора.
            {
                Title = "X",
                Labels = date2.Select(x => decimal.Round((decimal)x,2).ToString()).ToArray()
            });

            LineSeries line2 = new LineSeries(); //Создаем линию, задаем ей значения из коллекции
            line2.Title = "Y";
            line2.Values = zp2;

            series2.Add(line2); //Добавляем линию на график
            cartesianChart2.Series = series2; //Отрисовываем график в интерфейсе
        }

        private MyPoint[] getCubicInterpolation()
        {
            return Cubic.InterpolateXY(points.ToArray(), 20);
        }

        private MyPoint[] getLagrangeInterpolation()
        {
            return Lagrange.Interpolate(points.ToArray(), 20);
        }

        private void elementHost1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void elementHost2_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }
    }
}
