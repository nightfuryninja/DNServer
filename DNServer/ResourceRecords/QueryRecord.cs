using System;
using System.Collections.Generic;
using System.Text;

namespace DNServer.ResourceRecords
{
    class QueryRecord : Record
    {

        public QueryRecord(Domain domain = null) : base(domain, RecordType.A)
        {

        }

    }
}
