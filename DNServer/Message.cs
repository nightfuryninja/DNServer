using DNServer.Extensions;
using DNServer.ResourceRecords;
using System;
using System.Collections.Generic;
using System.IO;

namespace DNServer
{
    class Message
    {
        public static Random random = new Random();

        #region Header

        public byte[] flag = new byte[2];

        private ushort MessageID { get; set; }

        public bool QR
        {
            get { return flag[0].GetBitValueAt(0) != 1; }
            set { flag[0].SetBitValueAt(7, Convert.ToByte(value)); }
        }

        public OpCode Opcode
        {
            get { return (OpCode)flag[0].GetBitValueAt(1, 4); }
            set { flag[0].SetBitValueAt(6, 4, (byte)value); }
        }

        public bool AuthoritativeAnswer
        {
            get { return flag[0].GetBitValueAt(2, 1) != 0; }
            set { flag[0].SetBitValueAt(2, Convert.ToByte(value)); }
        }

        public bool Trunacated
        {
            get { return flag[0].GetBitValueAt(1, 1) != 0; }
            set { flag[0].SetBitValueAt(1, Convert.ToByte(value)); }
        }

        public bool RecursionDesired
        {
            get { return flag[0].GetBitValueAt(0, 1) != 0; }
            set { flag[0].SetBitValueAt(0, Convert.ToByte(value)); }
        }

        public bool RecursionAvaliable
        {
            get { return flag[1].GetBitValueAt(0) != 0; }
            set { flag[1].SetBitValueAt(7, Convert.ToByte(value)); }
        }

        public RCode Rcode
        {
            get { return (RCode)flag[1].GetBitValueAt(4, 4); }
            set { flag[1].SetBitValueAt(6, 4, (byte)value); }
        } 

        public ushort ANCount { get; set; }

        public ushort NSCount { get; set; }

        public ushort ARCount { get; set; }

        #endregion

        public List<Record> QueryRecord = new List<Record>();

        public List<AnswerRecord> AnswerRecords = new List<AnswerRecord>();

        public List<NameServerRecord> NameServerRecords = new List<NameServerRecord>();

        public List<Record> AdditionalRecords = new List<Record>();

        public Message()
        {
            MessageID = (ushort)random.Next(0, 65535);
            RecursionDesired = true;
        }

        /// <summary>
        /// Serializes a message object into a byte array.
        /// </summary>
        /// <returns></returns>
        public byte[] Serialize()
        {
            using (MemoryStream stream = new MemoryStream())
            using (BinaryWriter writer = new BinaryWriter(stream))
            {
                writer.WriteBE(MessageID);
                writer.Write(flag);
                writer.WriteBE((ushort)QueryRecord.Count);
                writer.WriteBE((ushort)AnswerRecords.Count);
                writer.WriteBE((ushort)NameServerRecords.Count);
                writer.WriteBE((ushort)AdditionalRecords.Count);
                foreach (Record record in QueryRecord)
                {
                    writer.Write(record.Serialize());
                }
                foreach(Record record in AnswerRecords)
                {
                    writer.Write(record.Serialize());
                }
                foreach (Record record in NameServerRecords)
                {
                    writer.Write(record.Serialize());
                }
                foreach (Record record in NameServerRecords)
                {
                    writer.Write(record.Serialize());
                }
                return stream.ToArray();
            }
        }

        /// <summary>
        /// Deserializes a byte array into a message object.
        /// </summary>
        /// <param name="stream"></param>
        public void Deserialize(byte[] data)
        {
            using(MemoryStream stream = new MemoryStream(data))
            using (BinaryReader reader = new BinaryReader(stream))
            {
                MessageID = reader.ReadUInt16();
                flag = reader.ReadBytes(2);
                ushort QueryRecordCount = reader.ReadUint16BE();
                ANCount= reader.ReadUint16BE();
                ushort NameServerRecordCount = reader.ReadUint16BE();
                ushort AdditionalRecordCount = reader.ReadUint16BE();
                //for (int i = 0; i < QueryRecordCount; i++)
                //{
                //    QueryRecord record = new QueryRecord();
                //    record.Deserialize(reader);
                //    QueryRecord.Add(record);
                //}
                //DeserializeAnswerRecords(reader);


                //for (int i = 0; i < NameServerRecordCount; i++)
                //{

                //}
                //for (int i = 0; i < AdditionalRecordCount; i++)
                //{

                //}
            }
        }

        //private void DeserializeAnswerRecords(BinaryReader reader, RecordType type)
        //{
        //    for (int i = 0; i < ANCount; i++)
        //    {
        //        Record record = new AnswerRecord();
        //        record.Deserialize(reader);
        //        AnswerRecords.Add(record);
        //    }
        //}

    }
}