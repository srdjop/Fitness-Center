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
    public class AppointmentRepository
    {
        private readonly string fileLocation = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\appointments.json";//Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\doctors.json";
        private List<Appointment> appointments = new List<Appointment>();


        public AppointmentRepository()
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
                    appointments = JsonConvert.DeserializeObject<List<Appointment>>(json);
                }
            }
        }
        public void WriteToJson()
        {
            string json = JsonConvert.SerializeObject(appointments);
            File.WriteAllText(fileLocation, json);
        }

        public List<Appointment> GetAll()
        {
            ReadJson();
            return appointments;
        }

        public Appointment GetById(int id)
        {
            ReadJson();
            int counter = id;
            int i = 0;
            foreach (Appointment appointment in appointments)
            {
                if (i == counter)
                    return appointment;
                i++;
            }
            return null;
        }
        public void Save(Appointment appointment)
        {
            appointments.Add(appointment);
            WriteToJson();
        }

        public void Delete(int id)
        {
            ReadJson();
            appointments.RemoveAt(id);
            WriteToJson();
        }

        public void Update(Appointment appointment, int index)
        {
            ReadJson();
            Appointment tempAppointment = GetById(index);
            tempAppointment.Id = appointment.Id;
            tempAppointment.PatientId = appointment.PatientId;
            tempAppointment.DoctorId = appointment.DoctorId;
            tempAppointment.AppointmentDate = appointment.AppointmentDate;
            tempAppointment.AppointmentDuration = appointment.AppointmentDuration;

            WriteToJson();
        }
    }
}
