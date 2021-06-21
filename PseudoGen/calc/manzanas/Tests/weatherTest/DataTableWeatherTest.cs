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
        public List<double> Ri;

        public List<string> Result;

        public double riSimulado;
        public string resultSimulado;

        public int nD3 = 0;
        public int nD5 = 0;
        public int nD8 = 0;
        public int nD10 = 0;
        public int nD14 = 0;
        public int nD16 = 0;

        Generador Gen;

        public string Conclusion;
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
            for (int j = 0; j < 51; j++)
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
                    nD14++; nDuracion++;
                if (result == WeatherTest.D16)
                    nD16++;
            }

            if(Apta=nDuracion<=50*.45)
            {
                opcElegida = WeatherTest.OPC_VENDER;
                precioVenta = 150d + (150d * .3);
            }
            else
            {
                opcElegida = WeatherTest.OPC_ESPERAR;
                riSimulado = Gen.Nums[50];
                resultSimulado = WeatherTest.GetPointState(Gen.Nums[50]);

                if(resultSimulado==WeatherTest.D3|| resultSimulado == WeatherTest.D5||resultSimulado == WeatherTest.D8|| resultSimulado == WeatherTest.D10)
                {
                    precioVenta = 150d +(150* .70d);
                }
                else
                {
                    precioVenta = 150d - (150d * .1d);
                }
            }





            
        }
    }
}
