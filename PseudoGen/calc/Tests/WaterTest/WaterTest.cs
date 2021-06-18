using PseudoGen.calc.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PseudoGen.calc.WaterTest
{
    class WaterTest
    {
        public const string COLOIDALES = "Sustancias coloidales";
        public const string MERCURIO = "Exceso de mercurio";
        public const string PETROQUIMICOS = "Residuos petroquímicos";
        public const string SULFATOS = "Sulfatos";
        public const string ACIDO = "Acido clorhídrico";
        public const string FOSFATOS = "Fosfatos";
        public const string OXIDOS = "Óxidos";

        public const double P_COLOIDALES = .05d;
        public const double P_MERCURIO = .10d;
        public const double P_PETROQUIMICOS = .25d;
        public const double P_SULFATOS = .15d;
        public const double P_ACIDO = .12d;
        public const double P_FOSFATOS = .16d;
        public const double P_OXIDOS = .17d;


        public static List<string> Contaminantes = new List<string>();
        public static List<double> Probabilidades = new List<double>();
        public static Dictionary<string, double> ProbContaminantes = new Dictionary<string, double>();
        public static List<Range> Rangos = new List<Range>();

        static WaterTest()
        {
            Contaminantes.Add(COLOIDALES);
            Contaminantes.Add(MERCURIO);
            Contaminantes.Add(PETROQUIMICOS);
            Contaminantes.Add(SULFATOS);
            Contaminantes.Add(ACIDO);
            Contaminantes.Add(FOSFATOS);
            Contaminantes.Add(OXIDOS);

            Probabilidades.Add(P_COLOIDALES);
            Probabilidades.Add(P_MERCURIO);
            Probabilidades.Add(P_PETROQUIMICOS);
            Probabilidades.Add(P_SULFATOS);
            Probabilidades.Add(P_ACIDO);
            Probabilidades.Add(P_FOSFATOS);
            Probabilidades.Add(P_OXIDOS);

            for (int i = 0; i < 7; i++)
            {
                ProbContaminantes.Add(Contaminantes[i], Probabilidades[i]);
            }
            double cuenta = 0.0d;
            for (int i = 0; i < Probabilidades.Count; i++)
            {
                double inf = cuenta;
                cuenta += Probabilidades[i];
                Rangos.Add(new Range(inf, cuenta, Probabilidades[i]));
            }



        }
        public static string GetPointState(double ri)
        {
            for (int i = 0; i < Rangos.Count; i++)
            {
                if (ri >= Rangos[i].LimiteInf && ri < Rangos[i].LimiteSup)
                    return Contaminantes[i];
            }
            return "ERROR";
        }
    }
}
