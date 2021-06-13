using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PseudoGen.calc.randomNumbers.proofs
{
    public class KolmogorovSmirnov
    {
        public int C;
        public string conclusion;
        public double Alfa;
        public bool UniformementeDistribuidos = false;
        Generador generador;
        public double[,] Smirnov;
        public double[,] tabladealfa;
        public double[] alfa1 = new double[50] { 0.90000, 0.68337, 0.56481, 0.49265, 0.44698, 0.41037, 0.38148, 0.35831, 0.33910, 0.32260, 0.30829, 0.29577, 0.28470, 0.27481, 0.26589, 0.25778, 0.25039, 0.24360, 0.23735, 0.23156, 0.22517, 0.22115, 0.21646, 0.21205, 0.20790, 0.20399, 0.20030, 0.19680, 0.19348, 0.19032, 0.18732, 0.18445, 0.18171, 0.17909, 0.17659, 0.17418, 0.17188, 0.16966, 0.16753, 0.16547, 0.16349, 0.16158, 0.15974, 0.15795, 0.15623, 0.15457, 0.15295, 0.15139, 0.14987, 0.14840 };
        public double[] alfa2 = new double[50] { 0.95000, 0.77639, 0.63604, 0.56522, 0.50945, 0.46799, 0.43607, 0.40962, 0.38746, 0.36866, 0.35242, 0.33815, 0.32549, 0.31417, 0.30397, 0.29472, 0.28627, 0.27851, 0.27136, 0.26473, 0.25858, 0.25283, 0.24746, 0.24242, 0.23768, 0.23320, 0.22898, 0.22497, 0.22117, 0.21756, 0.21412, 0.21085, 0.20771, 0.21472, 0.20185, 0.19910, 0.19646, 0.19392, 0.19148, 0.18913, 0.18687, 0.18468, 0.18257, 0.18051, 0.17856, 0.17665, 0.17481, 0.17301, 0.17128, 0.16959 };
        public double[] alfa3 = new double[50] { 0.97500, 0.84189, 0.70760, 0.62394, 0.56328, 0.51926, 0.48342, 0.45427, 0.43001, 0.40925, 0.39122, 0.37543, 0.36143, 0.34890, 0.33750, 0.32733, 0.31796, 0.30936, 0.30143, 0.29408, 0.28724, 0.28087, 0.27497, 0.26931, 0.26404, 0.25908, 0.25438, 0.24993, 0.24571, 0.24170, 0.23788, 0.23424, 0.23076, 0.22743, 0.22425, 0.22119, 0.21826, 0.21544, 0.21273, 0.21012, 0.20760, 0.20517, 0.20283, 10.20056, 0.19837, 0.19625, 0.19420, 0.19221, 0.19028, 0.18841 };
        public double[] alfa4 = new double[50] { 0.99000, 0.90000, 0.78456, 0.68887, 0.62718, 0.57741, 0.53844, 0.50654, 0.47960, 0.45562, 0.43670, 0.41918, 0.40362, 0.38970, 0.37713, 0.36571, 0.35528, 0.34569, 0.33685, 0.32866, 0.32104, 0.31394, 0.30728, 0.30104, 0.29518, 0.28962, 0.28438, 0.27942, 0.27471, 0.27023, 0.26596, 0.26189, 0.25801, 0.25429, 0.25073, 0.24732, 0.24404, 0.24089, 0.23785, 0.23494, 0.23213, 0.22941, 0.22679, 0.22426, 0.22181, 0.21944, 0.21715, 0.21493, 0.21281, 0.21068 };
        public double[] alfa5 = new double[50] { 0.99500, 0.92929, 0.82900, 0.73424, 0.66853, 0.61661, 0.57581, 0.54179, 0.51332, 0.48893, 0.46770, 0.44905, 0.43247, 0.41762, 0.40420, 0.39201, 0.38086, 0.37062, 0.36117, 0.35241, 0.34426, 0.33666, 0.32954, 0.32286, 0.31657, 0.30963, 0.30502, 0.29971, 0.29466, 0.28986, 0.28529, 0.28094, 0.27577, 0.27271, 0.26897, 0.26532, 0.26180, 0.25843, 0.25518, 0.25205, 0.24904, 0.24613, 0.24332, 0.24060, 0.23798, 0.23544, 0.23298, 0.23059, 0.22832, 0.22604 };
        public double[] alfa6 = new double[50] { 0.99750, 0.95000, 0.86428, 0.77639, 0.70543, 0.65287, 0.60975, 0.57429, 0.54443, 0.51872, 0.49539, 0.47672, 0.45921, 0.44352, 0.42934, 0.41644, 0.40464, 0.39380, 0.38379, 0.37451, 0.36588, 0.35782, 0.35027, 0.34318, 0.33651, 0.33022, 0.32425, 0.31862, 0.31327, 0.30818, 0.30333, 0.29870, 0.29428, 0.29005, 0.28600, 0.28211, 0.27838, 0.27483, 0.27135, 0.26803, 0.26482, 0.26173, 0.25875, 0.25587, 0.25308, 0.25038, 0.24776, 0.24523, 0.24281, 0.24039 };
        public double[] alfa7 = new double[50] { 0.99900, 0.96838, 0.90000, 0.82217, 0.75000, 0.69571, 0.65071, 0.61368, 0.58210, 0.55500, 0.53135, 0.51047, 0.49189, 0.47520, 0.45611, 0.44637, 0.43380, 0.42224, 0.41156, 0.40165, 0.39243, 0.38382, 0.37575, 0.36787, 0.36104, 0.35431, 0.34794, 0.34190, 0.33617, 0.33072, 0.32553, 0.32058, 0.31584, 0.31131, 0.30597, 0.30281, 0.29882, 0.29498, 0.29125, 0.28772, 0.28429, 0.28097, 0.27778, 0.27468, 0.27169, 0.26880, 0.26600, 0.26328, 0.26069, 0.25809 };
        public double[] alfa8 = new double[50] { 0.99950, 0.97764, 0.92065, 0.85047, 0.78137, 0.72479, 0.67930, 0.64098, 0.60846, 0.58042, 0.55588, 0.53422, 0.51490, 0.49753, 0.48182, 0.46750, 0.45540, 0.44234, 0.43119, 0.42085, 0.41122, 0.40223, 0.39380, 0.38588, 0.37743, 0.37139, 0.36473, 0.35842, 0.35242, 0.34672, 0.34129, 0.33611, 0.33115, 0.32641, 0.32187, 0.31751, 0.31333, 0.30931, 0.30544, 0.30171, 0.29811, 0.29465, 0.29130, 0.28806, 0.28493, 0.28190, 0.27896, 0.27611, 0.27339, 0.27067 };
        double max = 0;
        public double[] arreglito;
        public KolmogorovSmirnov(Generador gen)
        {
            generador = gen;
            C = gen.Nums.Length;
            Smirnov = new double[C, 7];
            tabladealfa = new double[C, 7];
            arreglito = new double[C];
            Array.Copy(generador.Nums, arreglito, C);
            Array.Sort(arreglito);
            for (int i = 0; i < C; i++)
            {
                Smirnov[i, 0] = arreglito[i];
            }
            for (int i = 0; i < C; i++)
            {
                Smirnov[i, 1] = (i + 1) / C;
            }
            for (int i = 0; i < C; i++)
            {
                Smirnov[i, 2] = Math.Abs(Smirnov[i, 0] - Smirnov[i, 1]);
            }
            max = 0;
            for (int i = 0; i < C; i++)
            {
                if (Smirnov[i, 2] > max)
                {
                    max = Smirnov[i, 2];
                }
            }
        
        }

        public string Result(double alfa)
        {
            Alfa = alfa;
            if (Smirnov.Length > 50)
            {
                if (alfa == 10)
                {
                    if (max <= (1.07 / 300))
                    {
                        conclusion = "Los numeros estan distribuidos uniformemente";
                        UniformementeDistribuidos = true;
                    }
                    else
                    {
                        conclusion = "Los numeros no estan distribuidos uniformemente";
                        UniformementeDistribuidos = false;
                    }
                }
                else if (alfa == 20)
                {
                    if (max <= (1.22 / 300))
                    {
                        conclusion = "Los numeros estan distribuidos uniformemente";
                        UniformementeDistribuidos = true;
                    }
                    else
                    {
                        conclusion = "Los numeros no estan distribuidos uniformemente";
                        UniformementeDistribuidos = false;
                    }
                }
                else if (alfa == 5)
                {
                    if (max <= (1.36 / 300))
                    {
                        conclusion = "Los numeros estan distribuidos uniformemente";
                        UniformementeDistribuidos = true;
                    }
                    else
                    {
                        conclusion = "Los numeros no estan distribuidos uniformemente";
                        UniformementeDistribuidos = false;
                    }
                }
                else if (alfa == 2)
                {
                    if (max <= (1.52 / 300))
                    {
                       conclusion = "Los numeros estan distribuidos uniformemente";
                        UniformementeDistribuidos = true;
                    }
                    else
                    {
                        conclusion = "Los numeros no estan distribuidos uniformemente";
                        UniformementeDistribuidos = false;
                    }
                }
                else if (alfa == 1)
                {
                    if (max <= (1.63 / 300))
                    {
                        conclusion = "Los numeros estan distribuidos uniformemente";
                        UniformementeDistribuidos = true;
                    }
                    else
                    {
                        conclusion = "Los numeros no estan distribuidos uniformemente";
                        UniformementeDistribuidos = false;
                    }
                }
                else if (alfa == 0.5)
                {
                    if (max <= (1.73 / 300))
                    {
                        conclusion = "Los numeros estan distribuidos uniformemente";
                        UniformementeDistribuidos = true;
                    }
                    else
                    {
                        conclusion = "Los numeros no estan distribuidos uniformemente";
                        UniformementeDistribuidos = false;
                    }
                }
                else if (alfa == 0.2)
                {
                    if (max <= (1.85 / 300))
                    {
                        conclusion = "Los numeros estan distribuidos uniformemente";
                        UniformementeDistribuidos = true;
                    }
                    else
                    {
                        conclusion = "Los numeros no estan distribuidos uniformemente";
                        UniformementeDistribuidos = false;
                    }
                }
                else if (alfa == 0.1)
                {
                    if (max <= (1.95 / 300))
                    {
                        conclusion = "Los numeros estan distribuidos uniformemente";
                        UniformementeDistribuidos = true;
                    }
                    else
                    {
                        conclusion = "Los numeros no estan distribuidos uniformemente";
                        UniformementeDistribuidos = false;
                    }
                }
            }
            else
            {
                if (alfa == 20)
                {
                    if (max <= alfa1[generador.Nums.Length])
                    {
                        conclusion = "Los numeros estan distribuidos uniformemente";
                        UniformementeDistribuidos = true;
                    }
                    else
                    {
                        conclusion = "Los numeros no estan distribuidos uniformemente";
                        UniformementeDistribuidos = false;
                    }
                }
                else if (alfa == 10)
                {
                    if (max <= alfa2[generador.Nums.Length])
                    {
                        conclusion = "Los numeros estan distribuidos uniformemente";
                        UniformementeDistribuidos = true;
                    }
                    else
                    {
                        conclusion = "Los numeros no estan distribuidos uniformemente";
                        UniformementeDistribuidos = false;
                    }
                }
                else if (alfa == 5)
                {
                    if (max <= alfa3[generador.Nums.Length])
                    {
                        conclusion = "Los numeros estan distribuidos uniformemente";
                        UniformementeDistribuidos = true;
                    }
                    else
                    {
                        conclusion = "Los numeros no estan distribuidos uniformemente";
                        UniformementeDistribuidos = false;
                    }
                }
                else if (alfa == 2)
                {
                    if (max <= alfa4[generador.Nums.Length])
                    {
                        conclusion = "Los numeros estan distribuidos uniformemente";
                        UniformementeDistribuidos = true;
                    }
                    else
                    {
                        conclusion = "Los numeros no estan distribuidos uniformemente";
                        UniformementeDistribuidos = false;
                    }
                }
                else if (alfa == 1)
                {
                    if (max <= alfa5[generador.Nums.Length])
                    {
                        conclusion = "Los numeros estan distribuidos uniformemente";
                        UniformementeDistribuidos = true;
                    }
                    else
                    {
                        conclusion = "Los numeros no estan distribuidos uniformemente";
                        UniformementeDistribuidos = false;
                    }
                }
                else if (alfa == 0.5)
                {
                    if (max <= alfa6[generador.Nums.Length])
                    {
                        conclusion = "Los numeros estan distribuidos uniformemente";
                        UniformementeDistribuidos = true;
                    }
                    else
                    {
                        conclusion = "Los numeros no estan distribuidos uniformemente";
                        UniformementeDistribuidos = false;
                    }
                }
                else if (alfa == 0.2)
                {
                    if (max <= alfa7[generador.Nums.Length])
                    {
                        conclusion = "Los numeros estan distribuidos uniformemente";
                        UniformementeDistribuidos = true;
                    }
                    else
                    {
                        conclusion= "Los numeros no estan distribuidos uniformemente";
                        UniformementeDistribuidos = false;
                    }
                }
                else if (alfa == 0.1)
                {
                    if (max <= alfa8[generador.Nums.Length])
                    {
                        conclusion = "Los numeros estan distribuidos uniformemente";
                        UniformementeDistribuidos = true;
                    }
                    else
                    {
                        conclusion= "Los numeros no estan distribuidos uniformemente";
                        UniformementeDistribuidos = false;
                    }

                }
              
            }
            return conclusion;
        }
    }
}
