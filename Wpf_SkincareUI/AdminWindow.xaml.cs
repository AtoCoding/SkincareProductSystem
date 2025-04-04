using BusinessLogicLayer.Services;
using BusinessLogicLayer.Services.Bases;
using BusinessLogicLayer.Services.IService;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Wpf_SkincareUI
{
    public partial class AdminWindow : Window
    {

        private readonly UserService _userService;

        public AdminWindow(User user)
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

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            SearchTextBox.Text = string.Empty;
            var users = _userService.GetAll();
            UsersDataGrid.ItemsSource = users;
        }

        private void PerformSearch(object sender, RoutedEventArgs e)
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

        private void PrintProducts_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RefreshProducts_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PerformProductSearch(object sender, RoutedEventArgs e)
        {

        }

        private void SearchProductTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void SearchOrderTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void PerformOrderSearch(object sender, RoutedEventArgs e)
        {

        }

        private void PrintOrders_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddOrder_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RefreshOrders_Click(object sender, RoutedEventArgs e)
        {

        }
        private void ViewOrder_Click(object sender, RoutedEventArgs e)
        {

        }
        private void DeleteOrder_Click(object sender, RoutedEventArgs e)
        {

        }
        private void EditProduct_Click(object sender, RoutedEventArgs e)
        {

        }
        private void DeleteProduct_Click(object sender, RoutedEventArgs e)
        {

        }
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {

        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}