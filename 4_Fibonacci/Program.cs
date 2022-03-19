using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 재귀함수를 이해하기 위한 피보나치 수열 구현

namespace _4_Fibonacci
{
    class Program
    {
        static void f(int n) // 기본적인 재귀함수 구조
        {
            if (n == 0) return; // boundary condition(무한 루프 방지)
            Console.WriteLine("hello");
            f(n-1);
        }

        static int fibo(int n) // recursive function으로 구현된 피보나치 수열
        {
            if (n == 0) return 1;
            if (n == 1) return 1;
            if (n >= 2) return fibo(n - 1) + fibo(n - 2); // 실제로 함수를 2개 씩 자꾸 불어나기에 n^2에 가깝다

            Console.WriteLine("Unexpected minus argument occur!!");
            Environment.Exit(-1);
            return -1; // syntax error 방지
        }

        static int for_fibo(int n) // for문으로 구현된 피보나치 수열
        {
            if (n == 0) return 1;
            if (n == 1) return 1;
            if (n < 0)
            {
                Console.WriteLine("Unexpected minus argumnet occur!!");
                Environment.Exit(-1);
            }
            int f0 = 1;
            int f1 = 1;
            int f2 = 0;
            for(int i = 1; i < n; i++) // for문으로 피보나치를 계산한다
            {
                f2 = f1 + f0;
                f0 = f1;
                f1 = f2;
            }
            return f2;
        }
        static void Main(string[] args)
        {
            // f(5);
            Console.WriteLine(fibo(0));
            Console.WriteLine(fibo(2));

            for(int i = 0; i < 40; i++) // 숫자가 올라갈수록 계산하는데 시간이 걸린다
            {
                Console.WriteLine(fibo(i));
            }

            for(int i = 0; i< 40; i++) // recursive function으로 구현된 것보다 훨씬 시간이 빠르다
            {
                Console.WriteLine(for_fibo(i));
            }
        }
    }
}
