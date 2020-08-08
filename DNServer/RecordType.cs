using System;
using System.Collections.Generic;
using System.Text;

namespace DNServer
{
    public enum RecordType
    {
        /// <summary>
        /// Host Address
        /// </summary>
        A = 1,

        /// <summary>
        /// Authoritative Name Server
        /// </summary>
        NS = 2,

        /// <summary>
        /// Canonical Name for Alias
        /// </summary>
        CNAME = 5,

        /// <summary>
        /// Start of a Zone of Authority
        /// </summary>
        SOA = 6,

        /// <summary>
        /// Well Known Service Description
        /// </summary>
        WKS = 11,

        /// <summary>
        /// Domain Name Pointer
        /// </summary>
        PTR = 12,

        /// <summary>
        /// Mail Exchange
        /// </summary>
        MX = 15,

        /// <summary>
        /// Text Strings
        /// </summary>
        TXT = 16,
    }
}
