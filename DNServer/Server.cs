using System;
using System.IO;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DNServer
{
    class Server
    {

        public Socket TCPSocket = new Socket(SocketType.Stream, ProtocolType.Tcp);

        public Socket UDPSocket = new Socket(SocketType.Dgram, ProtocolType.Udp);

        public Server()
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 53);
            TCPSocket.Bind(endPoint);
            UDPSocket.Bind(endPoint);
            Console.WriteLine("Opened both server sockets");
        }

        public async Task Start()
        {

            Task udp = StartUDP();
            Task tcp = StartTCP();
            await udp;
            await tcp;
        }

        private async Task StartUDP()
        {
            ArraySegment<byte> buffer = new byte[512];
            while (true)
            {
                Console.WriteLine("Awaiting UDP Connection...");
                await UDPSocket.ReceiveAsync(buffer, SocketFlags.None);
                
                Message request = new Message();
                request.Deserialize(new MemoryStream(buffer.Array));


            }
        }

        private async Task StartTCP()
        {
            while (true)
            {
                TCPSocket.Listen(10);
                Console.WriteLine("Awaiting TCP Connection...");
                
                await TCPSocket.AcceptAsync();
            }
        }

    }
}
