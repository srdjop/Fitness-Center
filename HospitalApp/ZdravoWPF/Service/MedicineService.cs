using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoWPF.Model;
using ZdravoWPF.Repository;

namespace ZdravoWPF.Service
{
    public class MedicineService
    {
        private MedicineRepository medicineRepository = new MedicineRepository();
        public List<Medicine> GetAll()
        {
            return medicineRepository.GetAll();
        }

        public Medicine GetById(int id)
        {
            return medicineRepository.GetById(id);
        }

        public void Save(Medicine medicine)
        {
            medicineRepository.Save(medicine);
        }

        public void Delete(int id)
        {
            medicineRepository.Delete(id);
        }

        public void Update(Medicine medicine, int index)
        {
            medicineRepository.Update(medicine, index);
        }
    }
}
