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

        public StaffPage(User? user)
        {
            InitializeComponent();
            _skincareProductService = SkincareProductService.GetInstance();
            this.user = user;
            Load_Data();
        }

        private void Load_Data()
        {
            var totalProduct = _skincareProductService.GetAll().Count();
            txtProducts.Text = totalProduct.ToString();
        }

        private void ProductManagement_Click(object sender, RoutedEventArgs e)
        {
            ProductPage productPage = new ProductPage(user);
            productPage.Show();
            this.Close();
        }

        private void CustomerManagement_Click(object sender, RoutedEventArgs e)
        {
            //StaffWindow customerDetailsWindow = new StaffWindow(user);
            //customerDetailsWindow.Show();
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
    }
}