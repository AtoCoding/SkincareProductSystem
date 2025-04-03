using BusinessLogicLayer.Services;
using BusinessLogicLayer.Services.IService;
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
        private readonly IUser _userService;
        public CustomerDetailsWindow(User customer)
        {
            InitializeComponent();
            _userService = UserService.GetInstance();
            this.user = customer;
            LoadInfo(customer);
        }

        private void LoadInfo(User customer)
        {
            txtUsername.Text = customer.Username;
            txtFullname.Text = customer.Fullname;
            txtGender.Text = customer.Gender;
            txtRole.Text = customer.Role.Name;
            txtSkinType.Text = customer.TypeOfSkin.Name;
            chkIsActive.IsChecked = customer.IsActive;

        }
        // Placeholder for Save Changes button
        //private void SaveChanges_Click(object sender, RoutedEventArgs e)
        //{
        //    bool changesMade = false;
        //    var currentCustomer = _userService.GetByUserName(user.Username);
        //    currentCustomer.Username = txtUsername.Text;
        //    currentCustomer.Fullname = txtFullname.Text;
        //    currentCustomer.Gender = txtGender.Text;
        //    currentCustomer.IsActive = chkIsActive.IsChecked == true;
        //    currentCustomer.Role.Name = txtRole.Text;
        //    currentCustomer.TypeOfSkin.Name = txtSkinType.Text;
        //    // Update the user in the database
        //    if (_userService.Update(currentCustomer))
        //    {
        //        changesMade = true;
        //    }
        //    else
        //    {
        //        MessageBox.Show("Failed to save changes. Please try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        //    }

        //    if (changesMade)
        //    {
        //        MessageBox.Show("Changes saved successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        //    }
        //    else
        //    {
        //        MessageBox.Show("No changes detected or failed to save.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
        //    }
        //}

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}