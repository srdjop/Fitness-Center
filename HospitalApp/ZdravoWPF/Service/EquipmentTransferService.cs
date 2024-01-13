using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoWPF.Model;
using ZdravoWPF.Repository;

namespace ZdravoWPF.Service
{
    public class EquipmentTransferService
    {
        private EquipmentTransferRepository transferRepository = new EquipmentTransferRepository();
        public List<EquipmentTransferQueue> GetAll()
        {
            return transferRepository.GetAll();
        }

        public EquipmentTransferQueue GetByEquipmentId(int id)
        {
            return transferRepository.GetByEquipmentId(id);
        }

        public void Save(EquipmentTransferQueue transferQueue)
        {
            transferRepository.Save(transferQueue);
        }

        public void Delete(int id)
        {
            transferRepository.Delete(id);
        }

        public void Update(EquipmentTransferQueue transferQueue, int index)
        {
            transferRepository.Update(transferQueue, index);
        }
    }
}
