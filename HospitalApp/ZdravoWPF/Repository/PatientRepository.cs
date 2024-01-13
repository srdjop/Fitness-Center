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
    internal class PatientRepository
    {
        private readonly string fileLocation = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\patients.json";//Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\doctors.json";
        private List<Patient> patients = new List<Patient>();

        public PatientRepository()
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
                    patients = JsonConvert.DeserializeObject<List<Patient>>(json);
                }
            }
        }
        public void WriteToJson()
        {
            string json = JsonConvert.SerializeObject(patients);
            File.WriteAllText(fileLocation, json);
        }

        public List<Patient> GetAll()
        {
            ReadJson();
            return patients;
        }

        public Patient GetById(int id)
        {
            ReadJson();
            return patients.Find(obj => obj.User.Id == id);
        }

        public Patient GetByElementId(int id)
        {
            ReadJson();
            foreach (Patient patient in patients)
            {
                if (patient.User.Id == id)
                    return patient;
            }
            return null;
        }
        public bool Save(Patient patient)
        {

            patients.Add(patient);
            WriteToJson();
            return true;
        }

        public bool Update(Patient tempPatient, int id)
        {
            ReadJson();
            Patient patient = GetById((int)id);
            patient.User.Name = tempPatient.User.Name;
            patient.User.Surname = tempPatient.User.Surname;
            patient.User.DateOfBirth = tempPatient.User.DateOfBirth;
            patient.User.Jmbg = tempPatient.User.Jmbg;

            WriteToJson();
            return true;
        }

        public bool Delete(int id)
        {
            ReadJson();
            int index = patients.FindIndex(obj => obj.User.Id == id);
            patients.RemoveAt(index);
            WriteToJson();
            return true;
        }
    }
}
