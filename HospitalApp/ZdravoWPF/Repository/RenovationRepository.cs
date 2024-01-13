using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoWPF.Model;

namespace ZdravoWPF.Repository
{
    public class RenovationRepository
    {
        private readonly string fileLocation = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\renovations.json";//Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\doctors.json";
        private List<Renovation> renovations = new List<Renovation>();


        public RenovationRepository()
        {
            ReadJson();
        }

        public void ReadJson()
        {
            if (!File.Exists(fileLocation))
            {
                File.Create(fileLocation).Close();
            }

            using (StreamReader r = new StreamReader(fileLocation))
            {
                string json = r.ReadToEnd();
                if (json != "")
                {
                    renovations = JsonConvert.DeserializeObject<List<Renovation>>(json);
                }
            }
        }
        public void WriteToJson()
        {
            string json = JsonConvert.SerializeObject(renovations);
            File.WriteAllText(fileLocation, json);
        }

        public List<Renovation> GetAll()
        {
            ReadJson();
            return renovations;
        }

        public Renovation GetById(int id)
        {
            ReadJson();
            int counter = id;
            int i = 0;
            foreach (Renovation renovation in renovations)
            {
                if (i == counter)
                    return renovation;
                i++;
            }
            return null;
        }
        public void Save(Renovation renovation)
        {
            renovations.Add(renovation);
            WriteToJson();
        }

        public void Delete(int id)
        {
            ReadJson();
            renovations.RemoveAt(id);
            WriteToJson();
        }

        public void Update(Renovation renovation, int index)
        {
            ReadJson();
            Renovation tempRenovation = GetById(index);
            tempRenovation.startDate = renovation.startDate;
            tempRenovation.endDate= renovation.endDate;
            tempRenovation.location = renovation.location;
            tempRenovation.type = renovation.type;
            tempRenovation.description = renovation.description;

            WriteToJson();
        }
    }
}
