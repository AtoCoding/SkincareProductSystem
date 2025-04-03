//using System.IO;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Input;
//using System.Windows.Media;
//using BusinessLogicLayer.Services;
//using BusinessLogicLayer.Services.IService;
//using DataAccessLayer.Entities;
//using Wpf_SkincareUI.Popup;
//using System.Linq;

//namespace Wpf_SkincareUI
//{
//    /// <summary>
//    /// Interaction logic for ProductPage.xaml
//    /// </summary>
//    public partial class ProductPage : Window
//    {
//        private readonly IService<SkincareProduct> _SkincareProductService;

//        private User? user;
//        public ProductPage() : this(null) { } // Constructor mặc định


//        // Biến cho phân trang 
//        private int _currentPage = 1;
//        private int _pageSize = 20; // Mặc định 20 sản phẩm mỗi trang
//        private int _totalPages => (_SkincareProductService.GetAll().Count + _pageSize - 1) / _pageSize;
//        public ProductPage(User? user)
//        {
//            InitializeComponent();
//            this.user = user;
//            _SkincareProductService = SkincareProductService.GetInstance();

//            LoadProducts();
//        }
//        private void LoadProducts()
//        {
//            string projectDirectory = AppContext.BaseDirectory;
//            string imageFolder = Path.Combine(projectDirectory, @"..\..\..\Image");
//            imageFolder = Path.GetFullPath(imageFolder);
//            string imagePath = Path.Combine(imageFolder, "02-31-15-21-02-2023-3ce-daf-1.jpg");
//            List<SkincareProduct> skincareProducts = _SkincareProductService.GetAll();
//            ProcessImage(skincareProducts);

//            dgProducts.ItemsSource = skincareProducts;


//            // dành cho phân trang hahahahahahahahaha
//            LoadCurrentPage();
//            UpdatePaginationInfo();
//        }
//        private void LoadCurrentPage()
//        {
//            List<SkincareProduct> skincareProducts = _SkincareProductService.GetAll();
//            int startIndex = (_currentPage - 1) * _pageSize;
//            var productsInPage = skincareProducts.Skip(startIndex).Take(_pageSize).ToList();
//            dgProducts.ItemsSource = productsInPage;
//        }

//        private void UpdatePaginationInfo()
//        {
//            txtCurrentPage.Text = _currentPage.ToString();
//            txtTotalPages.Text = _totalPages.ToString();

//            // Cập nhật trạng thái nút
//            btnFirst.IsEnabled = btnPrevious.IsEnabled = (_currentPage > 1);
//            btnNext.IsEnabled = btnLast.IsEnabled = (_currentPage < _totalPages);
//        }
//        private void ProcessImage(List<SkincareProduct> skincareProducts)
//        {
//            string projectDirectory = AppContext.BaseDirectory;
//            string imageFolder = Path.Combine(projectDirectory, @"..\..\..\Image");
//            imageFolder = Path.GetFullPath(imageFolder);
//            foreach (var skincareProduct in skincareProducts)
//            {
//                skincareProduct.Image = Path.Combine(imageFolder, skincareProduct.Image);
//            }
//        }

//        private void btnSearch_Click(object sender, RoutedEventArgs e)
//        {
//            string searchTerm = txtSearch.Text;
//            var skincarProductData = _SkincareProductService.Search(searchTerm);
//            dgProducts.ItemsSource = skincarProductData;
//        }
//        private void AddProduct_Click(object sender, RoutedEventArgs e)
//        {
//            AddEditPopup addPopup = new AddEditPopup(null, true, user);
//            addPopup.Show();
//            this.Hide();
//        }
//        private void EditProduct_Click(object sender, RoutedEventArgs e)
//        {
//            var selectedProduct = dgProducts.SelectedItem as SkincareProduct;
//            if (selectedProduct == null)
//            {
//                MessageBox.Show("Vui lòng chọn một sản phẩm để chỉnh sửa.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
//                return;
//            }
//            AddEditPopup addPopup = new AddEditPopup(selectedProduct, false, user);
//            addPopup.Show();
//            this.Hide();
//        }
//        private void DeleteProduct_Click(object sender, RoutedEventArgs e)
//        {
//            var selectedProduct = dgProducts.SelectedItem as SkincareProduct;
//            if (selectedProduct == null)
//            {
//                MessageBox.Show("Vui lòng chọn một sản phẩm để xóa.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
//                return;
//            }
//            var productID = selectedProduct.SkincareProductId;
//            var result = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này không?", "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Question);
//            if (result == MessageBoxResult.Yes)
//            {
//                _SkincareProductService.Delete(productID);
//                MessageBox.Show("Xóa sản phẩm thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
//                LoadProducts();
//            }
//            // Sau khi xử lý ảnh, xóa sản phẩm khỏi database
//        }
//        // Button management 
//        private void ProductManagement_Click(object sender, RoutedEventArgs e)
//        {
//            ProductPage productPage = new ProductPage(user);
//            productPage.Show();
//            this.Close();
//        }

