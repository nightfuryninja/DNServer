using System;
using System.Collections.Generic;
using System.Text;

namespace DNServer
{
    public enum OpCode
    {
            StandardQuery = 0,
            InverseQuery = 1,
            ServerStatus = 2,
            Reserved
    }
}
