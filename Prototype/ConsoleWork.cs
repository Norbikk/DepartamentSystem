using System;

namespace Prototype
{
    class ConsoleWork
    {
        private WorkCollection _workCollection = new();
        private DepartmentCollection _departmentCollection = new();

        /// <summary>
        /// Берет данные из ввода консоли в персон
        /// </summary>
        /// <param name="num">ID департамента</param>
        /// <returns>Возвращает персона</returns>
        public Person PersonDataInput(int num)
        {
            Console.WriteLine("Введите имя:");
            var name = Console.ReadLine();

            Console.WriteLine("Введите фамилию:");
            var surname = Console.ReadLine();

            Console.WriteLine("Введите возраст:");
            var age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите зарплату:");
            var salary = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите кол-во проектов");
            var projectCount = Convert.ToInt32(Console.ReadLine());

            var person = _workCollection.PersonData(num, name, surname, age, salary, projectCount);
            return person;
        }
        
        

        /// <summary>
        /// Берет данные из ввода консоли в департамент
        /// </summary>
        /// <returns>Возвращает департамент</returns>
        public Depart DepartDataInput()
        {
            Console.WriteLine("Введите название отдела");
            var name = Console.ReadLine();
            var depart = _departmentCollection.DepartData(name);
            return depart;
        }
        
    }
}