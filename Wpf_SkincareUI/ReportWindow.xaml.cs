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
    /// Interaction logic for StaffWindow.xaml
    /// </summary>
    public partial class StaffWindow : Window
    {
        public StaffWindow()
        {
            InitializeComponent();
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
