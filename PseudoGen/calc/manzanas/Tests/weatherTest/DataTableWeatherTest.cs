using PseudoGen.calc.manzanas.Tests.wheaterTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PseudoGen.calc.manzanas.Tests.weatherTest
{
    class DataTableWeatherTest
    {
        public List<double> Ri= new List<double>();

        public List<string> Result= new List<string>();

        public double riSimulado;
        public string resultSimulado;

        public int nD3 = 0;
        public int nD5 = 0;
        public int nD8 = 0;
        public int nD10 = 0;
        public int nD14 = 0;
        public int nD16 = 0;

        Generador Gen;

        public string ConclusionClima;
        public string ConclusionEleccion;
        public string ConclusionFinal;
        public bool Apta = false;


        public string ResultadoMFrecuente;
        public string opcElegida;

        public double precioVenta;
        

        public DataTableWeatherTest(Generador Gen)
        {
            this.Gen = Gen;
            GenerateData();
        }

        public void GenerateData()
        {

            
            int nDuracion=0;//Contador que registra las veces que el clima dura menos de 2 semanas durante los 50 años
            for (int j = 0; j < 50; j++)
            {
                if (Gen.Nums.Count() - 1 < 50) throw new Exception("La cantidad de números pseudoaleatorios generados no es la suficiente para la simulación. Se necesitan 51 números.");


                Ri.Add(Gen.Nums[j]);
                string result = WeatherTest.GetPointState(Gen.Nums[j]);
                Result.Add(result);

                if (result == WeatherTest.D3)
                {
                    nD3++;nDuracion++;
                }
                if (result == WeatherTest.D5)
                {
                    nD5++; nDuracion++;
                }
                if (result == WeatherTest.D8)
                {
                    nD8++; nDuracion++;
                }
                if (result == WeatherTest.D10)
                {
                    nD10++; nDuracion++;
                }

                if (result == WeatherTest.D14)
                    nD14++; 
                if (result == WeatherTest.D16)
                    nD16++;
            }
            ConclusionClima = WeatherTest.CLIMA + ((float)nDuracion / (50f/100f)).ToString()+ "%";

            if(Apta=(float)nDuracion<=50f*.45f)
            {

                ConclusionEleccion = "La elección escojida en base a los resultados es: " + WeatherTest.OPC_ESPERAR;

                riSimulado = Gen.Nums[50];
                resultSimulado = WeatherTest.GetPointState(Gen.Nums[50]);
                if (resultSimulado == WeatherTest.D14 || resultSimulado == WeatherTest.D16)
                {
                    precioVenta = 150d + (150 * .70d);

                }
                else
                {
                    precioVenta = 150d - (150d * .1d);
                }
                ConclusionFinal = WeatherTest.ESPERO + precioVenta.ToString();
              
            }
            else
            {
                ConclusionEleccion = "La elección escojida en base a los resultados es: " + WeatherTest.OPC_VENDER;
                precioVenta = 150d + (150d * .3d);
                ConclusionFinal = WeatherTest.VENDIO + precioVenta.ToString();



            }






        }
    }
}
