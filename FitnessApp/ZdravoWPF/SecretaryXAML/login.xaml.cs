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
using ZdravoWPF.Controller;
using ZdravoWPF.MainWindows;

namespace ZdravoWPF.SecretaryXAML
{
    /// <summary>
    /// Interaction logic for login.xaml
    /// </summary>
    public partial class login : Window
    {

        App application;
        List<Patient> patients = new List<Patient>();
        List<Doctor> doctors = new List<Doctor>();
        List<Manager> managers = new List<Manager>();
        public login()
        {
            InitializeComponent();
            application = Application.Current as App;
            patients = application.patientController.GetAll();
        }
        private Boolean CredentialsMatch(User user)
        {
            return user.Username.Equals(usernameTextBox.Text) && user.Password.Equals(passwordTextBox.Password);
        }
        private void preparePatientWindow(Patient p)
        {
            errorMessage.Visibility = Visibility.Hidden;
            PatientMainWindow win = new PatientMainWindow();
            win.Show();
        }
        private void prepareDoctorWindow(Doctor d)
        {
            errorMessage.Visibility = Visibility.Hidden;
            DoctorMW win1 = new DoctorMW(d);
            win1.Show();
        }

        private void LogIn(object sender, RoutedEventArgs e)
        {
            List<Patient> patientsInFile = application.patientController.GetAll();
            List<Doctor> doctorInFile = application.doctorController.GetAll();
            foreach (Patient p in patientsInFile)
            {
                if (CredentialsMatch(p.User))
                {
                        preparePatientWindow(p);
                        return;
                }
            }
            foreach (Doctor d in doctorInFile)
            {
                if (CredentialsMatch(d.User))
                {
                    prepareDoctorWindow(d);
                    return;
                }
            }

            showError("Korisnicko ime ili lozinka nisu ispravni");
        }
        private void showError(String message)
        {
            errorMessage.Content = message;
            errorMessage.Visibility = Visibility.Visible;
        }
    }
}
