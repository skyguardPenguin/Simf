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
    public partial class MainWindow : Form
    {

        Generador Gen;
        Promedios Proms;
        int X0, a, c, m;

        public MainWindow()
        {

            InitializeComponent();
            menuStrip1.Renderer = new ToolStripProfessionalRenderer(new PSAGenColorTable());
            tabControl.CloseButtonForeColor = SystemColors.Control;
            tabControl.CloseButtonBackColor = SystemColors.Control;
            textBDecimales.Text = "4";


        }
    #region MainBar
        //Control area of MainBar

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();


        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);


       
        
       
        //Close button method
        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
            
        }
         
        //Minimize
        private void butMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        //Método que permite mover la ventana al momento de arrastrar el MainBar
        private void menuBarPanel_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }
        #endregion
       


    #region ValidatingData
       //Muestra o esconde los mensajes de error cada vez que el usuario ingresa datos incorrectamente
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
        //Muestra o esconde los mensajes de error cada vez que el usuario ingresa datos incorrectamente
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
        //Muestra o esconde los mensajes de error cada vez que el usuario ingresa datos incorrectamente
        private void TextBoxLimitar_OnValueChanged(object sender, EventArgs e)
        {
            if (int.TryParse(TextBoxLimitar.Text, out int resutl) && checkBoxLimitar.Enabled)
            {
                okImageLimite.Visible = true;
                imageErrorLimite.Visible = false;
                labelErrorLimite.Visible = false;


            }
            else if (checkBoxLimitar.Enabled)
            {
                okImageLimite.Visible = false;
                imageErrorLimite.Visible = true;
                labelErrorLimite.Visible = true;

            }
        }
        //Muestra o esconde los mensajes de error cada vez que el usuario ingresa datos incorrectamente
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
        //Muestra o esconde los mensajes de error cada vez que el usuario ingresa datos incorrectamente
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

        //Activa o desactiva el textBox que captura la cantidad de números
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

            #endregion
       

        
    #region DecimalsControl
        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {

            textBDecimales.Text = (int.Parse(textBDecimales.Text) - 1).ToString();
            if (!ValidateDecimals())
                textBDecimales.Text = (int.Parse(textBDecimales.Text) + 1).ToString();
            else SetDecimals();

        }
        private void bunifuImageButton1_Click_1(object sender, EventArgs e)
        {

            textBDecimales.Text = (int.Parse(textBDecimales.Text) + 1).ToString();
            if (!ValidateDecimals())
                textBDecimales.Text = (int.Parse(textBDecimales.Text) - 1).ToString();
            else SetDecimals();
        }


        private void textBDecimales_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!ValidateDecimals())
                    textBDecimales.Text = "4";
                SetDecimals();
            }


        }

        private void textBDecimales_Leave(object sender, EventArgs e)
        {
            if (!ValidateDecimals())
                textBDecimales.Text = "4";
            SetDecimals();
        }

        private void SetDecimals()
        {
            if (Gen != null)
            {
                dataGridView1.Rows.Clear();

                for (int i = 0; i < Gen.Nums.Length-1; i++)
                {
                    dataGridView1.Rows.Add(i, Gen.Rows[i, 0], Gen.Rows[i, 1], Math.Round(Gen.Rows[i, 2], int.Parse(textBDecimales.Text)));
                }

            }
        }
        private bool ValidateDecimals()
        {
           
            try
            {
                if (int.Parse(textBDecimales.Text) <= 10&& int.Parse(textBDecimales.Text) >= 1)
                    return true;          
                    
                else if (int.Parse(textBDecimales.Text) >= 10)
                        MessageBox.Show("Solo se permiten máximo 10 decimales");
                    else
                        MessageBox.Show("Solo se permiten números enteros mayores a 0");

            }
            catch 
            {
                MessageBox.Show("Debe introducir un número entero");
            }
            return false;
        }

       
        #endregion

        //Genera y muestra los números pseudoaleatorios a partir de los datos capturados
        private void ButGenerar_Click(object sender, EventArgs e)
        {
            //Se eliminan los datos generados en el cálculo anterior
            if (dataGridView1.Rows.Count > 1) dataGridView1.Rows.Clear();

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


                for (int i = 0; i < Gen.Nums.Length - 1; i++)
                    dataGridView1.Rows.Add(i, Gen.Rows[i, 0], Gen.Rows[i, 1], Math.Round(Gen.Rows[i, 2], 7));

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

        private void MainWindow_Load(object sender, EventArgs e)
        {

        }

        //Abre la ventana de detalles del método de los promedios
        private void FlatButtonPromCheck_Click(object sender, EventArgs e)
        {
            DetallePromedios detallePromedios = new DetallePromedios(Gen, Proms, X0, a, m, c);
            detallePromedios.Show();
        }
        //Abre la ventana de detalles del método de los promedios
        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            //Aqí mandas a abrir tu form de detalle pruebas 
        }


        //Abre la exportación de datos a excel
        private void jhjToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Export.Excel.PromExcelExport promExcleExp = new Export.Excel.PromExcelExport(Gen);
            promExcleExp.OpenWindow();
        }

   

       

    }
}
