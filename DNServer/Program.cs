using DNServer.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DNServer
{
    class Program
    {

        /*
         *  TODO
         *  1) DNSClient and Server Classes.
         *  2) Add Test Cases
         *  1) Recursive and Root Servers.
         *  3) Resource Records.
         *  Response Parsing.
         *  DNS Caching.
         *  Big Endian Streams.
         *  
         *  DONE
         *  Record Class
         *  Join labels with '.' character.
         *  Reqest Flags.
         */

        static async Task Main(string[] args)
        {
            IPAddress address = IPAddress.Parse("192.168.1.128");
            byte[] addressBytes = new byte[4];
            addressBytes = address.GetAddressBytes();
            foreach(byte b in addressBytes)
            {
                Console.WriteLine(b);
            }
            //Server server = new Server();
            //await server.Start();
            //Message request = new Message();
            //request.Opcode = OpCode.StandardQuery;
            //request.RecursionDesired = true;
            //request.QueryRecord.Add(new Record(new Domain("www.google.com")));
            //Socket client = new Socket(SocketType.Dgram, ProtocolType.Udp);
            //IPAddress address = IPAddress.Parse("192.33.4.12");
            //client.Connect(new IPEndPoint(address, 53));
            //client.Send(Message.Serialize(request));
            //byte[] buffer = new byte[1024];
            //client.Receive(buffer);
            //foreach (byte b in buffer)
            //{
            //    Console.WriteLine(b);
            //}
        }
    }
}