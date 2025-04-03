﻿using BusinessLogicLayer.Services;
using DataAccessLayer.Entities;
using System.Windows;

namespace Wpf_SkincareUI
{
    /// <summary>
    /// Interaction logic for CustomerDetailsWindow.xaml
    /// </summary>
    public partial class CustomerDetailsWindow : Window
    {
        private readonly User user;
        private readonly UserService _userService;
        public CustomerDetailsWindow(User customer)
        {
            InitializeComponent();
            _userService = new UserService();
            this.user = customer;
            LoadInfo(customer);
        }
        private void LoadInfo(User customer)
        {
            txtUsername.Text = customer.Username;
            txtFullname.Text = customer.Fullname;
            txtGender.Text = customer.Gender;
            txtRole.Text = customer.RoleId.ToString();
            txtSkinType.Text = customer.TypeOfSkinId.ToString();
            chkIsActive.IsChecked = customer.IsActive;

        }
        // Placeholder for Save Changes button
        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            bool changesMade = false;
            var currentCustomer = _userService.GetByUserName(user.Username);
            currentCustomer.Username = txtUsername.Text;
            currentCustomer.Fullname = txtFullname.Text;
            currentCustomer.Gender = txtGender.Text;
            currentCustomer.IsActive = chkIsActive.IsChecked == true;
            currentCustomer.RoleId = int.Parse(txtRole.Text);
            currentCustomer.TypeOfSkinId = int.Parse(txtSkinType.Text);
            // Update the user in the database
            if (_userService.Update(currentCustomer))
            {
                changesMade = true;
            }
            else
            {
                MessageBox.Show("Failed to save changes. Please try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (changesMade)
            {
                MessageBox.Show("Changes saved successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No changes detected or failed to save.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
