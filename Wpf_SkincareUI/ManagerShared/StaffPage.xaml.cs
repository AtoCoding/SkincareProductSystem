using System.Windows;
using BusinessLogicLayer.Services;
using BusinessLogicLayer.Services.IService;
using DataAccessLayer.Entities;

namespace Wpf_SkincareUI
{
    /// <summary>
    /// Interaction logic for StaffPage.xaml
    /// </summary>
    public partial class StaffPage : Window
    {
        private User? user;
        private readonly IService<SkincareProduct> _skincareProductService;
        private readonly IUser _userService;
        private readonly IService<Order> _orderService;

        public StaffPage(User? user)
        {
            InitializeComponent();
            _skincareProductService = SkincareProductService.GetInstance();
            _userService = UserService.GetInstance();
            _orderService = OrderService.GetInstance();
            this.user = user;
            Load_Data();
        }

        private void Load_Data()
        {
            if (user.RoleId == 1) ReportBtn.IsEnabled = true;
            else ReportBtn.IsEnabled = false;

            txtNumberProducts.Text = _skincareProductService.GetAll().Count().ToString();
            txtNumberCustomers.Text = _userService.GetAll().Count().ToString();
            txtNumberOrders.Text = _orderService.GetAll().Count().ToString();
        }

        private void ProductManagement_Click(object sender, RoutedEventArgs e)
        {
            ProductPage productPage = new ProductPage(user);
            productPage.Show();
            this.Close();
        }

        private void CustomerManagement_Click(object sender, RoutedEventArgs e)
        {
            CustomersAndOrders customersAndOrders = new(user);
            customersAndOrders.Show();
            this.Close();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();

            this.Close();
            loginWindow.Show();
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ReportBtn_Click(object sender, RoutedEventArgs e)
        {
            ReportWindow reportWindow = new(user);
            reportWindow.ShowDialog();
        }
    }
}