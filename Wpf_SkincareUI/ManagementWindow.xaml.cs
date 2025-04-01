using System.Windows;
using DataAccessLayer.Entities;

namespace Wpf_SkincareUI
{
    /// <summary>
    /// Interaction logic for ManagementWindow.xaml
    /// </summary>
    public partial class ManagementWindow : Window
    {
        private User user;
        public ManagementWindow(User user)
        {
            InitializeComponent();
            this.user = user;
        }
    }
}
