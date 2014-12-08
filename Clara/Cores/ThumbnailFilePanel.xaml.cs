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

namespace Clara.Cores
{
    /// <summary>
    /// Interaction logic for ThumbnailFilePanel.xaml
    /// </summary>
    public partial class ThumbnailFilePanel : UserControl
    {
        public ThumbnailFilePanel()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            
        }

        public void add(string filepath, PDFLibNet.PDFWrapper pdf, int slide)
        {
            var test = new ThumbnailFile(filepath, slide, pdf);
            ThumbnailsHost.Children.Add(test);
        }

        
    }
}
