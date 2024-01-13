using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoWPF.Model;
using ZdravoWPF.Repository;

namespace ZdravoWPF.Service
{
    public class SecretaryService
    {
        private SecretaryRepository secretaryRepository = new SecretaryRepository();
        public List<Secretary> GetAll()
        {
            return secretaryRepository.GetAll();
        }

        public Secretary GetById(int id)
        {
            return secretaryRepository.GetById(id);
        }

        public bool Save(Secretary secretary)
        {
            return secretaryRepository.Save(secretary);
        }

        public bool Delete(int patient)
        {
            return secretaryRepository.Delete(patient);
        }
    }
}
