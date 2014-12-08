using System;
using System.Net;
using System.Net.Sockets;
using System.IO; 
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Drawing;
using System.Windows.Shapes;
using System.Threading;
using System.Windows.Threading;
using System.Xml;
using Clara.Cores;

namespace Clara.HostForms
{
    /// <summary>
    /// Interaction logic for FullScreen.xaml
    /// </summary>
    public partial class FullScreen : Window
    {
        private PDFLibNet.PDFWrapper _pdfDoc;
        private ArrayList i;
        private int pos = 1;
        private int q = 0;
        System.Windows.Point anchorPoint;
        System.Windows.Point currentPoint;
        bool isInDrag = false;
        double X;

        public FullScreen(PDFLibNet.PDFWrapper doc, int pos)
        {
            _pdfDoc = doc;
            this.pos = pos;
            i = new ArrayList();
            InitializeComponent();
            this.Top = 0;
            this.Left = 0;
            this.Width = SystemParameters.PrimaryScreenWidth;
            this.Height = SystemParameters.PrimaryScreenHeight;
            if (pos == 1)
            {
                var panel1 = new FullViewPanel(this.Width, this.Height, _pdfDoc, pos);
                Thumbnails.Children.Add(panel1);
                i.Add(pos);
                q++;
                var panel2 = new FullViewPanel(this.Width, this.Height, _pdfDoc, pos + 1);
                Thumbnails.Children.Add(panel2);
                i.Add(pos + 1);
                //q++;
                double Y = this.Width * (pos - 1);
                AniScroll.ScrollToHorizontalOffset(Y);
            }
            else
            {
                var panel1 = new FullViewPanel(this.Width, this.Height, _pdfDoc, pos - 1);
                Thumbnails.Children.Add(panel1);
                i.Add(pos - 1);
                q++;
                var panel2 = new FullViewPanel(this.Width, this.Height, _pdfDoc, pos);
                Thumbnails.Children.Add(panel2);
                i.Add(pos);
                q++;
                if (pos < _pdfDoc.PageCount)
                {
                    var panel3 = new FullViewPanel(this.Width, this.Height, _pdfDoc, pos + 1);
                    Thumbnails.Children.Add(panel3);
                    i.Add(pos + 1);
                }
                double Y = this.Width * (q - 1);
                AniScroll.ScrollToHorizontalOffset(Y);
            }
            
        }

        private void Close_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Thumbnails.Children.Clear();
            this.Close();
        }

        private void Container_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var element = sender as FrameworkElement;
            anchorPoint = e.GetPosition(null);
            element.CaptureMouse();
            isInDrag = true;
            e.Handled = true;
        }

        private void Container_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isInDrag = false;
            if (-X > this.Width / 3 && X < 0 && pos < _pdfDoc.PageCount)
            {
                q++;
                pos++;
                if (pos < _pdfDoc.PageCount && !i.Contains(pos + 1))
                {
                    var panel4 = new FullViewPanel(this.Width, this.Height, _pdfDoc, pos + 1);
                    Thumbnails.Children.Add(panel4);
                    i.Add(pos + 1);
                }
                double Y = this.Width * (q - 1);
                AniScroll.ScrollToHorizontalOffset(Y);
                
            }
            if (X > this.Width / 3 && X > 0 && q > 1) 
            {
                q--;
                pos--;
                if (pos > 1 && !i.Contains(pos - 1))
                {
                    var panel4 = new FullViewPanel(this.Width, this.Height, _pdfDoc, pos - 1);
                    Thumbnails.Children.Insert(0, panel4);
                    i.Add(pos - 1);
                    q++;
                }
                double Y = this.Width * (q - 1);
                AniScroll.ScrollToHorizontalOffset(Y);
            }
            else
            {
                double Y = this.Width * (q - 1);
                AniScroll.ScrollToHorizontalOffset(Y);
            }
        }

        private void Container_MouseMove(object sender, MouseEventArgs e)
        {
            if (isInDrag)
            {
                currentPoint = e.GetPosition(null);
                X = (currentPoint.X - anchorPoint.X);
                double Y = this.Width * (q - 1);
                AniScroll.ScrollToHorizontalOffset(Y - X);
                
            }
        }
    }
}
