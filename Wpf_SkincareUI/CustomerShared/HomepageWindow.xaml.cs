using System.IO;
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
    /// Interaction logic for HomepageWindow.xaml
    /// </summary>
    public partial class HomepageWindow : Window
    {
        private readonly IService<SkincareProduct> _SkincareProductService;

        private User? user;

        private List<SkincareProduct> products;
        public HomepageWindow(User? user, List<SkincareProduct> products)
        {
            InitializeComponent();
            this.user = user;
            _SkincareProductService = SkincareProductService.GetInstance();
            this.products = products.Count > 0 ? products : new List<SkincareProduct>();
            LoadButtonByPermission();
            LoadProducts();
        }

        private void LoadProducts()
        {
            List<SkincareProduct> products = _SkincareProductService.GetAll();
            List<SkincareProduct> productsClone = new();
            foreach (SkincareProduct product in products)
            {
                productsClone.Add(ServiceCommon.CloneObject(product));
            }
            ServiceCommon.ProcessImage(productsClone);

            icSkincareProduct.ItemsSource = productsClone;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new();
            loginWindow.Show();
            this.Close();
        }

        private void Product_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var stackPanel = sender as StackPanel;
            if (stackPanel != null)
            {
                if (stackPanel.DataContext is SkincareProduct product)
                {
                    ProductDetailsWindow productDetailsWindow = new(user, product, products);
                    productDetailsWindow.Show();
                    this.Close();
                }
            }
        }

        private void LoadButtonByPermission()
        {
            if (user == null)
            {
                spUnauthorize.Visibility = Visibility.Visible;
                spAuthorize.Visibility = Visibility.Hidden;
                txtWelcomMessage.Text = $"Hello, Guest";
            }
            else
            {
                txtWelcomMessage.Text = $"| Hello, {user.Fullname}";
                txtAccountBalance.Text = $"| Account Balance: {user.Budget:C}";
                spUnauthorize.Visibility = Visibility.Hidden;
                spAuthorize.Visibility = Visibility.Visible;
            }
        }

        private void Homepage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            LoadProducts();
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

        private void btnProfile_Click(object sender, RoutedEventArgs e)
        {
            if(user != null)
            {
                ProfileWindow profileWindow = new(user);
                profileWindow.ShowDialog();
                this.Close();
            }
        }
    }
}
