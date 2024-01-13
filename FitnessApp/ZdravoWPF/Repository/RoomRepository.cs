using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ZdravoWPF.Model;

namespace ZdravoWPF.Repository
{
    public class RoomRepository
    {
        private readonly string fileLocation = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\rooms.json";//Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\doctors.json";

        private List<Room> rooms = new List<Room>();


        public RoomRepository()
        {
            ReadJson();
        }

        public void ReadJson()
        {
            if (!File.Exists(fileLocation))
            {
                File.Create(fileLocation).Close();
            }

            using (StreamReader r = new StreamReader(fileLocation))
            {
                string json = r.ReadToEnd();
                if (json != "")
                {
                    rooms = JsonConvert.DeserializeObject<List<Room>>(json);
                }
            }
        }
        public void WriteToJson()
        {
            string json = JsonConvert.SerializeObject(rooms);
            File.WriteAllText(fileLocation, json);
        }

        public List<Room> GetAll()
        {
            ReadJson();
            return rooms;
        }

        public Room GetById(int id)
        {
            ReadJson();
            int counter = id;
            int i = 0;
            foreach (Room room in rooms)
            {
                if (i == counter)
                    return room;
                i++;
            }
            return null;
        }
        public void Save(Room room)
        {
            rooms.Add(room);
            WriteToJson();
        }

        public void Delete(int id)
        {
            ReadJson();
            rooms.RemoveAt(id);
            WriteToJson();
        }

        public void Update(Room room, int index)
        {
            ReadJson();
            Room tempRoom = GetById(index);
            tempRoom.name = room.name;
            tempRoom.type = room.type;
            tempRoom.floor = room.floor;
            tempRoom.description = room.description;

            WriteToJson();
        }
    }
}
