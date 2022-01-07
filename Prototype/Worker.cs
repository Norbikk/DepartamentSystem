using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Prototype
{
    class Worker
    {
        private static List<Person> _person = new();
        private static List<Depart> _depart = new();
        
        public void AddDepartInList()
        {
            var s = DepartDataInput();
            _depart.Add(new Depart(s.Id, s.Name, s.DateOfCreation,s.CountPersons));
        }
        public void AddPersonInList(int id)
        {
            var s = PersonDataInput(id);
            _person.Add(new Person(s.Id,s.Name,s.Surname,s.Age,s.Department,s.Salary,s.ProjectCount));
        }

        public string DepartInConsole()
        {
            string meminfo = null;
            for (int i = 0; i < _depart.Count; i++)
            {
                _depart[i].Id = i+1; 
                _depart[i].CountPersons = _person.Count(x => x.Department == _depart[i].Name);
                meminfo += _depart[i]+ "\n";
            }
            
            return meminfo;
        }
        public string PersonInConsole()
        {
            string meminfo = null;
            for (int i = 0; i < _person.Count; i++)
            {
                _person[i].Id = i + 1;
                meminfo += _person[i]+"\n";
            }
            return meminfo;
        }
        public void PersonToJSON()
        {
            var jsonString = JsonSerializer.Serialize(_person);
            var streamWriter =
                new StreamWriter("db.json"); //Запускаем стримрайтер для записи\дозаписи\создания
            streamWriter.WriteLine(jsonString); //Записываем в документ
            streamWriter.Close(); //Закрываем документ
        }
        public void DepartToJSON()
        {
            var jsonDepart = JsonSerializer.Serialize(_depart);
            var streamWriter =
                new StreamWriter("depart.json"); //Запускаем стримрайтер для записи\дозаписи\создания
            streamWriter.WriteLine(jsonDepart);
            streamWriter.Close(); //Закрываем документ
        }

        public void DeserializePersonJson()
        {
            if (File.Exists("db.json"))
            {
                string jsonString = File.ReadAllText("db.json");
                
                _person = JsonSerializer.Deserialize<List<Person>>(jsonString);
            }
        }
        public void DeserializeDepartJson()
        {
            if (File.Exists("depart.json"))
            {
                var jsonString = File.ReadAllText("depart.json");

                _depart = JsonSerializer.Deserialize<List<Depart>>(jsonString);
            }
        }

        private Person PersonDataInput(int number)
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
            int id = 0;
            var department = _depart[number].Name;
            var person = new Person(id, name, surname, age,department, salary,
                projectCount);
            return person;
        }

        private Depart DepartDataInput()
        {
            var id = 0;
            Console.WriteLine("Введите название отдела");
            var name = Console.ReadLine();
            var dateOfCreation = DateTime.Now;
            var countPersons = 0;
            var depart = new Depart(id,name, dateOfCreation, countPersons);
            return depart;
        }
    }
}