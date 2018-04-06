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
namespace _153301049
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
        List<List<List<double>>> XY = new List<List<List<double>>>();
        List<double> Fxsonuclari = new List<double>();
        List<List<List<double>>> arapopxy = new List<List<List<double>>>();
        List<double> MinUygunlukDegerleri = new List<double>();
        List<double> OrtUygunlukDegerleri = new List<double>();
        int psize;
        int d;
        int iterasyonsayisi;
        double min;
        double topla;
        private void button1_Click(object sender, EventArgs e)
        {
            psize = Convert.ToInt32(numericUpDown1.Value);
            d = Convert.ToInt32(numericUpDown2.Value);
            iterasyonsayisi = Convert.ToInt32(numericUpDown3.Value);
            MinUygunlukDegerleri.Clear();
            OrtUygunlukDegerleri.Clear();
            XY.Clear();
            Fxsonuclari.Clear();
            arapopxy.Clear();

            // İlk Popilasyon
            //
            IlkPop IlkPopilasyonum = new IlkPop(psize, d);
            XY = IlkPopilasyonum.IlkPopilasyon();

            while (iterasyonsayisi > 0)
            {
                Fxsonuclari.Clear();
                // Fonksiyon değerleri hesapla
                //
                TestFonksiyonu Fonksiyondegerleri = new TestFonksiyonu(XY, psize, d);
                Fxsonuclari = Fonksiyondegerleri.Fonksiyon();

                // Uygunluk Değerleri Hesapla
                //
                uygunlukd();

                // Doğal Seçilim
                //
                DogalSecilim Dogalsecilimim = new DogalSecilim(XY, psize, d, Fxsonuclari);
                arapopxy = Dogalsecilimim.DogalSecilimle();

                // Çaprazlama
                //
                Caprazlama Capraz = new Caprazlama(arapopxy, psize, d);
                arapopxy = Capraz.Caprazla();

                // Mutasyon
                //
                Mutasyon mutasyon = new Mutasyon(arapopxy, psize, d);
                arapopxy = mutasyon.Mutasyonla();
                iterasyonsayisi--;
            }
            grafk(MinUygunlukDegerleri, OrtUygunlukDegerleri);
        }
        
        public void uygunlukd()
        {
            if (iterasyonsayisi == Convert.ToInt32(numericUpDown3.Value))
                min = Fxsonuclari[0];
            topla = 0;
            for (int i = 0; i < psize; i++)
            {
                if (min > Fxsonuclari[i])
                {
                    min = Fxsonuclari[i];
                }
                topla += Fxsonuclari[i];
            }
            OrtUygunlukDegerleri.Add(topla / psize);
            MinUygunlukDegerleri.Add(min);
        }
        public void grafk(List<double> MinUygunlukDegerleri, List<double> OrtUygunlukDegerleri)
        {
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }

            try
            {
                Series ort = chart1.Series.Add("Ortalama Uygunluk");
                ort.ChartType = SeriesChartType.Line;
                ort.BorderWidth = 2;
                ort.Color = Color.Red;
                

                Series min = chart1.Series.Add("Minimum Uygunluk");
                min.ChartType = SeriesChartType.Line;
                min.Color = Color.Blue;
                min.BorderWidth = 2;
            }
            catch (Exception)
            { }

            foreach (var item in MinUygunlukDegerleri)
            {
                this.chart1.Series["Minimum Uygunluk"].Points.Add(item);
            }
            foreach (var item in OrtUygunlukDegerleri)
            {
                this.chart1.Series["Ortalama Uygunluk"].Points.Add(item);
            }
            listBox1.Items.Add(MinUygunlukDegerleri[MinUygunlukDegerleri.Count-1]);
        }
    }
}
