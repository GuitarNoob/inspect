﻿#pragma checksum "..\..\..\UserControls\RunPartStart.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "A7E72EA8CF8D8CBBFE87CEB6B5696740"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
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


namespace ProcessInspection.UserControls {
    
    
    /// <summary>
    /// RunPartStart
    /// </summary>
    public partial class RunPartStart : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 8 "..\..\..\UserControls\RunPartStart.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid MainGrid;
        
        #line default
        #line hidden
        
        
        #line 9 "..\..\..\UserControls\RunPartStart.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid contentDataGrid;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\UserControls\RunPartStart.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem MenuAdd;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\UserControls\RunPartStart.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem MenuEdit;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\UserControls\RunPartStart.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem MenuRemove;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\UserControls\RunPartStart.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonRefresh;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\UserControls\RunPartStart.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextboxSearch;
        
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
            System.Uri resourceLocater = new System.Uri("/ProcessInspection;component/usercontrols/runpartstart.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UserControls\RunPartStart.xaml"
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
            
            #line 7 "..\..\..\UserControls\RunPartStart.xaml"
            ((ProcessInspection.UserControls.RunPartStart)(target)).Loaded += new System.Windows.RoutedEventHandler(this.UserControl_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.MainGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.contentDataGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 11 "..\..\..\UserControls\RunPartStart.xaml"
            this.contentDataGrid.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.contentDataGrid_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 4:
            this.MenuAdd = ((System.Windows.Controls.MenuItem)(target));
            
            #line 14 "..\..\..\UserControls\RunPartStart.xaml"
            this.MenuAdd.Click += new System.Windows.RoutedEventHandler(this.MenuAdd_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.MenuEdit = ((System.Windows.Controls.MenuItem)(target));
            
            #line 15 "..\..\..\UserControls\RunPartStart.xaml"
            this.MenuEdit.Click += new System.Windows.RoutedEventHandler(this.MenuEdit_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.MenuRemove = ((System.Windows.Controls.MenuItem)(target));
            
            #line 16 "..\..\..\UserControls\RunPartStart.xaml"
            this.MenuRemove.Click += new System.Windows.RoutedEventHandler(this.MenuRemove_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.ButtonRefresh = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\UserControls\RunPartStart.xaml"
            this.ButtonRefresh.Click += new System.Windows.RoutedEventHandler(this.ButtonRefresh_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.TextboxSearch = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

