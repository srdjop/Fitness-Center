using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ZdravoWPF.Model;

namespace ZdravoWPF.Repository
{
    public class DoctorRepository
    {
        private readonly string fileLocation = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\doctors.json";//Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\doctors.json";
        private List<Doctor> doctors = new List<Doctor>();
        

        public DoctorRepository()
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
                    doctors = JsonConvert.DeserializeObject<List<Doctor>>(json);
                }
            }
        }
        public void WriteToJson()
        {
            string json = JsonConvert.SerializeObject(doctors);
            File.WriteAllText(fileLocation, json);
        }

        public List<Doctor> GetAll()
        {
            ReadJson();
            return doctors;
        }

        public Doctor GetById(int id)
        {
            ReadJson();
            return doctors.Find(obj => obj.User.Id == id);
        }
        public void Save(Doctor doctor)
        {

            doctors.Add(doctor);
            WriteToJson();
        }

        public void Delete(int id)
        {
            ReadJson();
            int index = doctors.FindIndex(obj => obj.User.Id == id);
            doctors.RemoveAt(index);
            WriteToJson();
        }
    }
}
