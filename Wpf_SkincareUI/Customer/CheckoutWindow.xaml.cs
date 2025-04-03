using System.ComponentModel.DataAnnotations;
using System.Windows;
using System.Windows.Input;
using BusinessLogicLayer.Services;
using BusinessLogicLayer.Services.IService;
using DataAccessLayer.Entities;

namespace Wpf_SkincareUI
{
    /// <summary>
    /// Interaction logic for CheckoutWindow.xaml
    /// </summary>
    public partial class CheckoutWindow : Window
    {
        private readonly IService<Order> _OrderService;

        private readonly User user;

        private readonly List<SkincareProduct> products;

        public CheckoutWindow(User user, List<SkincareProduct> products)
        {
            InitializeComponent();
            this.user = user;
            this.products = products;
            _OrderService = OrderService.GetInstance();
            LoadCheckout();
        }

        private void LoadCheckout()
        {
            txtWelcomMessage.Text = $"| Hello, {user.Fullname}";
            txtAccountBalance.Text = $"| Account Balance: {user.Budget:C}";
            txtEmail.Text = user.Username;
            txtFullname.Text = user.Fullname;

            int totalQuantity = 0;
            decimal totalPrice = 0;
            foreach (SkincareProduct product in products)
            {
                totalQuantity += product.Quantity;
                totalPrice += (product.UnitPrice * product.Quantity);
            }
            txtOrderSummary.Text = $"You have {totalQuantity} items in your cart.";
            txtTotalPrice.Text = totalPrice.ToString("C");
        }

        private void btnPlaceOrder_Click(object sender, RoutedEventArgs e)
        {
            List<OrderDetail> orderDetails = new();
            foreach (SkincareProduct product in products)
            {
                OrderDetail orderDetail = new()
                {
                    SkincareProductId = product.SkincareProductId,
                    Quantity = product.Quantity,
                    TotalPrice = (product.UnitPrice * product.Quantity)
                };
                orderDetails.Add(orderDetail);
            }

            Order order = new()
            {
                DateCreated = DateOnly.FromDateTime(DateTime.Now),
                Username = user.Username,
                OrderDetails = orderDetails
            };

            bool addResult = _OrderService.Add(order);

            if (addResult)
            {
                MessageBox.Show("Order successfully!");
                OrderDetailWindow orderDetailWindow = new(user, products);
                orderDetailWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("There is an error!");
            }
        }

        private void Homepage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            HomepageWindow homepageWindow = new(user, products);
            homepageWindow.Show();
            this.Close();
        }
    }
}
