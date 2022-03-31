using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 행렬의 연산을 다룬다
// 행렬의 덧셈과 뺄셈 연산은 행렬의 크기와 모양이 같아야 한다
// 행렬의 곱셈은 첫째 행렬의 열 개수와 둘째 행렬의 행 개수가 같아야 한다
// 행렬 곱셈 결과로는 첫째 행렬의 행과 둘째 행렬의 열 크기를 가진 행렬이 만들어져야한다

namespace _29_matrix_operation
{
    class Program
    {
        // 행렬의 덧셈은 같은 크기와 모양의 행렬만이 가능하다
        public static int[,] add(int[,] a, int[,] b) // 2차원 행렬을 두 개 받아와서 값을 더해 돌려주는 함수
        {
            int[,] res = new int[a.GetLength(0), a.GetLength(1)]; // a의 행열 크기를 그대로 가져와서 할당

            for (int i = 0; i < a.GetLength(0); i++) // 행의 길이만큼 반복
                for (int j = 0; j < a.GetLength(1); j++) // 열의 길이만큼 반복
                    res[i, j] = a[i, j] + b[i, j];

            return res;
        }

        // 행렬의 뺄셈은 같은 크기와 모양의 행렬만이 가능하다
        public static int[,] subtract(int[,] a, int[,] b) // 2차원 행렬을 두 개 값을 빼서 돌려주는 함수
        {
            int[,] res = new int[a.GetLength(0), a.GetLength(1)];

            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                    res[i, j] = a[i, j] - b[i, j];

            return res;
        }
        
        // 아래는 scalar multiplication 스칼라 곱셈을 하는 함수, 행렬의 크기나 모양에 관계가 없다
        public static int[,] multiply(int[,] a, int num) // 2차원 행렬에 값을 곱해서 돌려주는 함수
        {
            int[,] res = new int[a.GetLength(0), a.GetLength(1)];

            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                    res[i, j] = a[i, j] * num;

            return res;
        }
        // 아래는 2차원 행렬 두 개를 곱하는 함수
        // 행렬의 곱셈은 첫 행렬의 열의 크기와 둘째 행렬의 행의 크기가 같아야 한다
        // 곱셈 결과로 만들어지는 행렬은 첫째 행렬의 행의 크기와 둘째 행렬의 열의 크기를 가지고 있다
        // 곱셈 연산은 첫째 행렬의 행과 둘째 행렬의 열을 길이에 맞게 곱해서 각각을 다 더하는 연산이다
        public static int[,] multiply(int[,] a, int[,] b) // 2차원 행렬을 두 개를 곱해 돌려주는 함수
        {
            if (a.GetLength(0) != b.GetLength(1)) // 원래는 이런 조건에서 걸러내야 한다
            {
                
            }
            int[,] res = new int[a.GetLength(0), b.GetLength(1)]; // a 행렬의 행 길이와 b 행렬의 열 길이를 가진 2차원 행렬을 만든다

            for (int i = 0; i < a.GetLength(0); i++) // a 행렬의 행 길이만큼 반복
                for (int j = 0; j < b.GetLength(1); j++) // b 행렬의 열 길이만큼 반복
                {
                    res[i, j] = 0; // 해당 행렬 0으로 초기화
                    for (int k = 0; k < a.GetLength(1); k++) // a 행렬의 열 길이만큼 반복
                        res[i, j] += a[i, k] * b[k, j]; // 결과값 행렬에 a행렬과 b행렬의 값을 곱해 더해준다
                }
            return res;
        }

        public static void print(int[,] a) // 행렬의 내용을 출력하는 함수
        {
            for (int i = 0; i < a.GetLength(0); i++) // 행의 길이만큼 반복
            {
                for (int j = 0; j < a.GetLength(1); j++) // 열의 길이만큼 반복
                    Console.Write(a[i, j] + " ");
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            int[,] x = { { 1,2,3,4} , // 4x4 크기 행렬
                        {5,6,7,8 },
                        {9,10,11,12} };
            int[,] y = { { 1, 1, 1, 1 }, // 4x4 크기 행렬
                        {1,1,1,1 },
                        {1,1,1,1 } };
            int[,] w = { { 1,1}, // 4x2 크기 행렬
                        {1,1 },
                        {2,2 },
                        {2,2 } };

            print(x);
            print(y);

            int[,] z = add(x, y);
            print(z);

            z = subtract(x, y);
            print(z);

            z = multiply(x, 2); // scalar multiplication 벡터 곱셈 - 행렬에 수를 곱하는 것 
            print(z);

            print(x);
            print(w);

            z = multiply(x, w);
            print(z);
        }
    }
}
