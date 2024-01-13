using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZdravoWPF.Model
{
    public class ExaminationAppointment
    {
        public String Id { get; set; }
        public DateTime StartTime { get; set; }
        public int Length { get; set; }
        public Room Room { get; set; }
        public Room room { get; set; }


        public Patient patient;

        public ExaminationAppointment(string id, DateTime startTime, int length, Room room)
        {
            this.Id = id;
            this.StartTime = startTime;
            this.Length = length;
            this.room = room;

        }
        public ExaminationAppointment()
        { }

        public Patient GetPatient()
        {
            return patient;
        }

        public void SetPatient(Patient newPatient)
        {
            if (this.patient != newPatient)
            {
                if (this.patient != null)
                {
                    Patient oldPatient = this.patient;
                    this.patient = null;
                    oldPatient.RemoveExaminationAppointment(this);
                }
                if (newPatient != null)
                {
                    this.patient = newPatient;
                    this.patient.AddExaminationAppointment(this);
                }
            }
        }

    }
}
