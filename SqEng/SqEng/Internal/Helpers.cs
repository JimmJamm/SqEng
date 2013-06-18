using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqEng.Internal
{
    public static class Helpers
    {
        private enum splitMode
        {
            Whitespace,
            String,
            Other
        }
        public static string[] SplitWrtQuotes(string str)
        {
            //return System.Text.RegularExpressions.Regex.Split(str, "\"(.+?)(?<!\\\\)\"");
            string whitespace = " \t";

            splitMode mode = splitMode.Whitespace;
            List<string> pieces = new List<string>();
            string piece = "";
            for (int i = 0; i < str.Length; ++i)
            {
                //System.Windows.Forms.MessageBox.Show(mode.ToString() + " %" + piece + "%");
                if (mode == splitMode.Whitespace)
                {
                    if (whitespace.Contains(str[i]))
                    {
                        continue;
                    }
                    if (str[i] == '"')
                    {
                        mode = splitMode.String;
                        continue;
                    }
                    mode = splitMode.Other;
                }

                if (mode == splitMode.String)
                {
                    if (str[i] != '"')
                    {
                        piece += str[i];
                        continue;
                    }
                    else
                    {
                        pieces.Add(piece);
                        mode = splitMode.Whitespace;
                        piece = "";
                    }
                }

                if (mode == splitMode.Other)
                {
                    if (whitespace.Contains(str[i]))
                    {
                        pieces.Add(piece);
                        mode = splitMode.Whitespace;
                        piece = "";
                    }
                    else
                    {
                        piece += str[i];
                    }
                }
            }
            if (piece.Length > 0)
                pieces.Add(piece);

            return pieces.ToArray();
        }
    }
}
