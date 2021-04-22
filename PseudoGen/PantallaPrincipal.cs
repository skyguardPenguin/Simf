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
    public partial class PantallaPrincipal : Form
    {

        Generador Gen;
        Promedios Proms;
        int X0, a, c, m;

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();


        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);

        public PantallaPrincipal()
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
            //Se eliminan los datos generados en el cálculo anterior
            if(dataGridView1.Rows.Count>1) dataGridView1.Rows.Clear();

            try
            {
                int limite = 0;
                if (checkBoxLimitar.Checked)
                    limite = int.Parse(TextBoxLimitar.Text);


                X0 = int.Parse(TextboxX0.Text);
                a = int.Parse(TextBoxA.Text);
                c = int.Parse(TextBoxC.Text);
                m = int.Parse(TextBoxM.Text);
                Gen = new Generador(X0, a, c, m, limite);
                Proms = new Promedios(Gen);

                
                for (int i = 0; i < Gen.Nums.Length-1; i++)
                    dataGridView1.Rows.Add(i, Gen.Rows[i, 0],Gen.Rows[i, 1], Math.Round(Gen.Rows[i, 2],7));

                if (dataGridView1.Rows.Count < 12)
                    dataGridView1.Rows.Add(12 - dataGridView1.Rows.Count);


                FlatButtonPromCheck.Visible = true;
            

                if (Proms.H0)
                {
                    FlatButtonPromCheck.Text = "Los números están distribuidos uniformemente según la prueba de los promedios. Click para ver detalles.";
                    
                    FlatButtonPromCheck.Iconimage = new Bitmap(Image.FromFile(@"C:\Users\sinoa\source\repos\Simulacion\PseudoGen\PseudoGen\PseudoGen\images\png\ok_48px.png"));
             
                }
                else
                {
                    FlatButtonPromCheck.Text = "Los números no están distribuidos uniformemente según la prueba de los promedios. Click para ver detalles.";
                
                    FlatButtonPromCheck.Iconimage = new Bitmap(Image.FromFile(@"C:\Users\sinoa\source\repos\Simulacion\PseudoGen\PseudoGen\PseudoGen\images\png\cancel_48px.png"));
                
                }
            }
            catch
            {
                MessageBox.Show("Los datos introducidos están incompletos o incorrectos, asegurese de insertar números enteros y rellenar todos los campos requeridos. ");
            }

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

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {

        }

        private void FlatButtonPromCheck_Click(object sender, EventArgs e)
        {
            DetallePromedios detallePromedios = new DetallePromedios(Gen, Proms, X0, a, m, c);
            detallePromedios.Show();
        }

        private void checkBoxLimitar_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxLimitar.CheckState == CheckState.Checked)
            {
                TextBoxLimitar.Enabled = true;
                
                TextBoxLimitar.LineMouseHoverColor = Color.Blue;
            }
            else
            {
                TextBoxLimitar.Enabled = false;
                TextBoxLimitar.Text = "";
                TextBoxLimitar.LineMouseHoverColor = Color.Gray;
                okImageLimite.Visible = false;
                imageErrorLimite.Visible = false;
                labelErrorLimite.Visible = false;
            }
        }

        private void TextBoxLimitar_OnValueChanged(object sender, EventArgs e)
        {
            if (int.TryParse(TextBoxLimitar.Text, out int resutl)&&checkBoxLimitar.Enabled)
            {
                okImageLimite.Visible = true;
                imageErrorLimite.Visible = false;
                labelErrorLimite.Visible = false;
                

            }
            else if(checkBoxLimitar.Enabled)
            {
                okImageLimite.Visible = false;
                imageErrorLimite.Visible = true;
                labelErrorLimite.Visible = true;
            
            }
        }

        private void PantallaPrincipal_Load(object sender, EventArgs e)
        {

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
