using BusinessLogicLayer.Services;
using DataAccessLayer.Entities;
using DataAccessLayer;
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
    /// Interaction logic for AddUserWindow.xaml
    /// </summary>
    public partial class AddUserWindow : Window
    {
        private readonly UserService _userService;

        public AddUserWindow()
        {
            InitializeComponent();
            _userService = UserService.GetInstance();
            LoadRolesAndSkinTypes();
        }
        private void LoadRolesAndSkinTypes()
        {
            using (var context = new SkincareProductSystemContext())
            {
                RoleComboBox.ItemsSource = context.Roles.ToList();
                SkinTypeComboBox.ItemsSource = context.TypeOfSkins.ToList();
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(UsernameTextBox.Text) ||
                string.IsNullOrWhiteSpace(FullnameTextBox.Text) ||
                string.IsNullOrWhiteSpace(PasswordBox.Password) ||
                string.IsNullOrWhiteSpace(ConfirmPasswordBox.Password) ||
                GenderComboBox.SelectedItem == null ||
                RoleComboBox.SelectedItem == null ||
                SkinTypeComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string username = UsernameTextBox.Text.Trim();
            if (_userService.IsUsernameExists(username))
            {
                MessageBox.Show("Username already exists. Please choose a different username.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (PasswordBox.Password.Length < 2)
            {
                MessageBox.Show("Password must be at least 6 characters long.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (PasswordBox.Password != ConfirmPasswordBox.Password)
            {
                MessageBox.Show("Passwords do not match.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var newUser = new User
            {
                Username = username,
                Fullname = FullnameTextBox.Text.Trim(),
                Password = PasswordBox.Password.Trim(), 
                Gender = (GenderComboBox.SelectedItem as ComboBoxItem)?.Content.ToString(),
                RoleId = (RoleComboBox.SelectedItem as Role).RoleId,
                TypeOfSkinId = (SkinTypeComboBox.SelectedItem as TypeOfSkin).TypeOfSkinId,
                IsActive = IsActiveCheckBox.IsChecked ?? false
            };

            var result = _userService.Add(newUser);
            if (result != null)
            {
                MessageBox.Show("User added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Failed to add user.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

    }
}
