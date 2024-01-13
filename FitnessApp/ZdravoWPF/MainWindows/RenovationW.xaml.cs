using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
    /// Interaction logic for RenovationW.xaml
    /// </summary>
    public partial class RenovationW : Window
    {
        DataTable dt;
        DataView dv;
        RenovationService renovationService = new RenovationService();
        ObservableCollection<Renovation> oc = new ObservableCollection<Renovation>();
        List<Renovation> renovations;
        public RenovationW()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            renovations = renovationService.GetAll();

            dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Start Date", typeof(string));
            dt.Columns.Add("End Date", typeof(string));
            dt.Columns.Add("Type", typeof(string));
            dt.Columns.Add("Location", typeof(string));
            dt.Columns.Add("Description", typeof(string));

            foreach (Renovation renovation in renovations)
            {
                dt.Rows.Add(renovation.ToString().Split(','));
                oc.Add(renovation);
            }

            DataContext = oc;
            dv = new DataView(dt);
            dtRenovationGrid.ItemsSource = dv;
            dtRenovationGrid.SelectionMode = DataGridSelectionMode.Single;
        }

        private void MakeRenovation(object sender, RoutedEventArgs e)
        {
            if(dpStartDate.Text != "" && dpEndDate.Text != "" && txtDescription.Text != "")
            {
                int maxId;
                if (renovations.Count > 0)
                {
                    maxId = renovations.Max(t => t.id);
                }
                else
                {
                    maxId = 1;
                }
                Renovation renovation = new Renovation(maxId + 1, dpStartDate.Text, dpEndDate.Text, cmbRenovationType.Text, cmbRoomType.Text, txtDescription.Text);

                dt.Rows.Add(renovation.ToString().Split(','));
                renovationService.Save(renovation);
                dtRenovationGrid.ItemsSource = null;
                dv = new DataView(dt);
                dtRenovationGrid.ItemsSource = dt.DefaultView;
            }
            else
            {
                MessageBox.Show("Insert all necessary data");
            }
        }
    }
}
