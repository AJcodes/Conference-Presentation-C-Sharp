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
using Clara.Cores;

namespace Clara.ClientForms
{
    /// <summary>
    /// Interaction logic for ButtonPanel.xaml
    /// </summary>
    public partial class ButtonPanel : UserControl
    {
        public ButtonPanel(PDFLibNet.PDFWrapper doc, Binding bd, ClientThread client)
        {
            InitializeComponent();
            var view = new ButtonView(doc);
            ThumbnailsHost.Children.Add(view);
            var cam = new ButtonCamera(bd, client);
            ThumbnailsHost.Children.Add(cam);
        }

        public ButtonPanel(int i, ClientThread client)
        {
            InitializeComponent();
            if (i == 0)
            {
                var disc = new ButtonDiscussion(client);
                ThumbnailsHost.Children.Add(disc);
                var memo = new ButtonMemo();
                ThumbnailsHost.Children.Add(memo);
            }
            else if (i == 1)
            {
                var logout = new ButtonLogout();
                ThumbnailsHost.Children.Add(logout);
            }
        }


    }
}
