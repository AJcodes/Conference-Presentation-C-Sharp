using System;
using System.IO; 
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Clara.Cores
{
    public class ClientThread
    {
        private Clara.Forms.Client client;
        public string user;
        private Clara.ClientForms.Chat chat;
        private TcpClient tcpClient;
        private string path = @"C:\KCSdownload\\";

        public ClientThread(Clara.Forms.Client client, string ip, int port, string name)
        {
            this.client = client;
            user = name;
            tcpClient = new TcpClient(ip, port);
            NetworkStream clientStream = tcpClient.GetStream();
            StreamWriter writeData = new StreamWriter(clientStream);
            StreamReader readData = new StreamReader(clientStream);
            writeData.WriteLine("1");
            writeData.Flush();

            string pres = readData.ReadLine();
            string auth = readData.ReadLine();

            string pdffile = receiveFile(clientStream, readData);
            string filename = System.IO.Path.GetFileName(pdffile);
            PDFLibNet.PDFWrapper test = new PDFLibNet.PDFWrapper();
            test.LoadPDF(pdffile);

            client.name.Text = "Presentation: " + pres;
            client.author.Text = "Author: " + auth;
            client.pdf.Text = "Filename: " + filename;
            client.pagecount.Text = "No. of Pages: " + test.PageCount.ToString();
            client._pdfdoc = test;

            
        }

        public void assignChat(Clara.ClientForms.Chat c)
        {
            chat = c;
        }

        public void SendMsg(string text)
        {
            NetworkStream clientStream = tcpClient.GetStream();
            StreamWriter writeData = new StreamWriter(clientStream);
            StreamReader readData = new StreamReader(clientStream);
            writeData.WriteLine("2");
            writeData.Flush();
            writeData.WriteLine(user + ": " + text);
            writeData.Flush();
        }

        public void requestFile(string text)
        {
            NetworkStream clientStream = tcpClient.GetStream();
            StreamWriter writeData = new StreamWriter(clientStream);
            StreamReader readData = new StreamReader(clientStream);
            writeData.WriteLine("3");
            writeData.Flush();
            writeData.WriteLine(text);
            writeData.Flush();
        }


        public void Start()
        {
            NetworkStream clientStream = tcpClient.GetStream();
            StreamWriter writeData = new StreamWriter(clientStream);
            StreamReader readData = new StreamReader(clientStream);

            while (true)
            {
                string t = readData.ReadLine();
                switch (t)
                {
                    case "2":
                        string text = readData.ReadLine();
                        chat.AppendText(text);
                        break;
                    case "3":
                        string pdffile = receiveFile(clientStream, readData);
                        break;
                    default:

                        break;

                }


            }
        }

        private string receiveFile(NetworkStream clientStream, StreamReader readData)
        {
            byte[] b1;
            string rd = readData.ReadLine();
            string v = rd.Substring(rd.LastIndexOf(".") + 1);
            int m = int.Parse(v);
            b1 = new byte[m];
            clientStream.Read(b1, 0, b1.Length);
            System.IO.File.WriteAllBytes(path + rd.Substring(0, rd.LastIndexOf('.')), b1);
            return path + rd.Substring(0, rd.LastIndexOf('.'));
        }

    }
}
