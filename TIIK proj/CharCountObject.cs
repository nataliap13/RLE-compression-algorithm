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
        public double Probability { get; set; }

    }
}
