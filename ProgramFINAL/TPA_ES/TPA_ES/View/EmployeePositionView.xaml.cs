﻿using System;
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
namespace TPA_ES.View
{
    /// <summary>
    /// Interaction logic for EmployeePositionView.xaml
    /// </summary>
    public partial class EmployeePositionView : Window
    {
        EmployeePositionViewModel ViewModel;
        public EmployeePositionView()
        {
            InitializeComponent();
            ViewModel = new EmployeePositionViewModel();
            this.DataContext = ViewModel;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            HumanResourceManagementView humanResourceManagementView = new HumanResourceManagementView();
            humanResourceManagementView.Show();
            this.Close();
        }
    }
}
