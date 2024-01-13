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
    /// Interaction logic for updateDeleteUser.xaml
    /// </summary>
    public partial class updateDeleteUser : Window
    {
        App application;
        List<Patient> patients = new List<Patient>();
        Patient selectedPatient;
        public updateDeleteUser()
        {
            InitializeComponent();
            application = Application.Current as App;
            patients = application.patientController.GetAll();
            DataBinding1.ItemsSource = patients;

            var usersNew = application.patientController.GetAll();
            DataBinding1.ItemsSource = usersNew;
        }

        private void Update1(object sender, RoutedEventArgs e)
        {

            int patientId = selectedPatient.User.Id;
            application.patientController.Delete(patientId);
            var newPatient = new Patient(tb4.Text, tb3.Text, tb5.Text, tb1.Text, tb2.Text, tb6.Text, tb7.Text, tb8.Text, (DateTime)dateofbirth1.SelectedDate);
            newPatient.User.Id = patientId;
            application.patientController.Save(newPatient);
            MessageBox.Show("Successfully updated user");

            tb1.Text = "";
            tb2.Text = "";
            tb3.Text = "";
            tb4.Text = "";
            tb5.Text = "";
            tb6.Text = "";
            tb7.Text = "";
            tb8.Text = "";
            dateofbirth1.SelectedDate = default(DateTime);
        }

        private void Show(object sender, RoutedEventArgs e)
        {
            var usersNew = application.patientController.GetAll();
            DataBinding1.ItemsSource = usersNew;
        }

        private void Select(object sender, RoutedEventArgs e)
        {
            selectedPatient = (Patient)DataBinding1.SelectedItem;
            tb1.Text = selectedPatient.User.Name;
            tb2.Text = selectedPatient.User.Surname;
            tb3.Text = selectedPatient.User.Username;
            tb4.Text = selectedPatient.User.Jmbg;
            tb5.Text = selectedPatient.User.Password;
            tb6.Text = selectedPatient.User.Email;
            tb7.Text = selectedPatient.User.Address;
            tb8.Text = selectedPatient.User.Phone;
            dateofbirth1.SelectedDate = selectedPatient.User.DateOfBirth;
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            application.patientController.Delete(selectedPatient.User.Id);
            MessageBox.Show("Successfully delete user");

            tb1.Text = "";
            tb2.Text = "";
            tb3.Text = "";
            tb4.Text = "";
            tb5.Text = "";
            tb6.Text = "";
            tb7.Text = "";
            tb8.Text = "";
            dateofbirth1.SelectedDate = default(DateTime);
        }
    }
}
