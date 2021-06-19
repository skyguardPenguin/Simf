using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel1 = Microsoft.Office.Interop.Excel;

using System.Reflection;

namespace PseudoGen.Export.Excel
{
    class PromExcelExport
    {

        Microsoft.Office.Interop.Excel.Application oXL;
        Microsoft.Office.Interop.Excel._Workbook oWB;
        Microsoft.Office.Interop.Excel._Worksheet oSheet;
        Microsoft.Office.Interop.Excel.Range oRng;
        Generador Gen;

        public PromExcelExport(Generador gen)
        {
            this.Gen = gen;
        }
        public void OpenWindow()
        {
            
            


          
                bool completed = false;
                oXL = new Excel1.Application();
                oXL.Visible = true;
                oXL.Width = 600;
                oXL.Height = 500;
                oWB = (Excel1._Workbook)(oXL.Workbooks.Add(Missing.Value));
                oSheet = (Excel1._Worksheet)oWB.ActiveSheet;
            
            
            
            

            while (!completed)
            {
                try
                {
                 
                     oSheet.Cells[1, 1]= "n";
                    oSheet.Cells[1, 2] = "Xn";
                    oSheet.Cells[1, 3] = "Xn+1";
                    oSheet.Cells[1, 4] = "Nums";

                    oSheet.Cells[1, 7]="X0";
                    oSheet.Cells[2, 7] = "a";
                    oSheet.Cells[3, 7] = "c";
                    oSheet.Cells[4, 7] = "m";

                    oSheet.Cells[1, 8] = Gen.X0;
                    oSheet.Cells[2, 8] = Gen.a;
                    oSheet.Cells[3, 8] = Gen.c;
                    oSheet.Cells[4, 8] = Gen.m;
                    oSheet.Cells[2, 1] = "0";


                    int[,] n = new int[Gen.Nums.Length-1, 1];

                    int[,] xn = new int[Gen.Nums.Length-1, 1];
                    int[,] xnSig = new int[Gen.Nums.Length-1, 1];
                    double[,] nums = new double[Gen.Nums.Length-1,1];
                    for (int i = 0; i < Gen.Nums.Length-1; i++)
                    {
                        n[i, 0] = i;
                        xn[i, 0] = Gen.Xn[i];
                        xnSig[i, 0] = Gen.Xn[i + 1];
                        nums[i, 0] = Gen.Nums[i];
                        
                    }

                    oRng = oSheet.get_Range("D2",Missing.Value);
                    oRng = oRng.get_Resize(Gen.Nums.Length-1, 1);
                    oRng.set_Value(Missing.Value, nums);

                    oRng = oSheet.get_Range("A2", Missing.Value);
                    oRng = oRng.get_Resize(Gen.Nums.Length-1, 1);
                    oRng.set_Value(Missing.Value, n);

                    oRng = oSheet.get_Range("B2", Missing.Value);
                    oRng = oRng.get_Resize(Gen.Nums.Length-1, 1);
                    oRng.set_Value(Missing.Value, xn);

                    oRng = oSheet.get_Range("C2", Missing.Value);
                    oRng = oRng.get_Resize(Gen.Nums.Length-1, 1);
                    oRng.set_Value(Missing.Value, xnSig);
                 
                    oSheet.get_Range("A1", "D1").Font.Bold = true;
                    oSheet.get_Range("G1","G4").Font.Bold=true;
                    oSheet.get_Range("A1", "D1").Borders.LineStyle = Excel1.XlDataBarBorderType.xlDataBarBorderSolid;
                    oSheet.get_Range("G1", "H4").Borders.LineStyle = Excel1.XlDataBarBorderType.xlDataBarBorderSolid;
                    oSheet.get_Range("A1", "D1").VerticalAlignment =Excel1.XlVAlign.xlVAlignCenter;

                    completed = true;
                }
                catch
                {

                }
            }
        }

             
  
    }
}
