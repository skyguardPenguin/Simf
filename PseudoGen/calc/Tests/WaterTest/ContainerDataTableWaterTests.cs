using PseudoGen.calc.WaterTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PseudoGen.calc.Tests.WaterTest
{
    class ContainerDataTableWaterTests
    {

        public int NumTables;
        Generador Gen;

        DataTableWaterTest[] DataTables;

        public ContainerDataTableWaterTests(Generador gen)
        {
            Gen = gen;
            NumTables = (Gen.Nums.Count()-75)/80;
            if (NumTables < 3) throw new Exception("La cantidad de números pseudoaleatorios generados no es la suficiente para las pruebas de contaminantes.\nSe necesitan números para al menos 3 tablas. ");
        }

    }
}
