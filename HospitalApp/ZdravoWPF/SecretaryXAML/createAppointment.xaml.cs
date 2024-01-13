using System;
using System.Collections.Generic;
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

namespace ZdravoWPF.SecretaryXAML
{
    /// <summary>
    /// Interaction logic for createAppointment.xaml
    /// </summary>
    public partial class createAppointment : Window
    {

      /*  App application;
        public createAppointment()
        {
            InitializeComponent();
            application = Application.Current as App;
            List<Doctor> doctors = new List<Doctor>();
            doctors = application.doctorController.GetAll();
            List<Patient> patients = new List<Patient>();
            patients = application.patientController.GetAll();
            foreach (Doctor doctor in doctors)
            {
                cbdoctor.Items.Add(doctor.User.Jmbg);
            }
            foreach (Patient patient in patients)
            {
                cbpatient.Items.Add(patient.User.Jmbg);
            }
        }
        private void viewappointmentsbtn_Click(object sender, RoutedEventArgs e)
        {
            if (cbdoctor.SelectedItem == null)
            {
                MessageBox.Show("You have to choose a doctor to view possible appointments!");
            }
            else if (cbpatient.SelectedItem == null)
            {
                MessageBox.Show("You have to choose a patient to view possible appointments!");
            }
            else
            {
                if (rbdoctor.IsChecked == false && rbtime.IsChecked == false)
                {
                    Priority priority = Priority.None;
                    Doctor doctor = (Doctor)application.doctorController.GetById(Convert.ToInt32(cbdoctor.SelectedItem));
#pragma warning disable CS8629 // Nullable value type may be null.
                    DateTime begin = (DateTime)dpbegin.SelectedDate;
#pragma warning restore CS8629 // Nullable value type may be null.
                    DateTime end = (DateTime)dpend.SelectedDate;
                    Patient patient = (Patient)application.patientController.GetById(Convert.ToInt32(cbpatient.SelectedItem));
                   // AppointmentType type = (AppointmentType)cbtype.SelectedItem;
                    List<Appointments> possibleAppointments = application.appointmentsController.ShowAvailableAppointments(priority, doctor.User.Jmbg, begin, end);
                    foreach (Appointment a in possibleAppointments)
                    {
                        a.patient = patient;
                    }
                    Window pickAppointments = new PossibleAppointments(possibleAppointments);
                    pickAppointments.ShowDialog();
                }
                else if (rbdoctor.IsChecked == true && rbtime.IsChecked == false)
                {
                    Priority priority = Priority.Doctor;
                    Doctor doctor = (Doctor)MainWindow.doctorController.ds.dr.GetByID(cbdoctor.SelectedItem.ToString());
                    DateTime begin = (DateTime)dpbegin.SelectedDate;
                    DateTime end = (DateTime)dpend.SelectedDate;
                    Patient patient = (Patient)MainWindow.patientController.GetByID(cbpatient.SelectedItem.ToString());
                    AppointmentType type = (AppointmentType)cbtype.SelectedItem;
                    List<Appointment> possibleAppointments = MainWindow.appointmentController.appointmentService.ShowAvailableAppointments(priority, doctor.user.Jmbg1, begin, end, type);
                    foreach (Appointment a in possibleAppointments)
                    {
                        a.patient = patient;
                    }
                    Window pickAppointments = new PossibleAppointments(possibleAppointments);
                    pickAppointments.ShowDialog();
                }
                else
                {
                    Priority priority = Priority.Date;
                    Doctor doctor = (Doctor)MainWindow.doctorController.ds.dr.GetByID(cbdoctor.SelectedItem.ToString());
                    DateTime begin = (DateTime)dpbegin.SelectedDate;
                    DateTime end = (DateTime)dpend.SelectedDate;
                    Patient patient = (Patient)MainWindow.patientController.GetByID(cbpatient.SelectedItem.ToString());
                    AppointmentType type = (AppointmentType)cbtype.SelectedItem;
                    List<Appointment> possibleAppointments = MainWindow.appointmentController.appointmentService.ShowAvailableAppointments(priority, doctor.user.Jmbg1, begin, end, type);
                    foreach (Appointment a in possibleAppointments)
                    {
                        a.patient = patient;
                    }
                    Window pickAppointments = new PossibleAppointments(possibleAppointments);
                    pickAppointments.ShowDialog();
                }
            }
        }*/

    }
}
