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

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}