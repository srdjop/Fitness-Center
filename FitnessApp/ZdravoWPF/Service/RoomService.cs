using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoWPF.Model;
using ZdravoWPF.Repository;

namespace ZdravoWPF.Service
{
    public class RoomService
    {
        private RoomRepository roomRepository = new RoomRepository();
        private ManagerRepository managerRepository = new ManagerRepository();
        public List<Room> GetAll()
        {
            return roomRepository.GetAll();
        }

        public Room GetById(int id)
        {
            return roomRepository.GetById(id);
        }

        public void Save(Room room)
        {
            roomRepository.Save(room);
        }

        public void Delete(int id)
        {
            roomRepository.Delete(id);
        }

        public void Update(Room room, int index)
        {
            roomRepository.Update(room, index); 
        }

        public List<Manager> GetAllManager()
        {
            return managerRepository.GetAll();
        }
    }
}
