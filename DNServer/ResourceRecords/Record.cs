using DNServer.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace DNServer
{
    public abstract class Record
    {
        //https://tools.ietf.org/html/rfc1035

        public Domain Name { get; set; }

        public RecordType Type { get; set; }

        public RecordClass Class { get; set; }

        public Record(Domain name, RecordType type = RecordType.A, RecordClass recordClass = RecordClass.IN)
        {
            Name = name;
            Type = type;
            Class = recordClass;
        }

        /// <summary>
        /// Serializes a record object into a byte array.
        /// </summary>
        /// <returns></returns>
        public static byte[] Serialize(Record record)
        {
            using (MemoryStream stream = new MemoryStream())
            using (BinaryWriter writer = new BinaryWriter(stream))
            {
                writer.Write(Domain.Serialize(record.Name));
                writer.WriteBE((ushort)record.Type);
                writer.WriteBE((ushort)record.Class);
                return stream.ToArray();
            }
        }

        /// <summary>
        /// Deserializes a byte array into a record object.
        /// </summary>
        /// <returns></returns>
        //public static Record Deserialize(Stream stream)
        //{
        //    using (BinaryReader reader = new BinaryReader(stream))
        //    {
        //        Domain domain = Domain.Deserialize(stream);
        //        RecordType type = (RecordType)reader.ReadInt16();
        //        RecordClass recordClass = (RecordClass)reader.ReadInt16();
        //        Record record = new Record(domain, type, recordClass);
        //        return record;
        //    }
        //}

    }
}
