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

using TPA_ES.View.FinanceViews;
using TPA_ES.View.ATM_Machine;
using TPA_ES.View.SecurityMaintenanceViews;
namespace TPA_ES.View
{
    /// <summary>
    /// Interaction logic for MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        public MenuWindow()
        {
            InitializeComponent();
        }

        private void btnTeller_Click(object sender, RoutedEventArgs e)
        {
            TellerView objTellerView = new TellerView();
            objTellerView.Show();
            this.Close();
        }

        private void btnHRM_Click(object sender, RoutedEventArgs e)
        {
            HumanResourceManagementView objTellerView = new HumanResourceManagementView();
            objTellerView.Show();
            this.Close();
        }

        private void btnCustomerService_Click(object sender, RoutedEventArgs e)
        {
            CustomerServiceView customerServiceView = new CustomerServiceView();
            customerServiceView.Show();
            this.Close();
        }

        private void btnManager_Click(object sender, RoutedEventArgs e)
        {
            ManagerView managerView = new ManagerView();
            managerView.Show();
            this.Close();
        }

        private void btnQueue_Click(object sender, RoutedEventArgs e)
        {
            QueuMachineView queuMachineView = new QueuMachineView();
            queuMachineView.Show();
            this.Close();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnATM_Click(object sender, RoutedEventArgs e)
        {
            CustomerAccountAuthView customerAccountAuthView = new CustomerAccountAuthView();
            customerAccountAuthView.Show();
            this.Close();
        }

        private void btnSM_Click(object sender, RoutedEventArgs e)
        {
            SMMenuView menuView = new SMMenuView();
            menuView.Show();
            this.Close();
        }

        private void btnFinance_Click(object sender, RoutedEventArgs e)
        {
            FinanceTeamView view = new FinanceTeamView();
            view.Show();
            this.Close();
        }

        //TellerView objTellerView = new TellerView();
        //objTellerView.Show();
        //    this.Close();
    }
}
