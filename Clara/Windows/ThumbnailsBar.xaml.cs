﻿using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using Clara.Base;
using Clara.Controls;

namespace Clara.Windows
{
    /// <summary>
    /// Interaction logic for ThumbnailsBar.xaml
    /// </summary>
    public partial class ThumbnailsBar : Window
    {
        private bool isOpened;

        public ThumbnailsBar()
        {
                this.Width = SystemParameters.PrimaryScreenWidth;
                this.Top = 0;
            InitializeComponent();
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            this.Left = 0;
            isOpened = false;
            if (!Dwm.IsGlassAvailable() || !Dwm.IsGlassEnabled())
            {
                this.Left = -Height + 1;
                return;
            }

            var s = Resources["ToolbarCloseAnim"] as Storyboard;
            s.BeginTime = TimeSpan.FromMilliseconds(500);
            s.Begin();
            s.BeginTime = TimeSpan.FromMilliseconds(300);
            //InitializeThumbnails();
        }

        private void ToolbarMouseLeave(object sender, MouseEventArgs e)
        {
            CloseToolbar();
        }

        private void WindowMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

            if (!Dwm.IsGlassAvailable() || !Dwm.IsGlassEnabled())
                return;

            if (!isOpened)
            {
                Open();
            }
        }

        public void Open()
        {
            var s = Resources["ToolbarOpenAnim"] as Storyboard;
            s.Begin();
            isOpened = true;

            this.Opacity = 1;

            InitializeThumbnails();
        }

        private void InitializeThumbnails()
        {
            IntPtr handle = ((System.Windows.Interop.HwndSource)System.Windows.Interop.HwndSource.FromVisual(this)).Handle;
            IntPtr current = WinAPI.GetWindow(handle, WinAPI.GetWindowCmd.First);

            do
            {
                int GWL_STYLE = -16;
                uint normalWnd = 0x10000000 | 0x00800000 | 0x00080000;
                uint popupWnd = 0x10000000 | 0x80000000 | 0x00080000;
                var windowLong = WinAPI.GetWindowLong(current, GWL_STYLE);
                var text = WinAPI.GetText(current);
                if (((normalWnd & windowLong) == normalWnd || (popupWnd & windowLong) == popupWnd) && !string.IsNullOrEmpty(text))
                {
                    var t = new TextBlock();
                    t.HorizontalAlignment = HorizontalAlignment.Center;
                    t.TextAlignment = TextAlignment.Center;
                    t.TextWrapping = TextWrapping.Wrap;
                    t.TextTrimming = TextTrimming.CharacterEllipsis;
                    t.MaxHeight = 46;
                    t.FontSize = 16;
                    t.Margin = new Thickness(0, 10, 0, 0);
                    t.Foreground = Brushes.White;
                    t.Text = text;
                    //ThumbsList.Children.Add(t);

                    var thumb = new Thumbnail();
                    thumb.Width = 200;
                    thumb.Height = 140;
                    thumb.Source = current;
                    ThumbsList.Children.Add(thumb);
                }

                current = WinAPI.GetWindow(current, WinAPI.GetWindowCmd.Next);

                if (current == handle)
                    current = WinAPI.GetWindow(current, WinAPI.GetWindowCmd.Next);
            }
            while (current != IntPtr.Zero);
            //Opacity = 1;

            //invalidate layout, without this thumbnails will be invisible
            Height++;
            Height--;
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
            ThumbsList.Children.Clear();
            Opacity = 0.01;
        }

        private void ThisSourceInitialized(object sender, EventArgs e)
        {
            //invalidate layout, without this thumbnails will be invisible
            Height++;
            Height--;
        }

        private void ThumbsListMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var c = e.GetPosition(ThumbsList);
            foreach (Thumbnail thumb in ThumbsList.Children.OfType<Thumbnail>())
            {
                var transform = thumb.TransformToVisual(ThumbsList);
                Point p = transform.Transform(new Point(0, 0));
                if (c.Y > p.Y && c.Y < p.Y + thumb.Height && c.X > p.X && c.X < p.X + thumb.Width)
                {
                    if (WinAPI.IsIconic(thumb.Source))
                        WinAPI.ShowWindow(thumb.Source, WinAPI.WindowShowStyle.Restore);
                    else
                        WinAPI.ShowWindow(thumb.Source, WinAPI.WindowShowStyle.Show);
                    WinAPI.SetForegroundWindow(thumb.Source);
                    break;
                }
            }
        }
    }
}