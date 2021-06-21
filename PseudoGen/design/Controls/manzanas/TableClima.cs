using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PseudoGen.design.Controls.manzanas
{
    public partial class TableClima : UserControl
    {
        private int firstYear;

        public int FirstYear
        {
            get => firstYear;
            set
            {
                firstYear = value;
            }
        }
        public TableClima()
        {
            InitializeComponent();
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.ColumnCount = 6;
            tableLayoutPanel1.RowCount = 26;
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;


            tableLayoutPanel1.RowStyles.Clear();
            tableLayoutPanel1.ColumnStyles.Clear();
            for (int i = 0; i < 6; i++)
            {
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.66f));
                for (int j = 0; j < 26; j++)
                {
                    tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 4));
                }
            }

            Panel panelRi = new Panel();
            panelRi.BackColor = Color.FromArgb(0, 40, 80);
            panelRi.Margin = new Padding(0, 0, 0, 0);
            panelRi.Dock = DockStyle.Fill;
            Label labelRi = new Label();
            labelRi.Text = "Ri";
            labelRi.ForeColor = SystemColors.ButtonHighlight;
            labelRi.BackColor = Color.FromArgb(0, 40, 80);

            labelRi.Dock = DockStyle.Fill;
            labelRi.TextAlign = ContentAlignment.MiddleCenter;
            labelRi.AutoSize = false;
            panelRi.Controls.Add(labelRi);
            labelRi.Margin = new Padding(0, 0, 0, 0);
            tableLayoutPanel1.Controls.Add(panelRi, 1, 0);
            tableLayoutPanel1.Controls.Add(labelRi, 1, 0);
            Controls.Add(panelRi);



            Panel panelIteracion = new Panel();
            panelIteracion.BackColor = Color.FromArgb(0, 40, 80);
            panelIteracion.Margin = new Padding(0, 0, 0, 0);
            panelIteracion.Dock = DockStyle.Fill;
            Label labelIteracion = new Label();
            labelIteracion.Text = "#";
            labelIteracion.ForeColor = SystemColors.ButtonHighlight;
            labelIteracion.BackColor = Color.FromArgb(0, 40, 80);

            labelIteracion.Dock = DockStyle.Fill;
            labelIteracion.TextAlign = ContentAlignment.MiddleCenter;
            labelIteracion.AutoSize = false;
            labelIteracion.Margin = new Padding(0, 0, 0, 0);
            panelIteracion.Controls.Add(labelIteracion);
            tableLayoutPanel1.Controls.Add(labelIteracion, 0, 0);
            tableLayoutPanel1.Controls.Add(panelIteracion, 0, 0);
            Controls.Add(panelIteracion);


            Panel panelResult = new Panel();
            panelResult.BackColor = Color.FromArgb(0, 40, 80);
            panelResult.Margin = new Padding(0, 0, 0, 0);
            panelResult.Dock = DockStyle.Fill;
            Label labelResult = new Label();
            labelResult.Text = "Result";
            labelResult.ForeColor = SystemColors.ButtonHighlight;
            labelResult.BackColor = Color.FromArgb(0, 40, 80);
            labelResult.Margin = new Padding(0, 0, 0, 0);

            labelResult.Dock = DockStyle.Fill;
            labelResult.TextAlign = ContentAlignment.MiddleCenter;
            labelResult.AutoSize = false;

            panelResult.Controls.Add(labelResult);
            tableLayoutPanel1.Controls.Add(labelResult, 2, 0);
            tableLayoutPanel1.Controls.Add(panelResult, 2, 0);
            Controls.Add(panelResult);




            Panel panelRi2 = new Panel();
            panelRi2.BackColor = Color.FromArgb(40, 0, 80);
            panelRi2.Margin = new Padding(0, 0, 0, 0);
            panelRi2.Dock = DockStyle.Fill;
            Label labelRi2 = new Label();
            labelRi2.Text = "Ri";
            labelRi2.ForeColor = SystemColors.ButtonHighlight;
            labelRi2.BackColor = Color.FromArgb(40, 0, 80);

            labelRi2.Dock = DockStyle.Fill;
            labelRi2.TextAlign = ContentAlignment.MiddleCenter;
            labelRi2.AutoSize = false;
            panelRi2.Controls.Add(labelRi2);
            labelRi2.Margin = new Padding(0, 0, 0, 0);
            tableLayoutPanel1.Controls.Add(panelRi2, 4, 0);
            tableLayoutPanel1.Controls.Add(labelRi2, 4, 0);
            Controls.Add(panelRi2);



            Panel panelIteracion2 = new Panel();
            panelIteracion2.BackColor = Color.FromArgb(40, 0, 80);
            panelIteracion2.Margin = new Padding(0, 0, 0, 0);
            panelIteracion2.Dock = DockStyle.Fill;
            Label labelIteracion2 = new Label();
            labelIteracion2.Text = "#";
            labelIteracion2.ForeColor = SystemColors.ButtonHighlight;
            labelIteracion2.BackColor = Color.FromArgb(40, 0, 80);

            labelIteracion2.Dock = DockStyle.Fill;
            labelIteracion2.TextAlign = ContentAlignment.MiddleCenter;
            labelIteracion2.AutoSize = false;
            labelIteracion2.Margin = new Padding(0, 0, 0, 0);
            panelIteracion2.Controls.Add(labelIteracion2);
            tableLayoutPanel1.Controls.Add(labelIteracion2, 3, 0);
            tableLayoutPanel1.Controls.Add(panelIteracion2, 3, 0);
            Controls.Add(panelIteracion2);


            Panel panelResult2 = new Panel();
            panelResult2.BackColor = Color.FromArgb(40, 0, 80);
            panelResult2.Margin = new Padding(0, 0, 0, 0);
            panelResult2.Dock = DockStyle.Fill;
            Label labelResult2 = new Label();
            labelResult2.Text = "Result";
            labelResult2.ForeColor = SystemColors.ButtonHighlight;
            labelResult2.BackColor = Color.FromArgb(40, 0, 80);
            labelResult2.Margin = new Padding(0, 0, 0, 0);
            labelResult2.Dock = DockStyle.Fill;
            labelResult2.TextAlign = ContentAlignment.MiddleCenter;
            labelResult2.AutoSize = false;

            panelResult2.Controls.Add(labelResult2);
            tableLayoutPanel1.Controls.Add(labelResult2, 5, 0);
            tableLayoutPanel1.Controls.Add(panelResult2, 5, 0);
            Controls.Add(panelResult2);

            Label[] labelsItC1= new Label[25];
            Panel[] panelsItC1 = new Panel[25];

            Label[] labelsRiC1= new Label[25];
            Panel[] panelsRiC1 = new Panel[25];

            Label[] labelsResC1 = new Label[25];
            Panel[] panelResC1 = new Panel[25];



            Label[] labelsItC2 = new Label[25];
            Panel[] panelsItC2 = new Panel[25];

            Label[] labelsRiC2= new Label[25];
            Panel[] panelsRiC2 = new Panel[25];

            Label[] labelsResC2 = new Label[25];
            Panel[] panelResC2 = new Panel[25];

            for (int i=0;i<25;i++)
            {
             
                panelsRiC1[i] = new Panel();
                panelsRiC1[i].BackColor = Color.FromArgb(0, 40, 80);
                panelsRiC1[i].Margin = new Padding(0, 0, 0, 0);
                panelsRiC1[i].Dock = DockStyle.Fill;
                labelsRiC1[i] = new Label();
                labelsRiC1[i].Text = "";
                labelsRiC1[i].Margin = new Padding(0, 0, 0, 0);
                labelsRiC1[i].TextAlign = ContentAlignment.MiddleCenter;
                labelsRiC1[i].Dock = DockStyle.Fill;
                labelsRiC1[i].AutoSize = true;
                labelsRiC1[i].ForeColor = SystemColors.ButtonHighlight;
                labelsRiC1[i].BackColor = Color.FromArgb(0, 40, 80);

                panelsRiC1[i].Controls.Add(labelsRiC1[i]);
                tableLayoutPanel1.Controls.Add(labelsRiC1[i],1,1);
                tableLayoutPanel1.Controls.Add(panelsRiC1[i],1,i+1);



                panelsRiC2[i] = new Panel();
                panelsRiC2[i].BackColor = Color.FromArgb(0, 40, 80);
                panelsRiC2[i].Margin = new Padding(0, 0, 0, 0);
                panelsRiC2[i].Dock = DockStyle.Fill;
                labelsRiC2[i] = new Label();
                labelsRiC2[i].Text = "";
                labelsRiC2[i].Margin = new Padding(0, 0, 0, 0);
                labelsRiC2[i].TextAlign = ContentAlignment.MiddleCenter;
                labelsRiC2[i].Dock = DockStyle.Fill;
                labelsRiC2[i].AutoSize = true;
                labelsRiC2[i].ForeColor = SystemColors.ButtonHighlight;
                labelsRiC2[i].BackColor = Color.FromArgb(0, 40, 80);

                panelsRiC2[i].Controls.Add(labelsRiC2[i]);
                tableLayoutPanel1.Controls.Add(labelsRiC2[i], 4, i+1);
                tableLayoutPanel1.Controls.Add(panelsRiC2[i], 4, i + 1);




                panelsItC1[i] = new Panel();
                panelsItC1[i].BackColor = Color.FromArgb(0, 40, 80);
                panelsItC1[i].Margin = new Padding(0, 0, 0, 0);
                panelsItC1[i].Dock = DockStyle.Fill;
                labelsItC1[i] = new Label();
                labelsItC1[i].Text = "Año " + (i + 1).ToString();
                labelsItC1[i].Margin = new Padding(0, 0, 0, 0);
                labelsItC1[i].TextAlign = ContentAlignment.MiddleCenter;
                labelsItC1[i].Dock = DockStyle.Fill;
                labelsItC1[i].AutoSize = true;
                labelsItC1[i].ForeColor = SystemColors.ButtonHighlight;
                labelsItC1[i].BackColor = Color.FromArgb(0, 40, 80);

                panelsItC1[i].Controls.Add(labelsItC1[i]);
                tableLayoutPanel1.Controls.Add(labelsItC1[i], 1+1, 0);
                tableLayoutPanel1.Controls.Add(panelsItC1[i],i+1,0);



                panelsItC2[i] = new Panel();
                panelsItC2[i].BackColor = Color.FromArgb(0, 40, 80);
                panelsItC2[i].Margin = new Padding(0, 0, 0, 0);
                panelsItC2[i].Dock = DockStyle.Fill;
                labelsItC2[i] = new Label();
                labelsItC2[i].Text = "";
                labelsItC2[i].Margin = new Padding(0, 0, 0, 0);
                labelsItC2[i].TextAlign = ContentAlignment.MiddleCenter;
                labelsItC2[i].Dock = DockStyle.Fill;
                labelsItC2[i].AutoSize = true;
                labelsItC2[i].ForeColor = SystemColors.ButtonHighlight;
                labelsItC2[i].BackColor = Color.FromArgb(0, 40, 80);

                panelsItC2[i].Controls.Add(labelsItC2[i]);
                tableLayoutPanel1.Controls.Add(labelsItC2[i], 3, i + 1);
                tableLayoutPanel1.Controls.Add(panelsItC2[i], 3, i + 1);


            }
            




        }
    }
}
