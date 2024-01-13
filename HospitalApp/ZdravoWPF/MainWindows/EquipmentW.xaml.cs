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
    /// Interaction logic for EquipmentW.xaml
    /// </summary>
    public partial class EquipmentW : Window
    {
        public EquipmentW()
        {
            InitializeComponent();
        }

        DataTable dt;
        DataView dv;
        EquipmentService equipmentService = new EquipmentService();
        EquipmentTransferService equipmentTransfer = new EquipmentTransferService();
        ObservableCollection<Equipment> oc = new ObservableCollection<Equipment>();
        List<Equipment> equipments;
        List<EquipmentTransferQueue> queue;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 1; i < 100; i++)
            {
                cbQuantity.Items.Add(i);
            }

            equipments = equipmentService.GetAll();
            queue = equipmentTransfer.GetAll();
            // Creates Columns for DataTable

            dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Quantity", typeof(int));
            dt.Columns.Add("Location", typeof(string));
            dt.Columns.Add("Type", typeof(string));
            dt.Columns.Add("Relocation Date", typeof(string));
            dt.Columns.Add("Relocation Destionation", typeof(string));

            int counter = 0;
            foreach (Equipment equipment in equipments)
            {

                string[] data = equipment.ToString().Split(',');

                List<string> list = new List<string>(data);
                if (equipmentTransfer.GetByEquipmentId(Convert.ToInt32(data[0])) != null)
                {
                    EquipmentTransferQueue queueElement = equipmentTransfer.GetByEquipmentId(Convert.ToInt32(data[0]));

                    if (queueElement.TransferDate.Equals(DateTime.Today.ToString()))
                    {
                        equipment.Location = queueElement.TransferDestination;
                        equipmentService.Update(equipment, counter);

                        list = new List<string>(equipment.ToString().Split(','));

                        list.Add("XX-XX");
                        list.Add("XX-XX");

                        equipmentTransfer.Delete(queue.IndexOf(queueElement));
                    }
                    else
                    {
                        list.Add(queueElement.TransferDate);
                        list.Add(queueElement.TransferDestination);
                    }
                }
                else
                {
                    list.Add("XX-XX");
                    list.Add("XX-XX");
                }
                var myArray = list.ToArray();
                dt.Rows.Add(myArray);
                oc.Add(equipment);

                //MessageBox.Show(equipment.ToString());
                counter++;
            }

            this.DataContext = oc;

            dv = new DataView(dt);
            dtGrid.ItemsSource = dv;
            dtGrid.SelectionMode = DataGridSelectionMode.Single;
        }

        private void dtGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selectedIndex = Convert.ToInt32(dtGrid.SelectedIndex.ToString());

            DataRow row = dt.Rows[0];
            if (dtGrid.SelectedItem != null)
                row = dt.Rows[selectedIndex];

            cbQuantity.SelectedIndex = Convert.ToInt32(row[2]) - 1;
            cmbRoomType.Text = row[3].ToString();

        }

        private void Add_Equipment_To_Queue(object sender, RoutedEventArgs e)
        {
            if ((dtGrid.SelectedItem != null) && dpTransferDate.SelectedDate != null)
            {
                DataRow firstRow = dt.Rows[0];
                int firstId = Convert.ToInt32(firstRow["ID"]);

                int maxId;
                if (queue.Count > 0)
                {
                    maxId = queue.Max(t => t.Id);
                }
                else
                {
                    maxId = 1;
                }

                int selectedIndex = Convert.ToInt32(dtGrid.SelectedIndex.ToString());

                EquipmentTransferQueue newQueueItem = new EquipmentTransferQueue(maxId + 1, selectedIndex, dpTransferDate.Text, cmbRoomType.Text);


                int selectedId = Convert.ToInt32(dt.Rows[selectedIndex][0]);

                if (newQueueItem.TransferDate.Equals(DateTime.Today.ToString()))
                {
                    dt.Rows[selectedIndex].SetField(3, newQueueItem.TransferDestination);
                    dt.Rows[selectedIndex].SetField(5, "XX-XX");
                    dt.Rows[selectedIndex].SetField(6, "XX-XX");

                    Equipment equipment = equipmentService.GetById(selectedIndex);
                    equipment.Location = newQueueItem.TransferDestination;

                    equipmentService.Update(equipment, selectedIndex);


                }
                else
                {
                    equipmentTransfer.Save(newQueueItem);
                    dt.Rows[selectedIndex].SetField(5, newQueueItem.TransferDate);
                    dt.Rows[selectedIndex].SetField(6, newQueueItem.TransferDestination);
                }
                dtGrid.ItemsSource = null;
                dv = new DataView(dt);
                dtGrid.ItemsSource = dv;
            }
            else
            {
                MessageBox.Show("Select an item from the table");
            }
        }
    }
}

