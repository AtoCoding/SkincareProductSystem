using BusinessLogicLayer.Services;
using BusinessLogicLayer.Services.IService;
using DataAccessLayer.Entities;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Reflection;
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
        private readonly IService<Role> _roleService;
        private readonly IService<TypeOfSkin> _typeOfSkinService;
        public CustomerDetailsWindow(User user, User userToView)
        {
            InitializeComponent();
            _userService = UserService.GetInstance();
            _roleService = RoleService.GetInstance();
            _typeOfSkinService = TypeOfSkinService.GetInstance();
            this.user = user;
            this.userToView = userToView;
            LoadInfo();
            LoadPermisstion();
        }

        private void LoadInfo()
        {
            LoadRole();
            LoadSkinType();

            txtUsername.Text = userToView.Username;
            txtPassword.Text = userToView.Password;
            txtFullname.Text = userToView.Fullname;
            if (userToView.Gender == "Female")
            {
                rbFemale.IsChecked = true;
            }
            else
            {
                rbMale.IsChecked = true;
            }
            cbxRole.SelectedValue = userToView.Role.RoleId;
            cbxTypeOfSkin.SelectedValue = userToView.TypeOfSkin.TypeOfSkinId;
            chkIsActive.IsChecked = userToView.IsActive;
        }

        private void LoadPermisstion()
        {
            if (user.RoleId == 1)
            {
                btnUpdate.IsEnabled = true;
                btnDelete.IsEnabled = true;

                txtPassword.IsEnabled = true;
                txtFullname.IsEnabled = true;
                rbMale.IsEnabled = true;
                rbFemale.IsEnabled = true;
                cbxRole.IsEnabled = true;
                cbxTypeOfSkin.IsEnabled = true;
                chkIsActive.IsEnabled = true;
            }
        }

        private void LoadRole()
        {
            List<Role> roles = _roleService.GetAll();

            cbxRole.ItemsSource = roles;
            cbxRole.SelectedValuePath = "RoleId";
            cbxRole.DisplayMemberPath = "Name";
        }

        private void LoadSkinType()
        {
            List<TypeOfSkin> skinTypes = _typeOfSkinService.GetAll();

            cbxTypeOfSkin.ItemsSource = skinTypes;
            cbxTypeOfSkin.SelectedValuePath = "TypeOfSkinId";
            cbxTypeOfSkin.DisplayMemberPath = "Name";
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            User user = new()
            {
                Username = txtUsername.Text ?? string.Empty,
                Password = txtPassword.Text ?? string.Empty,
                Fullname = txtFullname.Text ?? string.Empty,
                Gender = new[] { rbMale, rbFemale }.FirstOrDefault(r => r.IsChecked == true)?.Content.ToString() ?? string.Empty,
                RoleId = cbxRole.SelectedValue != null ? int.Parse(cbxRole.SelectedValue.ToString()!) : 3,
                TypeOfSkinId = cbxTypeOfSkin.SelectedValue != null ? int.Parse(cbxTypeOfSkin.SelectedValue.ToString()!) : 3,
                IsActive = chkIsActive.IsChecked == true
            };

            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(user);

            bool isValid = Validator.TryValidateObject(user, context, validationResults, true);

            if (!isValid)
            {
                string errorMessages = string.Join("\n", validationResults.Select(e => e.ErrorMessage));
                MessageBox.Show(errorMessages, "Validation Errors", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                User? existingUser = _userService.GetByUserName(user.Username);
                if (existingUser == null)
                {
                    MessageBox.Show("User not found!");
                    return;
                } 
                else
                {
                    existingUser.Username = user.Username;
                    existingUser.Password = user.Password;
                    existingUser.Fullname = user.Fullname;
                    existingUser.Gender = user.Gender;
                    existingUser.RoleId = user.RoleId;
                    existingUser.TypeOfSkinId = user.TypeOfSkinId;
                    existingUser.IsActive = user.IsActive;

                    bool updateResult = _userService.Update(user);

                    if (updateResult)
                    {
                        MessageBox.Show("Update successfully!");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("There is an error!");
                    }
                }
                this.Close();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show(
                "Do you really want to delete this user?",
                "Confirmation",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                if (_userService.DeleteByUsername(userToView.Username))
                {
                    MessageBox.Show("Delete successfully");
                }
                else
                {
                    MessageBox.Show("Delete failed");
                }
                this.Close();
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}