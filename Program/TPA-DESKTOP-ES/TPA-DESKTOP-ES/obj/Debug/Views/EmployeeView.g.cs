// Updated by XamlIntelliSenseFileGenerator 12/6/2020 10:07:55 PM
#pragma checksum "..\..\..\Views\EmployeeView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "428388A4849EB15062937A283E73C10C4CE3D7BD613E0DE084C39AE55FF95D70"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using TPA_DESKTOP_ES.Views;


namespace TPA_DESKTOP_ES.Views
{


    /// <summary>
    /// Employeeview
    /// </summary>
    public partial class Employeeview : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector
    {

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/TPA-DESKTOP-ES;component/views/employeeview.xaml", System.UriKind.Relative);

#line 1 "..\..\..\Views\EmployeeView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);

#line default
#line hidden
        }

        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:
                    this.txtID = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 2:
                    this.txtName = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 3:
                    this.txtGender = ((System.Windows.Controls.TextBox)(target));
                    return;
                case 4:
                    this.btnAdd = ((System.Windows.Controls.Button)(target));
                    return;
                case 5:
                    this.btnSearch = ((System.Windows.Controls.Button)(target));
                    return;
                case 6:
                    this.btnUpdate = ((System.Windows.Controls.Button)(target));
                    return;
                case 7:
                    this.btnDelete = ((System.Windows.Controls.Button)(target));
                    return;
                case 8:
                    this.errorMessage = ((System.Windows.Controls.TextBlock)(target));
                    return;
                case 9:
                    this.dgEmployees = ((System.Windows.Controls.DataGrid)(target));
                    return;
            }
            this._contentLoaded = true;
        }
    }
}
