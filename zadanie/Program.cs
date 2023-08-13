using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using DataBaseAction;
using Output;
using sqlq;
using Menu;

namespace WorkStation
{
    
    class Program
    {
        
        ConsoleOutput op = new ConsoleOutput();
        SQLq sql = new SQLq();
        
        static void Main(string[] args)
        {
            
           
            mainMenu(connInfo());
           

        }
        public static void mainMenu(string connString)
        {
            MyMenu menu = new MyMenu();
            menu.MainMenu(connString);
           
        }
        static string connInfo()
        {
            string connString = "Host=" + DataBaseAction.Class1.Host + ";" + "Username=" + DataBaseAction.Class1.Username + ";" + "Password=" + DataBaseAction.Class1.Password + ";" + "Database=" + DataBaseAction.Class1.Database;
            return connString;
        }
        static NpgsqlCommand Connection(string connString, string sqlQuery)
        {
            NpgsqlConnection nc = new NpgsqlConnection(connString);
            NpgsqlCommand execQuery = new NpgsqlCommand(sqlQuery, nc);
            try
            {
                nc.Open();
                execQuery.ExecuteNonQuery();
                return execQuery;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return execQuery;
                Console.ReadLine();
            }
        }

        public void CreateTable(string connString)
        {
            
            Connection(connString,sql.createTableSQL());
            op.createTableOutput();
        }
        public void AddInfo(string connString)
        {
            
            Connection(connString, sql.addInfoSQL(op.AddInfoOutput()));
        }
        public void InsertInfo(string connString)
        {

            Connection(connString, sql.insertInfoSQL(op.insertInfoPath()));
        }

        public void deleteInfo(string connString)
        {

            Connection(connString, sql.deleteInfoSQL());
        }
        public void readInfo(string connString)
        {
            
            NpgsqlDataReader dr = Connection(connString, sql.readInfoSQL()).ExecuteReader();
            while (dr.Read())
            {
                object id = dr.GetValue(1);
                object fistName = dr.GetValue(3);
                object secName = dr.GetValue(4);
                Console.WriteLine("{0} \t{1}\t{2}", id, fistName, secName);
            }
            dr.Close();
        }

        
    }
}
