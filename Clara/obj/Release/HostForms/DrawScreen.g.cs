﻿#pragma checksum "..\..\..\HostForms\DrawScreen.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "1C1EAABD1394C84CD7EEDD10BA0C325A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
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


namespace Clara.HostForms {
    
    
    /// <summary>
    /// DrawScreen
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
    public partial class DrawScreen : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\HostForms\DrawScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.InkCanvas DrawingPad;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\HostForms\DrawScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Close;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\HostForms\DrawScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Erase;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\HostForms\DrawScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Draw;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Clara;component/hostforms/drawscreen.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\HostForms\DrawScreen.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.DrawingPad = ((System.Windows.Controls.InkCanvas)(target));
            return;
            case 2:
            this.Close = ((System.Windows.Controls.Image)(target));
            
            #line 17 "..\..\..\HostForms\DrawScreen.xaml"
            this.Close.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.Close_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Erase = ((System.Windows.Controls.Image)(target));
            
            #line 24 "..\..\..\HostForms\DrawScreen.xaml"
            this.Erase.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.Erase_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Draw = ((System.Windows.Controls.Image)(target));
            
            #line 31 "..\..\..\HostForms\DrawScreen.xaml"
            this.Draw.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.Draw_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

