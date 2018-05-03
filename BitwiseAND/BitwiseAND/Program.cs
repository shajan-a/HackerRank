using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitwiseAND
{
    class Program
    {
        static void Main(String[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());
            List<int> result = new List<int>();
            for (int a0 = 0; a0 < t; a0++)
            {
                string[] tokens_n = Console.ReadLine().Split(' ');
                int n = Convert.ToInt32(tokens_n[0]);
                int k = Convert.ToInt32(tokens_n[1]);
                result.Add(BiggestNumber(n, k));
            }
            foreach (int val in result)
                Console.WriteLine(val);
        }
        public static int BiggestNumber(int n, int k)
        {
            int res = 0;
            int OPres;
            for (int i = 1; i <= n; i++)
            {
                for (int j = i + 1; j <= n; j++)
                {
                    OPres = AndOP(i, j);
                    if (OPres > res && OPres < k)
                        res = OPres;
                }
            }
            return res;
        }
        public static int AndOP(int a, int b)
        {
            string astring = Convert.ToString(a, 2);
            string bstring = Convert.ToString(b, 2);
            string res = BitAndOperate(astring, bstring).Replace("\n\r", string.Empty);
            return Convert.ToInt32(res, 2);
        }

        public static string BitAndOperate(string astring, string bstring)
        {
            StringBuilder res = new StringBuilder();
            if (astring.Length == bstring.Length)
            { 
                for (int i = 0; i < astring.Length; i++)
                {
                    if (astring[i] == '1' && bstring[i] == '1')
                    {
                        res.Append(1);
                    }
                    else
                    {
                        res.Append(0);
                    }
                }
            }
            else if (astring.Length > bstring.Length)
            {
                for (int i = 0; i < bstring.Length; i++)
                {
                    if (astring[i] == '1' && bstring[i] == '1')
                    {
                        res.Append(1);
                    }
                    else
                    {
                        res.Append(0);
                    }
                }
                res.Append('0',astring.Length - bstring.Length);
                return new string(res.ToString().Reverse().ToArray());
            }
            else
            {
                astring = new string(astring.Reverse().ToArray());
                bstring = new string(bstring.Reverse().ToArray());

                for (int i = 0; i < astring.Length; i++)
                {
                    if (astring[i] == '1' && bstring[i] == '1')
                    {
                        res.Append(1);
                    }
                    else
                    {
                        res.Append(0);
                    }
                }
                res.Append('0',bstring.Length - astring.Length);
                return new string(res.ToString().Reverse().ToArray());
            }
            return res.ToString();
        }
    }
}
