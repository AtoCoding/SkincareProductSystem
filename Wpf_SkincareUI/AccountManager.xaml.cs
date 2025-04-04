using BusinessLogicLayer.Services;
using DataAccessLayer.Entities;
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

namespace Wpf_SkincareUI
{
    /// <summary>
    /// Interaction logic for AccountManager.xaml
    /// </summary>
    public partial class AccountManager : Window
    {
        private readonly UserService _userService;

        public AccountManager()
        {
            InitializeComponent();
            _userService = UserService.GetInstance();
        }

        private void PrintUsers_Click(object sender, RoutedEventArgs e)
        {
            var users = UserService.GetInstance().GetAll();
            UsersDataGrid.ItemsSource = users;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var addUserWindow = new AddUserWindow();
            if (addUserWindow.ShowDialog() == true)
            {
                var users = _userService.GetAll();
                UsersDataGrid.ItemsSource = users;
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {

            if (UsersDataGrid.SelectedItem == null)
            {
                MessageBox.Show("Please select a user to edit.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var selectedUser = UsersDataGrid.SelectedItem as User;
            if (selectedUser == null)
            {
                MessageBox.Show("Invalid user selected.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var editUserWindow = new EditUserWindow(selectedUser);

            try
            {
                if (editUserWindow.ShowDialog() == true)
                {
                    var users = _userService.GetAll();
                    UsersDataGrid.ItemsSource = users;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error editing user: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (UsersDataGrid.SelectedItem == null)
            {
                MessageBox.Show("Please select a user to delete.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var selectedUser = UsersDataGrid.SelectedItem as User;
            if (selectedUser == null)
            {
                MessageBox.Show("Invalid user selected.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var result = MessageBox.Show($"Are you sure you want to delete user '{selectedUser.Username}'?",
                "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.No)
            {
                return;
            }

            try
            {
                bool deleted = _userService.DeleteByUsername(selectedUser.Username);
                if (deleted)
                {
                    MessageBox.Show("User deleted successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    var users = _userService.GetAll();
                    UsersDataGrid.ItemsSource = users;
                }
                else
                {
                    MessageBox.Show("Failed to delete user.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting user: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            SearchTextBox.Text = string.Empty;
            var users = _userService.GetAll();
            UsersDataGrid.ItemsSource = users;
        }

        private void SearchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                PerformSearch();
            }
        }
        private void PerformSearch()
        {
            try
            {
                string searchTerm = SearchTextBox.Text.Trim();
                var users = _userService.Search(searchTerm);

                if (users == null || !users.Any())
                {
                    MessageBox.Show("No users found.");
                    UsersDataGrid.ItemsSource = null;
                    return;
                }

                UsersDataGrid.ItemsSource = users;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error when searching: {ex.Message}");
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            PerformSearch();
        }


    }
}

