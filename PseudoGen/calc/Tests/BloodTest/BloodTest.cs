using PseudoGen.calc.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PseudoGen.calc
{
    
  
    public class BloodTest
    {
        public const string ACIDEZ = "Alto grado de acidez";
        public const string ANEMIA = "Estado de anemia aguda";
        public const string NORMAL = "Estado en rango normal";
        public const string GLUCOSA = "Exceso de glucosa";
        public const string ALCALINIDAD = "Alto grado de alcalinidad";

        public const double P_ACIDEZ = .18;
        public const double P_ANEMIA = .08;
        public const double P_NORMAL = .35;
        public const double P_GLUCOSA = .17;
        public const double P_ALCALINIDAD = .22;

        public static Dictionary<string, double> ProbEnfermedades = new Dictionary<string, double>();
        public static List<string> Enfermedades = new List<string>();
        public static List<double> Probabilidades = new List<double>();
        public static List<Range> Rangos = new List<Range>();


        public Generador Gen;
        

        static BloodTest()
        {
            Enfermedades.Add(ACIDEZ);
            Enfermedades.Add(ANEMIA);
            Enfermedades.Add(NORMAL);
            Enfermedades.Add(GLUCOSA);
            Enfermedades.Add(ALCALINIDAD);
            
            Probabilidades.Add(P_ACIDEZ);
            Probabilidades.Add(P_ANEMIA);
            Probabilidades.Add(P_NORMAL);
            Probabilidades.Add(P_GLUCOSA);
            Probabilidades.Add(P_ALCALINIDAD);

            for(int i=0;i<5;i++)
            {
                ProbEnfermedades.Add(Enfermedades[i], Probabilidades[i]);
            }
            double cuenta = 0.0d;
            for(int i=0;i<Probabilidades.Count;i++)
            {
                double inf = cuenta;
                cuenta += Probabilidades[i];
                Rangos.Add(new Range(inf,cuenta,Probabilidades[i]));
            }
        }
        public BloodTest(Generador generador)
        {
            Gen = generador;

        }

        public static string GetPointState(double ri)
        {
           for(int i=0;i<Rangos.Count;i++)
            {
                if (ri >= Rangos[i].LimiteInf && ri < Rangos[i].LimiteSup)
                    return Enfermedades[i];
            }
            return "ERROR";
        }
     

        

    }
}
