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

using TPA_ES.View.HRView;
using TPA_ES.View.SecurityMaintenanceViews;
namespace TPA_ES.View
{
    /// <summary>
    /// Interaction logic for HumanResourceManagementView.xaml
    /// </summary>
    public partial class HumanResourceManagementView : Window
    {
        public HumanResourceManagementView()
        {
            InitializeComponent();
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            MenuWindow mainMenuView = new MenuWindow();
            mainMenuView.Show();
            this.Close();
        }

        private void btnManageEmployee_Click(object sender, RoutedEventArgs e)
        {
            ManageEmployeeView manageEmployeeView = new ManageEmployeeView();
            manageEmployeeView.Show();
            this.Close();
        }

        private void btnViolation_Click(object sender, RoutedEventArgs e)
        {
            ViolationEmployeeView violationEmployeeView= new ViolationEmployeeView();
            violationEmployeeView.Show();
            this.Close();
        }

        private void btnAvailablePosition_Click(object sender, RoutedEventArgs e)
        {
            EmployeePositionView employeePositionView = new EmployeePositionView();
            employeePositionView.Show();
            this.Close();
        }

        private void btnLeavingPermit_Click(object sender, RoutedEventArgs e)
        {
            EmployeeLeavingPermitView employeeLeavingPermitView = new EmployeeLeavingPermitView();
            employeeLeavingPermitView.Show();
            this.Close();
        }

        private void btnReportBrokenItem_Click(object sender, RoutedEventArgs e)
        {
            ReportBrokenItemView view= new ReportBrokenItemView();
            view.Show();
        }

        private void btnFireEmployee_Click(object sender, RoutedEventArgs e)
        {
            RequestFiringEmployee view = new RequestFiringEmployee();
            view.Show();
            this.Close();
        }

        private void btnEmployeeSalary_Click(object sender, RoutedEventArgs e)
        {
            RequestSalaryView salaryView = new RequestSalaryView();
            salaryView.Show();
            this.Close();
        }
    }
}
