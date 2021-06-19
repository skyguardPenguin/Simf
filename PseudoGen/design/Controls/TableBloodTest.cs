using PseudoGen.calc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PseudoGen.design.Controls
{
    public partial class TableBloodTest : UserControl
    {
        private int zona = 1;
        [
            Category("Propiedades de la tabla"),
            Description("Punto en el que se toma la muestra")
        ]
        public int Zona 
        {
            get => zona;
            set 
            {
                zona = value;
                labelZona.Text = "Punto " + value;
            } 
        }
        
        public override Font Font 
        {
           get=>base.Font;

            set
            {
                base.Font = value;
                for(int i=0;i<this.Controls.Count;i++)
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
    
        public override Color ForeColor
        {
            get => base.ForeColor;

            set
            {
                base.ForeColor = value;
                for (int i = 0; i < this.Controls.Count; i++)
                {
                    Controls[i].ForeColor = value;
                    if (Controls[i].Controls.Count > 0)
                        for (int j = 0; j < Controls[i].Controls.Count; j++)
                        {
                            Controls[i].Controls[j].ForeColor = value;
                            if (Controls[i].Controls[j].Controls.Count > 0)
                                for (int k = 0; k < Controls[i].Controls[j].Controls.Count; k++)
                                    Controls[i].Controls[j].Controls[k].ForeColor = value;
                        }
                }
            }
        }

        private DataTableBloodTest dataSource;
        public DataTableBloodTest DataSource 
        {
            get => dataSource;
            set { dataSource = value; if(value!=null)RefreshData(); }        
        }
        public TableBloodTest()
        {
         
            InitializeComponent();
            Zona = 1;
          
        }

        private void RefreshData()
        {
            
            List<double> riData = dataSource.RiPhases[0];
            List<string> resData = dataSource.ResultPhases[0];
            labelRInicio1.Text = riData[0].ToString();
            labelRInicio2.Text = riData[1].ToString();
            labelRInicio3.Text = riData[2].ToString();
            labelRInicio4.Text = riData[3].ToString();
            labelRInicio5.Text = riData[4].ToString();

            labelResInicio1.Text = resData[0];
            labelResInicio2.Text = resData[1];
            labelResInicio3.Text = resData[2];
            labelResInicio4.Text = resData[3];
            labelResInicio5.Text = resData[4];

            riData = dataSource.RiPhases[1];
            resData = dataSource.ResultPhases[1];

            labelR2Semanas1.Text = riData[0].ToString();
            labelR2Semanas2.Text = riData[1].ToString();
            labelR2Semanas3.Text = riData[2].ToString();
            labelR2Semanas4.Text = riData[3].ToString();
            labelR2Semanas5.Text = riData[4].ToString();

            labelRes2Semanas1.Text = resData[0];
            labelRes2Semanas2.Text = resData[1];
            labelRes2Semanas3.Text = resData[2];
            labelRes2Semanas4.Text = resData[3];
            labelRes2Semanas5.Text = resData[4];

            riData = dataSource.RiPhases[2];
            resData = dataSource.ResultPhases[2];

            labelRMes1.Text = riData[0].ToString();
            labelRMes2.Text = riData[1].ToString();
            labelRMes3.Text = riData[2].ToString();
            labelRMes4.Text = riData[3].ToString();
            labelRMes5.Text = riData[4].ToString();

            labelResMes1.Text = resData[0];
            labelResMes2.Text = resData[1];
            labelResMes3.Text = resData[2];
            labelResMes4.Text = resData[3];
            labelResMes5.Text = resData[4];

            labelConclusion.Text = dataSource.Conclusion + ", el resultado más frecuente fue: " + dataSource.ResultadoMFrecuente;


        }

        private void labelRes2Semanas3_Click(object sender, EventArgs e)
        {

        }
    }
}
