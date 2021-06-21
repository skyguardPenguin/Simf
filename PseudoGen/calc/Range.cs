using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PseudoGen.calc.Tests
{
    public class Range
    {
        public double LimiteInf;
        public double LimiteSup;
        public double Probabilidad;

        public Range(double inf, double sup, double probabilidad)
        {
            LimiteInf = inf;
            LimiteSup = sup;
            Probabilidad = probabilidad;
        }

    }
}
