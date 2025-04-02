using System.IO;
using System.Windows;
using BusinessLogicLayer.Services;
using BusinessLogicLayer.Services.IService;
using DataAccessLayer.Entities;
using Wpf_SkincareUI.Popup;


namespace Wpf_SkincareUI
{
    /// <summary>
    /// Interaction logic for ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Window
    {
        private readonly IService<SkincareProduct> _SkincareProductService;

        private User? user;
        public ProductPage() : this(null) { } // Constructor mặc định

        public ProductPage(User? user)
        {
            InitializeComponent();
            this.user = user;
            _SkincareProductService = SkincareProductService.GetInstance();
            LoadProducts();
        }
        private void LoadProducts()
        {
            string projectDirectory = AppContext.BaseDirectory;
            string imageFolder = Path.Combine(projectDirectory, @"..\..\..\Image");
            imageFolder = Path.GetFullPath(imageFolder);
            string imagePath = Path.Combine(imageFolder, "02-31-15-21-02-2023-3ce-daf-1.jpg");
            List<SkincareProduct> skincareProducts = _SkincareProductService.GetAll();
            ProcessImage(skincareProducts);

            dgProducts.ItemsSource = skincareProducts;

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

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string searchTerm = txtSearch.Text;
            var skincarProductData = _SkincareProductService.Search(searchTerm);
            dgProducts.ItemsSource = skincarProductData;
        }
        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            AddEditPopup addPopup = new AddEditPopup(null, true);
            addPopup.Show();
            this.Hide();
        }
        private void EditProduct_Click(object sender, RoutedEventArgs e)
        {
            var selectedProduct = dgProducts.SelectedItem as SkincareProduct;
            if (selectedProduct == null)
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm để chỉnh sửa.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            AddEditPopup addPopup = new AddEditPopup(selectedProduct, false);
            addPopup.Show();
            this.Hide();
        }
        private void DeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            var selectedProduct = dgProducts.SelectedItem as SkincareProduct;
            if (selectedProduct == null)
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm để xóa.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            var productID = selectedProduct.SkincareProductId;
            var result = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này không?", "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                _SkincareProductService.Delete(productID);
                MessageBox.Show("Xóa sản phẩm thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadProducts();
            }
            // Sau khi xử lý ảnh, xóa sản phẩm khỏi database
        }

    }
}