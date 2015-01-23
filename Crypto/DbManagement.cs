using System;
using System.Data;
using System.Data.SqlServerCe;
using System.IO;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;

namespace Crypto
{
    class DbManagement : Db
    {

        //Following method is an example of changing Password of the SqlCE database
        //It has not been called in the application and is purely included for additional development if needed.
        private void changeDatabasePassword(string newPass)
        {
            SqlCeEngine engine = new SqlCeEngine(conSrc);
            engine.Compact(null);
            engine.Compact("Data Source=" + Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\TheAurors\\Crypto\\cryptodb.sdf;password= " + newPass + ";encrypt database=true");          
            //Here the connection source have to be changed with new details.
        }


        public void backupDatabase(string location)
        {
            string data = null;
            int i = 0;
            int j = 0;

            DataTable dtbl = new DataTable();
            using (SqlCeConnection con = new SqlCeConnection(conSrc))
            {

                con.Open();
                string selectString = "select * from " + Get(DbTable.pwords) + " order by " + Get(PCol.p_name);
                using(SqlCeCommand getTable = new SqlCeCommand(selectString, con)){
                    using (SqlCeDataAdapter adapT = new SqlCeDataAdapter())
                    {
                        adapT.SelectCommand = getTable;
                        adapT.Fill(dtbl);
                    }
                }               
            }

            try
            {
                Excel.Application xlApp;
                Excel.Workbook xlWorkBook;
                xlApp = new Excel.Application();
                //xlApp.Visible = false;
                object misValue = System.Reflection.Missing.Value;
                xlWorkBook = xlApp.Workbooks.Add(misValue);


                Excel.Worksheet xlWorkSheet;
                xlWorkSheet = xlWorkBook.Sheets.Add(misValue, misValue, 1, misValue) as Excel.Worksheet;
                xlWorkSheet.Name = "Passwords";

                while (xlApp.ActiveWorkbook.Worksheets.Count != 1)
                {
                    xlWorkSheet = (Excel.Worksheet)xlApp.ActiveWorkbook.Worksheets[2];
                    xlWorkSheet.Delete();
                }
                xlWorkSheet = (Excel.Worksheet)xlApp.ActiveWorkbook.Worksheets[1];

                for (j = 1; j < dtbl.Columns.Count - 1; j++)
                {
                    data = dtbl.Columns[j].ColumnName;
                    xlWorkSheet.Cells[1, j] = data.Substring(2).ToUpperInvariant();
                }

                for (i = 0; i < dtbl.Rows.Count; i++)
                {
                    for (j = 1; j < dtbl.Columns.Count - 1; j++)
                    {
                        data = dtbl.Rows[i].ItemArray[j].ToString();
                        xlWorkSheet.Cells[i + 2, j] = data;
                    }
                }

                dtbl.Dispose();
                try
                { Marshal.ReleaseComObject(xlWorkSheet); }
                catch (Exception ex) { CustomMsgBox.Show(ex.Message, Msg.Exception); }

                string fileName = Path.Combine(location, "Crypto_Password_Backup.xlsx");

                xlWorkBook.SaveAs(fileName, Excel.XlFileFormat.xlOpenXMLWorkbook, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.UserControl = true;
                xlApp.Quit();

                try
                {
                    Marshal.ReleaseComObject(xlWorkBook);
                    Marshal.ReleaseComObject(xlApp);
                }
                catch (Exception ex) { CustomMsgBox.Show(ex.Message, Msg.Exception); }

                CustomMsgBox.Show("Passwords copied to the selected location as an excel file. Please secure the file.", Msg.Information);
            }
            catch (Exception ex)
            {
                CustomMsgBox.Show(ex.Message, Msg.Exception);
            }

        }

    }
}
