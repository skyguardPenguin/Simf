using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PseudoGen.design.Controls
{
    public partial class TableWaterTest : UserControl
    {
        private string dia;
        private int semana;
        Label[,] Labels;
        
        [Category("Información de la tabla"),Description("Día en que se toman las muestras")]
        public string Dia
        {
            get => dia;
            set
            {

                dia = value;
                labelDia.Text = "Día " + value;

            }
        }
        [Category("Información de la tabla"), Description("Semana en que se toman las muestras")]
        public int Semana
        {
            get => semana;
            set
            {
                semana = value;
                labelSemana.Text = "Semana " + value.ToString() ;
            }
        }
        public TableWaterTest()
        {
            InitializeComponent();
            Dia = "Lunes";
            Semana = 1;

            Labels = new Label[8,20];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    Labels[i, j] = new Label();
                    Labels[i, j].Text = "...";
                    Labels[i, j].AutoSize = false;
                    Labels[i, j].Dock = DockStyle.Fill;
             
                    Labels[i, j].TextAlign = ContentAlignment.MiddleCenter;
                    Labels[i, j].ForeColor = SystemColors.ButtonHighlight;
                 
                    Labels[i, j].Visible = true;
                    tableLayoutPanel1.Controls.Add(Labels[i, j],i+1,j+2);
                   
                }
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {
                    }
    }
}
