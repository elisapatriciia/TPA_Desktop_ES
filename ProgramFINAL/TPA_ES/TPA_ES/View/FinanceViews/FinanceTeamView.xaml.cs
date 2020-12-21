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
namespace TPA_ES.View.FinanceViews
{
    /// <summary>
    /// Interaction logic for FinanceTeamView.xaml
    /// </summary>
    public partial class FinanceTeamView : Window
    {
        public FinanceTeamView()
        {
            InitializeComponent();
        }

        private void btnManageEmployeeSalary_Click(object sender, RoutedEventArgs e)
        {
            SetEmployeeSalaryView view = new SetEmployeeSalaryView();
            view.Show();
            this.Close();
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            MenuWindow menu = new MenuWindow();
            menu.Show();
            this.Close();
        }

        private void btnReportBrokenItem_Click(object sender, RoutedEventArgs e)
        {
            ReportBrokenItemView report = new ReportBrokenItemView();
            report.Show();
            this.Close();
        }
    }
}
