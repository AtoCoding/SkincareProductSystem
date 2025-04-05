using System.Windows;
using System.Windows.Controls;
using BusinessLogicLayer;
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
        private readonly User _User;
        private int _CurrentPage = 1; // Biến cho phân trang
        private int _PageSize = 4; // Mặc định 4 sản phẩm mỗi trang
        private int _TotalProducts = 0;
        private int _TotalPages => (_TotalProducts + _PageSize - 1) / _PageSize;

        // Lưu trữ tất cả sản phẩm để tránh gọi GetAll() nhiều lần
        private List<SkincareProduct> _AllProducts = [];

        public ProductPage(User user)
        {
            InitializeComponent();
            _SkincareProductService = SkincareProductService.GetInstance();
            _User = user;

            // Tải dữ liệu ban đầu
            LoadAllProducts();
            SetupUI();
        }

        /// <summary>
        /// Tải tất cả sản phẩm từ dịch vụ và xử lý đường dẫn ảnh
        /// </summary>
        /// <returns></returns>
        private void LoadAllProducts()
        {
            try
            {
                List<SkincareProduct> productsClone = _SkincareProductService.GetAll();
                _AllProducts = [];
                foreach (SkincareProduct product in productsClone)
                {
                    _AllProducts.Add(ServiceCommon.CloneObject(product));
                }
                _TotalProducts = _AllProducts.Count;
                ServiceCommon.ProcessImage(_AllProducts);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách sản phẩm: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Thiết lập các thành phần UI ban đầu
        /// </summary>
        /// <returns></returns>
        private void SetupUI()
        {
            // Tải trang đầu tiên
            LoadCurrentPage();
            UpdatePaginationInfo();
        }

        /// <summary>
        /// Tải sản phẩm của trang hiện tại vào DataGrid
        /// </summary>
        /// <returns></returns>
        private void LoadCurrentPage()
        {
            try
            {
                int startIndex = (_CurrentPage - 1) * _PageSize;

                // Kiểm tra nếu startIndex vượt quá số lượng sản phẩm
                if (startIndex >= _AllProducts.Count && _AllProducts.Count > 0)
                {
                    _CurrentPage = 1;
                    startIndex = 0;
                }

                var productsInPage = _AllProducts.Skip(startIndex).Take(_PageSize).ToList();
                dgProducts.ItemsSource = productsInPage;
                dgProducts.Items.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải trang: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Cập nhật thông tin phân trang trên UI
        /// </summary>
        /// <returns></returns>
        private void UpdatePaginationInfo()
        {
            txtCurrentPage.Text = _CurrentPage.ToString();
            txtTotalPages.Text = _TotalPages.ToString();

            // Cập nhật trạng thái nút
            btnFirst.IsEnabled = btnPrevious.IsEnabled = (_CurrentPage > 1);
            btnNext.IsEnabled = btnLast.IsEnabled = (_CurrentPage < _TotalPages);
        }

        /// <summary>
        /// Xử lý sự kiện tìm kiếm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
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
                    List<SkincareProduct> searchResults = _SkincareProductService.Search(searchTerm);
                    List<SkincareProduct> searchResultsClone = [];
                    foreach (SkincareProduct product in searchResults)
                    {
                        searchResultsClone.Add(ServiceCommon.CloneObject(product));
                    }
                    ServiceCommon.ProcessImage(searchResultsClone);
                    dgProducts.ItemsSource = searchResultsClone;
                    dgProducts.Items.Refresh();

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
        /// <returns></returns>
        private void DisablePagination()
        {
            btnFirst.IsEnabled = btnPrevious.IsEnabled = btnNext.IsEnabled = btnLast.IsEnabled = false;
            txtCurrentPage.Text = "1";
            txtTotalPages.Text = "1";
        }

        /// <summary>
        /// Xử lý sự kiện thêm sản phẩm mới
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            AddEditPopup addPopup = new(null, true, _User);
            ProductPage productPage = new(_User);
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private void EditProduct_Click(object sender, RoutedEventArgs e)
        {
            var selectedProduct = dgProducts.SelectedItem as SkincareProduct;
            if (selectedProduct == null)
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm để chỉnh sửa.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            AddEditPopup editPopup = new(selectedProduct, false, _User);
            ProductPage productPage = new(_User);

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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
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
                                          "Xác nhận xóa",
                                          MessageBoxButton.YesNo,
                                          MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    _SkincareProductService.Delete(productID);
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private void CustomerManagement_Click(object sender, RoutedEventArgs e)
        {
            CustomersAndOrders customersAndOrders = new(_User);
            customersAndOrders.Show();
            this.Close();
        }

        /// <summary>
        /// Đăng xuất và trở về màn hình đăng nhập
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new();
            loginWindow.Show();
            this.Close();
        }

        /// <summary>
        /// Chuyển đến trang nhân viên
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            StaffPage staffPage = new(_User);
            staffPage.Show();
            this.Close();
        }
        #endregion

        #region Pagination Methods

        /// <summary>
        /// Quay lại trang trước
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            if (_CurrentPage > 1)
            {
                _CurrentPage--;
                LoadCurrentPage();
                UpdatePaginationInfo();
            }
        }

        /// <summary>
        /// Chuyển đến trang đầu tiên
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private void btnFirst_Click(object sender, RoutedEventArgs e)
        {
            _CurrentPage = 1;
            LoadCurrentPage();
            UpdatePaginationInfo();
        }

        /// <summary>
        /// Chuyển đến trang tiếp theo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            if (_CurrentPage < _TotalPages)
            {
                _CurrentPage++;
                LoadCurrentPage();
                UpdatePaginationInfo();
            }
        }

        /// <summary>
        /// Chuyển đến trang cuối cùng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private void btnLast_Click(object sender, RoutedEventArgs e)
        {
            _CurrentPage = _TotalPages;
            LoadCurrentPage();
            UpdatePaginationInfo();
        }

        /// <summary>
        /// Xử lý sự kiện thay đổi kích thước trang
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private void cboPageSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboPageSize.SelectedItem != null)
            {
                string content = ((ComboBoxItem)cboPageSize.SelectedItem).Content.ToString() ?? "4";
                if (int.TryParse(content, out int newPageSize))
                {
                    _PageSize = newPageSize;
                    _CurrentPage = 1; // Reset về trang đầu tiên khi thay đổi kích thước trang
                    LoadCurrentPage();
                    UpdatePaginationInfo();
                }
            }
        }
        #endregion
    }
}