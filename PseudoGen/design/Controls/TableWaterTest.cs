using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PseudoGen.calc.Tests.WaterTest;
using PseudoGen.calc;

namespace PseudoGen.design.Controls
{
    public partial class TableWaterTest : UserControl
    {
        private int dia = 1;
        private int semana;
        private ContainerDataTableWaterTests dataSource;
        private string[] daysOfWeek = new string[7];

        public ContainerDataTableWaterTests DataSource
        {
            get => dataSource;
            set
            {
                dataSource = value;
                if (value != null)
                {
               
                    RefreshCombos();
                    Clear();
                    labelConclusion.Text ="La sustancia encontrada con mayor frecuencia durante las 2 semanas es: "+ value.ResultadoMFrecuente;
                }
             
            }
        }
        Label[,] Labels;

        [Category("Información de la tabla"), Description("Día en que se toman las muestras")]
        public int Dia
        {
            get => dia;
            set
            {

                dia = value;


            }
        }
        [Category("Información de la tabla"), Description("Semana en que se toman las muestras")]
        public int Semana
        {
            get => semana;
            set
            {
                semana = value;

            }
        }

        public override Font Font
        {
            get => base.Font;

            set
            {
                base.Font = value;
                for (int i = 0; i < this.Controls.Count; i++)
                {
                    Controls[i].Font = value;
                    if (Controls[i].Controls.Count > 0)
                        for (int j = 0; j < Controls[i].Controls.Count; j++)
                        {
                            Controls[i].Controls[j].Font = value;
                            if (Controls[i].Controls[j].Controls.Count > 0)
                                for (int k = 0; k < Controls[i].Controls[j].Controls.Count; k++)
                                    Controls[i].Controls[j].Controls[k].Font = value;
                        }
                }
            }
        }


        public TableWaterTest()
        {
            InitializeComponent();



            Labels = new Label[8, 20];
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
                    tableLayoutPanel1.Controls.Add(Labels[i, j], i + 1, j + 2);

                }
            }



        }
        private void RefreshCombos()
        {
            qlibComboBox1.Items.Clear();
            qlibComboBox2.Items.Clear();
            daysOfWeek[0] = "1-Lunes";
            daysOfWeek[1] = "2-Martes";
            daysOfWeek[2] = "3-Miércoles";
            daysOfWeek[3] = "4-Jueves";
            daysOfWeek[4] = "5-Viernes";
            daysOfWeek[5] = "6-Sabado";
            daysOfWeek[6] = "7-Domingo";

            qlibComboBox1.Text = "Semana" + semana.ToString();
            qlibComboBox2.Text = daysOfWeek[dia - 1];
            int numWeeks = DataSource.NumTables > 7 ? 2 : 1;

            qlibComboBox1.Items.Add("Semana1");


            if (numWeeks == 2)
            {
                qlibComboBox1.Items.Add("Semana2");
            }
            for (int i = 0; i < dataSource.NumTables; i++)
            {
                qlibComboBox2.Items.Add(daysOfWeek[i]);
                if (i == 6) break;
            }

            
        }

        private void RefreshDataTable()
        {




            int k=0;
            string[,] resData;
            if (semana == 1)
            {
                resData = dataSource.DataTables[dia - 1].ToArrayString();
            }
            else
            {
            
                resData= dataSource.DataTables[dia +6].ToArrayString();
            }
         
            for (int i=0;i<8;i++)
            {
             
               
                for (int j = 0; j < 20; j++)
                {
                    Labels[i, j].Text = resData[i, j];
                }
            }
            
        }

        public void Clear()
        {
            for(int i=0;i<8;i++)
            {
                for(int j=0;j<20;j++)
                    Labels[i,j].Text = "";
            }
        }
        private void qlibComboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            foreach (char element in qlibComboBox1.Text.ToCharArray())
                if (int.TryParse(element.ToString(), out int result))
                    semana = int.Parse(element.ToString());
            if(qlibComboBox2.Text!="")
                RefreshDataTable();
        }

        private void qlibComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (char element in qlibComboBox2.Text.ToCharArray())
                if (int.TryParse(element.ToString(), out int result))
                    dia = int.Parse(element.ToString());
            if(qlibComboBox1.Text!="")
                RefreshDataTable();
        }
    }
}
