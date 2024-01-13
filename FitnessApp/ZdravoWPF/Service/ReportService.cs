using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZdravoWPF.Model;
using ZdravoWPF.Repository;

namespace ZdravoWPF.Service
{
    public class ReportService
    {
        private ReportRepository reportRepository = new ReportRepository();
        public List<Report> GetAll()
        {
            return reportRepository.GetAll();
        }

        public Report GetById(int id)
        {
            return reportRepository.GetById(id);
        }

        public Report GetByPatientId(int id)
        {
            return reportRepository.GetByPatientId(id);
        }

        public void Save(Report report)
        {
            reportRepository.Save(report);
        }

        public void Delete(int id)
        {
            reportRepository.Delete(id);
        }

        public void Update(Report report, int index)
        {
            reportRepository.Update(report, index);
        }
    }
}
