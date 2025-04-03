using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using BusinessLogicLayer.Services;
using BusinessLogicLayer.Services.Bases;

namespace Wpf_SkincareUI
{
    /// <summary>
    /// Interaction logic for ReportWindow.xaml
    /// </summary>
    public partial class ReportWindow : Window
    {
        private readonly IRevenueService _iRevenueService = new RevenueService();
        public ReportWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadRevenueList();
            LoadStatistical();
            LoadTopProductsSold();
            LoadLowSalesProducts();
            LoadTopProductsInMonth();
        }

        private void LoadRevenueList()
        {
            var revenueList = _iRevenueService.GetRevenueList();
            dgRevenue.ItemsSource = revenueList;
        }

        private void LoadStatistical()
        {
            var statistical = _iRevenueService.GetStatistical();
            txtTotalNewUsers.Text = statistical[0].ToString();
            txtTotalBuyer.Text = statistical[1].ToString();
            txtTotalProductsSold.Text = statistical[2].ToString();
            txtTotalOrders.Text = statistical[3].ToString();
        }
        private void LoadTopProductsSold()
        {
            var list = _iRevenueService.GetTopProductsSold();

            var textBoxGroups = new[]
            {
                (txtName1, txtPrice1, txtBrand1, txtCategory1, border1),
                (txtName2, txtPrice2, txtBrand2, txtCategory2, border2),
                (txtName3, txtPrice3, txtBrand3, txtCategory3, border3)
            };

            var stackPanelGroups = new[] { spProduct1, spProduct2, spProduct3 };

            for (int i = 0; i < textBoxGroups.Length; i++)
            {
                if (i < list.Count)
                {
                    textBoxGroups[i].Item1.Text = list[i].ProductName.ToString();
                    textBoxGroups[i].Item2.Text = list[i].ProductPrice.ToString();
                    textBoxGroups[i].Item3.Text = list[i].Brand.ToString();
                    textBoxGroups[i].Item4.Text = list[i].Category.ToString();

                    var imageSource = string.IsNullOrEmpty(list[i].Image) ? "empty.jpg" : list[i].Image ?? "empty.jpg";

                    var imageBrush = new ImageBrush();
                    imageBrush.ImageSource = GetImageSource(imageSource);
                    textBoxGroups[i].Item5.Background = imageBrush;
                }
                else
                {
                    textBoxGroups[i].Item1.Text = "Chưa có dữ liệu";

                    var imageBrush = new ImageBrush();
                    imageBrush.ImageSource = GetImageSource("empty.jpg");
                    textBoxGroups[i].Item5.Background = imageBrush;

                    stackPanelGroups[i].IsEnabled = false;
                }
            }

        }

        private void LoadLowSalesProducts()
        {
            var list = _iRevenueService.GetLowSalesProducts();

            var textBoxGroups = new[]
            {
                (txtNameLow1, txtPriceLow1, txtBrandLow1, txtCategoryLow1, borderLow1),
                (txtNameLow2, txtPriceLow2, txtBrandLow2, txtCategoryLow2, borderLow2),
                (txtNameLow3, txtPriceLow3, txtBrandLow3, txtCategoryLow3, borderLow3)
            };

            var stackPanelGroups = new[] { spProductLow1, spProductLow2, spProductLow3 };

            for (int i = 0; i < textBoxGroups.Length; i++)
            {
                if (i < list.Count)
                {
                    textBoxGroups[i].Item1.Text = list[i].ProductName.ToString();
                    textBoxGroups[i].Item2.Text = list[i].ProductPrice.ToString();
                    textBoxGroups[i].Item3.Text = list[i].Brand.ToString();
                    textBoxGroups[i].Item4.Text = list[i].Category.ToString();

                    var imageSource = string.IsNullOrEmpty(list[i].Image) ? "empty.jpg" : list[i].Image ?? "empty.jpg";

                    var imageBrush = new ImageBrush();
                    imageBrush.ImageSource = GetImageSource(imageSource);
                    textBoxGroups[i].Item5.Background = imageBrush;
                }
                else
                {
                    textBoxGroups[i].Item1.Text = "Chưa có dữ liệu";

                    var imageBrush = new ImageBrush();
                    imageBrush.ImageSource = GetImageSource("empty.jpg");
                    textBoxGroups[i].Item5.Background = imageBrush;

                    stackPanelGroups[i].IsEnabled = false;
                }
            }
        }

        private void LoadTopProductsInMonth()
        {
            var list = _iRevenueService.GetTopProductsInMonth();

            var textBoxGroups = new[]
            {
                (txtNameTop1, txtPriceTop1, txtBrandTop1, txtCategoryTop1, borderTop1),
                (txtNameTop2, txtPriceTop2, txtBrandTop2, txtCategoryTop2, borderTop2),
                (txtNameTop3, txtPriceTop3, txtBrandTop3, txtCategoryTop3, borderTop3)
            };

            var stackPanelGroups = new[] { spProductTop1, spProductTop2, spProductTop3 };

            for (int i = 0; i < textBoxGroups.Length; i++)
            {
                if (i < list.Count)
                {
                    textBoxGroups[i].Item1.Text = list[i].ProductName.ToString();
                    textBoxGroups[i].Item2.Text = list[i].ProductPrice.ToString();
                    textBoxGroups[i].Item3.Text = list[i].Brand.ToString();
                    textBoxGroups[i].Item4.Text = list[i].Category.ToString();

                    var imageSource = string.IsNullOrEmpty(list[i].Image) ? "empty.jpg" : list[i].Image ?? "empty.jpg";

                    var imageBrush = new ImageBrush();
                    imageBrush.ImageSource = GetImageSource(imageSource);
                    textBoxGroups[i].Item5.Background = imageBrush;
                }
                else
                {
                    textBoxGroups[i].Item1.Text = "Chưa có dữ liệu";

                    var imageBrush = new ImageBrush();
                    imageBrush.ImageSource = GetImageSource("empty.jpg");
                    textBoxGroups[i].Item5.Background = imageBrush;

                    stackPanelGroups[i].IsEnabled = false;
                }
            }
        }

        private BitmapImage GetImageSource(string imageName)
        {
            string projectDirectory = AppContext.BaseDirectory;
            string imageFolder = System.IO.Path.Combine(projectDirectory, @"..\..\..\Image");
            imageFolder = System.IO.Path.GetFullPath(imageFolder);

            string imagePath = System.IO.Path.Combine(imageFolder, imageName);

            if (!File.Exists(imagePath))
            {
                imagePath = System.IO.Path.Combine(imageFolder, "empty.jpg"); 
            }

            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(imagePath, UriKind.Absolute);
            bitmap.CacheOption = BitmapCacheOption.OnLoad;
            bitmap.EndInit();
            return bitmap;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        


    }
}
