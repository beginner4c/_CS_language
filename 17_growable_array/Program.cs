using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 성장 가능한 배열
// 보통 배열 길이의 2배 만큼 더 큰 배열을 만들어 할당한다

namespace _17_growable_array
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] x = new int[4];
            x[0] = 1;
            x[1] = 2;
            x[2] = 3;
            x[3] = 4;
            // 아래처럼 선언 후 컴파일하면 C#에서는 OutOfRangeException이 발생
            // x[4] = 5;

            if (4 >= x.Length) // x 배열에 overflow 발생할 경우
            {
                int[] y = new int[5]; // 더 큰 새로운 배열

                for (int i = 0; i < x.Length; i++) // 새로운 배열에 기존 배열 데이터 복사
                    y[i] = x[i];

                x = y; // 더 큰 배열을 다시 기존의 reference에 할당
            }

            x[4] = 5; // 커진 배열에 다시 데이터 삽입

            for( int i =0;i<x.Length; i++)
                Console.Write(x[i] + " ");
            

        }
    }
}
