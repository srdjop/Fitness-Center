using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoWPF.Model;
using ZdravoWPF.Repository;

namespace ZdravoWPF.Service
{
    public class EquipmentService
    {
        private EquipmentRepository equipmentRepository = new EquipmentRepository();
        public List<Equipment> GetAll()
        {
            return equipmentRepository.GetAll();
        }

        public Equipment GetById(int id)
        {
            return equipmentRepository.GetById(id);
        }

        public void Save(Equipment equipment)
        {
            equipmentRepository.Save(equipment);
        }

        public void Delete(int id)
        {
            equipmentRepository.Delete(id);
        }

        public void Update(Equipment equipment, int index)
        {
            equipmentRepository.Update(equipment, index);
        }
    }
}
