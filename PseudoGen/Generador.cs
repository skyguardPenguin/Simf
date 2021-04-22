using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PseudoGen
{
    public class Generador
    {
        int X0,a,c,m,limite;
        public int[] Xn;
       
        public double[] Nums;
        public double[,] Rows;

        public Generador(int X0,int a, int c, int m, int limite)
        {
            this.X0 = X0;
            this.a = a;
            this.c = c;
            this.m = m;
            this.limite = limite;
            if (limite == 0)
            {
                this.limite = m;
                Xn = new int[m + 1];

                Nums = new double[m + 1];

                Rows = new double[m + 1, 3];
            }
            else
            {
                Xn = new int[limite + 1];
                Nums = new double[limite + 1];
                Rows = new double[limite + 1, 3];
            }
            Calcular();
        }

        public void Calcular()
        {
            Xn[0] = X0;
            
            for(int i =0;i<limite+1;i++)
            {
                if (i <limite )
                {
                    Xn[i + 1] = (a * Xn[i] + c)%m;
                    Nums[i] = (double)Xn[i + 1]/(double)m;
                    Rows[i, 0] = Xn[i];
                    Rows[i, 1] = Xn[i + 1];
                    Rows[i, 2] = Nums[i];

                }
               
            

            }
        }



    }
}
