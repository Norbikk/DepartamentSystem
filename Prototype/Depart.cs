using System;

namespace Prototype
{
    class Depart
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfCreation { get; set; }

        public int CountPersons { get; set; }
        // public int _maxCountPersons = 1_000_000;

        public Depart(int id, string name, DateTime dateOfCreation,int countPersons)
        {
            Id = id;
            Name = name;
            DateOfCreation = dateOfCreation;
            CountPersons = countPersons;
        }

        public override string ToString() =>
            $"{Id}#{Name}#{DateOfCreation}#{CountPersons}";
    }

   /*
    public struct DepartData
    {
        public int Id;
        public string Name;
        public DateTime DateOfCreation;
        public int CountPersons;
    }
    */
}