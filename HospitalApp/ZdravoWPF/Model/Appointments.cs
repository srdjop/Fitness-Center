using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ZdravoWPF.Model
{
    public class Appointments
    {
        private string text;
        private DateTime selectedDate;
        private int v1;
        private int v2;
        private int v3;

        public String Id { get; set; }
       public DateTime date { get; set; } 
        public DateTime StartTime { get; set; }

        public DateTime FinishTime { get; set; }
        public int Duration { get; set; }    
        public String Type { get; set; }

        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }

        public Appointments()
        {

        }
        public Appointments(String newId, DateTime newStartTime, int newDuration, int hours, int minutes)
        {
            int day = newStartTime.Day;
            int month = newStartTime.Month;
            int year = newStartTime.Year;
            DateTime NewStart = new DateTime(year, month, day, hours, minutes, 0);
            this.Id = newId;
            this.StartTime = newStartTime;
            this.Duration = newDuration;
        }

        public Appointments(string text, DateTime selectedDate, int newDuration)
        {
            this.Id = text;
            this.StartTime = selectedDate;
            this.Duration  = newDuration;
        }

        public Appointments(DateTime selectedDate, int v1, int v2, int v3)
        {
            int day = selectedDate.Day;
            int month = selectedDate.Month;
            int year = selectedDate.Year;
            DateTime NewStart = new DateTime(year, month, day, v2, v3, 0);
            this.StartTime = NewStart;
            this.Duration = v1;
        }


        /*public Appointments(String newId, DateTime newStartTime, Double newDuration, int hours, int minutes)
        {
            int day = newStartTime.Day;
            int month = newStartTime.Month;
            int year = newStartTime.Year;
            DateTime NewStart = new DateTime(year, month, day, hours, minutes, 0);
            this.Id = newId;
            this.StartTime = NewStart;
            this.Duration = newDuration;
            this.FinishTime = StartTime.AddMinutes(Duration);
        }
        public Appointments(String newId, DateTime newStartTime, int newDuration, int hours, int minutes, Doctor doctor, Patient patient)
        {
            int day = newStartTime.Day;
            int month = newStartTime.Month;
            int year = newStartTime.Year;
            DateTime NewStart = new DateTime(year, month, day, hours, minutes, 0);
            this.Id = newId;
            this.StartTime = NewStart;
            this.Duration = newDuration;
            this.FinishTime = StartTime.AddMinutes(Duration);
            this.Doctor = doctor;
            this.Patient = patient;
        }*/
    }
}
