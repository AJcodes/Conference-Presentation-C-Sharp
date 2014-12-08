using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Drawing;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Interop;
using System.Threading;
using System.Windows.Threading;
using Clara.Forms;

namespace Clara.Cores
{
    /// <summary>
    /// Interaction logic for ThumbnailPDF.xaml
    /// </summary>
    public partial class ThumbnailPDF : UserControl
    {
        private Create input;
        private PDFLibNet.PDFWrapper doc;
        private bool isPressed;
        private int pos;
        public bool isLoaded = false;
        System.Windows.Forms.Control dummy = new System.Windows.Forms.Control();

        public ThumbnailPDF()
        {
            InitializeComponent();
        }

        public void Initialize(PDFLibNet.PDFWrapper _pdfDoc, int pos, Create here)
        {
            this.doc = _pdfDoc;
            this.pos = pos;
            this.input = here;
            nowLoad();
            //Thread.Sleep(2000);
            //UserControl_Loaded();
            
       }

        private void ThumbnailImage_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            input.GamesContainer2.Children.Clear();
            input.text1.Text = "Slide No: " + pos;
            input.pos = pos;
            input.isPageSelected = true;
            input.canv = new FileCanvas(doc, pos, input.test2, input.GamesContainer2.ActualWidth);
            input.GamesContainer2.Children.Add(input.canv);
        }

        public void nowLoad()
        {
            
            ThreadStart threadStarter = delegate
            {
                
                this.Dispatcher.Invoke(DispatcherPriority.Background, (Action)delegate
                {
                    doc.CurrentPage = pos;
                    double magicnumber = 1;
                    dummy.Width = Convert.ToInt32(ActualWidth / magicnumber);
                    dummy.Height = Convert.ToInt32(ActualHeight / magicnumber);

                    doc.FitToWidth(dummy.Handle);
                    doc.RenderPage(dummy.Handle);
                    dummy.Width = Convert.ToInt32(ActualWidth);
                    dummy.Height = Convert.ToInt32(ActualHeight);
                    Bitmap b = new Bitmap(dummy.Width, dummy.Height);
                    Graphics gr = Graphics.FromImage(b);
                    doc.ClientBounds = new System.Drawing.Rectangle(0, 0, b.Width, b.Height);
                    doc.DrawPageHDC(gr.GetHdc());
                    gr.ReleaseHdc();
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
                        ThumbnailImage.Source = result;
                        
                    }
                });
                
            };
            var thread = new Thread(threadStarter);
            thread.Start();
            
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.isLoaded = true;
            //nowLoad();
        }

        private void Storyboard_Completed(object sender, EventArgs e)
        {

        }
    }
}
