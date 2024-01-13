using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ZdravoWPF.Model;
using ZdravoWPF.Service;

namespace ZdravoWPF.MainWindows
{
    /// <summary>
    /// Interaction logic for AppointmentW.xaml
    /// </summary>
    public partial class AppointmentW : Window
    {
        public AppointmentW(int ThisDoctorsId)
        {
            LoggedDoctorId = ThisDoctorsId;
            InitializeComponent();
        }

        DataTable dt;
        DataView dv;
        AppointmentService appointmentService = new AppointmentService();
        PatientService patientService = new PatientService();
        ReportService reportService = new ReportService();
        ObservableCollection<Appointment> oc = new ObservableCollection<Appointment>();
        List<Appointment> appointments;
        List<Patient> patients = new List<Patient>();
        Patient selectedPatient;
        Report selectedReport;
        int LoggedDoctorId;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            appointments = appointmentService.GetAll();

            dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Date", typeof(string));
            dt.Columns.Add("Duration", typeof(string));
            dt.Columns.Add("Patient", typeof(string));

            foreach (Appointment appointment in appointments)
            {
                if (LoggedDoctorId == appointment.DoctorId)
                {


                    List<string> data = new List<string>(appointment.ToString().Split(','));
                    List<string> tempData = new List<string>();
                    Patient patient = patientService.GetById(appointment.PatientId);
                    patients.Add(patient);
                    data[4] = patient.User.Name + " " + patient.User.Surname;
                    tempData.Add(data[0]);
                    tempData.Add(data[1]);
                    tempData.Add(data[2]);
                    tempData.Add(patient.User.Name + " " + patient.User.Surname);

                    var filtratedList = tempData.ToArray();
                    dt.Rows.Add(filtratedList);
                    oc.Add(appointment);
                }
            }

            DataContext = oc;
            dv = new DataView(dt);
            dtAppointmentGrid.ItemsSource = dv;
            dtAppointmentGrid.SelectionMode = DataGridSelectionMode.Single;
        }


        private void dtAppointmentGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selectedIndex = Convert.ToInt32(dtAppointmentGrid.SelectedIndex.ToString());

            selectedPatient = patients[selectedIndex];

        }

        private void Otvori_Karton(object sender, RoutedEventArgs e)
        {
            if (dtAppointmentGrid.SelectedItem != null)
            {
                selectedReport = reportService.GetByPatientId(selectedPatient.User.Id);

                var PatientC = new PatientsCard(selectedPatient, selectedReport);
                PatientC.Show();
            }
        }
    }
}
