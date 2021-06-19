
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PseudoGen.calc.Tests.WaterTest;
namespace PseudoGen.calc.Tests.WaterTest
{
    public class ContainerDataTableWaterTests
    {

        public int NumTables;
        Generador Gen;

        public DataTableWaterTest[] DataTables;

        public int nColoidales = 0;
        public int nMercurio = 0;
        public int nPetroquimicos = 0;
        public int nSulfatos = 0;
        public int nAcido = 0;
        public int nFosfatos = 0;
        public int nOxidos = 0;

        public string ResultadoMFrecuente="ERROR";

        public ContainerDataTableWaterTests(Generador gen)
        {
            Gen = gen;
            NumTables= (int)((Gen.Nums.Count()-60)/80);
            if (NumTables*80+60> Gen.Nums.Count()-1)
                NumTables = NumTables-1;
             
            if (NumTables < 3) throw new Exception("La cantidad de números pseudoaleatorios generados no es la suficiente para las pruebas de contaminantes.\nSe necesitan números para al menos 3 tablas. ");
            DataTables = new DataTableWaterTest[NumTables];

            for(int i=0;i<NumTables;i++)
            {
                DataTables[i] = new DataTableWaterTest(Gen, i + 1);
                nColoidales += DataTables[i].nColoidales;
                nMercurio += DataTables[i].nMercurio;
                nPetroquimicos += DataTables[i].nPetroquimicos;
                nSulfatos += DataTables[i].nSulfatos;
                nAcido += DataTables[i].nAcido;
                nFosfatos += DataTables[i].nFosfatos;
                nOxidos += DataTables[i].nOxidos;
            }

            if (nColoidales > nMercurio && nColoidales > nPetroquimicos && nColoidales > nSulfatos && nColoidales > nAcido && nColoidales > nFosfatos && nColoidales > nOxidos)
            {
                ResultadoMFrecuente = WaterTest.COLOIDALES;
            }

            else if(nMercurio > nColoidales && nMercurio > nPetroquimicos && nMercurio > nSulfatos && nMercurio > nAcido && nMercurio > nFosfatos && nMercurio > nOxidos)
            {
                ResultadoMFrecuente = WaterTest.MERCURIO;
            }
            else if(nPetroquimicos > nMercurio && nPetroquimicos> nColoidales && nPetroquimicos > nSulfatos && nPetroquimicos > nAcido && nPetroquimicos > nFosfatos && nPetroquimicos > nOxidos)
            {
                ResultadoMFrecuente = WaterTest.PETROQUIMICOS;
            }
            else if(nSulfatos > nMercurio && nSulfatos > nPetroquimicos && nSulfatos > nColoidales && nSulfatos > nAcido && nSulfatos > nFosfatos && nSulfatos > nOxidos)
            {
                ResultadoMFrecuente = WaterTest.SULFATOS;
            }
            else if(nAcido > nMercurio && nAcido > nPetroquimicos && nAcido > nSulfatos && nAcido > nColoidales && nAcido > nFosfatos && nAcido > nOxidos)
            {
                ResultadoMFrecuente = WaterTest.ACIDO;
            }
            else if(nFosfatos> nMercurio && nFosfatos > nPetroquimicos && nFosfatos> nSulfatos && nFosfatos > nAcido && nFosfatos> nColoidales && nFosfatos > nOxidos)
            {
                ResultadoMFrecuente = WaterTest.FOSFATOS;
            }
            else if(nOxidos > nMercurio && nOxidos > nPetroquimicos && nOxidos > nSulfatos && nOxidos > nAcido && nOxidos > nFosfatos && nOxidos > nColoidales)
            {
                ResultadoMFrecuente = WaterTest.OXIDOS;
            }

           
        }


        
    }
}
