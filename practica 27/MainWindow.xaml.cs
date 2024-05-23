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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace practica_27
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            dataGrid.ItemsSource = Users;
        }

        private List<User> Users = new List<User>
        {
            new User { ID = 1, Name = "John Doe", Address = "1234 Elm St", Status = "Active" },
            new User { ID = 2, Name = "Jane Smith", Address = "5678 Oak St", Status = "Inactive" }
        };

        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            var newUser = new User
            {
                ID = int.Parse(IdTextBox.Text),
                Name = NameTextBox.Text,
                Address = AddressTextBox.Text,
                Status = StatusTextBox.Text
            };
            Users.Add(newUser);
            dataGrid.Items.Refresh();
            ClearFields();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Logic for saving to a database or file can be added here
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem is User selectedUser)
            {
                Users.Remove(selectedUser);
                dataGrid.Items.Refresh();
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            int searchId = int.Parse(IdTextBox.Text);
            var user = Users.FirstOrDefault(u => u.ID == searchId);
            if (user != null)
            {
                NameTextBox.Text = user.Name;
                AddressTextBox.Text = user.Address;
                StatusTextBox.Text = user.Status;
            }
            else
            {
                MessageBox.Show("User not found");
            }
        }

        private void ClearFields()
        {
            IdTextBox.Text = string.Empty;
            NameTextBox.Text = string.Empty;
            AddressTextBox.Text = string.Empty;
            StatusTextBox.Text = string.Empty;
        }
    }

    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }
    }
}