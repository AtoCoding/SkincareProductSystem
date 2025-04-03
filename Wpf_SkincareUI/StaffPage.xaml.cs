using System.Windows;
using DataAccessLayer.Entities;

namespace Wpf_SkincareUI
{
    /// <summary>
    /// Interaction logic for StaffPage.xaml
    /// </summary>
    public partial class StaffPage : Window
    {
        private User? user;

        public StaffPage(User? user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void ProductManagement_Click(object sender, RoutedEventArgs e)
        {
            ProductPage productPage = new ProductPage(user);
            productPage.Show();
            this.Close();
        }

        private void CustomerManagement_Click(object sender, RoutedEventArgs e)
        {
            CustomersAndOrders customersAndOrders = new CustomersAndOrders(user);
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
    }
}