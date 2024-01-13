using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for ManagerMW.xaml
    /// </summary>
    public partial class ManagerMW : Window
    {

        public ManagerMW()
        {
            InitializeComponent();
        }

        private void Room_Click(object sender, RoutedEventArgs e)
        {
            var RoomW = new RoomW();
            RoomW.Show();
        }
        private void Equipment_Click(object sender, RoutedEventArgs e)
        {
            var EquipmentW = new EquipmentW();
            EquipmentW.Show();
        }
        private void Renovation_Click(object sender, RoutedEventArgs e)
        {
            var RenovationW = new RenovationW();
            RenovationW.Show();
        }

        
    }
}
