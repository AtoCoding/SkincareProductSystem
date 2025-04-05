using System.Windows;
using DataAccessLayer.Entities;

namespace Wpf_SkincareUI
{
    /// <summary>
    /// Interaction logic for OrderDetailWindow.xaml
    /// </summary>
    public partial class OrderDetailWindow : Window
    {
        private readonly Order order;

        public OrderDetailWindow(Order order)
        {
            InitializeComponent();
            this.order = order;
            LoadOrderDetail();
        }

        private void LoadOrderDetail()
        {
            txtOrderId.Text = order.OrderId.ToString();
            LoadSkincareProductList(order.OrderDetails.ToList());

            decimal grandTotal = 0;
            foreach (OrderDetail orderDetail in order.OrderDetails)
            {
                grandTotal += orderDetail.TotalPrice;
            }
            txtGrandTotal.Text = grandTotal.ToString();
        }

        private void cmbSkincareProductId_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (cmbSkincareProductId.SelectedItem is OrderDetail selectedItem)
            {
                txtQuantity.Text = selectedItem.Quantity.ToString();
                txtTotalPrice.Text = selectedItem.TotalPrice.ToString();
            }
        }

        private void LoadSkincareProductList(List<OrderDetail> orderDetails)
        {
            cmbSkincareProductId.ItemsSource = orderDetails;
            cmbSkincareProductId.SelectedValuePath = "SkincareProductId";
            cmbSkincareProductId.DisplayMemberPath = "SkincareProductId";
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
