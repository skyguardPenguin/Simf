using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PseudoGen.calc
{
    class BloodTest
    {
        public const string ACIDEZ = "Alto grado de acidez";
        public const string ANEMIA = "Estado de anemia aguda";
        public const string NORMAL = "Estado en rango normal";
        public const string GLUCOSA = "Exceso de glucosa";
        public const string ALCALINIDAD = "Alto grado de alcalinidad";

        public const double P_ACIDEZ = .18;
        public const double P_ANEMIA=.08;
        public const double P_NORMAL=.35;
        public const double P_GLUCOSA=.17;
        public const double P_ALCALINIDAD=.22;


        public static Dictionary<string, double> ProbEnfermedades = new Dictionary<string, double>();
        public static List<string> Enfermedades= new List<string>();
        public static List<double> Probabilidades = new List<double>();

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
        }
        public BloodTest()
        {
           
        }

        

    }
}
