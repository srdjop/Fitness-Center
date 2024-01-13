using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoWPF.Model;
using ZdravoWPF.Service;

namespace ZdravoWPF.Controller
{
    public class SecretaryController
    {
        private SecretaryService secretaryService = new SecretaryService();

        public List<Secretary> GetAll()
        {
            return secretaryService.GetAll();
        }

        public Secretary GetById(int id)
        {
            return secretaryService.GetById(id);
        }

        public void Save(Secretary secretary)
        {
            secretaryService.Save(secretary);
        }

        public void Delete(int jmbg)
        {
            secretaryService.Delete(jmbg);
        }
    }
}
