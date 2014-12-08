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
    /// Interaction logic for ThumbnailFile.xaml
    /// </summary>
    public partial class ThumbnailFile : UserControl
    {
        private File file;

        public ThumbnailFile(string filepath, int slide, PDFLibNet.PDFWrapper pdf)
        {
            InitializeComponent();
            file = new File(filepath, slide, pdf);
            checkfiletype(filepath);
            Title.Text = System.IO.Path.GetFileName(filepath);
        }

        private void checkfiletype(string filepath)
        {
            if (filepath.EndsWith(".avi", StringComparison.Ordinal))
            {
                Uri uri = new Uri(@"/Clara;component/Resources/avi.png", UriKind.Relative);
                ImageSource imgSource = new BitmapImage(uri);
                ThumbnailImage.Source = imgSource;
            }
            else if (filepath.EndsWith(".exe", StringComparison.Ordinal))
            {
                Uri uri = new Uri(@"/Clara;component/Resources/pdf.exe", UriKind.Relative);
                ImageSource imgSource = new BitmapImage(uri);
                ThumbnailImage.Source = imgSource;
            }
            else if (filepath.EndsWith(".flv", StringComparison.Ordinal))
            {
                Uri uri = new Uri(@"/Clara;component/Resources/pdf.flv", UriKind.Relative);
                ImageSource imgSource = new BitmapImage(uri);
                ThumbnailImage.Source = imgSource;
            }
            else if (filepath.EndsWith(".mov", StringComparison.Ordinal))
            {
                Uri uri = new Uri(@"/Clara;component/Resources/mov.png", UriKind.Relative);
                ImageSource imgSource = new BitmapImage(uri);
                ThumbnailImage.Source = imgSource;
            }
            else if (filepath.EndsWith(".wma", StringComparison.Ordinal))
            {
                Uri uri = new Uri(@"/Clara;component/Resources/wma.png", UriKind.Relative);
                ImageSource imgSource = new BitmapImage(uri);
                ThumbnailImage.Source = imgSource;
            }
            else if (filepath.EndsWith(".mpg", StringComparison.Ordinal))
            {
                Uri uri = new Uri(@"/Clara;component/Resources/pdf.mpg", UriKind.Relative);
                ImageSource imgSource = new BitmapImage(uri);
                ThumbnailImage.Source = imgSource;
            }
            else if (filepath.EndsWith(".pdf", StringComparison.Ordinal))
            {
                Uri uri = new Uri(@"/Clara;component/Resources/pdf.png", UriKind.Relative); 
                ImageSource imgSource = new BitmapImage(uri); 
                ThumbnailImage.Source = imgSource;
            }
            else if (filepath.EndsWith(".doc", StringComparison.Ordinal))
            {
                Uri uri = new Uri(@"/Clara;component/Resources/word.png", UriKind.Relative);
                ImageSource imgSource = new BitmapImage(uri);
                ThumbnailImage.Source = imgSource;
            }
            else if (filepath.EndsWith(".docx", StringComparison.Ordinal))
            {
                Uri uri = new Uri(@"/Clara;component/Resources/word.png", UriKind.Relative);
                ImageSource imgSource = new BitmapImage(uri);
                ThumbnailImage.Source = imgSource;
            }
            else if (filepath.EndsWith(".ppt", StringComparison.Ordinal))
            {
                Uri uri = new Uri(@"/Clara;component/Resources/powerpoint.png", UriKind.Relative);
                ImageSource imgSource = new BitmapImage(uri);
                ThumbnailImage.Source = imgSource;
            }
            else if (filepath.EndsWith(".pptx", StringComparison.Ordinal))
            {
                Uri uri = new Uri(@"/Clara;component/Resources/powerpoint.png", UriKind.Relative);
                ImageSource imgSource = new BitmapImage(uri);
                ThumbnailImage.Source = imgSource;
            }
            else if (filepath.EndsWith(".jpg", StringComparison.Ordinal))
            {
                Uri uri = new Uri(@"/Clara;component/Resources/jpg.png", UriKind.Relative);
                ImageSource imgSource = new BitmapImage(uri);
                ThumbnailImage.Source = imgSource;
            }
            else if (filepath.EndsWith(".png", StringComparison.Ordinal))
            {
                Uri uri = new Uri(@"/Clara;component/Resources/png.png", UriKind.Relative);
                ImageSource imgSource = new BitmapImage(uri);
                ThumbnailImage.Source = imgSource;
            }
        }

        private void ThumbnailImage_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void UserControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start(file.Path);
        }


    }
}
