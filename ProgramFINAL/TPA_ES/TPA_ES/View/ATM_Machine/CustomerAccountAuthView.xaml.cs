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
    /// Interaction logic for CustomerAccountAuthView.xaml
    /// </summary>
    public partial class CustomerAccountAuthView : Window
    {
        CustomerViewModel ViewModel;
        public CustomerAccountAuthView()
        {
            InitializeComponent();
            ViewModel = new CustomerViewModel();
            this.DataContext = ViewModel;

            ViewModel.OnRequestClose += (s, e) => this.Close();
        }

    

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            MenuWindow menuWindow = new MenuWindow();
            menuWindow.Show();
            this.Close();
    
        }

    }
}
