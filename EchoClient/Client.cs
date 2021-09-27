using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ModelLib;

namespace EchoClient
{
    class Client
    {
        public void start()
        {
            TcpClient socket = new TcpClient("localhost", 2121);

            using (StreamReader sr = new StreamReader(socket.GetStream()))
            using (StreamWriter sw = new StreamWriter(socket.GetStream()))
            {
                Console.WriteLine("write a line : ");
                string line = Console.ReadLine();

                sw.WriteLine(line);
                sw.Flush();
            }

        }
       
    }
}
