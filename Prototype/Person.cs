namespace Prototype
{
    class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Department { get; set; }
        public int Salary { get; set; }
        public int ProjectCount { get; set; }

        /// <summary>
        /// Конструктор класса Person
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="name">Имя</param>
        /// <param name="surname">Фамилия</param>
        /// <param name="age">Кол-во лет</param>
        /// <param name="department">Наименование департамента</param>
        /// <param name="salary">Зарплата</param>
        /// <param name="projectCount">Кол-во проектов</param>
        public Person(int id, string name, string surname, int age, string department, int salary, int projectCount)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Age = age;
            Department = department;
            Salary = salary;
            ProjectCount = projectCount;
        }
        
        public override string ToString() =>
            $"№{Id}Имя:{Name} Фамилия:{Surname} Возраст:{Age} Отдел:{Department} Зарплата:{Salary} Кол-во проектов:{ProjectCount}";
    }

}