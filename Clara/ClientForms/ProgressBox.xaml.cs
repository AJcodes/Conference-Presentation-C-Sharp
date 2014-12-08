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
using Clara.Cores;

namespace Clara.ClientForms
{
    /// <summary>
    /// Interaction logic for ProgressBox.xaml
    /// </summary>
    public partial class ProgressBox : Window
    {
        private ClientThread client;

        public ProgressBox(string input, ClientThread client)
        {
            InitializeComponent();
            int i = 0;
            this.client = client;
            if (input.Contains(' '))
            {
                string[] words = input.Split(' ');
                foreach (string word in words)
                {
                    Status.Text = "Completed: " + 0 + "/" + words.Length;
                    Current.Text = "Current File: " + word;
                    client.requestFile(input);
                    i++;
                }
            }
            else
            {
                Status.Text = "Completed: " + 0 + "/1";
                Current.Text = "Current File: " + input;
                client.requestFile(input);
            }
            
            this.Close();
        }
    }
}
