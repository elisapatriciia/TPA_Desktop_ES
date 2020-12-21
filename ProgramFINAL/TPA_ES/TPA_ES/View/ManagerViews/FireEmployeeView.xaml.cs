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

using TPA_ES.ViewModel;
namespace TPA_ES.View.ManagerViews
{
    /// <summary>
    /// Interaction logic for FireEmployeeView.xaml
    /// </summary>
    public partial class FireEmployeeView : Window
    {
        EmployeeViewModel viewModel;
        public FireEmployeeView()
        {
            InitializeComponent();
            viewModel = new EmployeeViewModel();
            this.DataContext = viewModel;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            ManagerView managerView = new ManagerView();
            managerView.Show();
            this.Close();
        }
    }
}
