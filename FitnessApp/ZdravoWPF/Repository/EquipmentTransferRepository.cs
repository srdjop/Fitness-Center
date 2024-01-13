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
    public class EquipmentTransferRepository
    {
        private readonly string fileLocation = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\equimpentTransferQueue.json";//Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\doctors.json";
        private List<EquipmentTransferQueue> transferQueue = new List<EquipmentTransferQueue>();


        public EquipmentTransferRepository()
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
                    transferQueue = JsonConvert.DeserializeObject<List<EquipmentTransferQueue>>(json);
                }
            }
        }
        public void WriteToJson()
        {
            string json = JsonConvert.SerializeObject(transferQueue);
            File.WriteAllText(fileLocation, json);
        }

        public List<EquipmentTransferQueue> GetAll()
        {
            ReadJson();
            return transferQueue;
        }

        public EquipmentTransferQueue GetById(int id)
        {
            ReadJson();
            int counter = id;
            int i = 0;
            foreach (EquipmentTransferQueue equipment in transferQueue)
            {
                if (i == counter)
                    return equipment;
                i++;
            }
            return null;
        }

        public EquipmentTransferQueue GetByEquipmentId(int id)
        {
            ReadJson();
            foreach (EquipmentTransferQueue equipment in transferQueue)
            {
                if (equipment.EquipmentId == id)
                    return equipment;
            }
            return null;
        }
        public void Save(EquipmentTransferQueue equipment)
        {
            transferQueue.Add(equipment);
            WriteToJson();
        }

        public void Delete(int id)
        {
            ReadJson();
            transferQueue.RemoveAt(id);
            WriteToJson();
        }

        public void Update(EquipmentTransferQueue equipment, int index)
        {
            ReadJson();
            EquipmentTransferQueue tempEquipmentTransferQueue = GetById(index);
            tempEquipmentTransferQueue.EquipmentId = equipment.EquipmentId;
            tempEquipmentTransferQueue.TransferDate = equipment.TransferDate;
            tempEquipmentTransferQueue.TransferDestination = equipment.TransferDestination;

            WriteToJson();
        }
    }
}
