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
using Microsoft.Win32;
using System.Text;
using System.Windows.Input;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Windows.Navigation;

namespace Clara.ClientForms
{
    /// <summary>
    /// Interaction logic for Memo.xaml
    /// </summary>
    public partial class Memo : Window
    {

        private bool dataChanged = false;
        private string filePath = null;

        public Memo()
        {
            InitializeComponent();
            this.Top = 0;
            this.Left = 0;
            this.Width = SystemParameters.PrimaryScreenWidth;
            this.Height = SystemParameters.PrimaryScreenHeight;
        }

        private void New_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ProcessNewCommand();
        }

        private void Open_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ProcessOpenCommand();
        }

        private void Save_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ProcessSaveCommand();
        }

        private void mainmenu_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
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

        private void txtBoxContent_GotFocus(object sender, RoutedEventArgs e)
        {
            dataChanged = true;
        }

        private void txtBoxContent_KeyDown(object sender, KeyEventArgs e)
        {
            dataChanged = true;
        }

        private void NewItem(object sender, RoutedEventArgs e)
        {
            ProcessNewCommand();
        }

        //
        // When New is selected from the Menu
        //
        private void OpenItem(object sender, RoutedEventArgs e)
        {
            ProcessOpenCommand();
        }

        //
        // When Save is selected from the Menu
        //
        private void SaveItem(object sender, RoutedEventArgs e)
        {
            ProcessSaveCommand();
        }

        //
        // When Save As is selected from the Menu
        //
        private void SaveAsItem(object sender, RoutedEventArgs e)
        {
            ShowSaveDialog();
        }

        //
        // When Exit is selected from the Menu
        //
        private void ExitItem(object sender, RoutedEventArgs e)
        {
            if (dataChanged)
            {
                SaveFirst();
                this.Close();
            }
            else
            {
                this.Close();
            }
        }

        //
        // Display Open File dialog window
        //
        private void ShowOpenDialog()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text Files|*.txt|All|*.*";

            //
            // If user selected a file and pressed OK, process it.
            //
            if (ofd.ShowDialog() == true)
            {
                filePath = ofd.FileName;
                ReadFile(filePath);
                //SetTitle(ofd.SafeFileName);
                dataChanged = false;
            }
        }

        //
        // When given a file path, read that information and load it into the textfield
        //
        private void ReadFile(string path)
        {
            StreamReader reader = new StreamReader(path);
            StringBuilder sb = new StringBuilder();

            string r = reader.ReadLine();
            while (r != null)
            {
                sb.Append(r);
                sb.Append(Environment.NewLine);
                r = reader.ReadLine();
            }
            reader.Close();
            //
            // Sending text data to the text box
            //
            txtBoxContent.Text = sb.ToString();
        }

        //
        // Given a path to a file, write the contents of the textbox into it
        //
        private void SaveFile(string path)
        {
            StreamWriter writer = new StreamWriter(path);
            writer.Write(txtBoxContent.Text);
            writer.Close();
            dataChanged = false;
        }

        //
        // Display the Save Dialog window to specify the location to save your file
        //
        private void ShowSaveDialog()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text Document (.txt)|*.txt";

            bool? saveResult = sfd.ShowDialog();

            if (saveResult == true)
            {
                string s = sfd.FileName;
                filePath = s;
                SaveFile(s);
                //SetTitle(sfd.SafeFileName);
            }
        }

        //
        // Ensure that your save your changes before doing anything that might alter your textbox contents or close the program
        //
        private string SaveFirst()
        {
            MessageBoxResult mbr = MessageBox.Show("Do you want to save your changes first?", "Save File?", MessageBoxButton.YesNoCancel);

            if (mbr == MessageBoxResult.Yes)
            {
                if (filePath != null)
                {
                    SaveFile(filePath);
                }
                else
                {
                    ProcessSaveCommand();
                }
            }
            else if (mbr == MessageBoxResult.Cancel)
            {
                return "Cancel";
            }
            return "Nothing";
        }

        //
        // Clears all of the information from the screen
        //
        private void ClearState()
        {
            filePath = null;
            dataChanged = false;

            txtBoxContent.Text = "";

            //ResetTitle();
        }

        private void ProcessSaveCommand()
        {
            if (filePath == null)
            {
                ShowSaveDialog();
            }
            else
            {
                SaveFile(filePath);
            }
        }

        //
        // Determine best way to setup New document
        //
        private void ProcessNewCommand()
        {
            if (dataChanged)
            {
                string sf = SaveFirst();
                if (sf != "Cancel")
                {
                    ClearState();
                }
            }
            else
            {
                ClearState();
            }
        }

        //
        // Determine best way to Open document
        //
        private void ProcessOpenCommand()
        {
            if (dataChanged)
            {
                SaveFirst();
                ShowOpenDialog();
            }
            else
            {
                ShowOpenDialog();
            }
        }
    }
}
