namespace Prototype
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname{ get; set; }
        public int Age{ get; set; }
        public string Department{ get; set; }
        public int Salary{ get; set; }
        public int ProjectCount{ get; set; }

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
       
       
        /*public Person(PersonData data)
        {
           // Id = data.Id;
            Name = data.Name;
            Surname = data.Surname;
            Age = data.Age;
            Department = data.Department;
            Salary = data.Salary;
            ProjectCount = data.ProjectCount;
        }
*/


        public override string ToString() =>
            $"{Id}#{Name}#{Surname}#{Age}#{Department}#{Salary}#{ProjectCount}";
    }

    
   /*
    public struct PersonData
    {
        //public int Id;
        public string Name;
        public string Surname;
        public int Age;
        public string Department;
        public int Salary;
        public int ProjectCount;
    }
    */
}