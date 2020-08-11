using DNServer.ResourceRecords;
using System;
using System.Net;
using System.Net.Sockets;

namespace DNServer
{
    class Program
    {

        /*
         *  TODO
         *  1) Need to support trunacation.
         *  1) DNSClient and Server Classes.
         *  2) Add Test Cases
         *  1) Recursive and Root Servers.
         *  3) Resource Records.
         *  Response Parsing.
         *  DNS Caching.
         *  Big Endian Streams.
         */

        /*
         *  DONE
         *  Record Class
         *  Join labels with '.' character.
         *  Reqest Flags.
         */

        public static void Main(string[] args)
        {
            //Message response = new Message();
            //response.Deserialize(data);
            //foreach(AnswerRecord record in response.AnswerRecords)
            //{
            //    Console.WriteLine(record.Address.ToString());
            //}
            //Console.WriteLine(response.AnswerRecords.First().Address);
        }
    }
}