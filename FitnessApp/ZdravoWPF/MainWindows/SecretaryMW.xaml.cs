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
using ZdravoWPF.SecretaryXAML;

namespace ZdravoWPF.MainWindows
   
{
    /// <summary>
    /// Interaction logic for SecretaryMW.xaml
    /// </summary>
    public partial class SecretaryMW : Window
    {

        public SecretaryMW()
        {
            InitializeComponent();
        }
        
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            createUser cu = new createUser();
            this.Hide();
            cu.Show();
            this.Close();
        }
        

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            updateDeleteUser ud = new updateDeleteUser();
            this.Hide();
            ud.Show();
            this.Close();
        }

        
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            createGuest gu = new createGuest();
            this.Hide();
            gu.Show();
            this.Close();

        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            appointment ap = new appointment();
            this.Hide();
            ap.Show();
            this.Close();
        }

    }
}
