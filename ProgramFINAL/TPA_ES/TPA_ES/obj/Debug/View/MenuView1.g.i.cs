// Updated by XamlIntelliSenseFileGenerator 12/9/2020 3:36:01 PM
#pragma checksum "..\..\..\View\MenuView1.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "76BCC9C279179F595AB48D7B271F16DF853833ADCBD12CC6F7EE49765A820341"
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
using TPA_ES.View;


namespace TPA_ES.View
{


    /// <summary>
    /// MenuView
    /// </summary>
    public partial class MenuView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector
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
            System.Uri resourceLocater = new System.Uri("/TPA_ES;component/view/menuview1.xaml", System.UriKind.Relative);

#line 1 "..\..\..\View\MenuView1.xaml"
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
                    this.btnCustomer = ((System.Windows.Controls.Button)(target));
                    return;
                case 2:
                    this.btnTeller = ((System.Windows.Controls.Button)(target));

#line 31 "..\..\..\View\MenuView1.xaml"
                    this.btnTeller.Click += new System.Windows.RoutedEventHandler(this.btnTeller_Click);

#line default
#line hidden
                    return;
                case 3:
                    this.btnCustomerService = ((System.Windows.Controls.Button)(target));
                    return;
                case 4:
                    this.btnSMT = ((System.Windows.Controls.Button)(target));
                    return;
                case 5:
                    this.btnHRM = ((System.Windows.Controls.Button)(target));
                    return;
                case 6:
                    this.btnFinance = ((System.Windows.Controls.Button)(target));
                    return;
                case 7:
                    this.btnManager = ((System.Windows.Controls.Button)(target));
                    return;
            }
            this._contentLoaded = true;
        }
    }
}

