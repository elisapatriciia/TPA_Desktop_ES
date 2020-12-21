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
    /// Interaction logic for ReportBrokenItemView.xaml
    /// </summary>
    public partial class ReportBrokenItemView : Window
    {
        SecurityViewModel viewModel;
        public ReportBrokenItemView()
        {
            
            InitializeComponent();
            viewModel = new SecurityViewModel();
            this.DataContext = viewModel;
        }
    }
}
