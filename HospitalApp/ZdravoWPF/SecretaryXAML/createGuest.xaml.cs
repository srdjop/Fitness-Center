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
using ZdravoWPF.MainWindows;
using ZdravoWPF.Model;

namespace ZdravoWPF.SecretaryXAML
{
    /// <summary>
    /// Interaction logic for createGuest.xaml
    /// </summary>
    public partial class createGuest : Window
    {
        
        App application;
        List<Patient> patients = new List<Patient>();
        Patient selectedPatient;

        public createGuest()
        {
            InitializeComponent();
            application = Application.Current as App;
            patients = application.patientController.GetAll();
           // tb5 = RandomPassword(10);
            

        }
        public string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }
        public int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        public string RandomPassword(int size = 0)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4, true));
            builder.Append(RandomNumber(1000, 9999));
            builder.Append(RandomString(2, false));
            return builder.ToString();
        }

        private void Create(object sender, RoutedEventArgs e)
        {

            // tb3 = RandomPassword(10);
            
            var newPatient = new Patient(tb4.Text, tb3.Text, tb5.Password, tb1.Text, tb2.Text);
            int id = patients.Count + 1;
            int patientId = id;
            newPatient.User.Id = patientId;
            application.patientController.Save(newPatient);
            MessageBox.Show("Successfully created guest patient.");

            tb1.Text = "";
            tb2.Text = "";
            tb3.Text = "";
            tb4.Text = "";
            tb5.Password = "";

        }

        private void Home(object sender, RoutedEventArgs e)
        {
            var secretaryMainWindow = new SecretaryMW();
            secretaryMainWindow.Show();
        }
    }
}
