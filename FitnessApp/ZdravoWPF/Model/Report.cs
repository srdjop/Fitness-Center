using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZdravoWPF.Model
{
    public class Report
    {
        public int Id { get; set; }
        public string Detail { get; set; }
        public string Difficultie { get; set; }
        public string Diagnostics { get; set; }
        public string Perscription { get; set; }
        public string Medicine { get; set; }
        public int PatientId { get; set; }

        public Report(int id, string detail, string difficultie, string diagnostics, string perscription, string medicine, int patientId)
        {
            Id = id;
            Detail = detail;
            Difficultie = difficultie;
            Diagnostics = diagnostics;
            Perscription = perscription;
            PatientId = patientId;
            Medicine = medicine;
        }

        public Report()
        {
        }
    }
}
