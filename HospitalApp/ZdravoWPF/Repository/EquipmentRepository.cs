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
    public class EquipmentRepository
    {
        private readonly string fileLocation = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\equimpent.json";//Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\doctors.json";
        private List<Equipment> equipments = new List<Equipment>();


        public EquipmentRepository()
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
                    equipments = JsonConvert.DeserializeObject<List<Equipment>>(json);
                }
            }
        }
        public void WriteToJson()
        {
            string json = JsonConvert.SerializeObject(equipments);
            File.WriteAllText(fileLocation, json);
        }

        public List<Equipment> GetAll()
        {
            ReadJson();
            return equipments;
        }

        public Equipment GetById(int id)
        {
            ReadJson();
            int counter = id;
            int i = 0;
            foreach (Equipment equipment in equipments)
            {
                if (i == counter)
                    return equipment;
                i++;
            }
            return null;
        }
        public void Save(Equipment equipment)
        {
            equipments.Add(equipment);
            WriteToJson();
        }

        public void Delete(int id)
        {
            ReadJson();
            equipments.RemoveAt(id);
            WriteToJson();
        }

        public void Update(Equipment equipment, int index)
        {
            ReadJson();
            Equipment tempEquipment = GetById(index);
            tempEquipment.Name = equipment.Name;
            tempEquipment.Quantity = equipment.Quantity;
            tempEquipment.Location = equipment.Location;
            tempEquipment.Type = equipment.Type;

            WriteToJson();
        }
    }
}
