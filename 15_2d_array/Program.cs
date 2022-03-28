using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_2d_array
{
    class Program
    {
        static int getSum(int[][] a)
        {
            int sum = 0;

            for (int i = 0; i < a.Length; i++)
                for (int j = 0; j < a[i].Length; j++)
                    sum += a[i][j];

            return sum;
        }
        static int getSum(int[,] a)
        {
            int sum = 0;

            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                    sum += a[i, j];

            return sum;
        }
        static void Main(string[] args)
        {
            // 효율성의 2차원 배열 할당 방식
            // C# 예제에서 선호하는 방식
            int[,] x = new int[3, 4];
            int data = 1;

            for (int i = 0; i < x.GetLength(0); i++) // 행의 길이를 가지고 비교
                for (int j = 0; j < x.GetLength(1); j++) // 열의 길이를 가지고 비교
                    x[i, j] = data++;

            for (int i = 0; i < x.GetLength(0); i++)
            {
                for (int j = 0; j < x.GetLength(1); j++)
                {
                    Console.Write(x[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("sum = " + getSum(x));


            // 유연성에 초점을 둔 가변배열 형식의 2차원 배열

            // int[][] y = new int[3][4]; // 바로 만들면 syntax error가 발생한다
            // 이런 식으로 두 단계로 나누어서 배열을 만들어야 한다
            int[][] y = new int[3][];
            for (int i = 0; i < 3; i++)
                y[i] = new int[4];

            data = 1;

            for (int i = 0; i < y.Length; i++) // 행의 길이를 가지고 비교
                for (int j = 0; j < y[i].Length; j++) // 열의 길이를 가지고 비교
                    y[i][j] = data++;

            for (int i = 0; i < y.Length; i++)
            {
                for (int j = 0; j < y[i].Length; j++)
                {
                    Console.Write(y[i][j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("sum = " + getSum(y));
        }
    }
}
