using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlServerCe;

namespace Crypto
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {          
            bool result;
            var mutex = new System.Threading.Mutex(true, "CryptoPasswordManager", out result);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (!result)
            {
                CustomMsgBox.Show("Crypto Password Manager", "Application is already open", Msg.Information);
                return;
            }
            try
            {
                using (SqlCeConnection con = new SqlCeConnection(Db.conSrc))
                {
                    con.Open();
                }
            }
            catch (Exception ex)
            {
                CustomMsgBox.Show("Invalid Database Connection. Application will not load" + ex.Message, Msg.Error);
                return;
            }
            Application.Run(new Login());
            GC.KeepAlive(mutex);
        }
    }
}