//        private void CustomerManagement_Click(object sender, RoutedEventArgs e)
//        {
//            StaffWindow customerDetailsWindow = new StaffWindow(user);
//            customerDetailsWindow.Show();
//            this.Close();
//        }

//        private void Logout_Click(object sender, RoutedEventArgs e)
//        {
//            LoginWindow loginWindow = new LoginWindow();

//            this.Close();
//            loginWindow.Show();
//        }

//        private void MenuButton_Click(object sender, RoutedEventArgs e)
//        {
//            StaffPage staffPage = new StaffPage(user);
//            staffPage.Show();
//            this.Close();
//        }

//        private void btnPrevious_Click(object sender, RoutedEventArgs e)
//        {
//            if (_currentPage > 1)
//            {
//                _currentPage--;
//                LoadCurrentPage();
//                UpdatePaginationInfo();
//            }
//        }

//        private void btnFirst_Click(object sender, RoutedEventArgs e)
//        {
//            _currentPage = 1;
//            LoadCurrentPage();
//            UpdatePaginationInfo();
//        }

//        private void btnNext_Click(object sender, RoutedEventArgs e)
//        {
//            if (_currentPage < _totalPages)
//            {
//                _currentPage++;
//                LoadCurrentPage();
//                UpdatePaginationInfo();
//            }
//        }

//        private void btnLast_Click(object sender, RoutedEventArgs e)
//        {
//            _currentPage = _totalPages;
//            LoadCurrentPage();
//            UpdatePaginationInfo();
//        }

//        private void cboPageSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
//        {
//            if (cboPageSize.SelectedItem != null)
//            {
//                var content = ((ComboBoxItem)cboPageSize.SelectedItem).Content.ToString();
//                if (int.TryParse(content, out int newPageSize))
//                {
//                    _pageSize = newPageSize;
//                    _currentPage = 1; // Reset về trang đầu tiên khi thay đổi kích thước trang
//                    LoadCurrentPage();
//                    UpdatePaginationInfo();
//                }
//            }
//        }
//        // xử lý cuộn chuột 

//    }
//}


