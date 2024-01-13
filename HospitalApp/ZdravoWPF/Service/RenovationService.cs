using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoWPF.Model;
using ZdravoWPF.Repository;

namespace ZdravoWPF.Service
{
    public class RenovationService
    {
        private RenovationRepository renovationRepository = new RenovationRepository();
        public List<Renovation> GetAll()
        {
            return renovationRepository.GetAll();
        }

        public Renovation GetById(int id)
        {
            return renovationRepository.GetById(id);
        }

        public void Save(Renovation renovation)
        {
            renovationRepository.Save(renovation);
        }

        public void Delete(int id)
        {
            renovationRepository.Delete(id);
        }

        public void Update(Renovation renovation, int index)
        {
            renovationRepository.Update(renovation, index);
        }
    }
}
