using System.IO;
using System.Text;
using OfficeOpenXml;

namespace UAParser.ConsoleApp
{
  using System;
  using System.Linq;

    internal static class Program
    {
        private static void Main()
        {

            using (
                ExcelPackage xlPackage = new ExcelPackage(new FileInfo(@"C:\temp\uap-csharp\inputFiles\UserAgents.xlsx"))
                )
            {   
                //Read Stuff
                var myWorksheet = xlPackage.Workbook.Worksheets.First();
                var totalRows = myWorksheet.Dimension.End.Row;
                var totalColumns = myWorksheet.Dimension.End.Column;
                
                //Write Stuff
                ExcelWorksheet ws = xlPackage.Workbook.Worksheets.First();

                //Headers
                ws.Cells[1, 4].Value = "Browser";
                ws.Cells[1, 5].Value = "Browser Version";
                ws.Cells[1, 6].Value = "OS";

                

                //Get Excel Document
                for (int rowNum = 2; rowNum <= totalRows; rowNum++)
                {
                    var row =
                        myWorksheet.Cells[rowNum, 1, rowNum, totalColumns].Select(

                            c => c.Value == null ? string.Empty : c.Value.ToString()

                            );
                    ClientInfo result = ParseUAString(myWorksheet.Cells[rowNum, 3].Value.ToString());
                    string[] browserAndVersion = result.UA.ToString().Split(' ');
                    myWorksheet.Cells[rowNum, 4].Value = browserAndVersion[0];
                    myWorksheet.Cells[rowNum, 5].Value = browserAndVersion[1];
                    myWorksheet.Cells[rowNum, 6].Value = result.OS;
                    long percentage = (rowNum * 100 / totalRows);
                    Console.Clear();
                    Console.WriteLine("{0}%", percentage);
                }

                xlPackage.Save();
            }


        }


        private static ClientInfo ParseUAString(string uaString)
        {
            var uaParser = Parser.GetDefault();
            
            uaString = uaString.Trim();
            var c = uaParser.Parse(uaString);
            return c;
        }


}
}
