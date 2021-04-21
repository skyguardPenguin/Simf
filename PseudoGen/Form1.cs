using Bunifu.Framework.UI;
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
    public partial class Form1 : Form
    {
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();


        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);

        public Form1()
        {
            //ToolStripManager.Renderer =
          //new ToolStripProfessionalRenderer(new CustomProfessionalColors());
            
            InitializeComponent();
            menuStrip1.Renderer = new ToolStripProfessionalRenderer(new PSAGenColorTable());

           
           
        }
        
       

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
            
        }
         

        private void butMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void menuBarPanel_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void ButGenerar_Click(object sender, EventArgs e)
        {
            if(dataGridView1.Rows.Count>1)dataGridView1.Rows.Clear();
            Generador gen = new Generador(int.Parse(TextboxX0.Text), int.Parse(TextBoxA.Text), int.Parse(TextBoxC.Text),int.Parse(TextBoxM.Text));
            for (int i = 0; i < int.Parse(TextBoxM.Text); i++)
                dataGridView1.Rows.Add(i,gen.rows[i, 0], gen.rows[i, 1], gen.rows[i,2]);

            if (dataGridView1.Rows.Count < 12)
                dataGridView1.Rows.Add(12-dataGridView1.Rows.Count);
        }

        private void TextboxX0_OnValueChanged(object sender, EventArgs e)
        {
            
          
            if(int.TryParse(TextboxX0.Text, out int resutl))
            {
                OkImageX0.Visible = true;              
                ErrorImageX0.Visible = false;                
                labelErrorX0.Visible = false;             
            }
            else
            {
                OkImageX0.Visible = false;               
                ErrorImageX0.Visible = true;
                labelErrorX0.Visible = true;
            }


        }

        private void TextBoxA_OnValueChanged(object sender, EventArgs e)
        {
            if (int.TryParse(TextBoxA.Text, out int resutl))
            {
                OkImageA.Visible = true;
                ErrorImageA.Visible = false;
                labelErrorA.Visible = false;
            }
            else
            {
                OkImageA.Visible = false;
                ErrorImageA.Visible = true;
                labelErrorA.Visible = true;
            }
        }

        private void TextBoxC_OnValueChanged(object sender, EventArgs e)
        {
            if (int.TryParse(TextBoxC.Text, out int resutl))
            {
                OkImageC.Visible = true;
                ErrorImageC.Visible = false;
                labelErrorC.Visible = false;
            }
            else
            {
                OkImageC.Visible = false;
                ErrorImageC.Visible = true;
                labelErrorC.Visible = true;
            }
        }

        private void TextBoxM_OnValueChanged(object sender, EventArgs e)
        {
            if (int.TryParse(TextBoxM.Text, out int resutl))
            {
                OkImageM.Visible = true;
                ErrorImageM.Visible = false;
                labelErrorM.Visible = false;
            }
            else
            {
                OkImageM.Visible = false;
                ErrorImageM.Visible = true;
                labelErrorM.Visible = true;
            }
        }
    }
}
