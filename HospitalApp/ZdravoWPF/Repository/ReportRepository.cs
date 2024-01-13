using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoWPF.Model;

namespace ZdravoWPF.Repository
{
    public class ReportRepository
    {
        private readonly string fileLocation = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\reports.json";//Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\doctors.json";
        private List<Report> reports = new List<Report>();


        public ReportRepository()
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
                    reports = JsonConvert.DeserializeObject<List<Report>>(json);
                }
            }
        }
        public void WriteToJson()
        {
            string json = JsonConvert.SerializeObject(reports);
            File.WriteAllText(fileLocation, json);
        }

        public List<Report> GetAll()
        {
            ReadJson();
            return reports;
        }

        public Report GetById(int id)
        {
            ReadJson();
            int counter = id;
            int i = 0;
            foreach (Report report in reports)
            {
                if (i == counter)
                    return report;
                i++;
            }
            return null;
        }
        public Report GetByPatientId(int id)
        {
            ReadJson();
            foreach (Report report in reports)
            {
                if (report.PatientId == id)
                    return report;

            }


            // in case there is no report for particular patient
            int maxId;
            if (reports.Count > 0)
            {
                maxId = reports.Max(t => t.Id);
            }
            else
            {
                maxId = 0;
            }


            Report newReport = new Report(maxId+1, "","","","","", id);
            Save(newReport);
            WriteToJson();
            return newReport;
        }
        public void Save(Report report)
        {
            reports.Add(report);
            WriteToJson();
        }

        public void Delete(int id)
        {
            ReadJson();
            reports.RemoveAt(id);
            WriteToJson();
        }

        public void Update(Report report, int index)
        {
            ReadJson();
            Report tempReport = GetByPatientId(index);
            tempReport.Detail = report.Detail;
            tempReport.Difficultie = report.Difficultie;
            tempReport.Diagnostics = report.Diagnostics;
            tempReport.Perscription = report.Perscription;
            tempReport.Medicine = report.Medicine;
            tempReport.PatientId = report.PatientId;

            WriteToJson();
        }
    }
}
