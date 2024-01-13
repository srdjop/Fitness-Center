using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZdravoWPF.Model
{
    public class Equipment
    {
        public Equipment()
        {
        }

        public Equipment(int id, string name, int quantity, string location, string type)
        {
            Id = id;
            Quantity = quantity;
            Name = name;
            Location = location;
            Type = type;   
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Location { get; set; }
        public string Type { get; set; }

        public override string? ToString()
        {
            return "" + this.Id + "," + this.Name + "," + this.Quantity + "," + this.Location + "," + this.Type;
        }
    }
}
