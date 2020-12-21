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

using TPA_ES.View.SecurityMaintenanceViews;
using TPA_ES.View.ManagerViews;
namespace TPA_ES.View
{
    /// <summary>
    /// Interaction logic for ManagerView.xaml
    /// </summary>
    public partial class ManagerView : Window
    {
        public ManagerView()
        {
            InitializeComponent();
        }
        private void backBtn_Click_1(object sender, RoutedEventArgs e)
        {
            MenuWindow menuWindow= new MenuWindow();
            menuWindow.Show();
            this.Close();
        }

        private void btnReportBrokenItem_Click(object sender, RoutedEventArgs e)
        {
            ReportBrokenItemView view = new ReportBrokenItemView();
            view.Show();

        }

        private void btnFireEmployee_Click(object sender, RoutedEventArgs e)
        {
            FireEmployeeView fireEmployeeView = new FireEmployeeView();
            fireEmployeeView.Show();
            this.Close();
        }

        private void btnCheckRequestFire_Click(object sender, RoutedEventArgs e)
        {
            CheckRequestFiringView cv = new CheckRequestFiringView();
            cv.Show();
            this.Close();
        }
    }
}
