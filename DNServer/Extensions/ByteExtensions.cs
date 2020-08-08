﻿using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace DNServer.Extensions
{
    public static class ByteExtensions
    {
        public static byte GetBitValueAt(this byte b, byte offset, byte length)
        {
            return (byte)((b >> offset) & ~(0xff << length));
        }

        public static byte GetBitValueAt(this byte b, byte offset)
        {
            return b.GetBitValueAt(offset, 1);
        }

        public static void SetBitValueAt(ref this byte b, byte offset, byte length, byte value)
        {
            int mask = ~(0xff << length);
            value = (byte)(value & mask);
            b = (byte)((value << offset) | (b & ~(mask << offset)));
        }

        public static void SetBitValueAt(ref this byte b, byte offset, byte value)
        {
            b.SetBitValueAt(offset, 1, value);
        }

    }
}
