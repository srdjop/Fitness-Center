using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoWPF.Model;
using ZdravoWPF.Service;

namespace ZdravoWPF.Controller
{
    public class EquipmentTransferController
    {
        private EquipmentTransferService transferService = new EquipmentTransferService();
        public List<EquipmentTransferQueue> GetAll()
        {
            return transferService.GetAll();
        }

        public EquipmentTransferQueue GetByEquipmentId(int id)
        {
            return transferService.GetByEquipmentId(id);
        }

        public void Save(EquipmentTransferQueue doctor)
        {
            transferService.Save(doctor);
        }

        public void Delete(int id)
        {
            transferService.Delete(id);
        }

    }
}
