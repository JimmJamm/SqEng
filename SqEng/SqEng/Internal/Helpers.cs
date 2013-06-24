using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using SFML.Window;
using SFML.Graphics;
using System.Diagnostics;


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

        public static XmlDocument NodeToDoc(XmlNode n)
        {
            XmlDocument x = new XmlDocument();
            x.LoadXml(n.OuterXml);
            return x;
        }

        public static bool TrianglePointCollision(Vector2f[] tri, Vector2f pt)
        {
            Debug.Assert(tri.Length == 3);
            return TrianglePointCollision(tri[0], tri[1], tri[2], pt);
        }
        public static bool TrianglePointCollision(Vector2f top, Vector2f left, Vector2f right, Vector2f pt)
        {
            Debug.Assert(left.Y == right.Y);
            Debug.Assert(top.X == left.X || top.X == right.X);

            if (pt.X < left.X || pt.X > right.X || pt.Y > left.Y || pt.Y < top.Y)
                return false;

            float dy = top.Y - left.Y;

            if (top.X == left.X)
                dy *= -1;

            float dx = right.X - left.X;

            float m = dy / dx;

            float b;
            Debug.Assert(m != 0);

            if (m > 0)
                b = top.Y - m * right.X;
            else
                b = top.Y - m * left.X;

            float f_x = m * pt.X + b;

            return pt.Y <= f_x;
        }

        public static bool TriangleTriangleCollision(Vector2f[] tri1, Vector2f[] tri2)
        {
            Debug.Assert(tri1.Length == 3 && tri2.Length == 3);

            foreach (Vector2f pt in tri1)
            {
                if (TrianglePointCollision(tri2, pt))
                    return true;
            }
            foreach (Vector2f pt in tri2)
            {
                if (TrianglePointCollision(tri1, pt))
                    return true;
            }

            return false;
        }

        public static bool RectPointCollision(FloatRect rect, Vector2f pt)
        {
            return rect.Intersects(new FloatRect(pt.X, pt.Y, 1.0f, 1.0f));
        }
        public static bool RectRectCollision(FloatRect r1, FloatRect r2)
        {
            return r1.Intersects(r2);
        }

        public static bool TriangleRectCollision(Vector2f[] tri, FloatRect fr)
        {
            Debug.Assert(tri.Length == 3);

            if (tri[1].X < fr.Left)
                return false;
            if (tri[2].X > fr.Left + fr.Width)
                return false;

            if (tri[1].Y < fr.Top)
                return false;
            if (tri[0].Y > fr.Top + fr.Height)
                return false;

            foreach (Vector2f pt in tri)
            {
                if (RectPointCollision(fr, pt))
                    return true;
            }
            if (TrianglePointCollision(tri, new Vector2f(fr.Left, fr.Top)))
                return true;
            if (TrianglePointCollision(tri, new Vector2f(fr.Left, fr.Top + fr.Height)))
                return true;
            if (TrianglePointCollision(tri, new Vector2f(fr.Left + fr.Width, fr.Top)))
                return true;
            if (TrianglePointCollision(tri, new Vector2f(fr.Left + fr.Width, fr.Top + fr.Height)))
                return true;

            return false;
        }
    }
}
