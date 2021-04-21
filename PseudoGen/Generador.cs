using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PseudoGen
{
    class Generador
    {
        int X0,a,c,m;
        public int[] Xn;
       
        public double[] Nums;
        public object[,] rows;

        public Generador(int X0,int a, int c, int m)
        {
            this.X0 = X0;
            this.a = a;
            this.c = c;
            this.m = m;

            Xn = new int[m+1];
           
            Nums = new double[m+1];

            rows = new object[m+1, 3];
            Calcular();
        }

        public void Calcular()
        {
            Xn[0] = X0;
            
            for(int i =0;i<m+1;i++)
            {
                if (i <m )
                {
                    Xn[i + 1] = (a * Xn[i] + c)%m;
                    Nums[i] = (double)Xn[i + 1]/(double)m;
                    Nums[i]=Math.Round(Nums[i],5);
                    rows[i, 0] = Xn[i];
                    rows[i, 1] = Xn[i + 1];
                    rows[i, 2] = Nums[i];

                }
               
            

            }
        }



    }
}
