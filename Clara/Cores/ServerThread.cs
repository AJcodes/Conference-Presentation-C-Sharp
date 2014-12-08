using System;
using System.IO; 
using System.Net;
using System.Net.Sockets;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Threading;
using System.Windows.Forms;

namespace Clara.Cores
{
    public class ServerThread
    {
        private Clara.Forms.Host host;
        private TcpListener tcp;
        private ArrayList clients;

        public ServerThread(Clara.Forms.Host host, TcpListener tcp)
        {
            this.host = host;
            this.tcp = tcp;
            clients = new ArrayList();
        }

        public void Start()
        {
            while (true)
            {
                TcpClient tcpClient = tcp.AcceptTcpClient();
                NetworkStream clientStream = tcpClient.GetStream();
                StreamWriter writeData = new StreamWriter(clientStream);
                StreamReader readData = new StreamReader(clientStream);
                string i = readData.ReadLine();
                switch (i)
                {
                    case "1":
                        Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
                        clientThread.Start(tcpClient);
                        lock (clients)
                        {
                            clients.Add(tcpClient);
                        }
                        break;
                    case "0":
                        writeData.WriteLine(host.returnPres());
                        writeData.Flush();
                        writeData.WriteLine(host.returnAuth());
                        writeData.Flush();
                        break;
                }
                
            }
        }

        private void sendFile(string path, StreamWriter writeData, NetworkStream clientStream)
        {
            byte[] test2;
            FileInfo fi = new FileInfo(path);
            string n = fi.Name + "." + fi.Length;
            writeData.WriteLine(n);
            writeData.Flush();
            test2 = System.IO.File.ReadAllBytes(path);
            clientStream.Write(test2, 0, test2.Length);
        }

        private void sendToAll(string text)
        {
            foreach (TcpClient c in clients)
            {
                NetworkStream clientStream = c.GetStream();
                StreamWriter writeData = new StreamWriter(clientStream);
                writeData.WriteLine("2");
                writeData.Flush();
                writeData.WriteLine(text);
                writeData.Flush();
            }
        }

        private void findFile(string filename, StreamWriter writeData, NetworkStream clientStream)
        {
            foreach (Cores.File file in host.test2)
            {
                if (file.Path.Contains(filename))
                {
                    writeData.WriteLine("3");
                    sendFile(file.Path, writeData, clientStream);
                }
            }
        }

        private void HandleClientComm(object client)
        {
            TcpClient tcpClient = (TcpClient)client;
            NetworkStream clientStream = tcpClient.GetStream();
            StreamWriter writeData = new StreamWriter(clientStream);
            StreamReader readData = new StreamReader(clientStream);

                    writeData.WriteLine(host.returnPres());
                    writeData.Flush();
                    writeData.WriteLine(host.returnAuth());
                    writeData.Flush();
                    sendFile(host.pdfpath, writeData, clientStream);

                   
            while (true)
            {
                string test = readData.ReadLine();
                switch (test)
                {
                    case "2":
                        string msg = readData.ReadLine();
                        sendToAll(msg);
                        break;
                    case "3":
                        string filename = readData.ReadLine();
                        findFile(filename, writeData, clientStream);
                        break;
                    default:

                        break;

                }
                

            }

            
        }
    }


}
