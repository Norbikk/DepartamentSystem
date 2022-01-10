using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Prototype
{
    public class WorkWithJson
    {
        /// <summary>
        /// Сериализует Департаменты в Json
        /// </summary>
        public void DepartamentToJson()
        {
            var jsonDepart = JsonSerializer.Serialize(DepartmentCollection.Departs);
            var streamWriter =
                new StreamWriter("depart.json"); //Запускаем стримрайтер для записи\дозаписи\создания
            streamWriter.WriteLine(jsonDepart);
            streamWriter.Close(); //Закрываем документ
        }

        /// <summary>
        /// Сериализует  Персонов в Json
        /// </summary>
        public void PersonToJson()
        {
            var jsonString = JsonSerializer.Serialize(WorkCollection.Persons);
            var streamWriter =
                new StreamWriter("db.json"); //Запускаем стримрайтер для записи\дозаписи\создания
            streamWriter.WriteLine(jsonString); //Записываем в документ
            streamWriter.Close(); //Закрываем документ
        }

        /// <summary>
        /// Десерализует Департаменты из Json
        /// </summary>
        public void DeserializeDepartamentJson()
        {
            if (File.Exists("depart.json"))
            {
                var jsonString = File.ReadAllText("depart.json");

                DepartmentCollection.Departs = JsonSerializer.Deserialize<List<Depart>>(jsonString);
            }
        }

        /// <summary>
        /// Десереализует персонов из Json
        /// </summary>
        public void DeserializePersonJson()
        {
            if (File.Exists("db.json"))
            {
                string jsonString = File.ReadAllText("db.json");

                WorkCollection.Persons = JsonSerializer.Deserialize<List<Person>>(jsonString);
            }
        }
    }
}