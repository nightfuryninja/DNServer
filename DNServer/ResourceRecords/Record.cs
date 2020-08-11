using DNServer.Extensions;
using System.IO;

namespace DNServer
{
    public abstract class Record
    {

        public Domain Domain { get; set; }

        public RecordType Type { get; set; }

        public RecordClass Class { get; set; }

        public Record(Domain name = null, RecordType type = RecordType.A, RecordClass recordClass = RecordClass.IN)
        {
            Domain = name;
            Type = type;
            Class = recordClass;
        }

        /// <summary>
        /// Serializes a record object into a byte array.
        /// </summary>
        /// <returns></returns>
        public virtual byte[] Serialize()
        {
            using (MemoryStream stream = new MemoryStream())
            using (BinaryWriter writer = new BinaryWriter(stream))
            {
                writer.Write(Domain.Serialize(Domain));
                writer.WriteBE((ushort)Type);
                writer.WriteBE((ushort)Class);
                return stream.ToArray();
            }
        }

        /// <summary>
        /// Deserializes a byte array into a record object.
        /// </summary>
        /// <returns></returns>
        public virtual void Deserialize(BinaryReader reader)
        {
            Domain = Domain.Deserialize(reader);
            Type = (RecordType)reader.ReadInt16();
            Class = (RecordClass)reader.ReadInt16();
        }

    }
}