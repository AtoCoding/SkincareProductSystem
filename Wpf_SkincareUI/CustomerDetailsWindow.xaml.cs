using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Wpf_SkincareUI
{
    /// <summary>
    /// Interaction logic for CustomerDetailsWindow.xaml
    /// </summary>
    public partial class CustomerDetailsWindow : Window
    {
        public CustomerDetailsWindow()
        {
            InitializeComponent();
        }

        // Placeholder for Save Changes button
        private void SaveChanges_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Save functionality not implemented yet.");
        }
    }
}
