using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PilkarzeMVVM.Model
{
    public class Model
    {
        private const string DBFileName = "Database.json";

        public List<Footballer> Footballers { get; set; }

        public Model()
        {
            if (File.Exists(DBFileName))
            {
                string database = File.ReadAllText(DBFileName);
                Footballers = JsonConvert.DeserializeObject<List<Footballer>>(database);
            }

            if (Footballers == null)
            {
                Footballers = new List<Footballer>();
            }
        }

        public void WriteToFile()
        {
            string json = JsonConvert.SerializeObject(Footballers, Formatting.Indented);
            using (StreamWriter sw = new StreamWriter(DBFileName))
            {
                sw.Write(json);
                sw.Close();
            }
        }

        public void AddFootballer(string name, string surname, uint age, uint weight, uint height)
        {
            var id = Footballers.Count() + 1;
            var fbl = new Footballer(id, name, surname, age, weight, height);
            Footballers.Add(fbl);
            WriteToFile();
        }


        internal void UpdateFootballer(int id, string firstname, string surname, uint age, uint weight, uint height)
        {
            int IdOF = Footballers.FindIndex(x => x.Id == id);
            Footballers[IdOF].FirstName = firstname;
            Footballers[IdOF].Surname = surname;
            Footballers[IdOF].Age = age;
            Footballers[IdOF].Weight = weight;
            Footballers[IdOF].Height = height;
            WriteToFile();
        }

        internal void RemoveFootballer(int id)
        {
            var IdOF = Footballers.FindIndex(x => x.Id == id);
            Footballers.RemoveAt(IdOF);
            WriteToFile();
        }
    }
}
