using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace ConsoleApp1
{
    class Reader
    {
        public Dictionary<char, int> read(string filePath)
        {
            List<string> lines = File.ReadAllLines(filePath).ToList();
            Dictionary<char, int> dict = new Dictionary<char, int>();

            // every line we read separately
            foreach (string line in lines)
            {
                for (int i = 0; i < line.Length; i++)
                {   // if there isn't the char in the dictionary we add key
                    if (!dict.ContainsKey(line[i]))
                        dict.Add(line[i], 1);
                    // if there is the char in the dictionary we just increase the value
                    else
                        dict[line[i]] += 1;
                }
            }
            return dict;
        }
    }
}


