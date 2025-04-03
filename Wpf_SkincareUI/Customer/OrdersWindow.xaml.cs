using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BusinessLogicLayer;
using BusinessLogicLayer.Services;
using BusinessLogicLayer.Services.IService;
using DataAccessLayer.Entities;

namespace Wpf_SkincareUI
{
    /// <summary>
    /// Interaction logic for OrdersWindow.xaml
    /// </summary>
    public partial class OrdersWindow : Window
    {
        private readonly IService<Order> _OrderService;

        private readonly User user;

        private List<SkincareProduct> products;

        public OrdersWindow(User user, List<SkincareProduct> products)
        {
            InitializeComponent();
            this.user = user;
            this.products = products;
            _OrderService = OrderService.GetInstance();
            LoadOrders();
        }

        private void LoadOrders()
        {
            List<Order> orders = _OrderService.GetAll();

            orders.RemoveAll(x => !x.Username.Equals(user.Username));

            txtWelcomMessage.Text = $"| Hello, {user.Fullname}";
            txtAccountBalance.Text = $"| Account Balance: {user.Budget:C}";
            icOrderList.ItemsSource = orders;
        }

        private void Order_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var grid = sender as Grid;
            if (grid != null)
            {
                if (grid.DataContext is Order order)
                {
                    List<SkincareProduct> products = new();
                    foreach (OrderDetail orderDetail in order.OrderDetails)
                    {
                        products.Add(ServiceCommon.CloneObject(orderDetail.SkincareProduct));
                        products[^1].Quantity = orderDetail.Quantity;
                    }
                    OrderDetailWindow orderDetailWindow = new(user, products);
                    orderDetailWindow.Show();
                    this.Close();
                }
            }
        }

        private void Homepage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            HomepageWindow homepageWindow = new(user, products);
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
    }
}
