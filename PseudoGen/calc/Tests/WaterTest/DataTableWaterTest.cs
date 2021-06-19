using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PseudoGen.calc.Tests.WaterTest
{
    public class DataTableWaterTest
    {
        public List<double>[] RiPhases;

        public List<string>[] ResultPhases;

       
        Generador Gen;
        public int Phase;

        public int nColoidales=0;
        public int nMercurio=0;
        public int nPetroquimicos=0;
        public int nSulfatos=0;
        public int nAcido=0;
        public int nFosfatos=0;
        public int nOxidos=0;


        public DataTableWaterTest(Generador gen, int phase)
        {
            Gen = gen;
            Phase = phase;
            RiPhases = new List<double>[4];
            ResultPhases = new List<string>[4];
            GenerateData();
        }
        public string[,] ToArrayString()
        {
            string[,] data = new string[8, 20];
            int k = 0, l = 0;
            for(int i=0;i<8;i++)
            {
                List<double> riData= new List<double>();
                List<string> resData= new List<string>();
                if (i % 2 == 0 || i == 0)
                {
                    riData = RiPhases[k++];
                }
                else
                {
                    resData = ResultPhases[l++];
                }
                for(int j=0;j<20;j++)
                {
                    if(i%2==0||i==0)
                    {
                        data[i, j] = riData[j].ToString() ;
                    }
                    else
                    {
                        data[i, j] = resData[j];
                    }
                }
            }

            return data;
        }
        public void GenerateData()
        {
            int k = (80 * (Phase - 1))+60;
            for (int i = 0; i < 4; i++)
            {
                RiPhases[i] = new List<double>();
                ResultPhases[i] = new List<string>();
                for (int j = 0; j < 20; j++)
                { 
                    RiPhases[i].Add(Gen.Nums[k]);

                    string result= WaterTest.GetPointState(Gen.Nums[k]);
                    ResultPhases[i].Add(result);

                    if (result == WaterTest.COLOIDALES) nColoidales++; ;
                    if (result == WaterTest.MERCURIO) nMercurio++ ;
                    if (result == WaterTest.PETROQUIMICOS)nPetroquimicos++ ;
                    if (result == WaterTest.SULFATOS) nSulfatos++;
                    if (result == WaterTest.ACIDO) nAcido++;
                    if (result == WaterTest.FOSFATOS) nFosfatos++ ;
                    if (result == WaterTest.OXIDOS)nOxidos++ ;
                    k++;
                }
            }


        }

    }
}
