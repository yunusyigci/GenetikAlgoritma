using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _153301049
{
    class IlkPop
    {
        List<List<List<double>>> XY = new List<List<List<double>>>();
        List<List<double>> xy = new List<List<double>>();
        List<List<double>> x = new List<List<double>>();
        List<List<double>> y = new List<List<double>>();
        
        int psize;
        int d;
        int xalt=-15;
        int xust=-5;
        int yalt=-3;
        int yust=3;


        public IlkPop(int psize, int d)
        {
            this.psize = psize;
            this.d = d;
        }


        public List<List<double>> ilkdegerler(int ust, int alt)
        {
            
            Random rastgele = new Random();
            int i = 0;
            while (i < psize)
            {
                List<double> gecis = new List<double>();
                int j = 0;
                while (j < d)
                {
                    double sayi = Convert.ToDouble(rastgele.Next(ust, alt)) * rastgele.NextDouble();
                    gecis.Add(sayi);
                    j++;
                }
                xy.Add(gecis);
                
                i++;
            }
            return xy;
        }
        public List<List<List<double>>> IlkPopilasyon()
        {

            x = ilkdegerler(xalt, xust);
            xy.Clear();
            y = ilkdegerler(yalt, yust);
            XY.Add(x);
            XY.Add(y);
            return XY;
        }


    }
}
