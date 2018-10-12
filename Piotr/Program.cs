using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Reader r = new Reader();
            Dictionary<char, int> d=r.read(@"C:\Users\Piotr\Desktop\Projects\dziala\input.txt");
            d.ToList().ForEach(x => Console.WriteLine(x.Key + " Value: " + x.Value));

     

            Console.ReadLine();
        }
    }
}
