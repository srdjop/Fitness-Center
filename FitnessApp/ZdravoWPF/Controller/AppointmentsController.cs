using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoWPF.Model;
using ZdravoWPF.Service;

namespace ZdravoWPF.Controller
{
    public class AppointmentsController
    {
        private AppointmentsService appointmentService = new AppointmentsService();

       /* public List<Appointments> ShowAvailableAppointments(Priority priority, String doctorId, DateTime startTime, DateTime endTime)
        {
            List<Appointments> appointments;
           // appointments = appointmentService.ShowAvailableAppointments(priority, doctorId, startTime, endTime);
            return appointments;
        }*/
        public List<Appointments> GetAll()
        {
            return appointmentService.GetAll();
        }

        public Appointments GetById(string id)
        {
            return appointmentService.GetById(id);
        }

        public void Save(Appointments appointment)
        {
            appointmentService.Save(appointment);
        }

        public void Delete(string id)
        {
            appointmentService.Delete(id);
        }

    }
}
