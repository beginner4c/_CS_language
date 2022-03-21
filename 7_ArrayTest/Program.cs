using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// C#에서의 1차원 배열 선언과 사용법 + Length

namespace _7_ArrayTest
{
    class Program
    {
        private static int getMax(int[] a)
        {
            int max = -1;

            for (int i = 0; i < a.Length; i++)
                if (max < a[i])
                    max = a[i];

            return max;
        }

        private static double getSum(double[] a)
        {
            double sum = 0;

            for (int i = 0; i < a.Length; i++)
                sum += a[i];

            return sum;
        }

        static void Main(string[] args)
        {
            double[] x = new double[3]; // C#식 배열 선언 방식

            x[0] = 35.12;
            x[1] = 22.34;
            x[2] = 45.31;

            for (int i = 0; i < x.Length; i++)
                Console.WriteLine(x[i]);

            int[] y = new int[5];

            y[0] = 12;
            y[1] = 1;
            y[2] = 43;
            y[3] = 55;
            y[4] = 25;

            for (int i = 0; i < y.Length; i++)
                Console.WriteLine(y[i]);

            Console.WriteLine("\ngetMax(y)"+getMax(y));
            Console.WriteLine("getSum(x) = " + getSum(x));

            char[] c = new char[10];
            c[0] = 'a';
            for (int i = 1; i < c.Length; i++)
                c[i] = (char)((int)c[0] + i);

            for (int i = 0; i < c.Length; i++)
                Console.WriteLine("c[" + i + "] = " + c[i]);
        }
    }
}
