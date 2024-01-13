using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoWPF.Model;
using ZdravoWPF.Service;

namespace ZdravoWPF.Controller
{
    public class ManagerController
    {
        private RoomService managerService = new RoomService();
        public List<Room> GetAll()
        {
            return managerService.GetAll();
        }

        public Room GetById(int id)
        {
            return managerService.GetById(id);
        }

        public void Save(Room doctor)
        {
            managerService.Save(doctor);
        }

        public void Delete(int id)
        {
            managerService.Delete(id);
        }

        public List<Manager> GetAllManager()
        {
            return managerService.GetAllManager();
        }

    }
}
