using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _153301049
{
    class TestFonksiyonu
    {

        List<double> Fxsonuclari = new List<double>();
        List<List<double>> a = new List<List<double>>();
        List<List<double>> b = new List<List<double>>();
        int psize;
        int d;
        public TestFonksiyonu(List<List<List<double>>> XY, int psize, int d)
        {
            this.a = XY[0];
            this.b = XY[1];
            this.psize = psize;
            this.d = d;
        }
        public List<double> Fonksiyon()
        {

            for (int i = 0; i < psize; i++)
            {
                Fxsonuclari.Add(0);
                for (int j = 0; j < d; j++)
                {
                    double x = a[i][j];
                    double y = b[i][j];
                    double z = 100 * Math.Sqrt(Math.Abs(y - 0.01 * Math.Pow(x, 2))) + 0.01 * Math.Abs(x + 10);
                    Fxsonuclari[i] += z;
                }
            }
            return Fxsonuclari;
        }

        
    }
}
