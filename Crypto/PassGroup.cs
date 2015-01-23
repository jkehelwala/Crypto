using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;

namespace Crypto
{
    public class PassGroup : Db
    {
        int groupId;
        string groupName;
        string groupDesc;
        List<int> passIndex = new List<int>();

        public List<int> PassList
        {
            get { return passIndex; }
        }

        private void getPassList()
        {
            string query = @"select " + Get(GPCol.p_id) + " from " + Get(DbTable.grouped) + " where " + Get(GPCol.g_id) + " = @groupId order by " + Get(GPCol.p_id) ;
            passIndex.AddRange(getList(query));
        }

        private List<int> getList(string query)
        {
            List<int> pList = new List<int>();

            using (SqlCeConnection con = new SqlCeConnection(conSrc))
            {
                using (SqlCeCommand cmd = new SqlCeCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("groupId", groupId);
                    con.Open();
                    using (SqlCeDataReader extPass = cmd.ExecuteReader())
                    {
                        while (extPass.Read())
                        {
                            int id = Convert.ToInt32(extPass[Get(GPCol.p_id)]);                           
                            pList.Add(id);
                        }
                    }
                }
            }
            return pList;
        }       

        public int GroupId
        {
            get { return groupId;  }
            set { groupId = value; }
        }

        public string GroupName
        {
            get { return groupName; }
            set { groupName = value; }
        }

        public string GroupDesc
        {
            get { return groupDesc; }
            set { groupDesc = value; }
        }

        public PassGroup(string name, string desc)
        {
            groupName = name;
            groupDesc = desc;

            groupId = addPassGroup();

            if (groupId != 0)
                CustomMsgBox.Show("Password Group Successfully Added", Msg.Success);
            else
                CustomMsgBox.Show("Password Group Adding Failed", Msg.Error);
        }

        public PassGroup(int id)
        {
            groupId = id;
            refresh();
        }

        public PassGroup(int id, string name, string desc)
        {
            groupId = id;
            groupName = name;
            groupDesc = desc;            
            getPassList();
        }

        private int addPassGroup()
        {
            int id = 0;
            string query = "insert into " + Get(DbTable.pgroups) + " (" + Get(GCol.g_name) + "," + Get(GCol.g_desc) + ") values (@name, @desc)";

            using (SqlCeConnection con = new SqlCeConnection(conSrc))
            {
                using (SqlCeCommand cmd = new SqlCeCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("name", groupName);
                    cmd.Parameters.AddWithValue("desc", groupDesc);
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

        public bool deletePassGroup()
        {
            int success = 0;
            string query = "delete from " + Get(DbTable.grouped) + " where " + Get(GPCol.g_id) + " = @deleteid ; ";
            query += "delete from " + Get(DbTable.pgroups) + " where " + Get(GCol.g_id) + " = @deleteid";
            using (SqlCeConnection con = new SqlCeConnection(conSrc))
            {
                using (SqlCeCommand cmd = new SqlCeCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("deleteid", groupId);
                    con.Open();
                    success = cmd.ExecuteNonQuery();                    
                }
            }
            return success > 0;
        }

        public void refresh()
        {
            string query = @"select * from " + Get(DbTable.pgroups) + " where " + Get(GCol.g_id) + " = " + groupId;

            using (SqlCeConnection con = new SqlCeConnection(conSrc))
            {
                using (SqlCeCommand cmd = new SqlCeCommand(query, con))
                {
                    con.Open();
                    using (SqlCeDataReader extPass = cmd.ExecuteReader())
                    {
                        if (extPass.Read())
                        {
                            groupName = extPass[Get(GCol.g_name)].ToString();
                            groupDesc = extPass[Get(GCol.g_desc)].ToString();
                        }
                    }
                }
            }

            passIndex.Clear();
            getPassList();
        }

        public int editPassGroup(PassGroup compVal)
        {
            int success = 0;
            if (groupName == compVal.GroupName && groupDesc == compVal.GroupDesc)
                success = 3;
            else
            {
                string query = @"update " + Get(DbTable.pgroups) + " set " + Get(GCol.g_name) + " = @name, " + Get(GCol.g_desc) + " = @desc " +
                " where " + Get(GCol.g_id) + " = @updateid";

                using (SqlCeConnection con = new SqlCeConnection(conSrc))
                {
                    using (SqlCeCommand cmd = new SqlCeCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("name", compVal.GroupName);
                        cmd.Parameters.AddWithValue("desc", compVal.GroupDesc);
                        cmd.Parameters.AddWithValue("updateid", groupId);
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

        public bool addToGroup(List<int> pwrd)
        {
            int success = 0;
            string query = "insert into " + Get(DbTable.grouped) + " (" + Get(GPCol.g_id) + "," + Get(GPCol.p_id) + ") values (@groupId, @passId)";



            using (SqlCeConnection con = new SqlCeConnection(conSrc))
            {               
                    con.Open();
                    try
                    {
                        foreach(int p in pwrd){
                            using (SqlCeCommand cmd = new SqlCeCommand(query, con))
                            {
                                cmd.Parameters.AddWithValue("groupId", groupId);
                                cmd.Parameters.AddWithValue("passId", p);
                                success += cmd.ExecuteNonQuery();
                            }
                        }
                    }
                    catch (SqlCeException ex)
                    {
                        CustomMsgBox.Show(ex.Message, Msg.Exception);
                    }                             
            }

            if (success > 0)
            {
                passIndex.AddRange(pwrd);
                return true;
            }
            else
                return false;
        }

        public bool removeFromGroup(List<int> pwrd)
        {
            int success = 0;
            string query = "delete from " + Get(DbTable.grouped) + " where " + Get(GPCol.g_id) + " = @gId and " + Get(GPCol.p_id) + " in (";

            string sub = "";

            foreach (int p in pwrd)
                sub += "," + p.ToString();

            query += sub.Substring(1) + ")";
            
            using (SqlCeConnection con = new SqlCeConnection(conSrc))
            {
                using (SqlCeCommand cmd = new SqlCeCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("gId", groupId);
                    con.Open();
                    success = cmd.ExecuteNonQuery();
                }
            }
            if (success > 0)
            {
                passIndex.Clear();
                getPassList();
                return true;
            }
            else
                return false;
        }

        public void removeFromList(int pId)
        {
            passIndex.Remove(pId);
        }
        
    }

}
