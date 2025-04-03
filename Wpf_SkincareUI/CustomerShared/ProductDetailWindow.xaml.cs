using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using BusinessLogicLayer;
using DataAccessLayer.Entities;

namespace Wpf_SkincareUI
{
    /// <summary>
    /// Interaction logic for ProductDetailsWindow.xaml
    /// </summary>
    public partial class ProductDetailsWindow : Window
    {
        private User? user;

        private SkincareProduct product;

        private List<SkincareProduct> products;

        public ProductDetailsWindow(User? user, SkincareProduct product, List<SkincareProduct> products)
        {
            InitializeComponent();
            this.user = user;
            this.product = product;
            this.products = products;
            LoadButtonByPermission();
            LoadProductDetails();
        }

        private void btnAddCart_Click(object sender, RoutedEventArgs e)
        {
            if (user == null)
            {
                MessageBox.Show("Please login to add to cart!");
                DisplayLoginWindow();
            }
            else
            {
                SkincareProduct? productInList = products.FirstOrDefault(x => x.SkincareProductId == product.SkincareProductId);
                if (productInList == null)
                {
                    SkincareProduct productClone = ServiceCommon.CloneObject(product);
                    productClone.Quantity = 1;
                    products.Add(productClone);
                } 
                else if (product.Quantity > productInList.Quantity)
                {
                    productInList.Quantity++;
                }
                else
                {
                    MessageBox.Show("You have taken the maximum number of products!");
                    return;
                }
                MessageBox.Show("Add to cart successfully!");
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            DisplayLoginWindow();
        }

        private void DisplayLoginWindow()
        {
            LoginWindow loginWindow = new();
            loginWindow.Show();
            this.Close();
        }

        private void LoadProductDetails()
        {
            imgPath.ImageSource = new BitmapImage(new Uri(product.Image));
            txtName.Text = product.Name;
            txtCategory.Text = product.Category.Name;
            txtBrand.Text = product.Brand.Name;
            txtCapacity.Text = product.Capacity;
            txtPrice.Text = product.UnitPrice.ToString();
            txtQuantity.Text = product.Quantity.ToString();
            txtDescription.Text = product.Description;
            if (!product.IsAvailable)
            {
                btnAddCart.IsEnabled = product.IsAvailable;
                btnAddCart.Foreground = new SolidColorBrush(Colors.Black);
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
