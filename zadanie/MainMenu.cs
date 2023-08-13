using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkStation;

namespace Menu
{
    class MyMenu
    {
        Program conn = new Program();
        
       
        public void MainMenu(string connString)
        {
            Console.WriteLine("Меню\n Введите необходимую цифру \n 1 - Cоздать таблицу\n  2 - Добавить записи в таблицу \n 3 - Изменить записи \n 4 - Удалить запись\n 5 - Закрыть программу \n 6 - Вывести таблицу");
            int Num = int.Parse(Console.ReadLine());
            //ss
            do
            {
                switch (Num)
                {
                    case 1:
                        conn.CreateTable(connString);
                        break;
                    case 2:
                        conn.AddInfo(connString);
                        break;
                    case 3:
                        conn.InsertInfo(connString);
                        break;
                    case 4:
                        conn.deleteInfo(connString);
                        break;
                    case 5:
                        break;
                    case 6:
                        conn.readInfo(connString);
                        break;
                }
                Console.WriteLine("Меню\n Введите необходимую цифру \n 1 - Cоздать таблицу\n  2 - Добавить записи в таблицу \n 3 - Изменить записи \n4 - Удалить запись\n 5 - Закрыть программу \n6 - Вывести таблицу");
                Num = int.Parse(Console.ReadLine());
            }
            while (Num != 5);
        }
    }
}
