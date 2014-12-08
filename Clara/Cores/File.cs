using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clara.Cores
{
    class File
    {
        public PDFLibNet.PDFWrapper PDF;
        public string Path;
        public int SlideNo;

        public File(string filepath, int Slide, PDFLibNet.PDFWrapper pdf)
        {
            this.Path = filepath;
            this.PDF = pdf;
            this.SlideNo = Slide;
        }

    }
}
