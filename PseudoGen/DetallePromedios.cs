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
    public partial class DetallePromedios : Form
    {
        Generador Gen;
        Promedios Prom;
        int X0, a, m, c;




        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();


        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);

        public DetallePromedios(Generador gen, Promedios prom, int x0, int a, int m, int c)
        {
            InitializeComponent();
            Visible = false;
            Gen = gen;
            Prom = prom;
            X0 = x0;
            this.a = a;
            this.m = m;
            this.c = c;
        }

        private void menuBarPanel_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }




        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Dispose();
        }


        private void DetallePromedios_Load(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 1) dataGridView1.Rows.Clear();


            for (int i = 0; i < Gen.Nums.Count()-1; i++)
                dataGridView1.Rows.Add(i, Gen.Rows[i, 0], Gen.Rows[i, 1],Math.Round(Gen.Rows[i, 2],7));

            if (dataGridView1.Rows.Count < 15)
                dataGridView1.Rows.Add(15 - dataGridView1.Rows.Count);

            dataGridView2.Rows.Add(Gen.Nums.Count()-1, Math.Round(Prom.Promedio,7), Math.Round(Prom.Z,7), Prom.Za);
        }
    }
}
