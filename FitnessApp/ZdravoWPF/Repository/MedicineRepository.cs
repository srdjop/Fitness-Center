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
    public class MedicineRepository
    {
        private readonly string fileLocation = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\medicine.json";//Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\doctors.json";
        private List<Medicine> medicines = new List<Medicine>();


        public MedicineRepository()
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
                    medicines = JsonConvert.DeserializeObject<List<Medicine>>(json);
                }
            }
        }
        public void WriteToJson()
        {
            string json = JsonConvert.SerializeObject(medicines);
            File.WriteAllText(fileLocation, json);
        }

        public List<Medicine> GetAll()
        {
            ReadJson();
            return medicines;
        }

        public Medicine GetById(int id)
        {
            ReadJson();
            foreach (Medicine medicine in medicines)
            {
                if (medicine.Id == id)
                    return medicine;
            }
            return null;
        }
        public void Save(Medicine medicine)
        {
            medicines.Add(medicine);
            WriteToJson();
        }

        public void Delete(int id)
        {
            ReadJson();
            medicines.RemoveAt(id);
            WriteToJson();
        }

        public void Update(Medicine medicine, int index)
        {
            ReadJson();
            Medicine tempMedicine = GetById(index);
            tempMedicine.Name = medicine.Name;
            tempMedicine.Description = medicine.Description;
            tempMedicine.Alergens = medicine.Alergens;
            tempMedicine.Content = medicine.Content;

            WriteToJson();
        }
    }
}
