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
namespace TPA_ES.View.FinanceViews
{
    /// <summary>
    /// Interaction logic for SetEmployeeSalaryView.xaml
    /// </summary>
    public partial class SetEmployeeSalaryView : Window
    {
        EmployeeViewModel viewModel;
        public SetEmployeeSalaryView()
        {
            InitializeComponent();
            viewModel = new EmployeeViewModel();
            this.DataContext = viewModel;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            FinanceTeamView view = new FinanceTeamView();
            view.Show();
            this.Close();
        }
    }
}
