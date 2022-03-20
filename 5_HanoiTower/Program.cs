using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_HanoiTower
{
    class Program
    {   
        static void moveHanoi(int n, char from, char temp, char to)
        {
            if (n == 1)
            {
                Console.WriteLine(from + " => " + to);
                return;
            }
            moveHanoi(n - 1, from, to, temp);
            moveHanoi(1, from, temp, to); // 가장 무거운 거
            moveHanoi(n - 1, temp, from, to);
        }
        static void Main(string[] args)
        {
            moveHanoi(5, 'A', 'B', 'C');
        }
    }
}
