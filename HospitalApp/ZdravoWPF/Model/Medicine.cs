using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZdravoWPF.Model
{
    public class Medicine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Alergens { get; set; }
        public string Content { get; set; }

        public Medicine(int id, string name, string description, string alergens, string content)
        {
            Id = id;
            Name = name;
            Description = description;
            Alergens = alergens;
            Content = content;
        }

        public Medicine()
        {
        }
    }
}
