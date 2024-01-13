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
    /// Interaction logic for createUser.xaml
    /// </summary>
    public partial class createUser : Window
    {
        App application;
        List<Patient> patients = new List<Patient>();
        Patient selectedPatient;

        public createUser()
        {
            InitializeComponent();
            application = Application.Current as App;
            patients = application.patientController.GetAll();

        }

        private void Create(object sender, RoutedEventArgs e)
        {
            var newPatient = new Patient(tb4.Text, tb3.Text, tb5.Password, tb1.Text, tb2.Text, tb6.Text, tb7.Text, tb8.Text, (DateTime)dateofbirth1.SelectedDate);
            int id = patients.Count + 1;
            int patientId = id;
            newPatient.User.Id = patientId;
            application.patientController.Save(newPatient);
            MessageBox.Show("Successfully created user.");

            tb1.Text = "";
            tb2.Text = "";
            tb3.Text = "";
            tb4.Text = "";
            tb5.Password = "";
            tb6.Text = "";
            tb7.Text = "";
            tb8.Text = "";
            dateofbirth1.SelectedDate = default(DateTime);

        }

    }
}
