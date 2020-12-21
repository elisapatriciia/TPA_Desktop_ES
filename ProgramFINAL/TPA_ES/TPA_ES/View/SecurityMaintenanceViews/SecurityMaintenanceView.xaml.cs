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

using TPA_ES.ViewModel.SecutiryMaintenanceViewModels;

namespace TPA_ES.View.SecurityMaintenanceViews
{
    /// <summary>
    /// Interaction logic for SecurityMaintenanceView.xaml
    /// </summary>
    public partial class SecurityMaintenanceView : Window
    {
        SecurityViewModel ViewModel;
        public SecurityMaintenanceView()
        {
            InitializeComponent();
            ViewModel = new SecurityViewModel();
            this.DataContext = ViewModel;
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            SMMenuView menuView = new SMMenuView();
            menuView.Show();
            this.Close();
        }
    }
}
