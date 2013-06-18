using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqEng.Internal.Scripting
{
    public enum OpCode
    {
        nop,
        set,
        jmp,
        jeq,
        jneq,
        jg,
        jge,
        jl,
        jle,
        @goto,
        wait_ms,
        wait_ticks,
        end,
        dialog,
        stage,
        music,
        snd
    }
}
