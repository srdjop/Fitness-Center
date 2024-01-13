using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZdravoWPF.Model
{
    public class Patient
    {
        public string Lbo;
        public Status Status;
        public MedicalRecord MedicalRecord { get; set; }
        public Patient() { }

        public Patient(string jmbg, string username, string password, string name, string surname, string email, string address, string phone, DateTime dataOfBirth)
        {
            User newUser = new User(jmbg, username, password, name, surname, email, address, phone, dataOfBirth);
            this.User = newUser;
        }

        public Patient(User user)
        {
            this.User = user;
        }


        public Patient(string jmbg, string username, string password, string name, string surname)
        {
            User newUser = new User(jmbg, username, password, name, surname);
            this.User = newUser;
        }



        public User User { get; set; }

        public System.Collections.ArrayList examinationAppointment;

        public void AddExaminationAppointment(ExaminationAppointment newExaminationAppointment)
        {
            if (newExaminationAppointment == null)
                return;
            if (this.examinationAppointment == null)
                this.examinationAppointment = new System.Collections.ArrayList();
            if (!this.examinationAppointment.Contains(newExaminationAppointment))
            {
                this.examinationAppointment.Add(newExaminationAppointment);
                newExaminationAppointment.SetPatient(this);
            }
        }

        public void RemoveExaminationAppointment(ExaminationAppointment oldExaminationAppointment)
        {
            if (oldExaminationAppointment == null)
                return;
            if (this.examinationAppointment != null)
                if (this.examinationAppointment.Contains(oldExaminationAppointment))
                {
                    this.examinationAppointment.Remove(oldExaminationAppointment);
                    oldExaminationAppointment.SetPatient((Patient)null);
                }
        }
    }
}
