using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GodSharp.Sockets;

namespace client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadKey();

            SocketClient client = new SocketClient("192.168.43.2", 7788);

            client.OnData = (sender, data) =>
            {
                //get server data
                string message = client.Encoding.GetString(data, 0, data.Length);
                Console.WriteLine($"client received data from {sender.RemoteEndPoint.ToString()}: {message}");
            };

            client.Connect();
            client.Start();

            string msg = Console.ReadLine();


            while (msg.ToLower() != "q")
            {
                client.Sender.Send(msg);
                Console.WriteLine($"client send data to {client.RemoteEndPoint.ToString()}: {msg}");
                msg = Console.ReadLine();
            }
        }
    }
}