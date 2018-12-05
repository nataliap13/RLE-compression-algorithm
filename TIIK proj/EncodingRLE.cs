using System;


namespace TIIK_proj
{
    public static class EncodingRLE
    {
        private static string ToEncode;
        private static string Encoded;
        // spliting big string and give parametrs  to append function in format for example A2 b2 c17
        public static string Encode(string TextToEncode)
        {
            ToEncode = TextToEncode;
            Encoded = string.Empty;

            //Console.WriteLine("Starting encoding " + ToEncode);
            int numberOfOccurences = -1;

            while (ToEncode.Length > 1)
            {
                if (ToEncode[0] == ToEncode[1] && numberOfOccurences < UInt16.MaxValue)
                { numberOfOccurences++; }
                else
                {
                    //Console.WriteLine("1.passed this parameter: " + ToEncode[i] + numberOfOccurences);
                    AppendToEncodedResult(ToEncode[0], numberOfOccurences);
                    numberOfOccurences = -1;
                }
                ToEncode = ToEncode.Remove(0, 1);
            }

            if (ToEncode.Length == 1)
            {
                //Console.WriteLine("2.passed this parameter: " + ToEncode[i + 1] + numberOfOccurences);
                AppendToEncodedResult(ToEncode[0], numberOfOccurences);
            }
            return Encoded;
        }

        // creating final Encoded string
        private static void AppendToEncodedResult(char toappend, int count)
        {
            if (count == -1)
            { Encoded = Encoded + toappend; }
            else
            { Encoded = Encoded + toappend + toappend + (char)count; }

            //if (count == 0)
            //Console.WriteLine("Error: it's not possible");
            //Console.WriteLine("Final Result: " + Encoded);
        }
    }
}

