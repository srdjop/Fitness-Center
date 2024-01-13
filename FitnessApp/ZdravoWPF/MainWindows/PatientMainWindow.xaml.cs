using Controller;
using Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace ZdravoWPF.MainWindows
{
    /// <summary>
    /// Interaction logic for PatientMainWindow.xaml
    /// </summary>
    public partial class PatientMainWindow : Window
    {
        public ObservableCollection<ExaminationAppointment> pregledi;
        public ExaminationAppointmentRepository examinationrepo = new ExaminationAppointmentRepository();

        public ExaminationAppointmentController examinationcontroller = new ExaminationAppointmentController();

        public PatientMainWindow()
        {
            InitializeComponent();

            pregledi = new ObservableCollection<ExaminationAppointment>(examinationrepo.ListAppointments());
            PatientAppointments.ItemsSource = pregledi;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if ((ExaminationAppointment)PatientAppointments.SelectedItem == null)
            {
                MessageBox.Show("There is no selected appointment");

            }

            else
            {
                ExaminationAppointment objekat = ((ExaminationAppointment)PatientAppointments.SelectedItem);
                examinationcontroller.DeleteAppointment(objekat.Id);
                pregledi.Remove(objekat);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var d = new MakeAnAppointment(pregledi);
            d.Show();
        }

        private void Logout(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
        }
    }
}
