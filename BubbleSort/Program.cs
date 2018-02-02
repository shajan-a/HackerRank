using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSort
{
    class Program
    {
        static void Main(String[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] a_temp = Console.ReadLine().Split(' ');
            int[] a = Array.ConvertAll(a_temp, Int32.Parse);
            int totalSwaps = 0;
            for (int i = 0; i < n; i++)
            {
                int numberOfSwaps = 0;

                for (int j = 0; j < n - 1; j++)
                {
                    if (a[j] > a[j + 1])
                    {
                        a[j] = a[j] + a[j + 1];
                        a[j + 1] = a[j] - a[j + 1];
                        a[j] = a[j] - a[j + 1];
                        numberOfSwaps++;
                    }
                }

                if (numberOfSwaps == 0)
                {
                    break;
                }
                totalSwaps += numberOfSwaps;
            }
            Console.WriteLine("Array is sorted in {0} swaps.\nFirst Element: {1}\nLast Element: {2}", totalSwaps,a.Min(),a.Max());
            Console.ReadKey();
        }
    }
}
