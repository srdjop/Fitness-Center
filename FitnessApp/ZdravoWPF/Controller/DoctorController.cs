using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoWPF.Model;
using ZdravoWPF.Service;

namespace ZdravoWPF.Controller
{
    public class DoctorController
    {
        private DoctorService doctorService = new DoctorService();
        public List<Doctor> GetAll()
        {
            return doctorService.GetAll();
        }

        public Doctor GetById(int id)
        {
            return doctorService.GetById(id);
        }

        public void Save(Doctor doctor)
        {
            doctorService.Save(doctor);
        }

        public void Delete(int id)
        {
            doctorService.Delete(id);
        }

    }
}
