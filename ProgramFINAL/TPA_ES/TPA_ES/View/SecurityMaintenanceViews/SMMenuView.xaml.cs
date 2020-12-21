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

namespace TPA_ES.View.SecurityMaintenanceViews
{
    /// <summary>
    /// Interaction logic for SMMenuView.xaml
    /// </summary>
    public partial class SMMenuView : Window
    {
        public SMMenuView()
        {
            InitializeComponent();
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            MenuWindow menuWindow = new MenuWindow();
            menuWindow.Show();
            this.Close();
        }

        private void handleScheduleBtn_Click(object sender, RoutedEventArgs e)
        {
            SetScheduleView setScheduleView = new SetScheduleView();
            setScheduleView.Show();
            this.Close();
        }

        private void viewScheduleBtn_Click(object sender, RoutedEventArgs e)
        {
            SecurityMaintenanceView securityMaintenanceView = new SecurityMaintenanceView();
            securityMaintenanceView.Show();
            this.Close();
        }
    }
}
