using System.Security.Cryptography;
using System.Text;
using Crypto.Properties;

namespace Crypto
{
    class UserSettings
    {
        string secQ1;
        string secQ2;
        string secA1;
        string secA2;
        string passClose;
        string passOpen;

        public string SecQ1
        {
            get { return secQ1; }
        }

        public string SecQ2
        {
            get { return secQ2; }
        }

        public UserSettings()
        {
            secQ1 = Settings.Default.SecQ1;
            secQ2 = Settings.Default.SecQ2;
            secA1 = Settings.Default.SecA1;
            secA2 = Settings.Default.SecA2;
            passClose = Settings.Default.PassClose;
            passOpen = Settings.Default.PassOpen;
        }


        //Get md5 of string 
        private string convertLocalPassword(string input)
        {
            MD5 md5Hash = MD5.Create();
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }

        public bool checkPass(string input, bool safe)
        {
            string pass = "";
            if (safe)
                pass = passClose;
            else
                pass = passOpen;

            if (pass == convertLocalPassword(input))
                return true;
            else
                return false;
        }

        public void updatePassVulnerable(string pass)
        {
            Settings.Default.PassOpen = convertLocalPassword(pass);
            Settings.Default.Save();
            CustomMsgBox.Show("Vulnerable Password Updated", Msg.Success);
        }

        public void updatePassConfidential(string pass)
        {
            Settings.Default.PassClose = convertLocalPassword(pass);
            Settings.Default.Save();
            CustomMsgBox.Show("Confidential Password Updated", Msg.Success);
        }

        public void updateSecAnswers(string secnA1, string secnA2)
        {
            string nsecA1 = convertLocalPassword(secnA1);
            string nsecA2 = convertLocalPassword(secnA2);

            if(secA1 != "" && nsecA1 != secA1)
                Settings.Default.SecA1 = nsecA1;
            if (secA2 != "" && nsecA2 != secA2)
                Settings.Default.SecA2 = nsecA2;
            Settings.Default.Save();
        }


        public void updateSecQuestions(string nsecQ1, string nsecQ2)
        {
            if (nsecQ1 != "" && nsecQ1 != secQ1)
                Settings.Default.SecQ1 = nsecQ1;
            if (nsecQ2 != "" && nsecQ1 != secQ2)
                Settings.Default.SecQ2 = nsecQ2;
            Settings.Default.Save();
        }

        public bool validateAnswers(string secnA1, string secnA2)
        {
            string nsecA1 = convertLocalPassword(secnA1);
            string nsecA2 = convertLocalPassword(secnA2);

            if (nsecA1 == secA1 && nsecA2 == secA2)
                return true;
            else
                return false;
        }
    
    }
}
