using BusinessLogicLayer.Services;
using BusinessLogicLayer.Services.IService;
using DataAccessLayer;
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
    
    public partial class EditUserWindow : Window
    {
        private readonly UserService _userService;
        private readonly User _userToEdit;

        public EditUserWindow(User user)
        {
            InitializeComponent();
            _userService = UserService.GetInstance();
            _userToEdit = user;
            LoadRolesAndSkinTypes();
            PopulateUserData();
        }
        private void LoadRolesAndSkinTypes()
        {
            using (var context = new SkincareProductSystemContext())
            {
                RoleComboBox.ItemsSource = context.Roles.ToList();
                SkinTypeComboBox.ItemsSource = context.TypeOfSkins.ToList();
            }
        }

        private void PopulateUserData()
        {
            UsernameTextBox.Text = _userToEdit.Username;
            FullnameTextBox.Text = _userToEdit.Fullname;
            PasswordBox.Password = _userToEdit.Password; 
            ConfirmPasswordBox.Password = _userToEdit.Password;
            GenderComboBox.SelectedItem = GenderComboBox.Items.Cast<ComboBoxItem>()
                .FirstOrDefault(item => item.Content.ToString() == _userToEdit.Gender);
            RoleComboBox.SelectedItem = RoleComboBox.Items.Cast<Role>()
                .FirstOrDefault(r => r.RoleId == _userToEdit.RoleId);
            SkinTypeComboBox.SelectedItem = SkinTypeComboBox.Items.Cast<TypeOfSkin>()
                .FirstOrDefault(s => s.TypeOfSkinId == _userToEdit.TypeOfSkinId);
            IsActiveCheckBox.IsChecked = _userToEdit.IsActive;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(FullnameTextBox.Text) ||
                string.IsNullOrWhiteSpace(PasswordBox.Password) ||
                string.IsNullOrWhiteSpace(ConfirmPasswordBox.Password) ||
                GenderComboBox.SelectedItem == null ||
                RoleComboBox.SelectedItem == null ||
                SkinTypeComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (PasswordBox.Password.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters long.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }


            if (PasswordBox.Password != ConfirmPasswordBox.Password)
            {
                MessageBox.Show("Passwords do not match.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            _userToEdit.Fullname = FullnameTextBox.Text.Trim();
            _userToEdit.Password = PasswordBox.Password.Trim();
            _userToEdit.Gender = (GenderComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            _userToEdit.RoleId = (RoleComboBox.SelectedItem as Role).RoleId;
            _userToEdit.TypeOfSkinId = (SkinTypeComboBox.SelectedItem as TypeOfSkin).TypeOfSkinId;
            _userToEdit.IsActive = IsActiveCheckBox.IsChecked ?? false;

            var result = _userService.Update(_userToEdit);
            if (result != null)
            {
                MessageBox.Show("User updated successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Failed to update user.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
