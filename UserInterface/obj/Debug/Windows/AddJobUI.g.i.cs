﻿#pragma checksum "..\..\..\Windows\AddJobUI.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "A23E9254A84EFDCA9069996A84B2EA2CDFA740E23385744E7F8926BFF945EAA9"
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
using UserInterface.Windows;


namespace UserInterface.Windows {
    
    
    /// <summary>
    /// AddJobUI
    /// </summary>
    public partial class AddJobUI : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\..\Windows\AddJobUI.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox jobNameBox;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\Windows\AddJobUI.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox jobDiscriptionBox;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\Windows\AddJobUI.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker jobDatePicker;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\Windows\AddJobUI.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox jobFieldBox;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\Windows\AddJobUI.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addJobBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/UserInterface;component/windows/addjobui.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Windows\AddJobUI.xaml"
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
            this.jobNameBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.jobDiscriptionBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.jobDatePicker = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 4:
            this.jobFieldBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.addJobBtn = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\..\Windows\AddJobUI.xaml"
            this.addJobBtn.Click += new System.Windows.RoutedEventHandler(this.PridetiDarba);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

