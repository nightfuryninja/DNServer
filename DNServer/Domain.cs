using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Text;

namespace DNServer
{
    public class Domain
    {

        public string Name { get; set; }

        public string IPAddress { get; set; }

        public Domain(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Converts a string domain to length-prefixed byte array.
        /// </summary>
        /// <param name="domain"></param>
        /// <returns></returns>
        public static byte[] Serialize(Domain domain)
        {
            using (MemoryStream stream = new MemoryStream())
            using (BinaryWriter writer = new BinaryWriter(stream))
            {
                string[] labels = domain.Name.Split(".");
                foreach(string label in labels)
                {
                    writer.Write(label);
                }
                writer.Write((byte)0);
                return stream.ToArray();
            }
        }

        /// <summary>
        /// Converts a length-prefixed byte array to a string.
        /// </summary>
        /// <returns></returns>

        public static Domain Deserialize(BinaryReader reader)
        {
                StringBuilder builder = new StringBuilder();
                while(reader.ReadByte() != 0)
                {
                    reader.BaseStream.Position -= 1;
                    builder.Append("." + reader.ReadString());
                }
                builder.Remove(0, 1);
                return new Domain(builder.ToString());
            
        }

    }
}
