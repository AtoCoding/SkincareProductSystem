using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using DataAccessLayer.Entities;

namespace Wpf_SkincareUI
{
    /// <summary>
    /// Interaction logic for CartWindow.xaml
    /// </summary>
    public partial class CartWindow : Window
    {
        private User user;

        private List<SkincareProduct> products;

        public CartWindow(User user, List<SkincareProduct> products)
        {
            InitializeComponent();
            this.user = user;
            this.products = products;
            LoadCart();
        }

        private void LoadCart()
        {
            decimal totalPrice = 0;
            if (products.Count > 0)
            {
                foreach (SkincareProduct product in products)
                {
                    totalPrice += (product.UnitPrice * product.Quantity);
                }
            }
            txtTotalPrice.Text = totalPrice.ToString("C");

            icCartItems.ItemsSource = products;
            icCartItems.Items.Refresh();
        }

        private void Homepage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            HomepageWindow homepageWindow = new(user, products);
            homepageWindow.Show();
            this.Close();
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                if (button.DataContext is SkincareProduct product)
                {
                    if (product.Quantity == 1)
                    {
                        products.Remove(products.FirstOrDefault(x => x.SkincareProductId == product.SkincareProductId)!);
                    }
                    else
                    {
                        product.Quantity--;
                    }
                    LoadCart();
                }
            }
        }
    }
}
