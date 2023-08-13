using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Output;

namespace sqlq
{
    
    class SQLq
    {
        ConsoleOutput op = new ConsoleOutput();
        public string createTableSQL()
        {
            string sql = "CREATE TABLE Users (id serial primary key,created_by character varying(30),updated_by character varying(30),first_name text,last_name text,age integer,mail text);";
            return sql;
        }
        public string addInfoSQL(Dictionary<string, string> nums)
        {
            string sql = "INSERT INTO Users (created_by,first_name,last_name,age,mail) VALUES ('" + DateTime.Now + "','" + nums["fName"] + "','" + nums["sName"] + "'," + int.Parse(nums["age"]) + ",'" + nums["mail"] + "');";
            return sql;
        }
        public string insertInfoSQL(Dictionary<string, string> changedInfo)
        {
            string sql = "UPDATE users SET updated_by = '" + DateTime.Now + "'," + changedInfo["changedName"] + "=" + "'" + changedInfo["changedValue"] + "'" + "WHERE id =" + changedInfo["ID"] + ";";
            return sql;
        }
        public string deleteInfoSQL()
        {
            string sql = "DELETE FROM users WHERE id = " + "'" + op.deletedID() + "'" + ";";
            return sql;
        }
        public string readInfoSQL()
        {
            string strSQL = "SELECT * FROM users";
            return strSQL;
        }
    }
}
