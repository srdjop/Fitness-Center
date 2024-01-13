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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ZdravoWPF.MainWindows;
using ZdravoWPF.Model;
using ZdravoWPF.SecretaryXAML;

namespace ZdravoWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        App application;
        public MainWindow()
        {
            InitializeComponent();
            application = Application.Current as App;
        }

        private void Secretary_Click(object sender, RoutedEventArgs e)
        {
            var secretaryMainWindow = new SecretaryMW();
            secretaryMainWindow.Show();
        }

        private void prepareManagerWindow(Manager m)
        {
            errorMessage.Visibility = Visibility.Hidden;
            ManagerMW win1 = new ManagerMW();
            win1.Show();
        }

        private void LogIn(object sender, RoutedEventArgs e)
        {
            List<Patient> patientsInFile = application.patientController.GetAll();
            List<Doctor> doctorInFile = application.doctorController.GetAll();
            List<Secretary> secInFile = application.secretaryController.GetAll();
            List<Manager> managerInFile = application.managerController.GetAllManager();
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
            foreach (Secretary s in secInFile)
            {
                if (CredentialsMatch(s.User))
                {
                    prepareSecretaryWindow(s);
                    return;
                }
            }
            foreach (Manager m in managerInFile)
            {
                if (CredentialsMatch(m.User))
                {
                    prepareManagerWindow(m);
                    return;
                }
            }
        showError("Korisnicko ime ili lozinka nisu ispravni");

        }

        private void prepareSecretaryWindow(Secretary s)
        {
            errorMessage.Visibility = Visibility.Hidden;
            SecretaryMW win1 = new SecretaryMW();
            win1.Show();
        }

        private void preparePatientWindow(Patient p)
        {
            errorMessage.Visibility = Visibility.Hidden;
            PatientMainWindow win1 = new PatientMainWindow();
            win1.Show();
        }

        private void prepareDoctorWindow(Doctor d)
        {
            errorMessage.Visibility = Visibility.Hidden;
            DoctorMW win1 = new DoctorMW(d);
            win1.Show();
        }

        private void Patient_Click(object sender, RoutedEventArgs e)
        {
            var patientLogin = new login();
            patientLogin.Show();
        }

        private void Doctor_Click(object sender, RoutedEventArgs e)
        {
            var docLogin = new login();
            docLogin.Show();
        }

        private void Manager_Click(object sender, RoutedEventArgs e)
        {
            var managerWindow = new ManagerMW();
            managerWindow.Show();
        }


        private void showError(string message)
        {
            errorMessage.Content = message;
            errorMessage.Visibility = Visibility.Visible;
        }

        private bool CredentialsMatch(User user)
        {
            return user.Username.Equals(usernameTextBox.Text) && user.Password.Equals(passwordTextBox.Password);
        }

    }
}
