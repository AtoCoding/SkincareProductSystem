using System.ComponentModel.DataAnnotations;
using System.Windows;
using BusinessLogicLayer.Services;
using BusinessLogicLayer.Services.IService;
using DataAccessLayer.Entities;

namespace Wpf_SkincareUI
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        private readonly IUser _UserService;

        public RegisterWindow()
        {
            InitializeComponent();
            _UserService = UserService.GetInstance();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            User user = new()
            {
                Username = txtUsername.Text,
                Password = txtPassword.Password,
                Fullname = txtFullName.Text,
                Gender = new[] {rbMale, rbFemale}.FirstOrDefault(r => r.IsChecked == true)?.Content.ToString() ?? string.Empty
            };

            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(user);

            bool isValid = Validator.TryValidateObject(user, context, validationResults, true);

            if (!isValid)
            {
                string errorMessages = string.Join("\n", validationResults.Select(e => e.ErrorMessage));
                MessageBox.Show(errorMessages, "Validation Errors", MessageBoxButton.OK, MessageBoxImage.Warning);
            } 
            else if (!user.Password.Equals(txtConfirmPassword.Password))
            {
                MessageBox.Show("Confirm passwords are not the same!", "Validation Errors", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                bool isSuccess = _UserService.RegisterNewAccount(user);
                if (isSuccess)
                {
                    MessageBox.Show("Register successfully!");
                    HomepageWindow homepageWindow = new HomepageWindow(user, []);
                    homepageWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Register failed!");
                }
            }
        }

        private void btnBackToLogin_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }
    }
}
