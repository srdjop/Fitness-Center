using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoWPF.Model;
using ZdravoWPF.Service;

namespace ZdravoWPF.Controller
{
    public class EquipmentController
    {
        private EquipmentService equipmentService = new EquipmentService();
        public List<Equipment> GetAll()
        {
            return equipmentService.GetAll();
        }

        public Equipment GetById(int id)
        {
            return equipmentService.GetById(id);
        }

        public void Save(Equipment doctor)
        {
            equipmentService.Save(doctor);
        }

        public void Delete(int id)
        {
            equipmentService.Delete(id);
        }

    }
}
