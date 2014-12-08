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
using Clara.HostForms;

namespace Clara.Forms
{
    /// <summary>
    /// Interaction logic for Host.xaml
    /// </summary>
    public partial class Host : UserControl
    {
        private FullScreen ScreenWindow;
        private DrawScreen DrawWindow;
        private PDFLibNet.PDFWrapper _pdfDoc;
        public string pdfpath;
        private ServerThread server;
        private Thread serverThread = null;
        public ArrayList test2;
        private string author;
        private string presentation;
        public int pos = 1;
        public FileCanvas canv;
        public Clara.Windows.MainWindow main;
        System.Windows.Forms.Control dummy = new System.Windows.Forms.Control();

        public Host(Clara.Windows.MainWindow main, string pdf, PDFLibNet.PDFWrapper doc, ArrayList test, string auth, string pres)
        {
            InitializeComponent();
            test2 = test;
            pdfpath = pdf;
            this.main = main;
            _pdfDoc = doc;
            author = auth;
            presentation = pres;
            getCurrentPage(_pdfDoc);
            IPAddress ipAddress = IPAddress.Any;
            TcpListener tcpListener = new TcpListener(ipAddress, 5657);
            tcpListener.Start();
            server = new ServerThread(this, tcpListener);
            serverThread = new Thread(new ThreadStart(server.Start));
            serverThread.Start();
        }

        public string returnAuth()
        {
            return author;
        }

        public string returnPres()
        {
            return presentation;
        }

        public void getCurrentPage(PDFLibNet.PDFWrapper doc)
        {
            FileContainer.Children.Clear();
            doc.CurrentPage = pos;
            double magicnumber = 1;
            dummy.Width = Convert.ToInt32(550 / magicnumber);
            dummy.Height = Convert.ToInt32(900 / magicnumber);

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
            BackgroundT.Source = ThumbnailImage.Source;
            ThumbnailImage.Source = result2;
            var s = (Storyboard)Resources["SwitchPictureAnim"];
            s.Begin();
            slidetext.Text = "Slide " + pos + " of " + _pdfDoc.PageCount;
            canv = new FileCanvas(_pdfDoc, pos, test2, FileContainer.ActualWidth);
            FileContainer.Children.Add(canv);
        }

        private void Minimize_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            main.WindowState = WindowState.Minimized;
        }

        private void Close_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Next_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (pos < _pdfDoc.PageCount)
            {
                pos++;
                getCurrentPage(_pdfDoc);
            }
            else
            {
                pos = 1;
                getCurrentPage(_pdfDoc);
            }
            
        }

        private void Back_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (pos > 1)
            {
                pos--;
                getCurrentPage(_pdfDoc);
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void mainmenu_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            main.Appsbar.Open();
        }

        private void Fullscreen_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ScreenWindow = new FullScreen(_pdfDoc, pos);
            ScreenWindow.Show();
        }

        private void Edit_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            DrawWindow = new DrawScreen();
            DrawWindow.Show();
        }
    }
}
