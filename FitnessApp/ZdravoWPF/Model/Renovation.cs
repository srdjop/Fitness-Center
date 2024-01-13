using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZdravoWPF.Model
{
    public class Renovation
    {
        public int id { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public string type { get; set; }
        public string location { get; set; }
        public string description { get; set; }
        public Renovation() { }

        public Renovation(int id, string startDate, string endDate, string type, string location, string description)
        {
            this.id = id;
            this.startDate = startDate;
            this.endDate = endDate;
            this.type = type;
            this.location = location;
            this.description = description;
        }

        public override string? ToString()
        {
            return "" + this.id + "," + this.startDate + "," + this.endDate + "," + this.type + "," + this.location + "," + this.description;
        }
    }
}