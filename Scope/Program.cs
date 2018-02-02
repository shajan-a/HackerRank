using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scope
{
    class Program
    {
        static void Main(string[] args)
        {
            Convert.ToInt32(Console.ReadLine());

            int[] a = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();

            Difference d = new Difference(a);

            d.computeDifference();

            Console.Write(d.maximumDifference);
        }
    }

    class Difference
    {
        private int[] elements;
        public int maximumDifference;

        public Difference(int[] a)
        {
            elements = a;
        }

        internal void computeDifference()
        {
            for(int i= 0; i < elements.Length; i++)
            {
                for (int j = i+1; j < elements.Length; j++)
                {
                    if (maximumDifference < Math.Abs(elements[i] - elements[j]))
                    {
                        maximumDifference = Math.Abs(elements[i] - elements[j]);
                    }
                }
            }
        }
    }
}
