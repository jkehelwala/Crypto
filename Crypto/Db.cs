
using System;
namespace Crypto
{
    public class Db
    {
        protected enum DbTable { pwords, pgroups, grouped };
        protected enum PCol { p_id, p_name, p_site, p_username, p_email, p_value, p_safe };
        protected enum GCol { g_id, g_name, g_desc } ;
        protected enum GPCol { g_id, p_id };

        public static string conSrc = "Data Source=" + Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\TheAurors\\Crypto\\cryptodb.sdf;password=passdb;encrypt database=true";

        protected string Get(DbTable tbl)
        {
            return tbl.ToString();
        }

        protected string Get(PCol passCol)
        {
            return passCol.ToString();
        }

        protected string Get(GCol groupCol)
        {
            return groupCol.ToString();
        }

        protected string Get(GPCol groupedCol)
        {
            return groupedCol.ToString();
        }

        protected bool GetBool(string val)
        {
            if (val == "1")
                return true;
            else
                return false;
        }

        protected string GetBool(bool val)
        {
            if (val)
                return "1";
            else
                return "0";
        }

    }
}
