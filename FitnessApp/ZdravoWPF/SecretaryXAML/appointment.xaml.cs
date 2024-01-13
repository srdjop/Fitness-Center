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
    /// Interaction logic for appointment.xaml
    /// </summary>
    public partial class appointment : Window
    {

        App application;
        List<Appointments> appointments = new List<Appointments>();
        List<Patient> patient = new List<Patient>();
        List<Doctor> doctor = new List<Doctor>();
        Appointments selectedAppointment;

        public appointment()
        {
            InitializeComponent();
            application = Application.Current as App;
            appointments = application.appointmentsController.GetAll();
            lvDataBinding3.ItemsSource = doctor;

            var usersNew = application.appointmentsController.GetAll();
            lvDataBinding3.ItemsSource = usersNew;
        }

        private void Add_appointment(object sender, RoutedEventArgs e)
        {
            /*var doc = application.doctorController.GetById(textBox5.Text);
            var pat = application.patientController.GetById(textBox6.Text);
            Appointments a = new Appointments(textBox1.Text, (DateTime)datum.SelectedDate, Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text), doc, pat);
            application.appointmentsController.Save(a);
            */
            createAppointment sec = new createAppointment();
            sec.Show();
        
        }

        private void View_appointments(object sender, RoutedEventArgs e)
        {
            appointments = application.appointmentsController.GetAll();
            lvDataBinding3.ItemsSource = appointments;
        }

        private void Select(object sender, RoutedEventArgs e)
        {
            selectedAppointment = (Appointments)lvDataBinding3.SelectedItem;
            textBox1.Text = selectedAppointment.Id;
            datummm.SelectedDate = selectedAppointment.StartTime;
            textBox2.Text = selectedAppointment.Duration.ToString();
            textBox5.Text = selectedAppointment.Doctor.User.Id.ToString();
            textBox6.Text = selectedAppointment.Patient.User.Id.ToString();
        }

        private void Update_appointment(object sender, RoutedEventArgs e)
        {

            appointments = application.appointmentsController.GetAll();

            foreach (var app in appointments) {
                string appointmentId = selectedAppointment.Id;
                Doctor doctor = selectedAppointment.Doctor;
                Patient patient = selectedAppointment.Patient;
                
                application.appointmentsController.Delete(appointmentId);

                var newAppointment = new Appointments((DateTime)datummm.SelectedDate, Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text))
                {
                    Id = appointmentId,
                    Patient = patient,
                    Doctor = doctor
                };


                application.appointmentsController.Save(newAppointment);
                MessageBox.Show("Successfully updated user");

                /*textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
               // datummm.SelectedDate = default(DateTime);
                */
            }
        }

        private void Delete_appointment(object sender, RoutedEventArgs e)
        {
            appointments = application.appointmentsController.GetAll();
            foreach (var app in appointments)
            {
                if (app.Id == textBox1.Text)
                {
                    application.appointmentsController.Delete(app.Id);
                    break;
                }
            }
            textBox1.Text = "";
            MessageBox.Show("Successfully deleted appointment!");
        }

    }
}
