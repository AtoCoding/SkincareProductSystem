using System;

using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using BusinessLogicLayer.Services.IService;
using DataAccessLayer.Entities;
using BusinessLogicLayer.Services;

namespace Wpf_SkincareUI.Popup
{
    /// <summary>
    /// Interaction logic for AddEditPopup.xaml
    /// </summary>
    public partial class AddEditPopup : Window
    {
        private readonly IService<Category> _categoryService;
        private readonly IService<Brand> _brandService;

        private readonly IService<SkincareProduct> _skincareProductService;
        private Boolean isAddFeature;
        private string imagePath = null;
        private SkincareProduct SkincareProduct { get; set; }
        public AddEditPopup(SkincareProduct? product, bool isAddFeature)
        {
            InitializeComponent();
            _categoryService = CategoryService.GetInstance();
            _brandService = BrandService.GetInstance();
            _skincareProductService = SkincareProductService.GetInstance();
            this.SkincareProduct = product;
            this.isAddFeature = isAddFeature;
            loadCategory();
            loadBrand();
            loadEditedData();
        }

        private void loadEditedData()
        {
            if (SkincareProduct != null)
            {
                txtName.Text = SkincareProduct.Name;
                txtDescription.Text = SkincareProduct.Description;
                txtCapacity.Text = SkincareProduct.Capacity;
                txtUnitPrice.Text = SkincareProduct.UnitPrice.ToString();
                txtQuantity.Text = SkincareProduct.Quantity.ToString();
                imagePath = SkincareProduct.Image;
                BitmapImage bitmapImage = new BitmapImage(new Uri(imagePath));
                imgPreview.Source = bitmapImage;
                cbCategory.SelectedValue = SkincareProduct.CategoryId;
                cbBrand.SelectedValue = SkincareProduct.BrandId;
                chkInStock.IsChecked = SkincareProduct.IsAvailable;
            }
        }
        private void loadCategory()
        {
            var data = _categoryService.GetAll();
            cbCategory.ItemsSource = data;
            cbCategory.DisplayMemberPath = "Name"; // Tên thuộc tính hiển thị
            cbCategory.SelectedValuePath = "CategoryId"; // Giá trị khi chọn

        }
        private void loadBrand()
        {
            var data = _brandService.GetAll();
            cbBrand.ItemsSource = data;
            cbBrand.DisplayMemberPath = "Name"; // Tên thuộc tính hiển thị
            cbBrand.SelectedValuePath = "BrandId"; // Giá trị khi chọn
        }
        private void SelectImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
            if (openFileDialog.ShowDialog() == true)
            {
                imagePath = openFileDialog.FileName; // Lưu đường dẫn ảnh
                MessageBox.Show(imagePath);
                // Hiển thị ảnh trong Image control
                BitmapImage bitmapImage = new BitmapImage(new Uri(imagePath));
                imgPreview.Source = bitmapImage;
                SaveImageLink();
            }
        }

        private void SaveImageLink()
        {
            if (imagePath != null)
            {
                try
                {
                    // Lấy đường dẫn đến thư mục bin
                    string binDirectory = AppDomain.CurrentDomain.BaseDirectory;

                    // Đi lên 3 cấp từ thư mục bin để đến thư mục solution
                    // (bin -> Debug/Release -> project -> solution)
                    string solutionDirectory = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(binDirectory).FullName).FullName).FullName).FullName;

                    // Tạo đường dẫn đến thư mục Image trong thư mục solution
                    string ImageFolder = Path.Combine(solutionDirectory, "Image");

                    // Tạo thư mục nếu chưa tồn tại
                    if (!Directory.Exists(ImageFolder))
                    {
                        Directory.CreateDirectory(ImageFolder);
                    }

                    string ImageFileName = Guid.NewGuid().ToString() + Path.GetExtension(imagePath);
                    string NewPathImage = Path.Combine(ImageFolder, ImageFileName);
                    File.Copy(imagePath, NewPathImage);
                    MessageBox.Show(NewPathImage);