using System.IO;
using System.Windows;
using System.Windows.Controls;
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
        private readonly IService<SkincareProduct> _skincareProductService;
        private readonly User? _user;
        private readonly string _imageBasePath;

        // Biến cho phân trang 
        private int _currentPage = 1;
        private int _pageSize = 4; // Mặc định 20 sản phẩm mỗi trang
        private int _totalProducts = 0;
        private int _totalPages => (_totalProducts + _pageSize - 1) / _pageSize;

        // Lưu trữ tất cả sản phẩm để tránh gọi GetAll() nhiều lần
        private List<SkincareProduct> _allProducts = new List<SkincareProduct>();

        // Constructor mặc định
        public ProductPage() : this(null) { }

        public ProductPage(User? user)
        {
            InitializeComponent();
            _user = user;
            _skincareProductService = SkincareProductService.GetInstance();

            // Khởi tạo đường dẫn ảnh cơ sở
            string projectDirectory = AppContext.BaseDirectory;
            string imageFolder = Path.Combine(projectDirectory, @"..\..\..\Image");
            _imageBasePath = Path.GetFullPath(imageFolder);

            // Tải dữ liệu ban đầu
            LoadAllProducts();
            SetupUI();
        }

        /// <summary>
        /// Tải tất cả sản phẩm từ dịch vụ và xử lý đường dẫn ảnh
        /// </summary>
        private void LoadAllProducts()
        {
            try
            {
                _allProducts = _skincareProductService.GetAll();
                _totalProducts = _allProducts.Count;


                ProcessImages(_allProducts);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách sản phẩm: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Thiết lập các thành phần UI ban đầu
        /// </summary>
        private void SetupUI()
        {
            // Tải trang đầu tiên
            LoadCurrentPage();
            UpdatePaginationInfo();

            // Thiết lập ComboBox kích thước trang nếu có
            if (cboPageSize != null && cboPageSize.Items.Count == 0)
            {
                cboPageSize.Items.Add(new ComboBoxItem { Content = "1" });
                cboPageSize.Items.Add(new ComboBoxItem { Content = "2" });
                cboPageSize.Items.Add(new ComboBoxItem { Content = "5" });
                cboPageSize.SelectedIndex = 1; // Mặc định 20 item
            }
        }

        /// <summary>
        /// Tải sản phẩm của trang hiện tại vào DataGrid
        /// </summary>
        private void LoadCurrentPage()
        {
            try
            {
                int startIndex = (_currentPage - 1) * _pageSize;

                // Kiểm tra nếu startIndex vượt quá số lượng sản phẩm
                if (startIndex >= _allProducts.Count && _allProducts.Count > 0)
                {
                    _currentPage = 1;
                    startIndex = 0;
                }

                var productsInPage = _allProducts.Skip(startIndex).Take(_pageSize).ToList();
                dgProducts.ItemsSource = productsInPage;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải trang: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Cập nhật thông tin phân trang trên UI
        /// </summary>
        private void UpdatePaginationInfo()
        {
            txtCurrentPage.Text = _currentPage.ToString();
            txtTotalPages.Text = _totalPages.ToString();

            // Cập nhật trạng thái nút
            btnFirst.IsEnabled = btnPrevious.IsEnabled = (_currentPage > 1);
            btnNext.IsEnabled = btnLast.IsEnabled = (_currentPage < _totalPages);
        }

        /// <summary>
        /// Xử lý đường dẫn ảnh cho danh sách sản phẩm
        /// </summary>
        private void ProcessImages(List<SkincareProduct> products)
        {
            foreach (var product in products)
            {
                if (!string.IsNullOrEmpty(product.Image) && !Path.IsPathRooted(product.Image))
                {
                    product.Image = Path.Combine(_imageBasePath, product.Image);
                }
            }
        }

        /// <summary>
        /// Xử lý sự kiện tìm kiếm
        /// </summary>
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string searchTerm = txtSearch.Text?.Trim() ?? string.Empty;

                if (string.IsNullOrEmpty(searchTerm))
                {
                    // Nếu không có từ khóa tìm kiếm, tải lại tất cả sản phẩm
                    LoadAllProducts();
                    LoadCurrentPage();
                    UpdatePaginationInfo();
                }
                else
                {
                    // Tìm kiếm và hiển thị kết quả
                    var searchResults = _skincareProductService.Search(searchTerm);
                    ProcessImages(searchResults);
                    dgProducts.ItemsSource = searchResults;

                    // Vô hiệu hóa phân trang khi đang tìm kiếm
                    DisablePagination();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Vô hiệu hóa các điều khiển phân trang khi đang tìm kiếm
        /// </summary>
        private void DisablePagination()
        {
            btnFirst.IsEnabled = btnPrevious.IsEnabled = btnNext.IsEnabled = btnLast.IsEnabled = false;
            txtCurrentPage.Text = "1";
            txtTotalPages.Text = "1";
        }

        /// <summary>
        /// Xử lý sự kiện thêm sản phẩm mới
        /// </summary>
        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            AddEditPopup addPopup = new AddEditPopup(null, true, _user);
            ProductPage productPage = new ProductPage(_user);
            addPopup.Closed += (s, args) => {
                productPage.Show();
                LoadAllProducts();
                LoadCurrentPage();
                UpdatePaginationInfo();
            };
            addPopup.Show();
            this.Close();
        }

        /// <summary>
        /// Xử lý sự kiện chỉnh sửa sản phẩm
        /// </summary>
        private void EditProduct_Click(object sender, RoutedEventArgs e)
        {
            var selectedProduct = dgProducts.SelectedItem as SkincareProduct;
            if (selectedProduct == null)
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm để chỉnh sửa.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            AddEditPopup editPopup = new AddEditPopup(selectedProduct, false, _user);
            ProductPage productPage = new ProductPage(_user);

            editPopup.Closed += (s, args) => {
                productPage.Show();
                LoadAllProducts();
                LoadCurrentPage();
                UpdatePaginationInfo();
            };
            editPopup.Show();
            this.Close();
        }

        /// <summary>
        /// Xử lý sự kiện xóa sản phẩm
        /// </summary>
        private void DeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            var selectedProduct = dgProducts.SelectedItem as SkincareProduct;
            if (selectedProduct == null)
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm để xóa.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var productID = selectedProduct.SkincareProductId;
            var result = MessageBox.Show($"Bạn có chắc chắn muốn xóa sản phẩm '{selectedProduct.Name}' không?",
                "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    _skincareProductService.Delete(productID);
                    MessageBox.Show("Xóa sản phẩm thành công", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);

                    // Cập nhật lại danh sách sản phẩm
                    LoadAllProducts();
                    LoadCurrentPage();
                    UpdatePaginationInfo();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa sản phẩm: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        #region Navigation Methods

        /// <summary>
        /// Chuyển đến trang quản lý sản phẩm
        /// </summary>
        private void ProductManagement_Click(object sender, RoutedEventArgs e)
        {
            // Đã đang ở trang này, không cần tái tạo
            // Có thể refresh dữ liệu nếu cần
            LoadAllProducts();
            LoadCurrentPage();
            UpdatePaginationInfo();
        }

        /// <summary>
        /// Chuyển đến trang quản lý khách hàng
        /// </summary>
        private void CustomerManagement_Click(object sender, RoutedEventArgs e)
        {
            //StaffWindow customerDetailsWindow = new StaffWindow(_user);
            //customerDetailsWindow.Show();
            this.Close();
        }

        /// <summary>
        /// Đăng xuất và trở về màn hình đăng nhập
        /// </summary>
        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }

        /// <summary>
        /// Chuyển đến trang nhân viên
        /// </summary>
        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            StaffPage staffPage = new StaffPage(_user);
            staffPage.Show();
            this.Close();
        }

        #endregion

        #region Pagination Methods

        /// <summary>
        /// Quay lại trang trước
        /// </summary>
        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                LoadCurrentPage();
                UpdatePaginationInfo();
            }
        }

        /// <summary>
        /// Chuyển đến trang đầu tiên
        /// </summary>
        private void btnFirst_Click(object sender, RoutedEventArgs e)
        {
            _currentPage = 1;
            LoadCurrentPage();
            UpdatePaginationInfo();
        }

        /// <summary>
        /// Chuyển đến trang tiếp theo
        /// </summary>
        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            if (_currentPage < _totalPages)
            {
                _currentPage++;
                LoadCurrentPage();
                UpdatePaginationInfo();
            }
        }

        /// <summary>
        /// Chuyển đến trang cuối cùng
        /// </summary>
        private void btnLast_Click(object sender, RoutedEventArgs e)
        {
            _currentPage = _totalPages;
            LoadCurrentPage();
            UpdatePaginationInfo();
        }

        /// <summary>
        /// Xử lý sự kiện thay đổi kích thước trang
        /// </summary>
        private void cboPageSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboPageSize.SelectedItem != null)
            {
                string content = ((ComboBoxItem)cboPageSize.SelectedItem).Content.ToString() ?? "4";
                if (int.TryParse(content, out int newPageSize))
                {
                    _pageSize = newPageSize;
                    _currentPage = 1; // Reset về trang đầu tiên khi thay đổi kích thước trang
                    LoadCurrentPage();
                    UpdatePaginationInfo();
                }
            }
        }

        #endregion
    }
}