using System;

namespace Prototype
{
    class Depart
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfCreation { get; set; }

        public int CountPersons { get; set; }

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="id">ID департамента</param>
        /// <param name="name">Имя</param>
        /// <param name="dateOfCreation">Дата создания</param>
        /// <param name="countPersons">Кол-во персонов в департаменте</param>
        public Depart(int id, string name, DateTime dateOfCreation, int countPersons)
        {
            Id = id;
            Name = name;
            DateOfCreation = dateOfCreation;
            CountPersons = countPersons;
        }

        public override string ToString() =>
            $"№{Id} Название:{Name} Дата создания:{DateOfCreation} Кол-во сотрудников:{CountPersons}";
    }
}