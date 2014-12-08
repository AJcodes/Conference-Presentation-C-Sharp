using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
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
using Microsoft.Win32;
using System.Xml;
using System.Runtime.InteropServices;
using Clara.Cores;
using PDFLibNet;

namespace Clara.Forms
{
    /// <summary>
    /// Interaction logic for Create.xaml
    /// </summary>
    public partial class Create : UserControl
    {
        private PDFLibNet.PDFWrapper _pdfDoc;
        private string pdfpath;
        public ArrayList test2;
        public bool isPageSelected = false;
        public int pos = 0;
        public FileCanvas canv;
        private Clara.Windows.MainWindow main;

        public Create(Clara.Windows.MainWindow main)
        {
            InitializeComponent();
            this.main = main;
            this.Width = SystemParameters.PrimaryScreenWidth;
            this.Height = SystemParameters.PrimaryScreenHeight;
            test2 = new ArrayList();

        }

        private void Open_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
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
                KCFname.Text = ofd.FileName;
                xml = xmldoc.GetElementsByTagName("PDF");
                string pdf = xml[0].Attributes["Path"].Value;
                //kcfpath.Text = ofd.FileName;
                _pdfDoc = new PDFLibNet.PDFWrapper();
                _pdfDoc.LoadPDF(pdf);
                var thumbnail = new ThumbnailPanel(this);
                thumbnail.Initialize(_pdfDoc);
                Thumbnails.Children.Clear();
                //thumbnail.Initialize(doc, 0);
                Thumbnails.Children.Add(thumbnail);
                test2.Clear();
                xmlnode = xmldoc.GetElementsByTagName("File");
                for (int i = 0; i <= xmlnode.Count - 1; i++)
                {
                    int slide = Int32.Parse(xmlnode[i].Attributes["Slide"].Value);
                    string filepath = xmlnode[i].InnerText;
                    //canv.add(filepath);
                    test2.Add(new Cores.File(filepath, slide, _pdfDoc));
                }
                
            }
        }

        private void SaveAS_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "KCF file|*.kcf";
            saveFileDialog1.Title = "Save Presentation File";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                XmlDocument newDoc = new XmlDocument();
                newDoc.LoadXml("<KCF></KCF>");
                newDoc.PrependChild(newDoc.CreateXmlDeclaration("1.0", "utf-8", ""));

                XmlNode KCF = newDoc.GetElementsByTagName("KCF")[0];

                XmlElement PDF = newDoc.CreateElement("PDF");
                PDF.SetAttribute("Path", pdfpath);
                KCF.AppendChild(PDF);

                foreach (Cores.File f in test2)
                {
                    XmlElement file = newDoc.CreateElement("File");
                    file.SetAttribute("Slide", f.SlideNo.ToString());
                    file.InnerText = f.Path;
                    PDF.AppendChild(file);
                }

                newDoc.Save(saveFileDialog1.FileName);
                KCFname.Text = saveFileDialog1.FileName;

            }
        }



        private void AddPDF_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == true)
            {
                
                _pdfDoc = new PDFLibNet.PDFWrapper();
                pdfpath = ofd.FileName;
                _pdfDoc.LoadPDF(ofd.FileName);

                var thumbnail = new ThumbnailPanel(this);
                thumbnail.Initialize(_pdfDoc);
                Thumbnails.Children.Clear();
                //thumbnail.Initialize(doc, 0);
                Thumbnails.Children.Add(thumbnail);
                test2.Clear();

            }
        }

        private void AddList_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (isPageSelected == true && pos != 0)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                if (ofd.ShowDialog() == true)
                {
                    string filePath = ofd.FileName;
                    canv.add(filePath);
                    test2.Add(new Cores.File(filePath, pos, _pdfDoc));
                }
            }
        }

        private void Close_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void mainmenu_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            main.Appsbar.Open();
        }

        private void Minimize_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            main.WindowState = WindowState.Minimized;
        }
    }
}
