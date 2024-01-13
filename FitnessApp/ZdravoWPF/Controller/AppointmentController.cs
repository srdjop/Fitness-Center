using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoWPF.Model;
using ZdravoWPF.Service;

namespace ZdravoWPF.Controller
{
    public class AppointmentController
    {
        private AppointmentService appointmentService = new AppointmentService();
        public List<Appointment> GetAll()
        {
            return appointmentService.GetAll();
        }

        public Appointment GetById(int id)
        {
            return appointmentService.GetById(id);
        }

        public void Save(Appointment appointment)
        {
            appointmentService.Save(appointment);
        }

        public void Delete(int id)
        {
            appointmentService.Delete(id);
        }
    }
}
