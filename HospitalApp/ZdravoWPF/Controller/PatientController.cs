using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoWPF.Model;
using ZdravoWPF.Service;

namespace ZdravoWPF.Controller
{
    public class PatientController
    {
        private PatientService patientService = new PatientService();

        public List<Patient> GetAll()
        {
            return patientService.GetAll();
        }

        public Patient GetById(int id)
        {
            return patientService.GetById(id);
        }

        public void Save(Patient doctor)
        {
            patientService.Save(doctor);
        }

        public void Delete(int jmbg)
        {
            patientService.Delete(jmbg);
        }
    }
}
