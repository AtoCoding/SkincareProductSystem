using System.Windows;
using BusinessLogicLayer.Services;
using DataAccessLayer.Entities;

namespace Wpf_SkincareUI
{
    /// <summary>
    /// Interaction logic for StaffWindow.xaml
    /// </summary>
    public partial class CustomersAndOrders : Window
    {
        private User user;
        private readonly UserService _UserService;
        public CustomersAndOrders(User user)
        {
            InitializeComponent();
            this.user = user;
            this.Closing += CustomersAndOrders_Closing;
            _UserService = new UserService();
            LoadCustomerData();
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
            // Get the selected customer
            var customer = _UserService.GetByUserName(((User)CustomerGrid.SelectedItem).Username);

            // Open Customer Details Window
            CustomerDetailsWindow detailsWindow = new CustomerDetailsWindow(customer);
            detailsWindow.ShowDialog();
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            LoadCustomerData();
        }

        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            bool changesMade = false;

            foreach (var item in CustomerGrid.Items)
            {
                if (item is User user)
                {
                    // Retrieve the latest values from DataGrid
                    bool newIsActive = user.IsActive;

                    // Update the user in the database
                    if (_UserService.Update(user))
                    {
                        changesMade = true;
                    }
                }
            }

            if (changesMade)
            {
                MessageBox.Show("Changes saved successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No changes detected or failed to save.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            // Refresh the grid after saving
            LoadCustomerData();
        }

        private void LoadCustomerData()
        {
            //load Customer data to the grid
            try
            {
                List<User> customers = _UserService.GetAllByRoleId(3);

                if (customers == null || customers.Count == 0)
                {
                    MessageBox.Show("No customers found.");
                    return;
                }

                CustomerGrid.ItemsSource = customers;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading customers: {ex.Message}");
            }

        }
        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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

        private void CustomersAndOrders_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            StaffPage staffPage = new StaffPage(user);
            staffPage.Show();
        }
    }


}
