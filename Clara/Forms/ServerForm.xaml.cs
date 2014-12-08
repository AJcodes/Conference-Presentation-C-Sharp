using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Xml;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace Clara.Forms
{
    /// <summary>
    /// Interaction logic for ServerForm.xaml
    /// </summary>
    public partial class ServerForm : UserControl
    {
        private PDFLibNet.PDFWrapper _pdfDoc;
        private Clara.Windows.MainWindow main;
        private string pdf;
        public ArrayList test2;
        public bool isPageSelected = false;
        public int pos = 1;
        private object dummyNode = null;

        public ServerForm(Clara.Windows.MainWindow window)
        {
            InitializeComponent();
            test2 = new ArrayList();
            main = window;
        }

        private void Minimize_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            main.WindowState = WindowState.Minimized;
        }

        private void Close_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Host_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var host = new Host(main, pdf, _pdfDoc, test2, author.Text, name.Text);
            main.Content = host;
        }

        private void Cancel_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            main.Appsbar.Open();
        }

        private void AddKCF_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "KCF file|*.kcf";
            if (ofd.ShowDialog() == true)
            {
                XmlDocument xmldoc = new XmlDocument();
                XmlNodeList xml;
                XmlNodeList xmlnode;
                FileStream fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read);
                xmldoc.Load(fs);
                xml = xmldoc.GetElementsByTagName("PDF");
                pdf = xml[0].Attributes["Path"].Value;
                kcfpath.Text = ofd.FileName;
                _pdfDoc = new PDFLibNet.PDFWrapper();
                _pdfDoc.LoadPDF(pdf);
                xmlnode = xmldoc.GetElementsByTagName("File");
                for (int i = 0; i <= xmlnode.Count - 1; i++)
                {
                    int slide = Int32.Parse(xmlnode[i].Attributes["Slide"].Value);
                    string filepath = xmlnode[i].InnerText;
                    test2.Add(new Cores.File(filepath, slide, _pdfDoc));
                }
                TreeViewItem item = new TreeViewItem();
                item.Header = System.IO.Path.GetFileName(pdf);
                item.Tag = System.IO.Path.GetFileName(pdf);
                item.Foreground = Brushes.White;
                item.FontSize = 20;
                item.Items.Add(dummyNode);
                item.FontWeight = FontWeights.Normal;
                item.Expanded += new RoutedEventHandler(folder_Expanded);
                TreeViewFolder.Items.Add(item);
            }
            
            
        }

        private void folder_Expanded(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = (TreeViewItem)sender;
            if (item.Items.Count == 1 && item.Items[0] == dummyNode)
            {
                item.Items.Clear();
                try
                {
                    for (int i = 1; i <= _pdfDoc.PageCount; i++ )
                    {
                        TreeViewItem subitem = new TreeViewItem();
                        subitem.Header = "Page " + i;
                        subitem.Tag = i;
                        subitem.Foreground = Brushes.White;
                        subitem.FontSize = 18;
                        subitem.Items.Add(dummyNode);
                        subitem.FontWeight = FontWeights.Normal;
                        subitem.Expanded += new RoutedEventHandler(folder_Expanded2);
                        item.Items.Add(subitem);
                    }
                }
                catch (Exception) { }
            }
        }

        private void folder_Expanded2(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = (TreeViewItem)sender;
            if (item.Items.Count == 1 && item.Items[0] == dummyNode)
            {
                item.Items.Clear();
                try
                {
                    foreach (Clara.Cores.File s in test2)
                    {
                        if (s.SlideNo == Int32.Parse(item.Tag.ToString()))
                        {
                            TreeViewItem subitem = new TreeViewItem();
                            subitem.Header = System.IO.Path.GetFileName(s.Path);
                            subitem.Tag = System.IO.Path.GetFileName(s.Path);
                            subitem.Foreground = Brushes.White;
                            subitem.FontSize = 16;
                            subitem.FontWeight = FontWeights.Normal;
                            item.Items.Add(subitem);
                        }
                        
                    }
                }
                catch (Exception) { }
            }
        }

        private void mainmenu_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            main.Appsbar.Open();
        }
    }
}
