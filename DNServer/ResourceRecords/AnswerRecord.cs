using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace DNServer
{
    class AnswerRecord : Record
    {

        public uint TTL { get; set; }

        public ushort DataSize { get; set; }

        public IPAddress Address { get; set; }

        public AnswerRecord(Domain domain) : base(domain)
        {
            
        }

        /// <summary>
        /// 
        /// 0.+-
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        public static byte[] Serialize(AnswerRecord record)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                stream.Write(Record.Serialize(record));
                stream.Write(record.Address.GetAddressBytes());
                return stream.ToArray();
            }
        }

        public AnswerRecord Deserialize(byte[] data)
        {
            using (BinaryReader reader = new BinaryReader(new MemoryStream(data)))
            {
                AnswerRecord record = new AnswerRecord(new Domain(""));
                return new AnswerRecord(new Domain(""));
            }
        }


    }
}
