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

        public AnswerRecord(Domain domain = null) : base(domain, RecordType.A)
        {

        }

        /// <summary>
        /// Serializes a Answer Record object into a byte array.
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        public override byte[] Serialize() 
        {
            using (MemoryStream stream = new MemoryStream())
            {
                stream.Write(base.Serialize());
                stream.Write(Address.GetAddressBytes());
                return stream.ToArray();
            }
        }

        /// <summary>
        /// Deserializes a byte array to an Answer Record object.
        /// </summary>
        /// <param name="reader"></param>
        public override void Deserialize(BinaryReader reader)
        {
            base.Deserialize(reader);
            TTL = reader.ReadUInt32();
            DataSize = reader.ReadUInt16();
            Address = new IPAddress(reader.ReadBytes(DataSize));
        }

    }
}
