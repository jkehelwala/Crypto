using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;

namespace Crypto
{
    class ItemLists : Db
    {
        bool notSafe;

        public static Password lastPassword;
        public static PassGroup lastPassGroup;

        public ItemLists(bool vulnerable)
        {
            notSafe = vulnerable;
        }

        private PCol getCol(int i)
        {
            switch (i)
            {
                case 0:
                    return PCol.p_name;
                case 1:
                    return PCol.p_email;
                case 2: 
                    return PCol.p_username;
                case 3:
                    return PCol.p_site;
                default:
                    return PCol.p_name;
            }
        }

        public List<int> getPasswordIndex(int ind, string arg)
        {
            List<int> passInd = new List<int>();
            string query = @"select " + Get(PCol.p_id) + " from " + Get(DbTable.pwords) + " where lower(" + Get(getCol(ind)) + ") like @val ";
            if (notSafe)
                query += " and " + Get(PCol.p_safe) + " = 0 ";
            query += " order by " + Get(PCol.p_id);

            using (SqlCeConnection con = new SqlCeConnection(conSrc))
            {
                using (SqlCeCommand cmd = new SqlCeCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("val", "%" + arg + "%" );
                    con.Open();
                    using (SqlCeDataReader extPass = cmd.ExecuteReader())
                    {
                        while (extPass.Read())
                        {
                            int id = Convert.ToInt32(extPass[Get(PCol.p_id)]);
                            passInd.Add(id);
                        }
                    }
                }
            }
            return passInd;
        }

        public List<Password> getPasswords()
        {
            List<Password> passList = new List<Password>();           
            string query = @"select * from " + Get(DbTable.pwords);

            if (notSafe)
                query += " where "+ Get(PCol.p_safe) + " = 0 ";

            query += " order by " + Get(PCol.p_id);

            using (SqlCeConnection con = new SqlCeConnection(conSrc))
            {
                using (SqlCeCommand cmd = new SqlCeCommand(query, con))
                {
                    con.Open();
                    using (SqlCeDataReader extPass = cmd.ExecuteReader())
                    {
                        while (extPass.Read())
                        {
                            int id = Convert.ToInt32(extPass[Get(PCol.p_id)]);
                            string name = extPass[Get(PCol.p_name)].ToString();
                            string site = extPass[Get(PCol.p_site)].ToString();
                            string uName = extPass[Get(PCol.p_username)].ToString();
                            string email = extPass[Get(PCol.p_email)].ToString();
                            string pwrd = extPass[Get(PCol.p_value)].ToString();
                            bool safe = GetBool(extPass[Get(PCol.p_safe)].ToString());
                            Password ps = new Password(id, name, site, uName, email, pwrd, safe);
                            passList.Add(ps);
                        }
                    }
                }
            }
            return passList;
        }

        public List<PassGroup> getGroups()
        {
            List<PassGroup> groupList = new List<PassGroup>();
            string query = "";

            if (notSafe)
            {
                query = @"select g." + Get(GCol.g_id) + ", g." + Get(GCol.g_name) + ", g." + Get(GCol.g_desc) + " from " + Get(DbTable.pgroups) + " g inner join " + Get(DbTable.grouped) +
                     " gr on g." + Get(GCol.g_id) + " =  gr." + Get(GPCol.g_id) + " group by g." + Get(GCol.g_id) + ", g." + Get(GCol.g_name) + ", g." + Get(GCol.g_desc) + " having (count(gr." + Get(GPCol.p_id) + ") > 2) order by g." + Get(GCol.g_name);
            }
            else
            {
                query = @"select * from " + Get(DbTable.pgroups) + " order by " + Get(GCol.g_name);
            }

            using (SqlCeConnection con = new SqlCeConnection(conSrc))
            {
                using (SqlCeCommand cmd = new SqlCeCommand(query, con))
                {
                    con.Open();
                    using (SqlCeDataReader extGroup = cmd.ExecuteReader())
                    {
                        while (extGroup.Read())
                        {
                            int id = Convert.ToInt32(extGroup[Get(GCol.g_id)]);
                            string name = extGroup[Get(GCol.g_name)].ToString();
                            string desc = extGroup[Get(GCol.g_desc)].ToString();
                            PassGroup ps = new PassGroup(id, name, desc);
                            groupList.Add(ps);
                        }
                    }
                }
            }
            return groupList;
        }    

        public List<string> getGroupByName(string gname)
        {
            List<string> groups = new List<string>();

            string query = @"select " + Get(GCol.g_name) + " from "  + Get(DbTable.pgroups) + " where lower(" + Get(GCol.g_name) + ") like @val order by " + Get(GCol.g_name);

            using (SqlCeConnection con = new SqlCeConnection(conSrc))
            {
                using (SqlCeCommand cmd = new SqlCeCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("val", "%"+gname+"%");
                    con.Open();
                    using (SqlCeDataReader extGroup = cmd.ExecuteReader())
                    {
                        while (extGroup.Read())
                        {
                            string name = extGroup[Get(GCol.g_name)].ToString();
                            groups.Add(name);
                        }
                    }
                }
            }
            return groups;
        }

    }
}
