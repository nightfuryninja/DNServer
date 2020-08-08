using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DNServer.Extensions
{
    public static class BinaryWriterExtensions
    {

        private static byte[] buffer = new byte[16];

        public static void WriteBE(this BinaryWriter writer, ushort value)
        {
            buffer[0] = (byte)value;
            buffer[1] = (byte)(value >> 8);
            Array.Reverse(buffer, 0, 2);
            writer.Write(buffer, 0, 2);
        }        
        
        public static void WriteBE(this BinaryWriter writer, short value)
        {
            buffer[0] = (byte)value;
            buffer[1] = (byte)(value >> 8);
            Array.Reverse(buffer);
            writer.Write(buffer, 0, 2);
        }

        public static void WriteBE(this BinaryWriter writer, byte[] value)
        {
            Array.Reverse(value);
            writer.Write(value);
        }

        //public static void WriteBE(this BinaryWriter writer, int value)
        //{
        //    byte[] buffer = new byte[2];
        //    buffer[0] = (byte)value;
        //    buffer[1] = (byte)(value >> 8);
        //    Array.Reverse(buffer);
        //    writer.Write(buffer, 0, 2);
        //}

        //public static void WriteBE(this BinaryWriter writer, uint value)
        //{
        //    byte[] buffer = new byte[2];
        //    buffer[0] = (byte)value;
        //    buffer[1] = (byte)(value >> 8);
        //    Array.Reverse(buffer);
        //    writer.Write(buffer, 0, 2);
        //}

    }
}
