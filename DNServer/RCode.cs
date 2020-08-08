using System;
using System.Collections.Generic;
using System.Text;

namespace DNServer
{
    public enum RCode
    {
        NoError = 0,
        FormatError = 1,
        ServerFaliure = 2,
        NameError = 3,
        NotImplemented = 4,
        Refused = 5,
        Reserved
    }
}
