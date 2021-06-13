using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace PseudoGen.forms.proofs
{
    public partial class Smirno : Form
    {
        public int C;
        Generador generador;
        public double[,] Smirnov = new double[299,7];
        public double[,] tabladealfa = new double[299,7];
        public double[] alfa1 = new double[50] {0.90000,0.68337,0.56481,0.49265,0.44698,0.41037,0.38148,0.35831,0.33910,0.32260,0.30829,0.29577,0.28470,0.27481,0.26589,0.25778,0.25039,0.24360,0.23735,0.23156,0.22517,0.22115,0.21646,0.21205,0.20790,0.20399,0.20030,0.19680,0.19348,0.19032,0.18732,0.18445,0.18171,0.17909,0.17659,0.17418,0.17188,0.16966,0.16753,0.16547,0.16349,0.16158,0.15974,0.15795,0.15623,0.15457,0.15295,0.15139,0.14987,0.14840 };
        public double[] alfa2 = new double[50] {0.95000,0.77639,0.63604,0.56522,0.50945,0.46799,0.43607,0.40962,0.38746,0.36866,0.35242,0.33815,0.32549,0.31417,0.30397,0.29472,0.28627,0.27851,0.27136,0.26473,0.25858,0.25283,0.24746,0.24242,0.23768,0.23320,0.22898,0.22497,0.22117,0.21756,0.21412,0.21085,0.20771,0.21472,0.20185,0.19910,0.19646,0.19392,0.19148,0.18913,0.18687,0.18468,0.18257,0.18051,0.17856,0.17665,0.17481,0.17301,0.17128,0.16959};
        public double[] alfa3 = new double[50];
        public double[] alfa4 = new double[50];
        public double[] alfa5 = new double[50];
        public double[] alfa6 = new double[50];
        public double[] alfa7 = new double[50];
        public double[] alfa8 = new double[50];

        
        double max = 0;
        public Smirno(Generador gen,int c)
        {
            InitializeComponent();
            generador = gen;
            C = c;
        }
        private void InserteFormularioDeDetalleDePruebaDeSaidAqui_Load(object sender, EventArgs e)
        {
            for(int i=0;i<300;i++)
            {
                Smirnov[1,0] = generador.Nums[i];
            }

            Array.Sort(Smirnov);
            for (int i = 0; i < 300; i++)
            {
                Smirnov[i, 1] = (i + 1) / 300;
            }
            for (int i = 0; i < 300; i++)
            {
                Smirnov[i, 2] = Math.Abs(Smirnov[i, 0] - Smirnov[i, 1]);
            }
            max = 0;
            for (int i = 0; i < 300; i++)
            {
                if (Smirnov[i, 2] > max)
                {
                    max = Smirnov[i, 2];
                }
            }
        }
        public void alfa(float alfa)
        {
            if (Smirnov.Length > 50)
            {
                if (alfa == 10)
                {
                    if (max <= (1.07 / 300))
                    {
                        Resultado.Text = "Los numeros estan distribuidos uniformemente";
                    }
                    else
                    {
                        Resultado.Text = "Los numeros no estan distribuidos uniformemente";
                    }
                }
                else if (alfa == 20)
                {
                    if (max <= (1.22 / 300))
                    {
                        Resultado.Text = "Los numeros estan distribuidos uniformemente";
                    }
                    else
                    {
                        Resultado.Text = "Los numeros no estan distribuidos uniformemente";
                    }
                }
                else if (alfa == 5)
                {
                    if (max <= (1.36 / 300))
                    {
                        Resultado.Text = "Los numeros estan distribuidos uniformemente";
                    }
                    else
                    {
                        Resultado.Text = "Los numeros no estan distribuidos uniformemente";
                    }
                }
                else if (alfa == 2)
                {
                    if (max <= (1.52 / 300))
                    {
                        Resultado.Text = "Los numeros estan distribuidos uniformemente";
                    }
                    else
                    {
                        Resultado.Text = "Los numeros no estan distribuidos uniformemente";
                    }
                }
                else if (alfa == 1)
                {
                    if (max <= (1.63 / 300))
                    {
                        Resultado.Text = "Los numeros estan distribuidos uniformemente";
                    }
                    else
                    {
                        Resultado.Text = "Los numeros no estan distribuidos uniformemente";
                    }
                }
                else if (alfa == 0.5)
                {
                    if (max <= (1.73 / 300))
                    {
                        Resultado.Text = "Los numeros estan distribuidos uniformemente";
                    }
                    else
                    {
                        Resultado.Text = "Los numeros no estan distribuidos uniformemente";
                    }
                }
                else if (alfa == 0.2)
                {
                    if (max <= (1.85 / 300))
                    {
                        Resultado.Text = "Los numeros estan distribuidos uniformemente";
                    }
                    else
                    {
                        Resultado.Text = "Los numeros no estan distribuidos uniformemente";
                    }
                }
                else if (alfa == 0.1)
                {
                    if (max <= (1.95 / 300))
                    {
                        Resultado.Text = "Los numeros estan distribuidos uniformemente";
                    }
                    else
                    {
                        Resultado.Text = "Los numeros no estan distribuidos uniformemente";
                    }
                }
            }
            else
            {
                if (alfa == 20)
                {
                    if (max <= alfa1[generador.Nums.Length])
                    {
                        Resultado.Text = "Los numeros estan distribuidos uniformemente";
                    }
                    else
                    {
                        Resultado.Text = "Los numeros no estan distribuidos uniformemente";
                    }
                    //si el numero max <= a el numero del arreglo osea el maximo que se tenga pues este se pondra como el [numero] y se compara solo necesito
                    //poder guardarlo en un arreglo
                }
                else if (alfa == 10)
                { }
                else if (alfa == 5)
                { }
                else if (alfa == 2)
                { }
                else if (alfa == 1)
                { }
                else if (alfa == 0.5)
                { }
                else if (alfa == 0.2)
                { }
                else if (alfa == 0.1)
                { }


            }


        }
    }
}
