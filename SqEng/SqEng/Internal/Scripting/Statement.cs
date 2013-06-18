using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqEng.Internal.Scripting
{
    public class Statement
    {
        public OpCode Op;
        public List<Variable> Vars;

        public Statement(string rawLine)
        {
            string[] pieces = Helpers.SplitWrtQuotes(rawLine);

            Op = (OpCode)Enum.Parse(typeof(OpCode), pieces[0]);

            for (int i = 1; i < pieces.Length; ++i)
            {
                Vars.Add(new Variable(pieces[i]));
            }
        }
    }
}
