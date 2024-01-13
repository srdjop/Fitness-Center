using Service;
using System;
using System.Collections.Generic;
using ZdravoWPF.Model;

namespace Controller
{
    public class ExaminationAppointmentController
    {


        public bool CreateAppointment(ExaminationAppointment apointment)
        {
            return examinationAppointmentService.CreateAppointment(apointment);
        }

        public bool DeleteAppointment(String appointmentId)
        {
            return examinationAppointmentService.DeleteAppointment(appointmentId);
        }

        public bool EditAppointment(ExaminationAppointment appointment)
        {
            return examinationAppointmentService.EditAppointment(appointment);
        }



        public ExaminationAppointmentService examinationAppointmentService = new ExaminationAppointmentService();

    }
}
