using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Caching;
using System.Runtime.InteropServices;
using DNServer.ResourceRecords;
using System.Linq;

namespace DNServer
{
    class DNSCache
    {
        private static MemoryCache RecordCache = new MemoryCache("RecordCache");

        /// <summary>
        /// Looks for a record in the cahce.
        /// </summary>
        /// <param name="domain">Domain object to be fetched.</param>
        /// <returns></returns>
        public static Record LookupRecord(Domain domain)
        {
            Record record = (Record) RecordCache.Get(domain.Name);
            if(record == null)
            {
                Message request = new Message();
                request.QueryRecord.Add(new QueryRecord(domain));
                record = Client.Lookup(request).AnswerRecords.First();
            }
            return record;
        }

        /// <summary>
        /// Inserts a record into the cache.
        /// </summary>
        /// <param name="record"></param>
        public static void InsertRecord(AnswerRecord record)
        {
            try
            {
                RecordCache.Set(record.Domain.Name, record, new DateTimeOffset());
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine("Failed to cache record as no domain has been set.");
            }
            
        }
    }
}
