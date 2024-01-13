using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZdravoWPF.Model
{
    public class EquipmentTransferQueue
    {
        public EquipmentTransferQueue()
        {
        }

        public EquipmentTransferQueue(int id, int equipmentId, string transferDate, string transferDestination)
        {
            Id = id;
            EquipmentId = equipmentId;
            TransferDate = transferDate;
            TransferDestination = transferDestination;
        }

        public int Id { get; set; }
        public int EquipmentId { get; set; }
        public string TransferDate { get; set; }

        public string TransferDestination { get; set; }

        public override string? ToString()
        {
            return "" + this.Id + "," + this.EquipmentId + "," + this.TransferDate + "," + this.TransferDestination;
        }
    }
}
