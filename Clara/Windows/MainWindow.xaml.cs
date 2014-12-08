using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Reflection;
using Clara.Base;
using Clara.Forms;
using Clara.Cores;
using Clara.Controls;

namespace Clara.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private ThumbnailsBar thumbBar;
        public AppsBar Appsbar;

        public MainWindow()
        {
            
            InitializeComponent();
            
        }

        private void WindowSourceInitialized(object sender, EventArgs e)
        {
            var handle = new WindowInteropHelper(this).Handle;
            Appsbar = new AppsBar(this);
            Appsbar.Opacity = 0;
            Appsbar.Show();
            thumbBar = new ThumbnailsBar();
            thumbBar.Opacity = 0;
            thumbBar.Show();
            
            

            iFr.Helper.Animate(this, OpacityProperty, 1000, 0, 1);
            iFr.Helper.Delay(new Action(() =>
            {
                if (this.thumbBar != null) { this.thumbBar.Opacity = 1; }
                this.Appsbar.Opacity = 1;
            }), 1500);
            //var Cr1 = new ServerForm(this);
            //this.Content = Cr1;

        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            this.Width = SystemParameters.PrimaryScreenWidth;
            this.Height = SystemParameters.PrimaryScreenHeight;
            this.Top = 0;
            this.Left = 0;
            
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
        }

        private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
        }

        private void WindowMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (thumbBar == null)
            {
                thumbBar = new ThumbnailsBar();
                thumbBar.Show();
            }
        }



    }
}
