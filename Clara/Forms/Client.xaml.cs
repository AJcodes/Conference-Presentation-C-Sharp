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
using System.Threading;
using System.Windows.Threading;
using System.Net;
using System.Net.Sockets;
using Clara.ClientForms;
using Clara.Cores;
using Microsoft.Expression.Encoder.Devices;
using WebcamControl;

namespace Clara.Forms
{
    /// <summary>
    /// Interaction logic for Client.xaml
    /// </summary>
    public partial class Client : UserControl
    {
        private ClientThread client;
        private Thread clientThread = null;
        public PDFLibNet.PDFWrapper _pdfdoc;
        private Clara.Windows.MainWindow main;
        private Binding bndg_1;

        public Client(Clara.Windows.MainWindow main, string ip, int port, string name)
        {
            InitializeComponent();
            user.Text = name;
            this.main = main;
            FindDevices();
            bndg_1 = new Binding("SelectedValue");
            bndg_1.Source = VidDvcsComboBox;
            VidDvcsComboBox.SelectedIndex = 0;
            this.Width = SystemParameters.PrimaryScreenWidth;
            this.Height = SystemParameters.PrimaryScreenHeight;
            client = new ClientThread(this, ip, port, name);
            clientThread = new Thread(new ThreadStart(client.Start));
            clientThread.Start();
            var panel1 = new ButtonPanel(_pdfdoc, bndg_1, client);
            Thumbnails.Children.Add(panel1);
            var panel2 = new ButtonPanel(0, client);
            Thumbnails.Children.Add(panel2);
            var panel3 = new ButtonPanel(1, client);
            Thumbnails.Children.Add(panel3);
            

        }

        private void FindDevices()
        {
            var vidDevices = EncoderDevices.FindDevices(EncoderDeviceType.Video);

            foreach (EncoderDevice dvc in vidDevices)
            {
                VidDvcsComboBox.Items.Add(dvc.Name);
            }

        }

        private void Close_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Minimize_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            main.WindowState = WindowState.Minimized;
        }

        private void TextBlock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void mainmenu_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            main.Appsbar.Open();
        }
    }
}
