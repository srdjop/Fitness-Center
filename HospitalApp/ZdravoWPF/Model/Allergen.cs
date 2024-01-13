using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZdravoWPF.Model
{
    class Allergen
    {
        public int Id { get; set; }
        public int patientId { get; set; }
        public String Name { get; set; }
        public String Details { get; set; }

        public Allergen() { }
        public Allergen(int Id, String Name, String Details)
        {
            this.Id = Id;
            this.Name = Name;
            this.Details = Details;
        }

        public Allergen(int Id, int patientId, String Name, String Details)
        {
            this.Id = Id;
            this.patientId = patientId;
            this.Name = Name;
            this.Details = Details;

        }

        ~Allergen() { }

    }
}
