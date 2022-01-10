using System;
using System.Collections.Generic;
using System.Linq;


namespace Prototype
{
    class WorkCollection
    {
        public static List<Person> Persons = new();
        private static ConsoleWork _cw = new();

        /// <summary>
        /// Добавление персона в лист
        /// </summary>
        /// <param name="id">айди департамента</param>
        public void AddPersonInList(int id)
        {
            var s = _cw.PersonDataInput(id);
            Persons.Add(new Person(s.Id, s.Name, s.Surname, s.Age, s.Department, s.Salary, s.ProjectCount));
        }

        /// <summary>
        /// Возвращает строку
        /// </summary>
        /// <returns>Возвращает персонов в строку</returns>
        public string PersonInConsole()
        {
            string meminfo = null;
            for (int i = 0; i < Persons.Count; i++)
            {
                meminfo += Persons[i] + "\n";
            }

            return meminfo;
        }

        /// <summary>
        /// Создает нового персона
        /// </summary>
        /// <param name="number">Айди департамента</param>
        /// <param name="name">Имя</param>
        /// <param name="surname">Фамилия</param>
        /// <param name="age">Возраст</param>
        /// <param name="salary">Зарплата</param>
        /// <param name="projectCount">Кол-во проектов</param>
        /// <returns>Возвращает Персона</returns>
        public Person PersonData(int number, string name, string surname, int age, int salary, int projectCount)
        {
            var id = 0;
            for (int i = 0; i < Persons.Count; i++)
            {
                id = Persons.Count + 1;
            }

            var department = DepartmentCollection.Departs[number].Name;
            var person = new Person(id, name, surname, age, department, salary,
                projectCount);
            return person;
        }

        /// <summary>
        /// Удаляет человека и перенумировывает
        /// </summary>
        /// <param name="id">вписываемый айди</param>
        public void RemoveAndSetId(int id)
        {
            RemovePerson(id);
            SetNewIdPersons();
        }

        /// <summary>
        /// Изменение персона
        /// </summary>
        /// <param name="num">ID департамента</param>
        /// <param name="id">ID персона</param>
        public void ChangePerson(int num, int id)
        {
            for (int i = 0; i < Persons.Count; i++)
            {
                if (id == Persons[i].Id)
                {
                    var person = _cw.PersonDataInput(num);
                    person.Id = Persons[i].Id;
                    Persons[i] = new Person(person.Id, person.Name, person.Surname, person.Age, person.Department,
                        person.Salary, person.ProjectCount);
                }
            }
        }

        /// <summary>
        /// Вся сортировка через свич
        /// </summary>
        public void DifferentSorting()
        {
            var input = Console.ReadKey().Key;
            switch (input)
            {
                case ConsoleKey.D1:
                    SortingByAge();
                    break;
                case ConsoleKey.D2:
                    SortingByAgeAndSalary();
                    break;
                case ConsoleKey.D3:
                    SortingByAgeAndSalaryInDepart();
                    break;
                default:
                    Console.WriteLine("Введите от 1-3");
                    break;
            }
        }

        /// <summary>
        /// Удаление персона
        /// </summary>
        /// <param name="id">ID персона</param>
        private void RemovePerson(int id)
        {
            for (int i = 0; i < Persons.Count; i++)
            {
                if (id == Persons[i].Id)
                {
                    Persons.Remove(Persons[i]);
                }
            }
        }

        /// <summary>
        /// Выдает новые ID
        /// </summary>
        private void SetNewIdPersons()
        {
            for (var i = 0; i < Persons.Count; i++)
            {
                Persons[i].Id = i + 1;
            }
        }

        /// <summary>
        /// Сортирует по возрасту
        /// </summary>
        private void SortingByAge()
        {
            Persons = Persons.OrderBy(x => x.Age).ToList();
        }

        /// <summary>
        /// Сортирует по возрасту и заработку
        /// </summary>
        private void SortingByAgeAndSalary()
        {
            Persons = Persons.OrderBy(x => x.Age)
                .ThenBy(x => x.Salary).ToList();
        }

        /// <summary>
        /// Сортирует по возрасту и зароботку в департаменте
        /// </summary>
        private void SortingByAgeAndSalaryInDepart()
        {
            //Persons = Persons.Where(x => x.Department == DepartmentCollection.Departs[id].Name).OrderBy(x => x.Age)
            //  .ThenBy(x => x.Salary).ToList();
            Persons = Persons.OrderBy(x => x.Department)
                .ThenBy(x => x.Age)
                .ThenBy(x => x.Salary).ToList();
        }
    }
}