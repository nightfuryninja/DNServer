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
        }

        public static byte[] Serialize(Message request)
        {
            using (MemoryStream stream = new MemoryStream())
            using (BinaryWriter writer = new BinaryWriter(stream))
            {
                writer.WriteBE(request.MessageID);
                writer.Write(request.flag);
                writer.WriteBE((ushort)request.QueryRecord.Count);
                writer.WriteBE((ushort)request.AnswerRecords.Count);
                writer.WriteBE((ushort)request.NameServerRecords.Count);
                writer.WriteBE((ushort)request.AdditionalRecords.Count);
                foreach (Record record in request.QueryRecord)
                {
                    writer.Write(Record.Serialize(record));
                }
                foreach(Record record in request.AnswerRecords)
                {
                    writer.Write(Record.Serialize(record));
                }
                foreach (Record record in request.NameServerRecords)
                {
                    writer.Write(Record.Serialize(record));
                }
                foreach (Record record in request.NameServerRecords)
                {
                    writer.Write(Record.Serialize(record));
                }
                return stream.ToArray();
            }
        }

        public void Deserialize(Stream stream)
        {
            using (BinaryReader reader = new BinaryReader(stream))
            {
                Message message = new Message();
                message.MessageID = reader.ReadUInt16();
                message.flag = reader.ReadBytes(2);
                message.QueryRecord.Capacity = reader.ReadUInt16();
                ushort AnswerRecords = reader.ReadUInt16();
                ushort NameServerRecords = reader.ReadUInt16();
                ushort AdditionalRecords = reader.ReadUInt16();
                //for (int i = 0; i < message.QueryRecord.Capacity; i++)
                //{
                //    message.QueryRecord.Add(new Record());
                //}
                //for (int i = 0; i < AnswerRecords; i++)
                //{
                //    message.AnswerRecords.Add(AnswerRecord.Deserialize());
                //}
                //for (int i = 0; i < NameServerRecords; i++)
                //{

                //}
                //for (int i = 0; i < AdditionalRecords; i++)
                //{

                //}
            }
        }

    }
}