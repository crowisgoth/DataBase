using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Output
{
    class ConsoleOutput
    {
        public void createTableOutput()
        {

            Console.WriteLine("Запрос отправлен");
        }
        public string inputConsole(string text)
        {

            Console.WriteLine(text);
            return Console.ReadLine();
        }
        public int deletedID()
        {
            Console.WriteLine("Введите ID записи которую хотите удалить");
            int delID =int.Parse(Console.ReadLine());
            return delID;
        }
        public Dictionary<string, string> AddInfoOutput()
        {
            Dictionary<string, string> nums = new Dictionary<string, string>();
            nums.Add("fName", inputConsole("Введите ваше имя"));
            nums.Add("sName", inputConsole("Введите вашу фамилию"));
            while (true) { 
                try
                {
                    int age = int.Parse(inputConsole("Введите ваш возраст"));
                    nums.Add("age", age.ToString());
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Проверьте введенные данные");

                }

            }

            nums.Add("mail", inputConsole("Введите ваш адрес электронной почты"));

            return nums;
        }
        public Dictionary<string,string> insertInfoPath()
        {
            Dictionary<string, string> changedInfo = new Dictionary<string, string>();
            changedInfo.Add("changedName", inputConsole("Введите имя поля которое хотите изменить"));
            try
            {
                int id = int.Parse(inputConsole("Введите ID элемента который хотите изменить"));
                changedInfo.Add("ID", id.ToString());
            }
            catch(Exception ex)
            {
                Console.WriteLine("Проверьте введенные данные");
            }

            changedInfo.Add("changedValue", inputConsole("Введите новое значение"));
            return changedInfo;
        }
        
            
    }
}
