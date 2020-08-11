using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace DNServer.Extensions
{
    public static class BinaryReaderExtensions
    {
        private static byte[] buffer = new byte[16];

        public static ushort ReadUint16BE(this BinaryReader reader)
        {
            for (int i = 0; i < 2; i++)
            {
                buffer[i] = reader.ReadByte();
            }
            Array.Reverse(buffer, 0, 2);
            return (ushort)(buffer[0] | buffer[1] << 8);
        }

        //public static void WriteBE(this BinaryWriter writer, short value)
        //{
        //    buffer[0] = (byte)value;
        //    buffer[1] = (byte)(value >> 8);
        //    Array.Reverse(buffer);
        //    writer.Write(buffer, 0, 2);
        //}

        //public static void WriteBE(this BinaryWriter writer, byte[] value)
        //{
        //    Array.Reverse(value);
        //    writer.Write(value);
        //}

        //public static void ReadBEUshort(this BinaryReader reader)
        //{
        //    buffer = reader.ReadBytes(4);
        //}
    }
}
