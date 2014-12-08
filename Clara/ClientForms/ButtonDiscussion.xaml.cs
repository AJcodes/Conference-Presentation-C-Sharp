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
    /// Interaction logic for ButtonDiscussion.xaml
    /// </summary>
    public partial class ButtonDiscussion : UserControl
    {
        private Chat room;
        private ClientThread client;

        public ButtonDiscussion(ClientThread client)
        {
            InitializeComponent();
            this.client = client;
        }

        private void UserControl_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            room = new Chat(client);
            room.Show();
        }
    }
}
