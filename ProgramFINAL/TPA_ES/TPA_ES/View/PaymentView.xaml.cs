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
namespace TPA_ES.View
{
    /// <summary>
    /// Interaction logic for PaymentView.xaml
    /// </summary>
    public partial class PaymentView : Window
    {
        CustomerViewModel ViewModel;
        public PaymentView()
        {
            InitializeComponent();
            ViewModel = new CustomerViewModel();
            this.DataContext = ViewModel;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            TellerView tellerView = new TellerView();
            tellerView.Show();
            this.Close();
        }
    }
}
