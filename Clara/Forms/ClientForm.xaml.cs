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
using System.Threading;
using System.Windows.Threading;
using System.IO;
using System.Net;
using System.Net.Sockets;
using Clara.Cores;

namespace Clara.Forms
{
    /// <summary>
    /// Interaction logic for ClientForm.xaml
    /// </summary>
    public partial class ClientForm : UserControl
    {
        private Clara.Windows.MainWindow main;

        public ClientForm(Clara.Windows.MainWindow main)
        {
            InitializeComponent();
            this.main = main;

        }

        private void Minimize_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            main.WindowState = WindowState.Minimized;
        }

        private void Close_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void mainmenu_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            main.Appsbar.Open();
        }

        private void Search_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ThreadStart threadStarter = delegate
            {

                this.Dispatcher.Invoke(DispatcherPriority.Background, (Action)delegate
                {
                    for (int i = 5656; i < 5658; i++)
                    {
                        TcpClient tcpClient = new TcpClient();
                        try
                        {
                            tcpClient.Connect(IP.Text, i);
                            NetworkStream clientStream = tcpClient.GetStream();
                            StreamWriter writeData = new StreamWriter(clientStream);
                            StreamReader readData = new StreamReader(clientStream);
                            writeData.WriteLine("0");
                            writeData.Flush();
                            string j = i.ToString();
                            string pres = readData.ReadLine();
                            string auth = readData.ReadLine();
                            sessions.Items.Add(new { Col1 = pres, Col2 = auth, Col3 = j });
                            writeData.Close();
                            readData.Close();
                            clientStream.Close();
                            tcpClient.Close();
                        }
                        catch
                        {
                            tcpClient.Close();

                        }


                    }
                });

            };
            var thread = new Thread(threadStarter);
            thread.Start();
           
        }

        private void Join_Click(object sender, RoutedEventArgs e)
        {
            sessions.SelectedItem = (e.OriginalSource as FrameworkElement).DataContext;
            string s = sessions.SelectedItem.ToString();
            int start = s.IndexOf("Col3 = ");
            int end = s.IndexOf("}");
            string result = s.Substring(start, end - start - 1);
            string result2 = result.Replace("Col3 = ", "");
            int port = Convert.ToInt32(result2);
            var client = new Client(main, IP.Text, port, user.Text);
            main.Content = client;
        }

    }
}
