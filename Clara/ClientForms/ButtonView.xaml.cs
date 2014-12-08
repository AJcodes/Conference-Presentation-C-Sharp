using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Clara.HostForms;

namespace Clara.ClientForms
{
    /// <summary>
    /// Interaction logic for ButtonView.xaml
    /// </summary>
    public partial class ButtonView : UserControl
    {
        private FullScreen ScreenWindow;
        private PDFLibNet.PDFWrapper _pdfDoc;


        public ButtonView(PDFLibNet.PDFWrapper doc)
        {
            InitializeComponent();
            _pdfDoc = doc;
        }

        private void UserControl_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ScreenWindow = new FullScreen(_pdfDoc, 1);
            ScreenWindow.Show();
        }
    }
}
