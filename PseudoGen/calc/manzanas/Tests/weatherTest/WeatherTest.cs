using PseudoGen.calc.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PseudoGen.calc.manzanas.Tests.wheaterTest
{
    class WeatherTest
    {
        public const string D3 = "3 días";
        public const string D5 = "5 días";
        public const string D8 = "8 días";
        public const string D10 = "10 días";
        public const string D14= "14 días";
        public const string D16= "16 días";

        public const double PD3 = .15;
        public const double PD5 = .08;
        public const double PD8 = .12;
        public const double PD10 = .2;
        public const double PD14 = .25;
        public const double PD16 = .2;

        public static Dictionary<string, double> ProbDias = new Dictionary<string, double>();
        public static List<string> Dias = new List<string>();
        public static List<double> Probabilidades = new List<double>();
        public static List<Range> Rangos = new List<Range>();

        public Generador Gen;

        //Conclusiones
        public const string OPC_VENDER = "Vender toda su mercancía en este momento con una ganancia segura del 30%";
        public const string OPC_ESPERAR = "Esperar dos semanas con la posibilidad de obtener una ganancia del 70% si el clima no mejora, y la posibilidad de tener una pérdida del 10% si el clima mejora.";

        public const string VENDIO="Después de vender las manzanas antes del plazo de 2 semanas, el precio por caja es de: ";
        public const string ESPERO = "Después de esperar a que se cumpla el plazo de 2 semanas para vender, el precio por caja es de: ";

        public const string CLIMA = "Según los resultados de la simulación, el porcentaje de años en los que el clima mejoró en un lapso menor a 2 semanas es:  ";


        static WeatherTest()
        {
            Dias.Add(D3);
            Dias.Add(D5);
            Dias.Add(D8);
            Dias.Add(D10);
            Dias.Add(D14);
            Dias.Add(D16);

            Probabilidades.Add(PD3);
            Probabilidades.Add(PD5);
            Probabilidades.Add(PD8);
            Probabilidades.Add(PD10);
            Probabilidades.Add(PD14);
            Probabilidades.Add(PD16);

            for (int i = 0; i < 5; i++)
            {
                ProbDias.Add(Dias[i], Probabilidades[i]);
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
                    return Dias[i];
            }
            return "ERROR";
        }


    }
}
