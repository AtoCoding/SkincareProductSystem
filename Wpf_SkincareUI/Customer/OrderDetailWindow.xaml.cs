using System.Windows;
using DataAccessLayer.Entities;
using System.Windows.Input;
using BusinessLogicLayer;

namespace Wpf_SkincareUI
{
    /// <summary>
    /// Interaction logic for OrderDetailWindow.xaml
    /// </summary>
    public partial class OrderDetailWindow : Window
    {
        private readonly User user;

        private readonly List<SkincareProduct> products;

        public OrderDetailWindow(User user, List<SkincareProduct> products)
        {
            InitializeComponent();
            this.user = user;
            this.products = products;
            LoadOrderDetail();
        }

        private void LoadOrderDetail()
        {
            List<SkincareProduct> productsClone = new();
            decimal grandTotal = 0;
            foreach (SkincareProduct product in products)
            {
                grandTotal += (product.UnitPrice * product.Quantity);
                productsClone.Add(ServiceCommon.CloneObject(product));
            }

            ServiceCommon.ProcessImage(productsClone);
            txtGrandTotal.Text = grandTotal.ToString("C");
            txtWelcomMessage.Text = $"| Hello, {user.Fullname}";
            txtAccountBalance.Text = $"| Account Balance: {user.Budget:C}";
            icOrderDetail.ItemsSource = productsClone;
        }

        private void Homepage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            HomepageWindow homepageWindow = new(user, []);
            homepageWindow.Show();
            this.Close();
        }

        private void btnCart_Click(object sender, RoutedEventArgs e)
        {
            if (user != null)
            {
                CartWindow cartWindow = new(user, products);
                cartWindow.Show();
                this.Close();
            }
        }

        private void btnMyOrders_Click(object sender, RoutedEventArgs e)
        {
            OrdersWindow ordersWindow = new(user!, products);
            ordersWindow.Show();
            this.Close();
        }
    }
}
