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
using Microsoft.Expression.Encoder.Devices;
using WebcamControl;
using System.IO;
using System.Drawing.Imaging;
using Clara.Cores;

namespace Clara.ClientForms
{
    /// <summary>
    /// Interaction logic for Snap.xaml
    /// </summary>
    public partial class Snap : Window
    {
        private Webcam webCamCtrl;
        private ProgressBox prog;
        private ClientThread client;

        public Snap(Binding bndg_1, ClientThread client)
        {
            InitializeComponent();
            this.client = client;
            this.Top = 0;
            this.Left = 0;
            this.Width = SystemParameters.PrimaryScreenWidth;
            this.Height = SystemParameters.PrimaryScreenHeight;
            //ContentControl1.Width = this.Width;
            //ContentControl1.Height = this.Height;
            webCamCtrl = new Webcam();
            webCamCtrl.SetBinding(Webcam.VideoDeviceProperty, bndg_1);
            string imgPath = @"C:\WebcamSnapshots";

            if (Directory.Exists(imgPath) == false)
            {
                Directory.CreateDirectory(imgPath);
            }
            webCamCtrl.ImageDirectory = imgPath;
            webCamCtrl.PictureFormat = ImageFormat.Bmp;
            ContentControl1.Content = webCamCtrl;

            try
            {
                // Display webcam video on control.
                webCamCtrl.StartCapture();
            }
            catch (Microsoft.Expression.Encoder.SystemErrorException ex)
            {
                MessageBox.Show("Device is in use by another application");
            }

        }

        

        private void Close_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            webCamCtrl.StopCapture();
            this.Close();
        }

        private void ContentControl1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            string date1;
            string extractedText = "";
            webCamCtrl.TakeSnapshot();
            webCamCtrl.StopCapture();
            DateTime date = DateTime.Now;
            if (date.Day < 10)
            {
                date1 = date.ToString("d-MM-yyyy h.m");
            }
            else
            {
                date1 = date.ToString("dd-MM-yyyy h.m");
            }
            string[] files = Directory.GetFiles(@"C:\WebcamSnapshots", "*" + date1 + "*");
            try
            {
                MODI.Document doc = new MODI.Document();
                doc.Create(files[0]);
                doc.OCR(MODI.MiLANGUAGES.miLANG_ENGLISH, true, true);
                MODI.Image img = (MODI.Image)doc.Images[0];
                MODI.Layout layout = img.Layout;
                for (int i = 0; i < layout.Words.Count; i++)
                {
                    MODI.Word word = (MODI.Word)layout.Words[i];
            
                    if (extractedText.Length > 0)
                    {
                        extractedText += " ";
                    }

                    extractedText += word.Text;
                
                }
                doc.Close();
            }  
            catch (Exception ex)  
            {  
                throw new Exception(ex.Message);  
            }  

            prog = new ProgressBox(extractedText, client);
            prog.Show();
            this.Close();
        }
    }
}