                    // Lưu tên file vào biến imagePath
                    imagePath = ImageFileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lưu ảnh: " + ex.Message);
                }
            }
        }
        private void SaveProduct_Click(object sender, RoutedEventArgs e)
        {
            var name = txtName.Text.Trim();
            var description = txtDescription.Text.Trim();
            var capacity = txtCapacity.Text.Trim();
            var unitPriceText = txtUnitPrice.Text.Trim();
            var quantityText = txtQuantity.Text.Trim();
            var image = imagePath;
            var username = "staff@gmail.com";

            // Kiểm tra tên sản phẩm
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Vui lòng nhập tên sản phẩm.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Kiểm tra mô tả sản phẩm
            if (string.IsNullOrWhiteSpace(description))
            {
                MessageBox.Show("Vui lòng nhập mô tả sản phẩm.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Kiểm tra dung tích
            if (string.IsNullOrWhiteSpace(capacity))
            {
                MessageBox.Show("Vui lòng nhập dung tích sản phẩm.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Kiểm tra danh mục
            if (cbCategory.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn danh mục sản phẩm.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            int categoryId = (int)cbCategory.SelectedValue;

            // Kiểm tra thương hiệu
            if (cbBrand.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn thương hiệu sản phẩm.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            int brandId = (int)cbBrand.SelectedValue;

            // Kiểm tra đơn giá
            if (!decimal.TryParse(unitPriceText, out decimal unitPrice) || unitPrice <= 0)
            {
                MessageBox.Show("Vui lòng nhập đơn giá hợp lệ (số dương).", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Kiểm tra số lượng
            if (!int.TryParse(quantityText, out int quantity) || quantity < 0)
            {
                MessageBox.Show("Vui lòng nhập số lượng hợp lệ (số nguyên không âm).", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Xác định trạng thái còn hàng
            bool isAvailable = chkInStock.IsChecked == true;

            if (isAddFeature)
            {
                SkincareProduct skincareProduct = new SkincareProduct()
                {
                    Name = name,
                    Description = description,
                    CategoryId = categoryId,
                    BrandId = brandId,
                    IsAvailable = isAvailable,
                    Capacity = capacity,
                    UnitPrice = unitPrice,
                    Image = image,
                    Quantity = quantity,
                    Username = username
                };

                // Hiển thị thông tin sản phẩm trước khi thêm
                MessageBox.Show($"Tên sản phẩm: {skincareProduct.Name}\n" +
                    $"Mô tả: {skincareProduct.Description}\n" +
                    $"Danh mục ID: {skincareProduct.CategoryId}\n" +
                    $"Thương hiệu ID: {skincareProduct.BrandId}\n" +
                    $"Còn hàng: {(skincareProduct.IsAvailable ? "Có" : "Không")}\n" +
                    $"Dung tích: {skincareProduct.Capacity}\n" +
                    $"Giá: {skincareProduct.UnitPrice:C}\n" +
                    $"Hình ảnh: {skincareProduct.Image}\n" +
                    $"Số lượng: {skincareProduct.Quantity}", "Thông tin sản phẩm", MessageBoxButton.OK, MessageBoxImage.Information);

                // Thêm sản phẩm vào hệ thống
                if (_skincareProductService.Add(skincareProduct))
                {
                    MessageBox.Show("Thêm sản phẩm thành công.", "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Thêm sản phẩm thất bại. Vui lòng thử lại.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                if(SkincareProduct == null)
                {
                    MessageBox.Show("Không tìm thấy sản phẩm cần chỉnh sửa.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                SkincareProduct.Name = name;
                SkincareProduct.Description = description;
                SkincareProduct.CategoryId = categoryId;
                SkincareProduct.BrandId = brandId;
                SkincareProduct.IsAvailable = isAvailable;
                SkincareProduct.Capacity = capacity;
                SkincareProduct.UnitPrice = unitPrice;
                SkincareProduct.Image = image;
                SkincareProduct.Quantity = quantity;
                SkincareProduct.Username = username;
                if(_skincareProductService.Update(SkincareProduct))
                {
                    MessageBox.Show("Cập nhật sản phẩm thành công.", "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Cập nhật sản phẩm thất bại. Vui lòng thử lại.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            // Tạo đối tượng sản phẩm
            
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            ProductPage productPage = new ProductPage();
            productPage.Show();
            this.Close();
        }

        private void cbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
