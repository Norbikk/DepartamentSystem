using System;
using System.Collections.Generic;
using System.Linq;

namespace Prototype
{
    class DepartmentCollection
    {
        public static List<Depart> Departs = new();
        private static ConsoleWork _cw = new();

        /// <summary>
        /// Добавляет департамент в лист
        /// </summary>
        public void AddDepartInList()
        {
            var s = _cw.DepartDataInput();

            Departs.Add(new Depart(s.Id, s.Name, s.DateOfCreation, s.CountPersons));
        }

        /// <summary>
        /// Возвращает строку
        /// </summary>
        /// <returns>Возвращает департамент в строку</returns>
        public string DepartInConsole()
        {
            string meminfo = null;
            for (int i = 0; i < Departs.Count; i++)
            {
                Departs[i].CountPersons = WorkCollection.Persons.Count(x => x.Department == Departs[i].Name);
                meminfo += Departs[i] + "\n";
            }

            return meminfo;
        }

        /// <summary>
        /// Создает новый департамент
        /// </summary>
        /// <param name="name">Название департамента</param>
        /// <returns>Возвращает департамент</returns>
        public Depart DepartData(string name)
        {
            int id = 0;
            int countPersons = 0;
            if (Departs.Count > 0)
            {
                for (int i = 0; i < Departs.Count; i++)
                {
                    id = Departs.Count + 1;
                }
            }
            else
            {
                id = 1;
            }

            var dateOfCreation = DateTime.Now;

            var depart = new Depart(id, name, dateOfCreation, countPersons);
            return depart;
        }
    }
}