﻿#pragma checksum "..\..\..\ClientForms\Chat.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "9B75477F2B06F214B9C22E7B97673EAC"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Clara.Controls;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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


namespace Clara.ClientForms {
    
    
    /// <summary>
    /// Chat
    /// </summary>
    public partial class Chat : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\..\ClientForms\Chat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid mainGrid;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\ClientForms\Chat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GamesContainer2;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\ClientForms\Chat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox view;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\ClientForms\Chat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox entry;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\ClientForms\Chat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock enter;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\ClientForms\Chat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid canvas;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\ClientForms\Chat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock @return;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\ClientForms\Chat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Close;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\ClientForms\Chat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Minimize;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\ClientForms\Chat.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock KCFname;
        
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
            System.Uri resourceLocater = new System.Uri("/Clara;component/clientforms/chat.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\ClientForms\Chat.xaml"
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
            this.mainGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.GamesContainer2 = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.view = ((System.Windows.Controls.TextBox)(target));
            
            #line 14 "..\..\..\ClientForms\Chat.xaml"
            this.view.GotFocus += new System.Windows.RoutedEventHandler(this.pane_GotFocus);
            
            #line default
            #line hidden
            return;
            case 4:
            this.entry = ((System.Windows.Controls.TextBox)(target));
            
            #line 15 "..\..\..\ClientForms\Chat.xaml"
            this.entry.GotFocus += new System.Windows.RoutedEventHandler(this.entry_GotFocus);
            
            #line default
            #line hidden
            return;
            case 5:
            this.enter = ((System.Windows.Controls.TextBlock)(target));
            
            #line 16 "..\..\..\ClientForms\Chat.xaml"
            this.enter.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.enter_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 6:
            this.canvas = ((System.Windows.Controls.Grid)(target));
            return;
            case 7:
            this.@return = ((System.Windows.Controls.TextBlock)(target));
            
            #line 22 "..\..\..\ClientForms\Chat.xaml"
            this.@return.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.return_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Close = ((System.Windows.Controls.Image)(target));
            
            #line 29 "..\..\..\ClientForms\Chat.xaml"
            this.Close.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.Close_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 9:
            this.Minimize = ((System.Windows.Controls.Image)(target));
            
            #line 36 "..\..\..\ClientForms\Chat.xaml"
            this.Minimize.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.Minimize_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 10:
            this.KCFname = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
