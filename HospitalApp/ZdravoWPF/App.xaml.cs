using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ZdravoWPF.Controller;

namespace ZdravoWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public readonly PatientController patientController = new PatientController();
        public readonly DoctorController doctorController = new DoctorController();
        public readonly AppointmentsController appointmentsController = new AppointmentsController();
        public readonly SecretaryController secretaryController = new SecretaryController();
        public readonly ManagerController managerController = new ManagerController();
        public readonly DoctorController doc = new DoctorController();
        public string id;
    }
}
