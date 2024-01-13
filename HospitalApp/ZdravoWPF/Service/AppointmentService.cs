using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoWPF.Model;
using ZdravoWPF.Repository;

namespace ZdravoWPF.Service
{
    public class AppointmentService
    {
        private AppointmentRepository appointmentRepository = new AppointmentRepository();
        public List<Appointment> GetAll()
        {
            return appointmentRepository.GetAll();
        }

        public Appointment GetById(int id)
        {
            return appointmentRepository.GetById(id);
        }

        public void Save(Appointment appointment)
        {
            appointmentRepository.Save(appointment);
        }

        public void Delete(int id)
        {
            appointmentRepository.Delete(id);
        }

        public void Update(Appointment appointment, int index)
        {
            appointmentRepository.Update(appointment, index);
        }
    }
}
