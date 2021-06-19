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

        private int nAcidez=0;
        private int nAnemia=0;
        private int nNormal=0;
        private int nGlucosa=0;
        private int nAlcalinidad=0;


        Generador Gen;
        public int Phase;
        public string Conclusion;
        public bool Apta = false;
        public string ResultadoMFrecuente;
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
                    if (k == Gen.Nums.Count()-1) throw new Exception("La cantidad de números pseudoaleatorios generados no es la suficiente para las pruebas de sangre y muestras de agua.");
              

                    RiPhases[i].Add(Gen.Nums[k]);
                    string result= BloodTest.GetPointState(Gen.Nums[k]);
                    ResultPhases[i].Add(result);

                    if (result == BloodTest.ACIDEZ)
                        nAcidez++;
                    if (result == BloodTest.ANEMIA)
                        nAnemia++;
                    if (result == BloodTest.NORMAL)
                        nNormal++;
                    if (result == BloodTest.GLUCOSA)
                        nGlucosa++;
                    if (result == BloodTest.ALCALINIDAD)
                        nAlcalinidad++;



                    k++;
                }
            }
            if (nAcidez > nAnemia && nAcidez > nNormal && nAcidez > nGlucosa && nAcidez > nAlcalinidad)
            {
                Conclusion = BloodTest.NO_APTA;ResultadoMFrecuente = BloodTest.ACIDEZ;
            }
            else if(nAnemia > nAcidez && nAnemia > nNormal && nAnemia > nGlucosa && nAnemia > nAlcalinidad)
            {
                Conclusion = BloodTest.NO_APTA; ResultadoMFrecuente = BloodTest.ANEMIA;
            }
            else if (nNormal > nAcidez && nNormal > nAnemia && nNormal > nGlucosa && nNormal > nAlcalinidad)
            {
                Conclusion = BloodTest.APTA; ResultadoMFrecuente = BloodTest.NORMAL;Apta = true;
            }
            else if (nGlucosa > nAcidez && nGlucosa > nNormal && nGlucosa > nAnemia && nGlucosa > nAlcalinidad)
            {
                Conclusion = BloodTest.NO_APTA; ResultadoMFrecuente = BloodTest.GLUCOSA;
            }
            else if (nAlcalinidad > nAcidez && nAlcalinidad > nNormal && nAlcalinidad > nGlucosa && nAlcalinidad > nAnemia)
            {
                Conclusion = BloodTest.NO_APTA; ResultadoMFrecuente = BloodTest.ALCALINIDAD;
            }



        }
        
    }
}
