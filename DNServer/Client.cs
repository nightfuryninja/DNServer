using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Reflection.Metadata;
using System.IO;
using System.Net;

namespace DNServer
{
    class Client
    {

        private Socket socket = new Socket(SocketType.Stream, ProtocolType.Tcp);

        public Message Lookup(Message message)
        {
            byte[] messageData = message.Serialize();
            if (messageData.Length > 512)
            {
                // Use TCP
            }
            else
            {
                // Use UDP
            }
        }


    }
}
