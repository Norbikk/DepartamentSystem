using System;
using System.IO;
using System.Text.Json;

namespace Prototype
{
    class Program
    {
        private static WorkCollection _workCollection = new();
        private static WorkWithJson _workWithJson = new();
        private static DepartmentCollection _departmentCollection = new();

        static void Main(string[] args)
        {
            _workWithJson.DeserializePersonJson();
            _workWithJson.DeserializeDepartamentJson();
            do
            {
                Console.WriteLine("1 - Вписать Отдел. \n" +
                                  "2 - Вписать человека. \n" +
                                  "3 - Записать данные в JSON. \n" +
                                  "4 - Сортировка \n" +
                                  "5 - Редактирование");
                var input = Console.ReadKey().Key;
                switch (input)
                {
                    case ConsoleKey.D1:
                        InputDepartment();
                        break;
                    case ConsoleKey.D2:
                        InputPersons();
                        DisplayPersonList();
                        break;
                    case ConsoleKey.D3:
                        _workWithJson.PersonToJson();
                        _workWithJson.DepartamentToJson();
                        break;
                    case ConsoleKey.D4:
                        DisplayPersonList(); //Вывод до сортировки
                        Sorting();
                        DisplayPersonList(); //Вывод после сортировки
                        break;
                    case ConsoleKey.D5:
                        DisplayPersonList(); //Вывод до редактрования
                        DeleteOrEdit();
                        DisplayPersonList(); //Вывод после рдактирования
                        break;
                    default:
                        Console.WriteLine("Выбор от 1 до 3");
                        break;
                }

                Console.WriteLine("Для продолжения нажмите ENTER");
            } while (Console.ReadLine() == String.Empty);
        }

        /// <summary>
        /// Ввод нового департамента
        /// </summary>
        private static void InputDepartment()
        {
            var result = "\n"+_departmentCollection.DepartInConsole();
            Console.WriteLine(result);
            _departmentCollection.AddDepartInList();
        }

        /// <summary>
        /// Вывод информации на экран
        /// </summary>
        private static void DisplayPersonList()
        {
            var personResult = "\n" + _workCollection.PersonInConsole();
            Console.WriteLine(personResult);
        }

        /// <summary>
        /// Ввод нового персона
        /// </summary>
        private static void InputPersons()
        {
            Console.WriteLine("Выберите Отдел: ");
            var result = _departmentCollection.DepartInConsole();
            Console.WriteLine(result);
            var number = Convert.ToInt32(Console.ReadLine()) - 1;
            _workCollection.AddPersonInList(number);
        }

        /// <summary>
        /// Удаление пользователя по вводу из консоли.
        /// </summary>
        private static void RemovePersonById()
        {
            Console.WriteLine("Впишите ID, кого вы хотите удалить.");
            Console.WriteLine("Для продолжения без удаления нажмите ENTER");
            var id = Convert.ToInt32(Console.ReadLine());
            _workCollection.RemoveAndSetId(id);
        }

        /// <summary>
        /// Выбор редактировния
        /// </summary>
        private static void DeleteOrEdit()
        {
            Console.WriteLine("1 - удаление \n2 - редактировать");
            var input = Console.ReadKey().Key;
            switch (input)
            {
                case ConsoleKey.D1:
                    RemovePersonById();
                    break;
                case ConsoleKey.D2:
                    EditPersonByID();
                    break;
                default:
                    Console.WriteLine("Только 1 или 2");
                    break;
            }
        }


        /// <summary>
        /// Работа с консолью по редактированию персона
        /// </summary>
        private static void EditPersonByID()
        {
            Console.WriteLine("Впишите ID, кого вы хотите отредактировать.");
            Console.WriteLine("Для продолжения нажмите ENTER");
            var id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Выберите Отдел: ");
            var result = _departmentCollection.DepartInConsole();
            Console.WriteLine(result);
            var number = Convert.ToInt32(Console.ReadLine()) - 1;
            _workCollection.ChangePerson(number, id);
        }

        /// <summary>
        /// Меню сортировки
        /// </summary>
        private static void Sorting()
        {
            Console.WriteLine("1-Сортировать по возрасту\n" +
                              "2-Сортировать по возрасту и зарплате\n" +
                              "3-Сортировать по возрасту и зарплате в рамках отделов");
            _workCollection.DifferentSorting();
        }
    }
}