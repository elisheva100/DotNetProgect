﻿#pragma checksum "..\..\ContractsWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "201F61401182492E428EE0833C2017F3"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using PLForms;
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


namespace PLForms {
    
    
    /// <summary>
    /// ContractsWindow
    /// </summary>
    public partial class ContractsWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\ContractsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button deleteContractBotton;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\ContractsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button updateContractBotton;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\ContractsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button All_ContractsBotton;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\ContractsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddContractBotton;
        
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
            System.Uri resourceLocater = new System.Uri("/PLForms;component/contractswindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ContractsWindow.xaml"
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
            this.deleteContractBotton = ((System.Windows.Controls.Button)(target));
            
            #line 10 "..\..\ContractsWindow.xaml"
            this.deleteContractBotton.Click += new System.Windows.RoutedEventHandler(this.deleteContractBotton_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.updateContractBotton = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\ContractsWindow.xaml"
            this.updateContractBotton.Click += new System.Windows.RoutedEventHandler(this.updateContractBotton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.All_ContractsBotton = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\ContractsWindow.xaml"
            this.All_ContractsBotton.Click += new System.Windows.RoutedEventHandler(this.All_ContractsBotton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.AddContractBotton = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\ContractsWindow.xaml"
            this.AddContractBotton.Click += new System.Windows.RoutedEventHandler(this.AddContractBotton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

