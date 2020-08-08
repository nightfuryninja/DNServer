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

        //public static void WriteBE(this BinaryWriter writer, ushort value)
        //{
        //    buffer[0] = (byte)value;
        //    buffer[1] = (byte)(value >> 8);
        //    Array.Reverse(buffer, 0, 2);
        //    writer.Write(buffer, 0, 2);
        //}

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

        public static void ReadBEUshort(this BinaryReader reader)
        {
            buffer = reader.ReadBytes(4);
        }
    }
}
