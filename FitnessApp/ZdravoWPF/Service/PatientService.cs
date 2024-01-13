using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoWPF.Model;
using ZdravoWPF.Repository;

namespace ZdravoWPF.Service
{
    public class PatientService
    {
        private PatientRepository patientRepository = new PatientRepository();
        public List<Patient> GetAll()
        {
            return patientRepository.GetAll();
        }

        public Patient GetById(int id)
        {
            return patientRepository.GetById(id);
        }
        public Patient GetByElementId(int id)
        {
            return patientRepository.GetByElementId(id);
        }

        public bool Save(Patient patient)
        {
            return patientRepository.Save(patient);
        }
        public bool Update(Patient patient, int id)
        {
            return patientRepository.Update(patient, id);
        }

        public bool Delete(int patient)
        {
            return patientRepository.Delete(patient);
        }
    }
}
