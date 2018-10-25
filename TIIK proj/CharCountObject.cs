using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIIK_proj
{
    public class CharCountObject
    {
        public char Character { get; set; }
        public int Count { get; set; }
        public int ASCII { get { return Character; } }
        public int Probability { get; set; }
        public string ProbabilityAsString { get {
                var query = (Probability.ToString().Insert(0, "000").Insert(Probability.ToString().Length, ",") + " %").SkipWhile(x => x == '0');
                string result = string.Empty;
                foreach (var character in query)
                {
                    result += character;
                }
                return result;
            } }

    }
}
