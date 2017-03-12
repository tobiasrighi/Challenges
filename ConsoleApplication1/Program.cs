using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] A = new int[8];
            //A[0] = -1;
            //A[1] = 3;
            //A[2] = -4;
            //A[3] = 5;
            //A[4] = 1;
            //A[5] = -6;
            //A[6] = 2;
            //A[7] = 1;

            //foreach (int item in Equi(A))
            //{
            //    Console.WriteLine(item);
            //}

            //Console.WriteLine(Solution(328));
            //Console.WriteLine(Solution(6));
            //Console.WriteLine(Solution(1162));
            //Console.WriteLine(Solution(5));
            //Console.WriteLine(Solution(51712));
            //Console.WriteLine(Solution(20));
            //Console.WriteLine(Solution(66561));
            //Console.WriteLine(Solution(6291457));
            //Console.WriteLine(Solution(805306373));
            //Console.WriteLine(Solution(1610612737));
            //Console.WriteLine(Solution(9));
            //Console.WriteLine(Solution(529));
            //Console.WriteLine(Solution(20));
            //Console.WriteLine(Solution(15));
            //Console.WriteLine(Solution(1041));

            //createHour(1, 8, 3, 2);
            //createHour(2, 4, 0, 0);
            //createHour(3, 0, 7, 0);
            //createHour(9,1,9,7);
        }

        //return the bigger hour giving 4 numbers or NOT POSSIBLE
        public static string createHour(int A, int B, int C, int D)
        {
            string ret = string.Empty;
            List<int> pos = new List<int>();
            List<int> nros = new List<int>();
            nros.Add(A);
            nros.Add(B);
            nros.Add(C);
            nros.Add(D);

            for (int p = 1, nro = 2; nro >= 0; nro--)
            {
                if (pos.Count == 4)
                    break;
                for (int n = 0; n < nros.Count; n++)
                {
                    if (nros[n] >= 0 && nros[n] == nro)
                    {
                        pos.Add(nro);
                        nros[n] = -1;
                        if (p == 1 && nro == 2)
                            nro = 4;
                        else if (p == 1)
                            nro = 10;
                        else if (p == 2)
                            nro = 6;
                        else if (p == 3)
                            nro = 10;
                        p++;
                        break;
                    }
                }
            }

            if (pos.Count < 4)
                ret = "NOT POSSIBLE";
            else
                ret = pos[0].ToString() + pos[1].ToString() + ":" + pos[2].ToString() + pos[3].ToString();
            return ret;
        }

        //return bigger string with the pattern "start with a capital letter and dont have digits"
        public static int biggerMatch(string S)
        {
            // Get first match.
            Match match = Regex.Match(S, @"[A-Z]+[a-zA-z]*\D");
            var ret = -1;
            while (match.Success)
            {
                if (ret < match.Value.Length)
                    ret = match.Value.Length;
                match = match.NextMatch();
            }

            return ret;
        }
        
        //if number can be divide by 3 return 'Fizz'
        //if number can be divide by 5 return 'Buzz'
        //if number can be divide by 7 return 'Woof'
        //if can be divide by more than one, concat the string
        public static void tobias(int N)
        {
            string ret = string.Empty;
            for (int pos = 1; pos <= N; pos++)
            {
                if (pos % 3 == 0)
                    ret = "Fizz";
                if (pos % 5 == 0)
                    ret += "Buzz";
                if (pos % 7 == 0)
                    ret += "Woof";

                if (string.IsNullOrEmpty(ret))
                    Console.WriteLine(pos);
                else
                    Console.WriteLine(ret);

                ret = string.Empty;
            }

        }

        //binary gap
        //Find longest sequence of zeros in binary representation of an integer.
        public static int Solution(int N)
        {
            string val = Convert.ToString(N, 2);
            int max = 0;
            int counter = 0;

            for (int i = 0; i < val.Length; i++)
            {
                if (val[i] == '0')
                    counter++;
                else
                {
                   if (counter > max)
                       max = counter;
                       counter = 0;
                }
             }

            return max;
        }

        //Equi
        //Find an index in an array such that its prefix sum equals its suffix sum
        public static List<int> Equi(int[] A)
        {
            List<int> ret = new List<int>();
            var eq = 1;
            var somaA = A[0];
            var somaB = 0;

            for(eq = 2; eq < A.Length; eq++)
            {
                somaB += A[eq];
            }
            if (somaA == somaB)
                ret.Add(1);

            for (eq = 2; eq < A.Length; eq++)
            {
                somaA += A[eq-1];
                somaB -= A[eq];
                if(somaA == somaB)
                    ret.Add(eq);
            }

             if (ret.Count == 0)
                ret.Add(-1);
            return ret;
        }
    }
}
