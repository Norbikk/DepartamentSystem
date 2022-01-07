using System;
using System.IO;
using System.Text.Json;

namespace Prototype
{
    class Program
    {
        private static Worker _worker = new();

        static void Main(string[] args)
        {
           _worker.DeserializePersonJson();
            _worker.DeserializeDepartJson();
            do
            {
                Console.WriteLine("1 - Вписать Отдел. \n 2 - Вписать человека. \n 3 - Записать данные в JSON");
                var input = Console.ReadKey().Key;
                switch (input)
                {
                    case ConsoleKey.D1:
                        _worker.AddDepartInList();
                        break;
                    case ConsoleKey.D2:
                        Console.WriteLine("Выберите Отдел: ");
                        var s = _worker.DepartInConsole();
                        Console.WriteLine(s);
                        var number = Convert.ToInt32(Console.ReadLine()) - 1;
                        _worker.AddPersonInList(number);
                        var q = _worker.PersonInConsole();
                        Console.WriteLine(q);
                        break;
                    case ConsoleKey.D3:
                        _worker.PersonToJSON();
                        _worker.DepartToJSON();
                        break;
                    default:
                        Console.WriteLine("Выбор от 1 до 3");
                        break;
                }

                Console.WriteLine("Для продолжения нажмите ENTER");
            } while (Console.ReadLine() == String.Empty);
        }
    }
}