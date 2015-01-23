using System.Data.SqlServerCe;
using System;

namespace Crypto
{
    public class Password : Db
    {
        int passId;
        string passName;
        string passWebSite;
        string passUserName;
        string passEmail;
        string passWord;
        bool safe;

        //getters and setters
        public int PassId
        {
            get { return passId; }
            set { passId = value; }
        }

        public string PassName
        {
            get {return passName;}
            set { passName = value; }
        }

        public string PassWebSite
        {
            get{ return passWebSite; }
            set { passWebSite = value;}
        }

        public string PassUserName
        {
            get { return passUserName; }
            set { passUserName = value; }
        }

        public string Passwrd
        {
            get { return passWord; }
            set { passWord = value; }
        }

        public string PassEmail
        {
            get { return passEmail; }
            set { passEmail = value; }
        }

        public bool Safe
        {
            get { return safe; }
            set { safe = value; }
        }


        public Password(int id)
        {
            //get Values
            passId = id;
            refresh();
        }

        public Password(int id, string pName, string pWebSite, string pUName, string pEmail, string pWrd, bool makeSafe)
        {
            //with values
            passId = id;
            passName = pName;
            passWebSite = pWebSite;
            passUserName = pUName;
            passEmail = pEmail;
            passWord = pWrd;
            safe = makeSafe;
        }
     
        public Password(string pName, string pWebSite, string pUName, string pEmail, string pWrd, bool makeSafe)
        {
            passName = pName;
            passWebSite = pWebSite;
            passUserName = pUName;
            passEmail = pEmail;
            passWord = pWrd;
            safe = makeSafe;

            passId = addPassword();
            if (passId != 0)
                CustomMsgBox.Show("Password Successfully Added", Msg.Success);
            else
                CustomMsgBox.Show("Password Adding Fail", Msg.Error);
        }

        private int addPassword()
        {
            int id = 0;
            string query = @"insert into " + Get(DbTable.pwords) + " (" + Get(PCol.p_name) + "," + Get(PCol.p_site) + ","
                + Get(PCol.p_username) + "," + Get(PCol.p_email) + "," + Get(PCol.p_value) + "," + Get(PCol.p_safe) +
                    ") values (@name, @site, @uname, @email, @pass, @safe)";

            using (SqlCeConnection con = new SqlCeConnection(conSrc))
            {
                using (SqlCeCommand cmd = new SqlCeCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("name", passName);
                    cmd.Parameters.AddWithValue("site", passWebSite);
                    cmd.Parameters.AddWithValue("uname", passUserName);
                    cmd.Parameters.AddWithValue("email", passEmail);
                    cmd.Parameters.AddWithValue("pass", passWord);
                    cmd.Parameters.AddWithValue("safe", GetBool(safe));
                    con.Open();
                    int success = cmd.ExecuteNonQuery();
                    if (success == 1)
                    {
                        cmd.CommandText = "SELECT @@IDENTITY";
                        id = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
            return id;
        }

        public bool deletePassword()
        {
            int success = 0;
            string query = "delete from " + Get(DbTable.grouped) + " where " + Get(GPCol.p_id) + " = @deleteid ; ";
            query += "delete from " + Get(DbTable.pwords) + " where " + Get(PCol.p_id) + " = @deleteid";
            
            using (SqlCeConnection con = new SqlCeConnection(conSrc))
            {
                using (SqlCeCommand cmd = new SqlCeCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("deleteid", passId);
                    con.Open();
                    success = cmd.ExecuteNonQuery();
                }
            }
            return success > 0;
        }

        public void refresh()
        {
            string query = @"select * from " + Get(DbTable.pwords) + " where " + Get(PCol.p_id) + " = " + passId;

            using (SqlCeConnection con = new SqlCeConnection(conSrc))
            {
                using (SqlCeCommand cmd = new SqlCeCommand(query, con))
                {
                    con.Open();
                    using (SqlCeDataReader extPass = cmd.ExecuteReader())
                    {
                        if (extPass.Read())
                        {
                            passName = extPass[Get(PCol.p_name)].ToString();
                            passWebSite = extPass[Get(PCol.p_site)].ToString();
                            passUserName = extPass[Get(PCol.p_username)].ToString();
                            passEmail = extPass[Get(PCol.p_email)].ToString();
                            passWord = extPass[Get(PCol.p_value)].ToString();
                            safe = GetBool(extPass[Get(PCol.p_safe)].ToString());
                        }
                    }
                }
            }
        }

        public int editPassword(Password compVal)
        {
            int success = 0;
            if (passName == compVal.PassName &&
            passWebSite == compVal.PassWebSite &&
            passUserName == compVal.PassUserName &&
            passEmail == compVal.PassEmail &&
            passWord == compVal.Passwrd &&
            safe == compVal.Safe)
            {
                success = 3;
            }
            else
            {

                string query = @"update " + Get(DbTable.pwords) + " set " + Get(PCol.p_name) + " = @name, " + Get(PCol.p_site) + " = @site , "
                + Get(PCol.p_username) + " = @uname , " + Get(PCol.p_email) + " = @email , " + Get(PCol.p_value)
                + " = @pass, " + Get(PCol.p_safe) + " = @safe where " + Get(PCol.p_id) + " = @updateid";

                using (SqlCeConnection con = new SqlCeConnection(conSrc))
                {
                    using (SqlCeCommand cmd = new SqlCeCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("name", compVal.PassName);
                        cmd.Parameters.AddWithValue("site", compVal.PassWebSite);
                        cmd.Parameters.AddWithValue("uname", compVal.PassUserName);
                        cmd.Parameters.AddWithValue("email", compVal.PassEmail);
                        cmd.Parameters.AddWithValue("pass", compVal.Passwrd);
                        cmd.Parameters.AddWithValue("safe", GetBool(compVal.Safe));
                        cmd.Parameters.AddWithValue("updateid", passId);
                        con.Open();
                        try
                        {
                            success = cmd.ExecuteNonQuery();
                        }
                        catch (SqlCeException ex)
                        {
                            CustomMsgBox.Show(ex.Message, Msg.Exception);
                        }
                    }
                }               
            }
            return success;
        }
    }
}
