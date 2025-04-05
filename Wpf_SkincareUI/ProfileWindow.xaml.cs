using BusinessLogicLayer.Services;
using BusinessLogicLayer.Services.IService;
using DataAccessLayer.Entities;
using System.ComponentModel.DataAnnotations;
using System.Windows;
using System.Windows.Controls;

namespace Wpf_SkincareUI
{
    /// <summary>
    /// Interaction logic for ProfileWindow.xaml
    /// </summary>
    public partial class ProfileWindow : Window
    {
        private readonly IUser _userService;
        private readonly IService<TypeOfSkin> _typeOfSkinService;
        private User _account;
        
        public ProfileWindow(User account)
        {
            InitializeComponent();
            _account = account;
            _userService = UserService.GetInstance();
            _typeOfSkinService = TypeOfSkinService.GetInstance();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadTypeOfSkin();
            LoadData();
        }

        private void LoadData()
        {
            txtEmail.Text = _account.Username;
            txtPassword.Password = _account.Password;
            txtFullName.Text = _account.Fullname;
            if(_account.Gender == "Nữ")
            {
                rbFemale.IsChecked = true;
            }
            else
            {
                rbMale.IsChecked = true;
            }
            txtBudget.Text = _account.Budget.ToString();
            txtDateCreated.Text = _account.DateCreated.ToString();
            txtRole.Text = _account.Role.Name;
            cbxTypeOfSkin.SelectedValue = _account.TypeOfSkinId;
        }

        private void LoadTypeOfSkin()
        {
            var skinList = _typeOfSkinService.GetAll();
            cbxTypeOfSkin.ItemsSource = skinList;
            cbxTypeOfSkin.SelectedValuePath = "TypeOfSkinId";
            cbxTypeOfSkin.DisplayMemberPath = "Name";
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            _account.Password = txtPassword.Password;
            _account.Fullname = txtFullName.Text;
            if (rbFemale.IsChecked == true)
            {
                _account.Gender = "Nữ";
            }
            else
            {
                _account.Gender = "Nam";
            }
            _account.TypeOfSkinId = (int)cbxTypeOfSkin.SelectedValue;
            var validationResults = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
            var context = new ValidationContext(_account);

            bool isValid = Validator.TryValidateObject(_account, context, validationResults, true);

            if (!isValid)
            {
                string errorMessages = string.Join("\n", validationResults.Select(e => e.ErrorMessage));
                MessageBox.Show(errorMessages, "Validation Errors", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                _userService.Update(_account);
                MessageBox.Show("Update successfully!");
            }
        }
    }
}
