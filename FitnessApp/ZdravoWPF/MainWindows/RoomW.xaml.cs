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
    public partial class RoomW : Window
    {

        public RoomW()
        {
            InitializeComponent();
        }

        DataTable dt;
        DataView dv;
        RoomService roomService = new RoomService();

        ObservableCollection<Room> oc = new ObservableCollection<Room>();
        List<Room> rooms;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            rooms = roomService.GetAll();
            // Creates Columns for DataTable

            dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Room Name", typeof(string));
            dt.Columns.Add("Room Type", typeof(string));
            dt.Columns.Add("Floor", typeof(int));
            dt.Columns.Add("Description", typeof(string));

            foreach (Room room in rooms)
            {
                dt.Rows.Add(room.ToString().Split(','));
                oc.Add(room);

                //MessageBox.Show(room.ToString());
            }

            this.DataContext = oc;

            dv = new DataView(dt);
            dtGrid.ItemsSource = dv;
            dtGrid.SelectionMode = DataGridSelectionMode.Single;
        }

        private void CreateRoom_Click(object sender, RoutedEventArgs e)
        {
            if (!Regex.IsMatch(txtRoomName.Text, @"^(?!\s*$).+") || !Regex.IsMatch(txtDescription.Text, @"^(?!\s*$).+")) //Check Not Empty String 
            {
                MessageBox.Show("Fill all inputs!");
            }
            else
            {


                DataRow firstRow = dt.Rows[0];
                int firstId = Convert.ToInt32(firstRow["ID"]);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow row = dt.Rows[i];
                    int compareId = Convert.ToInt32(row["ID"]);
                    if (compareId > firstId)
                    {
                        firstId = compareId;
                    }
                }


                Room newRoom = new Room(firstId + 1, txtRoomName.Text, cmbRoomType.Text, cmbFloor.SelectedIndex + 1, txtDescription.Text);

                string tempRoomData = newRoom.id.ToString() + ',' + newRoom.name.ToString() + ',' + newRoom.type.ToString() + ',' + newRoom.floor + ',' + newRoom.description.ToString();

                roomService.Save(newRoom);

                dt.Rows.Add(tempRoomData.Split(','));
                dv = new DataView(dt);

                List<string> tempRoomDataList = new List<string>();
                tempRoomDataList.Add(tempRoomData);
            }
        }

        private void DeleteRoom_Click(object sender, RoutedEventArgs e)
        {
            if (dtGrid.SelectedItem != null)
            {
                roomService.Delete(Convert.ToInt32(dtGrid.SelectedIndex.ToString()));
                dt.Rows.Remove(dt.Rows[Convert.ToInt32(dtGrid.SelectedIndex.ToString())]);

                dtGrid.ItemsSource = null;
                dv = new DataView(dt);
                dtGrid.ItemsSource = dv;
            }
            else
            {
                MessageBox.Show("Select an item from the table");
            }

        }

        private void UpdateRoom_Click(object sender, RoutedEventArgs e)
        {
            if (dtGrid.SelectedItem != null)
            {
                int selectedIndex = Convert.ToInt32(dtGrid.SelectedIndex.ToString());
                int selectedId = Convert.ToInt32(dt.Rows[selectedIndex][0]);
                Room newRoom = new Room(selectedId, txtRoomName.Text, cmbRoomType.Text, cmbFloor.SelectedIndex + 1, txtDescription.Text);
                roomService.Update(newRoom, selectedIndex);


                dt.Rows[selectedIndex].SetField(1, txtRoomName.Text);
                dt.Rows[selectedIndex].SetField(2, cmbRoomType.Text);
                dt.Rows[selectedIndex].SetField(3, cmbFloor.SelectedIndex + 1);
                dt.Rows[selectedIndex].SetField(4, txtDescription.Text);

                dtGrid.ItemsSource = null;
                dv = new DataView(dt);
                dtGrid.ItemsSource = dv;

            }
            else
            {
                MessageBox.Show("Select an item from the table");
            }
        }

        private void dtGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selectedIndex = Convert.ToInt32(dtGrid.SelectedIndex.ToString());
            if (selectedIndex > dt.Rows.Count)              // Trying to set inputs to empty string or default if
            {                                               // selected grid table element is empty or does not exist
                txtRoomName.Text = "";
                txtDescription.Text = "";
                cmbRoomType.SelectedIndex = 0;
                cmbFloor.SelectedIndex = 0;
                MessageBox.Show("Select an item from the table");
            }
            else
            {
                DataRow row = dt.Rows[0];
                if (dtGrid.SelectedItem != null)
                    row = dt.Rows[selectedIndex];

                txtRoomName.Text = row[1].ToString();
                txtDescription.Text = row[4].ToString();

                int cmbSelectedIndex = 0;

                switch (row[2].ToString())
                {
                    case "Operation Room":
                        cmbSelectedIndex = 0;
                        break;

                    case "Resting Room":
                        cmbSelectedIndex = 1;
                        break;

                    case "Waiting Room":
                        cmbSelectedIndex = 2;
                        break;

                    case "Checkup Room":
                        cmbSelectedIndex = 3;
                        break;

                    case "Laboratory":
                        cmbSelectedIndex = 4;
                        break;

                    case "Intensive Care":
                        cmbSelectedIndex = 5;
                        break;

                    case "Emergency Room":
                        cmbSelectedIndex = 6;
                        break;
                }


                cmbRoomType.SelectedIndex = cmbSelectedIndex;
                cmbFloor.SelectedIndex = Convert.ToInt32(row[3]) - 1;
            }
        }
    }
}
