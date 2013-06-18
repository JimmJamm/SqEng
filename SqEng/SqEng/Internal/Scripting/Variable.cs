using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqEng.Internal.Scripting
{
    public class Variable
    {
        public object Contents;
        public VarType Type;

        public Variable(string rawString)
        {
            if ("1234567890-+".Contains(rawString[0]))
            {
                Type = VarType.Number;
                Contents = Convert.ToInt32(rawString);
            }
            else if (rawString[0] == '"')
            {
                Type = VarType.String;
                Contents = rawString.Substring(1, rawString.Length - 2);
            }
            else
            {
                Contents = rawString.Substring(1, rawString.Length - 1);
                switch (rawString[0])
                {
                    case '$':
                        Type = VarType.Local;
                        break;
                    case '^':
                        Type = VarType.Obj;
                        break;
                    case '*':
                        Type = VarType.Global;
                        break;
                    default:
                        throw new Exception("Vartype not implemented: " + rawString[0]);
                }
            }
        }
    }
}
