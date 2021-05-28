using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PseudoGen.calc
{
    class DistribucionTriangular
    {
        double a,b,c,r,x;
        public double diff;
        public DistribucionTriangular(double a,double b,double c,double r)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.r = r;
            diff = (b - a) / (c - a);
        }

        public double Result()
        {
            
            if (r< (b - a) / (c - a))
            {
                return x = a + Math.Sqrt((b-a)*(c-a)*r);
            }
            else if(r==(b-a)/(c-a))
            {
                return x = b;
            }
            else
            {
                return x = c - Math.Sqrt((c-b)*(c-a)*(1-r));
            }
            return 0.0;
        }
       
    }
}
