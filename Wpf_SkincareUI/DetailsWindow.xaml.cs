using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using DataAccessLayer.Entities;

namespace Wpf_SkincareUI
{
    /// <summary>
    /// Interaction logic for DetailsWindow.xaml
    /// </summary>
    public partial class DetailsWindow : Window
    {
        private User? user;

        private SkincareProduct product;

        public DetailsWindow(User? user, SkincareProduct product)
        {
            InitializeComponent();
            this.user = user;
            this.product = product;
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
            HomepageWindow homepageWindow = new(user);
            homepageWindow.Show();
            this.Close();
        }
    }
}
