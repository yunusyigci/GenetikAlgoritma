using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _153301049
{
    class Caprazlama
    {
        List<List<List<double>>> XY = new List<List<List<double>>>();
        List<List<double>> arapopx = new List<List<double>>();
        List<List<double>> arapopy = new List<List<double>>();
        int psize;
        int d;
        public Caprazlama(List<List<List<double>>> XY, int psize, int d)
        {
            this.arapopx = XY[0];
            this.arapopy = XY[1];
            this.psize = psize;
            this.d = d;
        }
        public List<List<List<double>>> Caprazla()
        {
            Random rnd = new Random();
            int[] sayi = new int[psize];
            for (int i = 0; i < psize; i++)
            {
                sayi[i] = i;
            }
            int n = psize, deger;
            while (n > 1)
            {
                n--;
                int k = rnd.Next(n + 1);
                deger = sayi[k];
                sayi[k] = sayi[n];
                sayi[n] = deger;
            }

            double rs = rnd.NextDouble();
            if (rs < 0.95)
            {

                double temp;
                double temp2;
                for (int i = 0; i < psize / 2 - 1; i++)
                {

                    int a = rnd.Next(1, d - 1);
                    int b = a;
                    for (int j = 0; j < d - b; j++)
                    {
                        temp = arapopx[sayi[i]][ a];
                        arapopx[sayi[i]][ a] = arapopx[sayi[i + 1]][ a];
                        arapopx[sayi[i + 1]][ a] = temp;

                        temp2 = arapopy[sayi[i]][ a];
                        arapopy[sayi[i]][ a] = arapopy[sayi[i + 1]][ a];
                        arapopy[sayi[i + 1]][ a] = temp2;
                        a++;
                    }
                }
            }
            XY.Add(arapopx);
            XY.Add(arapopy);
            return XY;
        }



    }
}
