using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZdravoWPF.Model
{
    public class Appointment
    {
        public Appointment()
        {
        }

        public Appointment(int id, string appointmentDate, string appointmentDuration, int doctorId, int patientId)
        {
            Id = id;
            AppointmentDate = appointmentDate;
            AppointmentDuration = appointmentDuration;
            DoctorId = doctorId;
            PatientId = patientId;
        }

        public int Id { get; set; }
        public string AppointmentDate { get; set; }
        public string AppointmentDuration { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public override string? ToString()
        {
            return "" + this.Id + "," + this.AppointmentDate + "," + this.DoctorId + "," + this.PatientId + "," + AppointmentDuration;
        }
    }
}
