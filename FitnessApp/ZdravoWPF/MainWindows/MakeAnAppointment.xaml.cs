using Controller;
using Repository;
using Service;
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
    /// Interaction logic for MakeAnAppointment.xaml
    /// </summary>
    public partial class MakeAnAppointment : Window
    {
        public ExaminationAppointmentController pregledikontroler = new ExaminationAppointmentController();
        public ExaminationAppointmentService preglediservis = new ExaminationAppointmentService();
        public ExaminationAppointmentRepository pregledirepozitorijm = new ExaminationAppointmentRepository();
        public ObservableCollection<ExaminationAppointment> pregledi;
        public MakeAnAppointment(ObservableCollection<ExaminationAppointment> pregledi)
        {
            InitializeComponent();
            this.pregledi = pregledi;

        }
        private ExaminationAppointment ucitaj()
        {
            ExaminationAppointment pregled = new ExaminationAppointment("id", DatePicker.SelectedDate.GetValueOrDefault(), 234, null);
            return pregled;
        }




        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_4(object sender, TextChangedEventArgs e)
        {

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            var s = new PatientMainWindow();
            s.Show();
            Close();


        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {

            ExaminationAppointment pregled = ucitaj();
            preglediservis.CreateAppointment(pregled);
            this.pregledi.Add(pregled);



            Close();
        }
    }
}
