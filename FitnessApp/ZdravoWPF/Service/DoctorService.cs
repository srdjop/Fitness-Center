using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoWPF.Model;

namespace ZdravoWPF.Service
{
    public class DoctorService
    {
        private Repository.DoctorRepository doctorRepository = new Repository.DoctorRepository();
        public List<Doctor> GetAll()
        {
            return doctorRepository.GetAll();
        }

        public Doctor GetById(int id)
        {
            return doctorRepository.GetById(id);
        }

        public void Save(Doctor doctor)
        {
            doctorRepository.Save(doctor);
        }

        public void Delete(int id)
        {
            doctorRepository.Delete(id);
        }

    }
}
