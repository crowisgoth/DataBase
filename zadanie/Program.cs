using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace zadanie
{
    class Program
    {

        static void Main(string[] args)
        {
            Program create = new Program();
            string connString = "Host=185.112.83.196;Username=postgres;Password=mysecretpassword;Database=postgres";
            Console.WriteLine("Меню\n Введите необходимую цифру \n 1 - Cоздать таблицу\n 2 - Проверить соединение \n 3 - Добавить записи в таблицу \n 4 - Изменить записи \n 5 - Удалить запись\n 6 - Закрыть программу \n 7 - Вывести таблицу");
            int Num = int.Parse(Console.ReadLine());

            do
            {


                switch (Num)
                {
                    case 1:
                        create.CreateTable(connString);
                        break;
                    case 2:
                        ConnTry(connString);
                        break;
                    case 3:
                        create.AddInfo(connString);
                        break;
                    case 4:
                        create.InsertInfo(connString);
                        break;
                    case 5:
                        create.deleteInfo(connString);
                        break;
                    case 6:
                        break;
                    case 7:
                        create.readInfo(connString);
                        break;

                }
                Console.WriteLine("Меню\n Введите необходимую цифру \n 1 - Cоздать таблицу\n 2 - Проверить соединение \n 3 - Добавить записи в таблицу \n 4 - Изменить записи \n5 - Удалить запись\n 6 - Закрыть программу \n7 - Вывести таблицу");
                Num = int.Parse(Console.ReadLine());
            }
            while (Num != 6);







        }

        static void ConnTry(string connString)
        {
            NpgsqlConnection nc = new NpgsqlConnection(connString);
            try
            {
                //Открываем соединение.
                nc.Open();
                Console.WriteLine("Подключение к серверу прошло успешно");
                Console.ReadLine();
                nc.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка при подключении к серверу");
                Console.ReadLine();
            }
        }
        public void CreateTable(string connString)
        {
            NpgsqlConnection nc = new NpgsqlConnection(connString);
            try
            {
                nc.Open();
                string sql = "CREATE TABLE Users (id serial primary key,created_by character varying(30),updated_by character varying(30),first_name text,last_name text,age integer,mail text);";
                NpgsqlCommand ng = new NpgsqlCommand(sql, nc);
                ng.ExecuteNonQuery();

                Console.WriteLine("Запрос отправлен");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Произошла ошибка при попытке выполнения запроса (Таблица уже создана)");
            }


            nc.Close();

        }
        public void AddInfo(string connString)
        {
            Console.WriteLine("Введите ваше имя");
            string first_name = Console.ReadLine();
            Console.WriteLine("Введите вашу фамилию");
            string last_name = Console.ReadLine();
            Console.WriteLine("Введите ваш возраст");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите ваш адрес электронной почты");
            string mail = Console.ReadLine();
            NpgsqlConnection nc = new NpgsqlConnection(connString);
            try
            {
                Console.WriteLine("Давайте заполним ваши данные");

                nc.Open();
                string sql = "INSERT INTO Users (created_by,first_name,last_name,age,mail) VALUES ('" + DateTime.Now + "','" + first_name + "','" + last_name + "'," + age + ",'" + mail + "');";
                //string sql = "INSERT INTO Users (created_by) VALUES ('" + @DateTime.Now + "');";
                //NpgsqlParameter nameparam = new NpgsqlParameter("'@DateTime.Now'", @DateTime.Now);
                NpgsqlCommand cmd = new NpgsqlCommand();
                //cmd.Parameters.Add(nameparam);
                NpgsqlCommand com = new NpgsqlCommand(sql, nc);
                com.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }




            nc.Close();

        }
        public void InsertInfo(string connString)
        {
            Console.WriteLine("Введите имя поля, которое вы хотите изменить");
            string changedName = Console.ReadLine();
            Console.WriteLine("Введите ID нужного поля");
            int changedID = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите значение");
            string newValue = Console.ReadLine();
            try
            {
                NpgsqlConnection nc = new NpgsqlConnection(connString);
                nc.Open();
                string sql = "UPDATE users SET " + changedName + "=" + "'" + newValue + "'" + ";";
                NpgsqlCommand com = new NpgsqlCommand(sql, nc);

                com.ExecuteNonQuery();
                nc.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        public void deleteInfo(string ConnString)
        {
            Console.WriteLine("Введите ID записи которую хотите удалить");
            int NumDelete = int.Parse(Console.ReadLine());
            try
            {
                NpgsqlConnection nc = new NpgsqlConnection(ConnString);
                nc.Open();
                string sql = "DELETE FROM users WHERE id = " + "'" + NumDelete + "'" + ";";
                NpgsqlCommand com = new NpgsqlCommand(sql, nc);
                com.ExecuteNonQuery();
                nc.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
        public void readInfo(string ConnString)
        {
            NpgsqlConnection nc = new NpgsqlConnection(ConnString);
            nc.Open();
            string strSQL = "SELECT * FROM users";
            NpgsqlCommand myCommand = new NpgsqlCommand(strSQL, nc);
            NpgsqlDataReader dr = myCommand.ExecuteReader();
        
            int iq = 3;
            while (dr.Read())
            {

                object id = dr.GetValue(1);
                object fistName = dr.GetValue(3);
                object secName = dr.GetValue(4);
                //object age = dr.GetValue(5);
                //object mail = dr.GetValue(6);
                Console.WriteLine("{0} \t{1}\t{2}", id, fistName, secName);
                
            }

            dr.Close();


        }
    }
    }
