using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Patterns
{
    class Program
    {
        static void Main(String[] args)
        {
            int N = Convert.ToInt32(Console.ReadLine());
            List<KeyValuePair<string,string>> lstkeyValuePair = new List<KeyValuePair<string, string>>();
            for (int a0 = 0; a0 < N; a0++)
            {
                string[] tokens_firstName = Console.ReadLine().Split(' ');
                string firstName = tokens_firstName[0];
                string emailID = tokens_firstName[1];
                lstkeyValuePair.Add(new KeyValuePair<string, string>(firstName, emailID));
            }
            Regex regex = new Regex("@gmail.com$");
            IList<KeyValuePair<string, string>> orderedEnumerable = new List<KeyValuePair<string, string>>();
            if (lstkeyValuePair.Count > 0)
            {
                orderedEnumerable = lstkeyValuePair.OrderBy(x=>x.Key).Where(x=> regex.IsMatch(x.Value)).ToList();
            }
            foreach (var kvp in orderedEnumerable)
            {
                Console.WriteLine(kvp.Key);
            }

            Console.ReadKey();
        }
    }
}
