using System.Windows;
using DataAccessLayer.Entities;
using System.Windows.Input;

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
            txtWelcomMessage.Text = $"| Hello, {user.Fullname}";
            txtAccountBalance.Text = $"| Account Balance: {user.Budget.ToString("C")}";
            icOrderDetail.ItemsSource = products;
            decimal grandTotal = 0;
            foreach (SkincareProduct product in products)
            {
                grandTotal += (product.UnitPrice * product.Quantity);
            }
            txtGrandTotal.Text = grandTotal.ToString("C");
        }

        private void Homepage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            HomepageWindow homepageWindow = new(user, []);
            homepageWindow.Show();
            this.Close();
        }
    }
}
