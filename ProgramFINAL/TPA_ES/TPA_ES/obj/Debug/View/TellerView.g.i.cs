﻿#pragma checksum "..\..\..\View\TellerView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "910E7E9F615F8256910855C907AA268AA678C23F33170339EFA40A7EEBEEA14F"
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


namespace TPA_ES.View {
    
    
    /// <summary>
    /// TellerView
    /// </summary>
    public partial class TellerView : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 28 "..\..\..\View\TellerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDepositMoney;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\View\TellerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnTransferMoney;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\View\TellerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPayments;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\View\TellerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnWithdrawMoney;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\View\TellerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnQRReview;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\View\TellerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnReportBrokenItem;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\View\TellerView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button backBtn;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/TPA_ES;component/view/tellerview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\TellerView.xaml"
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
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.btnDepositMoney = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\..\View\TellerView.xaml"
            this.btnDepositMoney.Click += new System.Windows.RoutedEventHandler(this.btnDepositMoney_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnTransferMoney = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\..\View\TellerView.xaml"
            this.btnTransferMoney.Click += new System.Windows.RoutedEventHandler(this.btnTransferMoney_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnPayments = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\..\View\TellerView.xaml"
            this.btnPayments.Click += new System.Windows.RoutedEventHandler(this.btnPayments_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnWithdrawMoney = ((System.Windows.Controls.Button)(target));
            
            #line 35 "..\..\..\View\TellerView.xaml"
            this.btnWithdrawMoney.Click += new System.Windows.RoutedEventHandler(this.btnWithdrawMoney_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnQRReview = ((System.Windows.Controls.Button)(target));
            return;
            case 6:
            this.btnReportBrokenItem = ((System.Windows.Controls.Button)(target));
            
            #line 39 "..\..\..\View\TellerView.xaml"
            this.btnReportBrokenItem.Click += new System.Windows.RoutedEventHandler(this.btnReportBrokenItem_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.backBtn = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\..\View\TellerView.xaml"
            this.backBtn.Click += new System.Windows.RoutedEventHandler(this.backBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

