using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace DNServer.ResourceRecords
{
    class NameServerRecord : Record
    {
        public NameServerRecord(Domain domain) : base(domain, RecordType.NS, RecordClass.IN)
        {

        }

        //public override Record Deserialize(Stream stream)
        //{
        //    return new NameServerRecord(new Domain(""));
        //}
    }
}
