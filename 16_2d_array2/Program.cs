using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_2d_array2
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
        static void Main(string[] args)
        {
            // 유연성에 초점을 둔 가변배열 형식의 2차원 배열
            // 각 행마다 다른 길이를 할당할 수 있다

            int[][] y = new int[3][];
            // 정수 배열을 가르키는 reference의 배열
            /*
            y[0] = new int[2];
            y[1] = new int[4];
            y[2] = new int[3];
            */

            // 이렇게 만드는 경우 y[1]과 y[2]가 y[0]를 참조하기 때문에 같은 행으로 취급된다
            y[0] = new int[4];
            y[1] = y[0];
            y[2] = y[0];

            int data = 1;

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
