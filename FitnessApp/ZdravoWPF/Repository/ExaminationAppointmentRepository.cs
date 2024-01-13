using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using ZdravoWPF.Model;

namespace Repository
{
    public class ExaminationAppointmentRepository
    {

        private string path;

        public ExaminationAppointmentRepository()
        {
            path = @"..\..\..\Data\ExaminationAppointment.json";
        }



        //ovo je citanje iz fajla 

        public List<ExaminationAppointment> ReadFromFile()
        {
            List<ExaminationAppointment> termini_pregleda = new List<ExaminationAppointment>();

            if (File.Exists(path))
            {
                string jsonText = File.ReadAllText(path);

                if (!string.IsNullOrEmpty(jsonText))
                {
                    termini_pregleda = JsonConvert.DeserializeObject<List<ExaminationAppointment>>(jsonText);
                }
            }
            return termini_pregleda;
        }
        //upisivanje u fajl
        public void LoadIntoFile(List<ExaminationAppointment> termini_pregleda)
        {
            JsonSerializer Serializer = new JsonSerializer();
            Serializer.Formatting = Formatting.Indented;
            StreamWriter writer = new StreamWriter(path);
            JsonWriter jWriter = new JsonTextWriter(writer);
            Serializer.Serialize(jWriter, termini_pregleda);
            jWriter.Close();
            writer.Close();

        }


        public ExaminationAppointment GetAppointmentbyId(String appointmentID)
        {
            List<ExaminationAppointment> termini = ListAppointments();
            foreach (ExaminationAppointment i in termini)
            {
                if (i.Id.Equals(appointmentID))
                {
                    return i;
                }

            }
            return null;
        }

        public List<ExaminationAppointment> showPatientsAppointments(String pacijent_lbo)
        {
            List<ExaminationAppointment> termini = ReadFromFile();
            List<ExaminationAppointment> noviTermini = new List<ExaminationAppointment>();
            foreach (ExaminationAppointment i in termini)
            {
                if (i.patient.Lbo.Equals(pacijent_lbo))
                {
                    noviTermini.Add(i);
                }
            }
            return noviTermini;
        }

        public List<ExaminationAppointment> ListAppointments()
        {

            List<ExaminationAppointment> termini = ReadFromFile();
            return termini;
        }






        public ZdravoWPF.Model.ExaminationAppointment examinationAppointment;

    }
}
