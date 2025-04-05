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
        private readonly User userToView;
        private readonly IUser _userService;
        public CustomerDetailsWindow(User user, User userToView)
        {
            InitializeComponent();
            _userService = UserService.GetInstance();
            this.user = user;
            this.userToView = userToView;
            LoadInfo();
        }

        private void LoadInfo()
        {
            txtUsername.Text = userToView.Username;
            txtFullname.Text = userToView.Fullname;
            txtGender.Text = userToView.Gender;
            txtRole.Text = userToView.Role.Name;
            txtSkinType.Text = userToView.TypeOfSkin.Name;
            chkIsActive.IsChecked = userToView.IsActive;
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}