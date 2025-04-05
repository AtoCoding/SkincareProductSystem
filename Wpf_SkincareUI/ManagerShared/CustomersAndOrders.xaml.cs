using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using BusinessLogicLayer.Services;
using BusinessLogicLayer.Services.IService;
using DataAccessLayer.Entities;

namespace Wpf_SkincareUI
{
    /// <summary>
    /// Interaction logic for CustomersAndOrders.xaml
    /// </summary>
    public partial class CustomersAndOrders : Window
    {
        private User user;
        private readonly IUser _UserService;
        private readonly IService<Order> _OrderService;

        public CustomersAndOrders(User user)
        {
            InitializeComponent();
            this.user = user;
            this.Closing += CustomersAndOrders_Closing;
            _UserService = UserService.GetInstance();
            _OrderService = OrderService.GetInstance();
            LoadCustomerData();
            LoadOrderData();
        }

        #region CUSTOMER TAB
        // Placeholder for Search button
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            var searchText = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(searchText))
            {
                MessageBox.Show("Please enter a search term.");
                return;
            }

            var customers = _UserService.GetAllByRoleId(3);

            // Filter customers by any attribute
            var filteredCustomers = customers.Where(c =>
                c.Username.Contains(searchText, StringComparison.OrdinalIgnoreCase) ||
                c.Fullname.Contains(searchText, StringComparison.OrdinalIgnoreCase) ||
                c.Gender.Contains(searchText, StringComparison.OrdinalIgnoreCase) ||
                c.TypeOfSkin?.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase) == true ||
                c.Role?.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase) == true
            ).ToList();

            // Update DataGrid
            CustomerGrid.ItemsSource = filteredCustomers;
        }

        private void Search_Changed(object sender, TextChangedEventArgs e)
        {
            var searchText = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(searchText))
            {
                return;
            }

            var customers = _UserService.GetAllByRoleId(3);

            // Filter customers by any attribute
            var filteredCustomers = customers.Where(c =>
                c.Username.Contains(searchText, StringComparison.OrdinalIgnoreCase) ||
                c.Fullname.Contains(searchText, StringComparison.OrdinalIgnoreCase) ||
                c.Gender.Contains(searchText, StringComparison.OrdinalIgnoreCase) ||
                c.TypeOfSkin?.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase) == true ||
                c.Role?.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase) == true
            ).ToList();

            // Update DataGrid
            CustomerGrid.ItemsSource = filteredCustomers;
        }

        private void DataGrid_DoubleClick(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource is DependencyObject source)
            {
                DataGridRow? row = FindParent<DataGridRow>(source);
                if (row != null && row.Item != CollectionView.NewItemPlaceholder) // Prevent empty row selection
                {
                    // Get the selected customer
                    var customer = _UserService.GetByUserName(((User)CustomerGrid.SelectedItem).Username);

                    // Open Customer Details Window
                    CustomerDetailsWindow detailsWindow = new CustomerDetailsWindow(user, customer);
                    detailsWindow.ShowDialog();
                }
            }

        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            LoadCustomerData();
        }

        private void LoadCustomerData()
        {
            //load Customer data to the grid
            try
            {
                List<User> customers = user.RoleId == 1 ? _UserService.GetAll() : _UserService.GetAllByRoleId(3);

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

        private static T? FindParent<T>(DependencyObject child) where T : DependencyObject
        {
            DependencyObject? parent = VisualTreeHelper.GetParent(child);
            while (parent != null)
            {
                if (parent is T typedParent)
                {
                    return typedParent;
                }
                parent = VisualTreeHelper.GetParent(parent);
            }
            return null;
        }
        #endregion

        #region ORDER HISTORY
        private void LoadOrderData()
        {
            try
            {
                List<Order> orders = _OrderService.GetAll();

                if (orders.Count == 0)
                {
                    MessageBox.Show("No customers found.");
                    return;
                }

                OrderGrid.ItemsSource = orders;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading customers: {ex.Message}");
            }

        }

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
            Order order = (Order)OrderGrid.SelectedItem;
            if (order == null)
            {
                MessageBox.Show("Please select an order.");
                return;
            }
            // Open Order Details Window
            OrderDetailWindow orderDetailWindow = new(order);
            orderDetailWindow.ShowDialog();
        }
        #endregion

        private void CustomersAndOrders_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            StaffPage staffPage = new StaffPage(user);
            staffPage.Show();
        }
    }
}