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
namespace TPA_ES.View
{
    /// <summary>
    /// Interaction logic for TellerView.xaml
    /// </summary>
    public partial class TellerView : Window
    {
        
        public TellerView()
        {
            InitializeComponent();
           
        }

        private void btnDepositMoney_Click(object sender, RoutedEventArgs e)
        {
            DepositMoneyView objDepositMoneyView= new DepositMoneyView();
            objDepositMoneyView.Show();
            this.Close();
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            MenuWindow mainMenuView = new MenuWindow();
            mainMenuView.Show();
            this.Close();
        }

        private void btnWithdrawMoney_Click(object sender, RoutedEventArgs e)
        {
            WithdrawMoneyView withdrawMoneyView = new WithdrawMoneyView();
            withdrawMoneyView.Show();
            this.Close();
        }

        private void btnTransferMoney_Click(object sender, RoutedEventArgs e)
        {
            TransferMoneyView transferMoneyView = new TransferMoneyView();
            transferMoneyView.Show();
            this.Close();
        }

        private void btnPayments_Click(object sender, RoutedEventArgs e)
        {
            PaymentView paymentView = new PaymentView();
            paymentView.Show();
            this.Close();
        }

        private void btnReportBrokenItem_Click(object sender, RoutedEventArgs e)
        {
            ReportBrokenItemView view= new ReportBrokenItemView();
            view.Show();
        }
    }
}
