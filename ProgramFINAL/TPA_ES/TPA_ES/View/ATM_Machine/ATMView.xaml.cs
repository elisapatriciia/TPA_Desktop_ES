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

using TPA_ES.ViewModel.CustomerViewModels;
namespace TPA_ES.View.ATM_Machine
{
    /// <summary>
    /// Interaction logic for ATMView.xaml
    /// </summary>
    public partial class ATMView : Window
    {
        public ATMView()
        {
            InitializeComponent();
            CustomerViewModel viewModel = new CustomerViewModel();
            this.DataContext = viewModel;
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            MenuWindow menuWindow= new MenuWindow();
            menuWindow.Show();
            this.Close();
        }

        private void btnDepositMoney_Click(object sender, RoutedEventArgs e)
        {
            DepositbyATMView depositbyATMView = new DepositbyATMView();
            depositbyATMView.Show();
            this.Close();
        }

        private void btnTransferMoney_Click(object sender, RoutedEventArgs e)
        {
            TransferbyATMView ATMView = new TransferbyATMView();
            ATMView.Show();
            this.Close();
        }

        private void btnPayments_Click(object sender, RoutedEventArgs e)
        {
            PaymentsbyATMView ATMView = new PaymentsbyATMView();
            ATMView.Show();
            this.Close();
        }

        private void btnWithdrawMoney_Click(object sender, RoutedEventArgs e)
        {
            WithdrawbyATMView ATMView = new WithdrawbyATMView();
            ATMView.Show();
            this.Close();
        }

        private void btnCustomerTrackStatus_Click(object sender, RoutedEventArgs e)
        {
            TransferVirtualAccountView transferVirtualAccountView = new TransferVirtualAccountView();
            transferVirtualAccountView.Show();
            this.Close();
        }
    }
}
