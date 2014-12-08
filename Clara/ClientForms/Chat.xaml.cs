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
using System.Windows.Shapes;
using System.Windows.Interop;
using System.Threading;
using System.Windows.Threading;
using Clara.Cores;

namespace Clara.ClientForms
{
    /// <summary>
    /// Interaction logic for Chat.xaml
    /// </summary>
    public partial class Chat : Window
    {
        private ClientThread client;

        public Chat(ClientThread client)
        {
            InitializeComponent();
            this.Top = 0;
            this.Left = 0;
            this.Width = SystemParameters.PrimaryScreenWidth;
            this.Height = SystemParameters.PrimaryScreenHeight;
            client.assignChat(this);
            this.client = client;
            KCFname.Text = "Username: " + client.user;
        }

        private void entry_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void pane_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void return_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void Close_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Minimize_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void enter_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            
            client.SendMsg(entry.Text);
            entry.Text = "";
        }

        public void AppendText(string text)
        {
            //fulltext += text + Environment.NewLine;
            ThreadStart threadStarter = delegate
            {

                this.Dispatcher.Invoke(DispatcherPriority.Background, (Action)delegate
                {
                    view.AppendText(text + Environment.NewLine);
                });

            };
            var thread = new Thread(threadStarter);
            thread.Start();
        }

        private void entry_GotFocus(object sender, RoutedEventArgs e)
        {

        }
    }
}
