using System;


namespace TIIK_proj
{
    public static class EncodingRLE
    {
        private static string ToEncode;
        private static string Encoded;
        public const int MagicNumber = 9;
        public static char CustomSeparator;
        // spliting big string and give parametrs  to append function in format for example A2 b2 c17
        public static string Encode(string TextToEncode, char customSeparator)
        {
            ToEncode = TextToEncode;
            Encoded = string.Empty;
            CustomSeparator = customSeparator;

            //Console.WriteLine("Starting encoding " + ToEncode);
            int numberOfOccurences = 1;
            if (ToEncode.Length == 1)
            { AppendToEncodedResult(ToEncode[0], numberOfOccurences); }

            for (int i = 0; i < ToEncode.Length - 1; i++)
            {
                if (ToEncode[i] == ToEncode[i + 1])
                { numberOfOccurences++; }
                else
                {
                    //Console.WriteLine("1.passed this parameter: " + ToEncode[i] + numberOfOccurences);
                    AppendToEncodedResult(ToEncode[i], numberOfOccurences);
                    numberOfOccurences = 1;
                }

                if (i == (ToEncode.Length - 2))
                {
                    //Console.WriteLine("2.passed this parameter: " + ToEncode[i + 1] + numberOfOccurences);
                    AppendToEncodedResult(ToEncode[i + 1], numberOfOccurences);
                }
            }
            return Encoded;
        }

        // creating final Encoded string
        private static void AppendToEncodedResult(char toappend, int count)
        {
            int rest = count % MagicNumber;
            int times = count / MagicNumber;
            //Console.WriteLine("rest: " + rest);
            //Console.WriteLine("times: " + times);

            for (int i = 0; i < times; i++)
                Encoded = Encoded + toappend + CustomSeparator + MagicNumber;

            if (rest != 0 && rest != 1)
                Encoded = Encoded + toappend + CustomSeparator + rest;

            if (rest == 1 && toappend != CustomSeparator)
                Encoded = Encoded + toappend;

            if (rest == 1 && toappend == CustomSeparator)
                Encoded = Encoded + toappend + CustomSeparator + count;

            //if (count == 0)
                //Console.WriteLine("Error: it's not possible");

            //Console.WriteLine("Final Result: " + Encoded);
        }
    }
}

