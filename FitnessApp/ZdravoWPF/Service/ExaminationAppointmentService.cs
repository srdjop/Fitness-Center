using Repository;
using System;
using System.Collections.Generic;
using ZdravoWPF.Model;

namespace Service
{


    public class ExaminationAppointmentService
    {
        public ExaminationAppointmentRepository pregled_servis = new ExaminationAppointmentRepository();


        public bool CreateAppointment(ExaminationAppointment apointment_novi)
        {
            List<ExaminationAppointment> termini = pregled_servis.ReadFromFile();
            foreach (ExaminationAppointment i in termini)
            {
                if (i.Id.Equals(apointment_novi.Id))
                {
                    return false;

                }
            }
            termini.Add(apointment_novi);
            pregled_servis.LoadIntoFile(termini);
            return true;
        }

        public bool DeleteAppointment(String appointmentId)
        {
            List<ExaminationAppointment> termini = pregled_servis.ReadFromFile();
            foreach (ExaminationAppointment i in termini)
            {
                if (i.Id.Equals(appointmentId))
                {
                    termini.Remove(i);
                    pregled_servis.LoadIntoFile(termini);
                    return true;
                }
            }
            return false;

        }




        public bool EditAppointment(ExaminationAppointment appointment)
        {
            List<ExaminationAppointment> termini = pregled_servis.ReadFromFile();
            foreach (ExaminationAppointment i in termini)
            {
                if (i.Id.Equals(appointment.Id))
                {

                    termini.Remove(i);
                    termini.Add(appointment);
                    pregled_servis.LoadIntoFile(termini);
                    return true;
                }
            }
            return false;
        }
    }
}
