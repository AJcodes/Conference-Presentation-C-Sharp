using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Threading;
using System.Runtime.InteropServices;
using Clara.Forms;

namespace Clara.Cores
{
    /// <summary>
    /// Interaction logic for ThumbnailPanel.xaml
    /// </summary>
    public partial class ThumbnailPanel : UserControl
    {

        private Create input;
        private int k = 0;
        public ThumbnailPanel(Create here)
        {
            InitializeComponent();
            this.input = here;
        }

        public void Initialize(PDFLibNet.PDFWrapper _pdfDoc)
        {
            for (int i = 1; i <= _pdfDoc.PageCount; i++)
            {
                var thumb = new ThumbnailPDF();
                thumb.Initialize(_pdfDoc, i, input);
                ThumbnailsHost.Children.Add(thumb);
            }

            
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            
            //LoadThumbnailsHandler lthmb = new LoadThumbnailsHandler(LoadThumbnails);
            //lthmb.BeginInvoke(null, null);

        }

    }
}
