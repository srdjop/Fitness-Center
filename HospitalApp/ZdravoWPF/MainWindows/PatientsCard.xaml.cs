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
using ZdravoWPF.Service;

namespace ZdravoWPF.MainWindows
{
    /// <summary>
    /// Interaction logic for PatientsCard.xaml
    /// </summary>
    public partial class PatientsCard : Window
    {
        Patient selectedPatient;
        PatientService patientService = new PatientService();

        Report selectedReport;
        ReportService reportService = new ReportService();

        Medicine med;
        MedicineService medicineService = new MedicineService();
        List<Medicine> medicine;
        public PatientsCard(Patient patient, Report report)
        {
            selectedPatient = patient;
            selectedReport = report;
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            medicine = medicineService.GetAll();

            foreach(Medicine m in medicine)
            {
                cbMedicine.Items.Add(m.Name);
            }
            string[] patientsMedicine = { };

            if (selectedReport.Medicine != "" || selectedReport.Medicine != null)
                if (selectedReport.Medicine.Contains(','))
                {
                    patientsMedicine = selectedReport.Medicine.ToString().Split(',');
                    foreach (string s in patientsMedicine)
                    {
                        lbMedicine.Items.Add(s);
                    }
                }
                else
                    lbMedicine.Items.Add(selectedReport.Medicine);
            


            txtIme.Content = selectedPatient.User.Name;
            txtPrezime.Content = selectedPatient.User.Surname;
            txtDatumRodjenja.Content = selectedPatient.User.DateOfBirth.ToString();
            txtJMBG.Content = selectedPatient.User.Jmbg;

            //============================================//

            txtDetails.Text = selectedReport.Detail;
            txtDifficulties.Text = selectedReport.Difficultie;
            txtDiagnostics.Text = selectedReport.Diagnostics;
            txtPersciption.Text = selectedReport.Perscription;




        }

        private void Izmeni_Informacije(object sender, RoutedEventArgs e)
        {
            if ((bool)chcbEnabled.IsChecked)
            {
                selectedReport.Detail = txtDetails.Text;
                selectedReport.Difficultie = txtDifficulties.Text;
                selectedReport.Diagnostics = txtDiagnostics.Text;
                selectedReport.Perscription = txtPersciption.Text;

                //patientService.Update(selectedPatient, selectedPatient.User.Id);
                reportService.Update(selectedReport, selectedPatient.User.Id);

            }
            else
            {
                MessageBox.Show("Please check enable box.");
            }
            
        }

        private void chcbEnabled_Checked(object sender, RoutedEventArgs e)
        {
            txtDetails.IsEnabled = txtDifficulties.IsEnabled = txtDiagnostics.IsEnabled = txtPersciption.IsEnabled = true;
        }

        private void chcbEnabled_Unchecked(object sender, RoutedEventArgs e)
        {
            txtDetails.IsEnabled = txtDifficulties.IsEnabled = txtDiagnostics.IsEnabled = txtPersciption.IsEnabled = false;
        }

        private void DodajLek(object sender, RoutedEventArgs e)
        {
            if (cbMedicine.SelectedValue != null)
            {
                if (selectedReport.Medicine.Equals(""))
                {
                    selectedReport.Medicine += cbMedicine.Text;
                }
                else
                {
                    selectedReport.Medicine += "," + cbMedicine.Text;
                }
                reportService.Update(selectedReport, selectedPatient.User.Id);


                lbMedicine.Items.Add(cbMedicine.Text);
            }
            else
            {
                MessageBox.Show("Select Medicine to prescript");
            }

        }
    }
}
