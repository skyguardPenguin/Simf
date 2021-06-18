using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PseudoGen.calc
{
    public class DataTableBloodTest
    {
        public List<double>[] RiPhases;

        public List<string>[] ResultPhases;

        Generador Gen;
        public int Phase;
        public DataTableBloodTest(Generador gen, int phase)
        {
            Gen = gen;
            Phase = phase;
            RiPhases = new List<double>[3];
            ResultPhases = new List<string>[3];
            GenerateData();
        }
        public void GenerateData()
        {
            int k = 15*(Phase-1);
            for(int i=0;i<3;i++)
            {
                RiPhases[i] = new List<double>();
                ResultPhases[i] = new List<string>();
                for (int j=0;j<5;j++)
                {
                    if (k == Gen.Nums.Count()) throw new Exception("La cantidad de números pseudoaleatorios generados no es la suficiente para las pruebas de sangre");
              

                    RiPhases[i].Add(Gen.Nums[k]);
                    ResultPhases[i].Add(BloodTest.GetPointState(Gen.Nums[k]));
                    k++;
                }
            }

            
        }
        
    }
}
