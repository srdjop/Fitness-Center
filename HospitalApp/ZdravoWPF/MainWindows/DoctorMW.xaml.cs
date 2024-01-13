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

namespace ZdravoWPF.MainWindows
{
    /// <summary>
    /// Interaction logic for DoctorMW.xaml
    /// </summary>
    public partial class DoctorMW : Window
    {
        int loggedDoctorsId;
        public DoctorMW(Doctor d)
        {
            loggedDoctorsId = d.User.Id;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
        }

        private void OpenAppointmentsW(object sender, RoutedEventArgs e)
        {
            var AppointmentWindow = new AppointmentW(loggedDoctorsId);
            AppointmentWindow.Show();
        }
    }
}
