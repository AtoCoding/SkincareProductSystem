using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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
            string projectDirectory = AppContext.BaseDirectory;
            string imageFolder = Path.Combine(projectDirectory, @"..\..\..\Image");
            imageFolder = Path.GetFullPath(imageFolder);
            string imagePath = Path.Combine(imageFolder, "AaG.jpg");

            List<SkincareProduct> skincareProducts = _SkincareProductService.GetAll();
            ProcessImage(skincareProducts);

            icSkincareProduct.ItemsSource = skincareProducts;
        }

        private void ProcessImage(List<SkincareProduct> skincareProducts)
        {
            string projectDirectory = AppContext.BaseDirectory;
            string imageFolder = Path.Combine(projectDirectory, @"..\..\..\Image");
            imageFolder = Path.GetFullPath(imageFolder);

            foreach (var skincareProduct in skincareProducts)
            {
                skincareProduct.Image = Path.Combine(imageFolder, skincareProduct.Image);
            }
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
                    DetailsWindow detailsWindow = new(user, product, products);
                    detailsWindow.Show();
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
            }
            else
            {
                txtWelcomMessage.Text = $"Hello, {user.Fullname}";
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
    }
}
