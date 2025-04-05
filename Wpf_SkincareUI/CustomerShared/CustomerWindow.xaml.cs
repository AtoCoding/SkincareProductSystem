using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using BusinessLogicLayer;
using BusinessLogicLayer.Services;
using BusinessLogicLayer.Services.IService;
using DataAccessLayer.Entities;

namespace Wpf_SkincareUI
{
    /// <summary>
    /// Interaction logic for CustomerWindow.xaml
    /// </summary>
    public partial class CustomerWindow : Window
    {
        private readonly IService<SkincareProduct> _SkincareProductService;

        private readonly IService<Order> _OrderService;

        private User? user;

        private List<SkincareProduct> productsInCart;

        private SkincareProduct product;

        public CustomerWindow(User? user)
        {
            InitializeComponent();
            _SkincareProductService = SkincareProductService.GetInstance();
            this.user = user;
            _OrderService = OrderService.GetInstance();
            productsInCart = new();
            product = new();
            LoadButtonByPermission();
            LoadProducts();
        }

        #region Product List
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
        #endregion

        #region Product Detail
        private void Product_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var stackPanel = sender as StackPanel;
            if (stackPanel != null)
            {
                if (stackPanel.DataContext is SkincareProduct product)
                {
                    this.product = product;
                    productListSession.Visibility = Visibility.Hidden;
                    productDetailSession.Visibility = Visibility.Visible;
                    myCartSession.Visibility = Visibility.Hidden;
                    checkoutSession.Visibility = Visibility.Hidden;
                    myOrderSession.Visibility = Visibility.Hidden;
                    orderDetailWindow.Visibility = Visibility.Hidden;

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
                    else
                    {
                        btnAddCart.IsEnabled = product.IsAvailable;
                        btnAddCart.Foreground = new SolidColorBrush(Colors.White);
                    }
                }
            }
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
                if (product != null)
                {
                    SkincareProduct? tmpProduct = productsInCart.FirstOrDefault(x => x.SkincareProductId == product.SkincareProductId);
                    if (tmpProduct == null)
                    {
                        SkincareProduct productClone = ServiceCommon.CloneObject(product);
                        productClone.Quantity = 1;
                        productsInCart.Add(productClone);
                    }
                    else if (product.Quantity > tmpProduct.Quantity)
                    {
                        tmpProduct.Quantity++;
                    }
                    else
                    {
                        MessageBox.Show("You have taken the maximum number of products!");
                        return;
                    }
                    MessageBox.Show("Add to cart successfully!");
                }
            }
        }
        #endregion

        #region Profile
        private void btnProfile_Click(object sender, RoutedEventArgs e)
        {
            ProfileWindow profileWindow = new(user);
            profileWindow.Show();
            this.Close();
        }
        #endregion

        #region My Cart
        private void LoadCart()
        {
            decimal totalPrice = 0;
            if (productsInCart.Count > 0)
            {
                if (productsInCart.Count > 0)
                {
                    foreach (SkincareProduct product in productsInCart)
                    {
                        totalPrice += (product.UnitPrice * product.Quantity);
                    }
                }

                btnCheckout.IsEnabled = true;
                btnCheckout.Foreground = new SolidColorBrush(Colors.White);
            }
            else
            {
                btnCheckout.IsEnabled = false;
                btnCheckout.Foreground = new SolidColorBrush(Colors.Black);
            }

            txtCartTotalPrice.Text = totalPrice.ToString("C");
            icCartItems.ItemsSource = productsInCart;
            icCartItems.Items.Refresh();
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
                        productsInCart.Remove(productsInCart.FirstOrDefault(x => x.SkincareProductId == product.SkincareProductId)!);
                    }
                    else
                    {
                        product.Quantity--;
                    }
                    LoadCart();
                }
            }
        }

        private void btnCheckout_Click(object sender, RoutedEventArgs e)
        {
            productListSession.Visibility = Visibility.Hidden;
            productDetailSession.Visibility = Visibility.Hidden;
            myCartSession.Visibility = Visibility.Hidden;
            checkoutSession.Visibility = Visibility.Visible;
            myOrderSession.Visibility = Visibility.Hidden;
            orderDetailWindow.Visibility = Visibility.Hidden;

            LoadCheckout();
        }
        #endregion

        #region Checkout
        private void LoadCheckout()
        {
            txtEmail.Text = user.Username;
            txtFullname.Text = user.Fullname;

            int totalQuantity = 0;
            decimal totalPrice = 0;
            foreach (SkincareProduct product in productsInCart)
            {
                totalQuantity += product.Quantity;
                totalPrice += (product.UnitPrice * product.Quantity);
            }
            txtOrderSummary.Text = $"You have {totalQuantity} items in your cart.";
            txtCheckoutTotalPrice.Text = totalPrice.ToString("C");
        }

        private void btnPlaceOrder_Click(object sender, RoutedEventArgs e)
        {
            List<OrderDetail> orderDetails = new();
            foreach (SkincareProduct product in productsInCart)
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
                LoadOrderDetail(productsInCart);
            }
            else
            {
                MessageBox.Show("There is an error!");
            }
        }
        #endregion

        #region My Order
        private void LoadOrders()
        {
            List<Order> orders = _OrderService.GetAll();

            orders.RemoveAll(x => !x.Username.Equals(user.Username));

            icOrderList.ItemsSource = orders;
        }

        private void Order_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var grid = sender as Grid;
            if (grid != null)
            {
                if (grid.DataContext is Order order)
                {
                    List<SkincareProduct> productsInOrderDetail = new();
                    foreach (OrderDetail orderDetail in order.OrderDetails)
                    {
                        productsInOrderDetail.Add(ServiceCommon.CloneObject(orderDetail.SkincareProduct));
                        productsInOrderDetail[^1].Quantity = orderDetail.Quantity;
                    }

                    LoadOrderDetail(productsInOrderDetail);
                }
            }
        }
        #endregion

        #region Order Detail
        private void LoadOrderDetail(List<SkincareProduct> productsInOrderDetail)
        {
            productListSession.Visibility = Visibility.Hidden;
            productDetailSession.Visibility = Visibility.Hidden;
            myCartSession.Visibility = Visibility.Hidden;
            checkoutSession.Visibility = Visibility.Hidden;
            myOrderSession.Visibility = Visibility.Hidden;
            orderDetailWindow.Visibility = Visibility.Visible;

            List<SkincareProduct> productsClone = new();
            decimal grandTotal = 0;
            foreach (SkincareProduct product in productsInOrderDetail)
            {
                grandTotal += (product.UnitPrice * product.Quantity);
                productsClone.Add(ServiceCommon.CloneObject(product));
            }

            ServiceCommon.ProcessImage(productsClone);
            txtGrandTotal.Text = grandTotal.ToString("C");
            icOrderDetail.ItemsSource = productsClone;
        }
        #endregion

        #region Skin Type Test

        #endregion

        #region Common
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

        private void LoadButtonByPermission()
        {
            if (user == null)
            {
                btnLogin.Content = "Login";
                btnProfile.Visibility = Visibility.Hidden;
                btnCart.Visibility = Visibility.Hidden;
                btnMyOrder.Visibility = Visibility.Hidden;
                btnSkinTest.Visibility = Visibility.Hidden;
            }
            else
            {
                btnLogin.Content = "Logout";
                btnProfile.Visibility = Visibility.Visible;
                btnCart.Visibility = Visibility.Visible;
                btnMyOrder.Visibility = Visibility.Visible;
                btnSkinTest.Visibility = Visibility.Visible;
            }
        }

        private void btnSkincareStore_Click(object sender, RoutedEventArgs e)
        {
            productListSession.Visibility = Visibility.Visible;
            productDetailSession.Visibility = Visibility.Hidden;
            myCartSession.Visibility = Visibility.Hidden;
            checkoutSession.Visibility = Visibility.Hidden;
            myOrderSession.Visibility = Visibility.Hidden;
            orderDetailWindow.Visibility = Visibility.Hidden;

            LoadProducts();
        }

        private void btnMyOrders_Click(object sender, RoutedEventArgs e)
        {
            productListSession.Visibility = Visibility.Hidden;
            productDetailSession.Visibility = Visibility.Hidden;
            myCartSession.Visibility = Visibility.Hidden;
            checkoutSession.Visibility = Visibility.Hidden;
            myOrderSession.Visibility = Visibility.Visible;
            orderDetailWindow.Visibility = Visibility.Hidden;

            LoadOrders();
        }

        private void btnCart_Click(object sender, RoutedEventArgs e)
        {
            productListSession.Visibility = Visibility.Hidden;
            productDetailSession.Visibility = Visibility.Hidden;
            myCartSession.Visibility = Visibility.Visible;
            checkoutSession.Visibility = Visibility.Hidden;
            myOrderSession.Visibility = Visibility.Hidden;
            orderDetailWindow.Visibility = Visibility.Hidden;

            LoadCart();
        }
        #endregion
    }
}
