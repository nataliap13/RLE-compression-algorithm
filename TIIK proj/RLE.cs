using System;
using System.Collections.Generic;
using System.Linq;

namespace TIIK_proj
{
    public static class RLE
    {
        private static string Encoded;
        //private static List<char> EncodedList;
        // spliting big string and give parametrs to append function in format for example A2 b2 c17
        public static string Encode(string TextToEncode)
        {
            List<char> ToEncode = TextToEncode.ToList();
            Encoded = string.Empty;
            //EncodedList = new List<char>();
            int numberOfOccurences = -1;

            while (ToEncode.Count > 1)
            {
                if (ToEncode[0] == ToEncode[1] && numberOfOccurences < char.MaxValue)
                { numberOfOccurences++; }
                else
                {
                    AppendToEncodedResult(ToEncode[0], numberOfOccurences);
                    numberOfOccurences = -1;
                }
                ToEncode.RemoveAt(0);
            }

            if (ToEncode.Count == 1)
            {
                AppendToEncodedResult(ToEncode[0], numberOfOccurences);
            }
            return Encoded;
            //return new string(EncodedList.ToArray());
        }

        // creating final Encoded string
        private static void AppendToEncodedResult(char toappend, int count)
        {
            if (count == -1)
            { Encoded = Encoded + toappend; }
            else
            { Encoded = Encoded + toappend + toappend + (char)count; }
            /*if (count == -1)
            { EncodedList.Add(toappend); }
            else
            {
                EncodedList.Add(toappend);
                EncodedList.Add(toappend);
                EncodedList.Add((char)count);
            }*/
        }
        /*
        public static string Decode(string toDecode)
        {
            //int toDecodeLen = toDecode.Length;
            string decoded = string.Empty;
            //Console.WriteLine("toDecodeLen " + toDecodeLen);
            while (toDecode.Length > 1)
            {
                if (toDecode[0] == toDecode[1])
                {
                    int count = (int)toDecode[2];
                    // bo ma byc dopisanych znakow aa3 -> 3 a wiec sumarycznie 3+2=5, dlatego petla sie obraca count+2
                    decoded += new String(toDecode[0], count + 2);
                    toDecode = toDecode.Remove(0, 3);
                }
                else
                {
                    decoded += toDecode[0];
                    toDecode = toDecode.Remove(0, 1);
                }
            }
            if (toDecode.Length == 1)
            { decoded += toDecode[0]; }
            return decoded;
        }*/
        ///*
        public static string Decode(string TextToDecode)
        {
            List<char> toDecode = TextToDecode.ToList();
            //int toDecodeLen = toDecode.Length;
            string decoded = string.Empty;
            //Console.WriteLine("toDecodeLen " + toDecodeLen);
            while (toDecode.Count > 1)
            {
                if (toDecode[0] == toDecode[1])
                {
                    int count = (int)toDecode[2];
                    // bo ma byc dopisanych znakow aa3 -> 3 a wiec sumarycznie 3+2=5, dlatego petla sie obraca count+2
                    decoded += new String(toDecode[0], count + 2);
                    toDecode.RemoveRange(0, 3);
                }
                else
                {
                    decoded += toDecode[0];
                    toDecode.RemoveAt(0);
                }
            }
            if (toDecode.Count == 1)
            { decoded += toDecode[0]; }
            return decoded;
        }//*/
    }
}

