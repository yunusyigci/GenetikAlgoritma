using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _153301049
{
    class DogalSecilim
    {
        List<List<List<double>>> XY = new List<List<List<double>>>();
        List<List<double>> x = new List<List<double>>();
        List<List<double>> y = new List<List<double>>();
        List<List<double>> arapopx = new List<List<double>>();
        List<List<double>> arapopy = new List<List<double>>();
        List<double> Fxsonuclari = new List<double>();
        int psize;
        int d;
        public DogalSecilim(List<List<List<double>>> XY, int psize, int d, List<double> Fxsonuclari)
        {
            this.x = XY[0];
            this.y = XY[1];
            this.psize = psize;
            this.d = d;
            this.Fxsonuclari = Fxsonuclari;
        }

        public List<List<List<double>>> DogalSecilimle()
        {
            double[] olasilik = new double[psize];
            double uygunlukdegeri = 0;

            foreach (int i in Fxsonuclari)
                uygunlukdegeri += 1.0 / i;
            for (int i = 0; i < psize; i++)
            {
                olasilik[i] =1.0/ Fxsonuclari[i] / uygunlukdegeri;
                if (i > 0)
                {
                    olasilik[i] += olasilik[i - 1];
                }
            }
            Random rastgele = new Random();
            double[] rasgeleolasilik = new double[psize];
            for (int i = 0; i < psize; i++)
            {
                rasgeleolasilik[i] = rastgele.NextDouble();
            }
            arapopx = x;
            arapopy = y;
            for (int i = 0; i < psize; i++)
            {
                for (int j = 0; j < psize; j++)
                {
                    if (rasgeleolasilik[i] < olasilik[j])
                    {
                        for (int a = 0; a < d; a++)
                        {
                            arapopx[i][ a] = x[j][ a];
                            arapopy[i][ a] = y[j][ a];

                        }
                        break;//olasılık arlığı ilk tutanı aldıktan sonra diğerlerine atma
                    }
                }
            }
            XY.Add(arapopx);
            XY.Add(arapopy);
            return XY;
        }
    }
}