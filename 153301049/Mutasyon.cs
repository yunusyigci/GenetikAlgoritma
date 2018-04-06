using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _153301049
{
    class Mutasyon
    {

        List<List<List<double>>> XY = new List<List<List<double>>>();
        List<List<double>> arapopx = new List<List<double>>();
        List<List<double>> arapopy = new List<List<double>>();
        int psize;
        int d;
        public Mutasyon(List<List<List<double>>> XY, int psize, int d)
        {
            this.arapopx = XY[0];
            this.arapopy = XY[1];
            this.psize = psize;
            this.d = d;
        }

        public List<List<List<double>>> Mutasyonla()
        {
            Random rnd = new Random();
            double[,] rs = new double[psize, d];
            for (int i = 0; i < psize; i++)
            {
                for (int j = 0; j < d; j++)
                {
                    rs[i, j] = rnd.NextDouble();
                    if (rs[i, j] < 5 / 1000)
                    {
                        double rs2 = rnd.Next(-15, -5) * rnd.NextDouble();
                        double rs3 = rnd.Next(-3, 3) * rnd.NextDouble();

                        arapopx[i][j] = rs2;
                        arapopy[i][j] = rs3;
                    }
                }
            }
            XY.Add(arapopx);
            XY.Add(arapopy);
            return XY;
        }
    }
}
