using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
