using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZdravoWPF.Model
{
    public class Room
    {
        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public int floor { get; set; }
        public string description { get; set; }
        public Room() {}
        public Room(int id, string name, string type, int floor, string description)
        {
            this.id = id;
            this.name = name;
            this.type = type;
            this.floor = floor;
            this.description = description;
        }

        public override string? ToString()
        {
            return "" + this.id + "," + this.name + "," + this.type + "," + this.floor + "," + this.description;
        }
    }
}
