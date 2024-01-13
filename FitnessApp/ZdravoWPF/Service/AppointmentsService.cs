using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoWPF.Model;
using ZdravoWPF.Repository;

namespace ZdravoWPF.Service
{
    public class AppointmentsService
    {
        public AppointmentsRepository appointmentRepository = new AppointmentsRepository();


        public List<Appointments> GetAll()
        {
            return appointmentRepository.GetAll();
        }

        public Appointments GetById(string id)
        {
            return appointmentRepository.GetById(id);
        }

        public void Save(Appointments appointment)
        {
            appointmentRepository.Save(appointment);


        }

        public void Delete(string id)
        {
            appointmentRepository.Delete(id);
        }
        /*public List<Appointments> AppointmentsToCancel(string specialization)
        {
            List<Appointments> appointments = new List<Appointments>();
            appointments = appointmentRepository.GetAll();
            List<Appointments> appsToCancel = new List<Appointments>();
            foreach (var app in appointments)
            {
                if (app.doctor.specialization == specialization)
                {
                    appsToCancel.Add(app);
                }
            }
            return appsToCancel;
        }*/
    }
}
