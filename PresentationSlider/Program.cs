using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using GodSharp.Sockets;



namespace PresentationSlider
{
    class Program 
    {
        
        static void Main(string[] args)
        {
            Random random = new Random();
            SocketServer server = new SocketServer(port: 7788)
            {
                OnConnected = (sender) =>
                {
                    Console.WriteLine($"Client {sender.RemoteEndPoint.ToString()} connected");
                }
            };

            server.OnData = (sender, data) =>
            {
                //get client data
                string message = server.Encoding.GetString(data, 0, data.Length);
                Console.WriteLine($"server received data from {sender.RemoteEndPoint}: {message}");

                //message = "server repley " + message;
                message = random.Next(100000000, 999999999).ToString();
                sender.Send(message);

                Console.WriteLine($"server send data to {sender.RemoteEndPoint}: {message}");
            };

            server.Listen();
            server.Start();

            Console.ReadKey();


        }

        private static void keypress()
        {
            try
            {
               
                SendKeys.SendWait("X");
                SendKeys.SendWait("Winkey");

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                
            }
            
        }


      


}
}
