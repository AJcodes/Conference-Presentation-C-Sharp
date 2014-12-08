using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using Microsoft.Win32;
using Clara.Base;
using Clara.Cores;
using Clara.Forms;
using Clara.Controls;

namespace Clara.Windows
{
    /// <summary>
    /// Interaction logic for ThumbnailsBar.xaml
    /// </summary>
    public partial class AppsBar : Window
    {
        private bool isOpened;
        private MainWindow main;

        public AppsBar(MainWindow window)
        {
                this.Height = SystemParameters.PrimaryScreenHeight;
                this.Width = SystemParameters.PrimaryScreenWidth;
                this.Top = 0;
                main = window;
            InitializeComponent();
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            this.Left = 0;
            isOpened = false;
            if (!Dwm.IsGlassAvailable() || !Dwm.IsGlassEnabled())
            {
                this.Left = Width - 1;
                return;
            }

            //InitializeThumbnails();
        }

        private void ToolbarMouseLeave(object sender, MouseEventArgs e)
        {
            CloseToolbar();
        }

        private void WindowMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        public void Open()
        {
            var s = Resources["ToolbarOpenAnim"] as Storyboard;
            s.Begin();
            isOpened = true;

            this.Opacity = 1;

        }

        public void CloseToolbar()
        {
            var s = Resources["ToolbarCloseAnim"] as Storyboard;
            s.Begin();
            isOpened = false;
        }

        private void ToolbaOpenAnimCompleted(object sender, EventArgs e)
        {
        }

        private void ToolbarCloseAnimCompleted(object sender, EventArgs e)
        {
            //AppsList.Children.Clear();
            Opacity = 0.01;
        }


        private void AppsMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void TextBlock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void Create_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var Cr1 = new Create(main);
            main.Content = Cr1;
            CloseToolbar();
        }

        private void Edit_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void Host_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var Cr1 = new ServerForm(main);
            main.Content = Cr1;
            CloseToolbar();
        }

        private void Client_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var Cr1 = new ClientForm(main);
            main.Content = Cr1;
            CloseToolbar();
        }

        private void Return_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            CloseToolbar();
        }
    }
}