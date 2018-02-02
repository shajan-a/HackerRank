using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringToInt
{
    class Program
    {
        static void Main(String[] args)
        {
            string S = Console.ReadLine();
            try
            {
                Console.WriteLine(Convert.ToInt64(S));
            }
            catch (Exception)
            {
                Console.WriteLine("Bad String");
            }
        }
    }
}
