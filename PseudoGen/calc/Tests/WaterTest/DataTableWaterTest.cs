using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PseudoGen.calc.WaterTest
{
    class DataTableWaterTest
    {
        public List<double>[] RiPhases;

        public List<string>[] ResultPhases;

        Generador Gen;
        public int Phase;

        public DataTableWaterTest(Generador gen, int phase)
        {
            Gen = gen;
            Phase = phase;
            RiPhases = new List<double>[3];
            ResultPhases = new List<string>[3];
            GenerateData();
        }

        public void GenerateData()
        {
            int k = 15 * (Phase - 1);
            for (int i = 0; i < 4; i++)
            {
                RiPhases[i] = new List<double>();
                ResultPhases[i] = new List<string>();
                for (int j = 0; j < 20; j++)
                { 
                    RiPhases[i].Add(Gen.Nums[k]);
                    ResultPhases[i].Add((WaterTest.GetPointState(Gen.Nums[k])));
                    k++;
                }
            }
        }

    }
}
