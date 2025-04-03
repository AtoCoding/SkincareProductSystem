using System.Windows;
using DataAccessLayer.Entities;

namespace Wpf_SkincareUI
{
    /// <summary>
    /// Interaction logic for StaffWindow.xaml
    /// </summary>
    public partial class CustomersAndOrders : Window
    {
        private User user;
        public CustomersAndOrders(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        #region CUSTOMER TAB
        // Placeholder for Search button
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Search functionality not implemented yet.");
        }

        // Placeholder for View Details button
        private void ViewDetails_Click(object sender, RoutedEventArgs e)
        {
            if (CustomerGrid.SelectedItem == null)
            {
                MessageBox.Show("Please select a customer.");
                return;
            }

            // Open Customer Details Window
            CustomerDetailsWindow detailsWindow = new CustomerDetailsWindow();
            detailsWindow.ShowDialog();
        }
        #endregion

        #region ORDER HISTORY
        private void SearchOrder_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Search functionality not implemented yet.");
        }

        private void FilterByDate_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Filter by date functionality not implemented yet.");
        }

        private void ViewOrderDetails_Click(object sender, RoutedEventArgs e)
        {
            if (OrderGrid.SelectedItem == null)
            {
                MessageBox.Show("Please select an order.");
                return;
            }
            // Open Order Details Window
            OrderDetailsWindow detailsWindow = new OrderDetailsWindow();
            detailsWindow.ShowDialog();
        }
        #endregion
    }
}
