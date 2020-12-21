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

using TPA_ES.ViewModel.EmployeeViewModels;
namespace TPA_ES.View
{
    /// <summary>
    /// Interaction logic for EmployeeLeavingPermitView.xaml
    /// </summary>
    public partial class EmployeeLeavingPermitView : Window
    {
        EmployeeLeavingPermitViewModel ViewModel;
        public EmployeeLeavingPermitView()
        {
            InitializeComponent();
            ViewModel = new EmployeeLeavingPermitViewModel();
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
