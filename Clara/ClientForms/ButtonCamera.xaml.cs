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
    /// Interaction logic for ButtonCamera.xaml
    /// </summary>
    public partial class ButtonCamera : UserControl
    {
        private Snap cam;
        private Binding b;
        private ClientThread client;

        public ButtonCamera(Binding bd, ClientThread client)
        {
            InitializeComponent();
            b = bd;
            this.client = client;
        }

        private void UserControl_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            cam = new Snap(b,client);
            cam.Show();
        }
    }
}
