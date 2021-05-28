using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel1 = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace PseudoGen.Export.Excel
{
    class PromExcelExport
    {
        Excel1.Application oXL;
        Excel1._Workbook oWB;
        Excel1._Worksheet oSheet;
        Excel1.Range oRng;
        Generador Gen;
        bool dataDisplayed = false;
        public PromExcelExport(Generador gen)
        {
            this.Gen = gen;
        }
        public void OpenWindow()
        {

            
            bool completed = false;
            //Start Excel and get Application object.
            oXL = new Excel1.Application();
            oXL.Visible = true;
            oXL.Width=600;
            oXL.Height = 500;
            oWB = (Excel1._Workbook)(oXL.Workbooks.Add(Missing.Value));
            oSheet = (Excel1._Worksheet)oWB.ActiveSheet;
            oSheet.Application.SheetChange += Application_SheetChange;
            while (!completed)
            {
                try
                {
                    //Add table headers going cell by cell.
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

                    completed = true;



                    //Format A1:D1 as bold, vertical alignment = center.
                    oSheet.get_Range("A1", "D1").Font.Bold = true;
                    oSheet.get_Range("G1","G4").Font.Bold=true;
                    oSheet.get_Range("A1", "D1").Borders.LineStyle = Excel1.XlDataBarBorderType.xlDataBarBorderSolid;
                    oSheet.get_Range("G1", "H4").Borders.LineStyle = Excel1.XlDataBarBorderType.xlDataBarBorderSolid;
                    oSheet.get_Range("A1", "D1").VerticalAlignment =Excel1.XlVAlign.xlVAlignCenter;

                    //Fill D2:D6 with a formula(=RAND()*100000) and apply format.
                    //oRng = oSheet.get_Range("D2", "D6");
                    // oRng.Formula = "=RAND()*100000";
                    // oRng.NumberFormat = "$0.00";
                    oSheet.Application.SheetChange += Application_SheetChange;
                    completed = true;
                    dataDisplayed = true;
                }
                catch
                {

                }
            }
        }

        private void Application_SheetChange(object Sh, Excel1.Range Target)
        {
            if (dataDisplayed)
            {
                oRng = oSheet.get_Range("B2", "B2");
                oRng.Formula = "=H1";
                oRng = oSheet.get_Range("C2", "C2");
                //oRng.NumberFormat = "0.0000";
                oRng.Formula= "=1*RESIDUO(H2*H1+H3,H4)";

                oRng.NumberFormat = "0.0000";

                oRng = oSheet.get_Range("D2", "D2");
                oRng.NumberFormat = "0.0000";
                oRng.Formula = "=C2/H4";
                dataDisplayed = false;
            }
        }

        private void Application_SheetTableUpdate(object Sh, Excel1.TableObject Target)
        {
            
        }

  
    }
}
