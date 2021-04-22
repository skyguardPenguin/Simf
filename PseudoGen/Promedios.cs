using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PseudoGen
{
    public class Promedios
    {
        public float Alfa, Z, Promedio, Za;
        Generador Gen;
        public bool H0;//Hipótesis que indica si los números están uniformemente distribuidos

        public Promedios(Generador gen)
        {
            Alfa = .05f;
            Za = 1.96f;
            Gen = gen;
            Promedio = (float)Gen.Nums.Sum()/((float)Gen.Nums.Count()-1);
            Z = ((Promedio - .5f) * (float)Math.Sqrt(Gen.Nums.Count()-1))/(float)Math.Sqrt(1f/12F);

            H0 = Math.Abs(Z) < Za;
        }
    }
}
