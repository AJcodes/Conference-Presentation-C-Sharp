using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Clara.Cores;

namespace Clara.Forms
{
    /// <summary>
    /// Interaction logic for FileCanvas.xaml
    /// </summary>
    public partial class FileCanvas : UserControl
    {
        private int i = 0;
        private int slideno;
        private int grid;
        private PDFLibNet.PDFWrapper pdf;
        private ThumbnailFilePanel t;
        private ArrayList test;

        public FileCanvas(PDFLibNet.PDFWrapper doc, int slide, ArrayList files, double width)
        {
            InitializeComponent();
            grid = (int)width/100;
            slideno = slide;
            pdf = doc;
            t = new ThumbnailFilePanel();
            FilePanels.Children.Add(t);
            test = new ArrayList();
            test = files;
            foreach (Clara.Cores.File g in test)
            {
                if ((g.SlideNo == slideno) && (g.PDF == pdf))
                {
                    if (i < grid)
                    {
                        t.add(g.Path, pdf, slideno);
                        i++;
                    }
                    else
                    {
                        i = 0;
                        t = new ThumbnailFilePanel();
                        FilePanels.Children.Add(t);
                        t.add(g.Path, pdf, slideno);
                    }

                }
            }
        }

        public void add(string filepath)
        {
            
            if (i < grid)
            {
                t.add(filepath, pdf, slideno);
                i++;
            }
            else
            {
                i = 0;
                t = new ThumbnailFilePanel();
                FilePanels.Children.Add(t);
                t.add(filepath, pdf, slideno);
            }
        }
    }
}
