using BusinessLogicLayer.Services;
using DataAccessLayer.Entities;
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
    /// Interaction logic for NewCustomerWindows.xaml
    /// </summary>
    public partial class NewCustomerWindow : Window
    {
        private readonly User user;
        private readonly UserService _userService;
        public NewCustomerWindow()
        {
            InitializeComponent();
            _userService = new UserService();
            this.user = new User();
        }

        private void CreateNewCustomer_Click(object sender, RoutedEventArgs e)
        {

            this.Close();
        }
    }
}
