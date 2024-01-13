using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using ZdravoWPF.Model;

namespace ZdravoWPF.Repository
{
    public class AppointmentsRepository
    {
        private readonly string fileLocation = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\appsec.json";
        public List<Appointments> appointments = new List<Appointments>();

        public AppointmentsRepository()
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
                    appointments = JsonConvert.DeserializeObject<List<Appointments>>(json);
                }
            }
        }

        public void WriteToJson()
        {
            string json = JsonConvert.SerializeObject(appointments);
            File.WriteAllText(fileLocation, json);
        }
        public void Save(Appointments appointment)
        {
            ReadJson();
            appointments.Add(appointment);
            WriteToJson();
        }

        public void Delete(string id)
        {
            ReadJson();
            int index = appointments.FindIndex(obj => obj.Id == id);
            appointments.RemoveAt(index);
            WriteToJson();
        }

        public Appointments GetById(String id)
        {
            // TODO: implement
            ReadJson();
            return appointments.Find(obj => obj.Id == id);
        }
        public List<Appointments> GetAll()
        {
            ReadJson();
            return appointments;
        }
        /*public List<Appointments> GetByDoctorId(string id)
        {

            List<Appointments> apps = new List<Appointments>();
            foreach (var app in appointments)
            {
                if (app.doctor.User.Id == id)
                {
                    apps.Add(app);
                }

            }
            return apps;

        }*/
        
    }
}
