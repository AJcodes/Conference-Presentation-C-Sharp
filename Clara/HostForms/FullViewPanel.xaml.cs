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
    /// Interaction logic for FullViewPanel.xaml
    /// </summary>
    public partial class FullViewPanel : UserControl
    {

        private PDFLibNet.PDFWrapper _pdfDoc;
        public string pdfpath;
        private bool Exists = false;
        public int pos = 1;
        System.Windows.Forms.Control dummy = new System.Windows.Forms.Control();

        public FullViewPanel(double width, double height, PDFLibNet.PDFWrapper doc, int pos)
        {
            _pdfDoc = doc;
            this.pos = pos;
            this.Width = width;
            this.Height = height;
            InitializeComponent();
            getCurrentPage(_pdfDoc);
            Exists = true;
        }

        public bool Check()
        {
            return Exists;
        }

        public void getCurrentPage(PDFLibNet.PDFWrapper doc)
        {
            //FileContainer.Children.Clear();
            doc.CurrentPage = pos;
            double magicnumber = 1;
            dummy.Width = Convert.ToInt32(this.Width / magicnumber);
            dummy.Height = Convert.ToInt32(this.Height / magicnumber);

            doc.FitToWidth(dummy.Handle);
            dummy.Height = doc.PageHeight;
            doc.RenderPage(dummy.Handle);
            dummy.Width = doc.PageWidth;
            dummy.Height = doc.PageHeight;

            Bitmap b = new Bitmap(dummy.Width, dummy.Height);
            Graphics gr = Graphics.FromImage(b);
            doc.ClientBounds = new System.Drawing.Rectangle(0, 0, b.Width, b.Height);
            doc.DrawPageHDC(gr.GetHdc());
            gr.ReleaseHdc();
            BitmapImage result2 = new BitmapImage();
            using (MemoryStream stream = new MemoryStream())
            {
                b.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);

                stream.Position = 0;
                BitmapImage result = new BitmapImage();
                result.BeginInit();
                result.CacheOption = BitmapCacheOption.OnLoad;
                result.StreamSource = stream;
                result.EndInit();
                result.Freeze();
                result2 = result;

            }
            ThumbnailImage.Source = result2;
            /*BackgroundT.Source = ThumbnailImage.Source;
            ThumbnailImage.Source = result2;
            var s = (Storyboard)Resources["SwitchPictureAnim"];
            s.Begin();
            slidetext.Text = "Slide " + pos + " of " + _pdfDoc.PageCount;
            canv = new FileCanvas(_pdfDoc, pos, test2, FileContainer.ActualWidth);
            FileContainer.Children.Add(canv);*/
        }
    }
}
