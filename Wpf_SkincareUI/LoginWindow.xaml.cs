using System.Windows;
using BusinessLogicLayer.Services;
using BusinessLogicLayer.Services.IService;
using DataAccessLayer.Entities;

namespace Wpf_SkincareUI
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly IUser _UserService;

        private User? user;

        public LoginWindow()
        {
            InitializeComponent();
            _UserService = UserService.GetInstance();
            user = null;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Password;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Email or password is not correct!");
                return;
            }

            user = _UserService.CheckLogin(txtEmail.Text, txtPassword.Password);

            if (user != null)
            {
                switch(user.RoleId)
                {
                    case 1:
                        {
                            AdminWindow adminWindow = new AdminWindow(user);
                            adminWindow.Show();
                            break;
                        }
                    case 2:
                        {
                            StaffPage staffWindow = new StaffPage(user);
                            staffWindow.Show();
                            break;
                        }
                    default:
                        {
                            HomepageWindow homepageWindow = new HomepageWindow(user, []);
                            homepageWindow.Show();
                            break;
                        }
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Email or password is not correct!");
            }
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Show();
            this.Close();
        }

        private void txtMessage_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            HomepageWindow homepageWindow = new HomepageWindow(null, []);
            homepageWindow.Show();
            this.Close();
        }
    }
}
