using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqEng.Internal.Scripting
{
    public enum VarType
    {
        Variable    = 0x80,           
        Local       = Variable | 0x40,
        Obj         = Variable | 0x20,
        Global      = Variable | 0x10,

        Number      = 0x08,
        String      = 0x04
    }
}
