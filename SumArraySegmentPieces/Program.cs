using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace SumArraySegmentPieces
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            int N  = Convert.ToInt32(Console.ReadLine());
//            int[] A = new int[N];
//            A = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
//            int sum = Summing(N,A);
//            Console.WriteLine(sum);
//            Console.ReadKey();

//        }

//        private static int ArraySegmentPieceSum(int[] a)
//        {
//            List<int[]> lstarr = new List<int[]>();
//            int Sum = 0;

//            for (int i = 0; i < a.Length; i++)
//            {
//                for (int j = 0; j < a.Length - i; j++)
//                {
//                    int[] arr  = a.Skip(j).Take(i+1).ToArray();
//                    lstarr.Add(arr);


//                    Sum += arr.Sum() * arr.Length;
//                    if (arr.Length > 1)
//                    {

//                        int[] rest = a.Where(x => !arr.Contains(x)).ToArray();
//                        lstarr.Add(rest);
//                        Sum += rest.Sum();
//                    }
//                }
//            }
//            return  Sum % 1000000007;
//        }

//        static int Summing(int n, int[] a)
//        {
//            bool IsOdd = n%2 != 0;
//            int limit = IsOdd ? n/2 + 1: n / 2;
//            int[] t = new int[limit];
//            t[0] = Pow(2, n) - 1;

//            for (int i = 1; i < limit; i++)
//            {
//                t[i] = t[i - 1] + Pow(2, n-2-(i-1)) - Pow(2, i - 1);
//            }
//            int[] temp = t.Reverse().ToArray();
//            int destinationLength = t.Length;
//            if (IsOdd)
//            {
//                Array.Resize(ref t, destinationLength + temp.Skip(1).ToArray().Length);
//                Array.Copy(temp.Skip(1).ToArray(),0,t, destinationLength, temp.Skip(1).ToArray().Length);
//            }
//            else
//            {
//                Array.Resize(ref t, destinationLength + temp.Length);
//                Array.Copy(temp, 0, t, t.Length, temp.Length);
//            }
            
//            int Sum = 0;
//            for (int i = 0; i < n; i++)
//            {
//                Sum += t[i]*a[i];
//            }
//            return Sum%1000000007;
//        }

//        //    int[] powers = new int[1000003];
//        //    const int MOD = 1000000007;
//        //    powers[0] = 1;
//        //        for (int i = 1; i< 1000003; i++)
//        //        {
//        //            powers[i] = (2 * powers[i - 1]) % MOD;
//        //        }
//        //long result = 0;
//        //        for (int i = 0; i<n; i++)
//        //        {


//        //            long mult = ((powers[i + 1] + powers[i] - 1) * powers[n - 1 - i] - powers[i] + MOD) % MOD;
//        //result += a[i] * mult % MOD;
//        //            result = result % MOD;
//        //        }
//        //        return result;
//        static int Pow(int x, int p)
//        {
//            int result = 1;
//            for (int i = 0; i < p; i++)
//            {
//                result *= x;
//            }
//            return result;
//        }
//    }
//}

namespace SumArraySummingPieces
{
    class Program
    {
        /*
         * 
         * start: 11:09 
         * read problem statement
         * https://www.hackerrank.com/contests/world-codesprint-7/challenges/summing-pieces
         * work on DP formula 
         * from 11:00 -> 12:46pm 
         * work on two test cases 
         * Fully understand the fomula, let us give it a try using code
         * 
         * put code to run: 1:37pm 
         * debugging more 50+ minutes
         * put int testing on 3:02pm 
         * 
         * Start: 3:06pm 
         * work on wrong answer, timeout issue 
         * Add memorization into the code 
         * Continue to more code more readable, less complicate 
         * 
         * start: 7:36pm
         * work on bug fix using module -> 11 point out of 40
         * continue to work on timeout 3 second issue
         * 
         * bug fix NO2: 11.03 -> 13.79
         * comment out debug code: 
         * 
         * push long -> int
         * 
         * special discussion in the function:
         * multiplicationWithCare
         * score from 13.79 -> 19.31
         * Ranking from 732 -> 692
        */
        static void Main(string[] args)
        {
            //test(); 
            program();
        }

        private static void test()
        {
            int n = 3;
            string[] arr = new string[3] { "1", "3", "6" };

            Console.WriteLine(calculateUsingDP(n, arr));
        }
        /*
         * start: 1:39pm 
         * 
         */
        private static void program()
        {
            int n = Convert.ToInt32(Console.ReadLine());
            string[] arr = Console.ReadLine().Split(' ');

            Console.WriteLine(calculateUsingDP(n, arr));
        }
        /*
         * work on: 1:20pm 
         * continue: 1:20pm - ? 
         * IMPORTANT FIX:  
         * bug fix NO1: this fix -> point 4 -> point 11
         */
        private static long calculateUsingDP(int n, string[] arr)
        {
            int module = 1000 * 1000 * 1000 + 7;

            int[] input = convertInt(arr);
            int[] kCount = new int[n];
            int[] kSum = new int[n];
            int[] sumA = new int[n];

            kCount[0] = 1;
            kSum[0] = 1;

            sumA[0] = input[0];

            Dictionary<string, int> data = new Dictionary<string, int>();
            for (int i = 1; i < n; i++)
            {
                int[] tmp = new int[i + 1];

                int memo = 0;
                for (int j = i; j >= 0; j--)
                {
                    int start = j;
                    int end = i;
                    int count = end - start + 1;

                    int leftEnd = j - 1;
                    if (leftEnd >= 0)
                    {
                        int tmpSum = (memo + input[start]) % module;
                        int prod = AxB(tmpSum, count);

                        tmp[start] = (sumA[leftEnd] +
                            AxB(kCount[leftEnd], prod)) % module;

                        memo = tmpSum;
                    }
                    else
                    {
                        int v1 = AxB(memo + input[0], count);

                        tmp[0] = v1 % module;
                    }
                }

                sumA[i] = arraySum(tmp, module);

                kCount[i] = (kSum[i - 1] + 1) % (int)module;         // bug fix NO1
                kSum[i] = (kSum[i - 1] + kCount[i]) % (int)module; //bug fix NO1
            }

            return sumA[n - 1];
        }

        /*
         * start: 6:44pm
         * exit:  6:46pm 
         * 
         * Reduce % modulde calculation to minimum 
         * Still same score 
         */
        private static int arraySum(int[] tmp, int module)
        {
            int result = 0;
            foreach (int item in tmp)
            {
                result = (result + item) % module;
            }

            return result;
        }

        /*
         * start: 3:26pm
         * Test case: 
         * sum * count 
         * Need to figure out how to shorten the time to do calculation
         * Test the funnction
         *
         * speed up modulation
         * https://www.khanacademy.org/computing/computer-science/cryptography/modarithmetic/a/fast-modular-exponentiation
         */
        private static int AxB(int sum, int count)
        {
            int module = 1000 * 1000 * 1000 + 7;
            long MAX = long.MaxValue;

            int result = 0;
            long p = (long)sum * (long)count;

            if (p < MAX)
                result = (int)(p % module);
            else
            {
                int step = (int)(MAX / sum);
                int no = count / step;

                int small = count - (no * step);

                result = (sum * step);
                result = (result * no);
                result += (sum * small);
                result = result % module;
            }

            return result;
        }

        private static int[] convertInt(string[] arr)
        {
            int n = arr.Length;
            int[] res = new int[n];

            for (int i = 0; i < n; i++)
                res[i] = Convert.ToInt32(arr[i]);

            return res;
        }
    }
}
