using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using ModelLib.Model;


namespace TCPServer
{
    internal class Server
    {
        private ManagaeFbPlayers manage = new ManagaeFbPlayers();

        public void Start()
        {
            TcpListener tcpListener = new(2121);
            tcpListener.Start();
            while (true)
            {
                TcpClient socket = tcpListener.AcceptTcpClient();
                Task.Run(() => DoClient(socket));
            }

        }

        public void DoClient(TcpClient socket)
        {
            using (StreamReader sr = new StreamReader(socket.GetStream()))
            using (StreamWriter sw = new StreamWriter(socket.GetStream()))
            {
                bool Run = true;
                while (Run)
                {
                    string str = sr.ReadLine();
                    string[] ReadString = str.Split(' ');
                    switch (ReadString[0])
                    {
                        case "HentAlle":
                            foreach (FootBallPlayers footballplayer in manage.Get())
                            {
                                Console.WriteLine(footballplayer);
                                sw.WriteLine(footballplayer);
                            }

                            break;

                        case "Hent":
                            Console.WriteLine(manage.Get(Convert.ToInt16(ReadString[1])));
                            sw.WriteLine(manage.Get(Convert.ToInt16(ReadString[1])));
                            break;

                        case "Gem":
                            try
                            {
                                if (manage.Create(new FootBallPlayers(Convert.ToInt16(ReadString[1]), ReadString[2],
                                    Convert.ToInt16(ReadString[3]), Convert.ToInt16(ReadString[4]))))
                                {
                                    Console.WriteLine("Spiller oprettet");
                                    sw.WriteLine("Spiller oprettet");
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                                sw.WriteLine(e.Message);
                            }

                            break;

                        default:
                            sw.WriteLine("Hav en dejlig dag");
                            Console.WriteLine("Hav en dejlig dag");
                            Run = false;
                            break;
                    }
                }

                socket?.Close();
            }
        }

    }
}
