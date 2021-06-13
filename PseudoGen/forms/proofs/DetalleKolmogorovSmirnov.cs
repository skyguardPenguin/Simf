using PseudoGen.calc.randomNumbers.proofs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PseudoGen
{
    public partial class SmirnovMetodo : Form
    {
       
        Generador generador;
        KolmogorovSmirnov Smirnov;


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();


        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);


    
        public SmirnovMetodo(Generador gen, KolmogorovSmirnov smirnov)
        {
            generador = gen;
            Smirnov = smirnov;
           
            InitializeComponent();

            Resultado.Text = Smirnov.conclusion + ". Valor de alfa: " + Smirnov.Alfa.ToString();



        }
     
    
              
        private void button3_Click(object sender, EventArgs e)
        {
            Smirnov.Result(20);
            Resultado.Text = Smirnov.conclusion+". Valor de alfa: "+ Smirnov.Alfa.ToString();
           

        }
        private void button2_Click(object sender, EventArgs e)
        {
           
            Smirnov.Result(10);
            Resultado.Text = Smirnov.conclusion + ". Valor de alfa: " + Smirnov.Alfa.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Smirnov.Result(5);
            Resultado.Text = Smirnov.conclusion + ". Valor de alfa: " + Smirnov.Alfa.ToString();
        }
            

        private void button5_Click(object sender, EventArgs e)
        {
            Smirnov.Result(2);
            Resultado.Text = Smirnov.conclusion + ". Valor de alfa: " + Smirnov.Alfa.ToString();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Smirnov.Result(1);
            Resultado.Text = Smirnov.conclusion + ". Valor de alfa: " + Smirnov.Alfa.ToString();
        }
        private void button8_Click(object sender, EventArgs e)
        {
           
            Smirnov.Result(0.5d);
            Resultado.Text = Smirnov.conclusion + ". Valor de alfa: " + Smirnov.Alfa.ToString();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            Smirnov.Result(0.2d);
            Resultado.Text = Smirnov.conclusion + ". Valor de alfa: " + Smirnov.Alfa.ToString();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            Smirnov.Result(0.1d);
            Resultado.Text = Smirnov.conclusion + ". Valor de alfa: " + Smirnov.Alfa.ToString();
        }

        private void butMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void butCerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void menuBarPanel_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void SmirnovMetodo_Load(object sender, EventArgs e)
        {
        }
    }
}