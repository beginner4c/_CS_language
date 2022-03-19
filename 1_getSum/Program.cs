using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// C처럼 구현된 C#
// Procedural Programming 이다 (객체 지향x)

namespace _1_getSum
{
    class Program
    {
        static int getSum(int n)
        {
            int total = 0;
            int i;

            if (n <= 0)
            {
                Console.WriteLine("Please use positive number.");
                Environment.Exit(-1);
            }

            for (i = 0; i <= n; i++)
            {
                total = total + i;
            }

            return total;
        }
        static void Main(string[] args)
        {
            int sum;

            sum = Program.getSum(100);
            Console.WriteLine("sum = " + sum);
        }
    }
}
