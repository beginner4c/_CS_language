using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// #define MAX (100) 이와 같은 매크로는 더 이상 불가능
// define 자체가 불가능

namespace _3_BasicTypes
{
    class Program
    {
        // #define 자체가 불가능
        static int MAX = 100; // 이게 매크로의 대용품으로 사용
        static void Main(string[] args)
        {
            decimal x; // 16 byte의 실수형이라 굉장히 긴 소숫점 아래 유효 숫자를 표현해준다
            x = 12.74648948874621444M; //(decimal을 사용할 땐 마지막 자리에 M 넣어줘야 한다
            bool b;
            b = true;

            Console.WriteLine(sizeof(int)); // 4 byte
            Console.WriteLine(sizeof(decimal)); // 16 byte
            Console.WriteLine(sizeof(bool)); // 1 byte

            Console.WriteLine(x);
            Console.WriteLine(b);

            int i = 100;

            // if 문의 조건에 boolean type이 들어가야 한다
            if (i == 10) // C의 경우 i = 10을 하는 경우 syntax error가 발생한다
                         // C# 의 경우 i = 10이 syntax error 발생!
            {
                Console.WriteLine("same");
            }
            else
            {
                Console.WriteLine("not same");
            }

            int 한글변수; // 한글 변수와 함수 이름이 선언 가능
            한글변수 = 100; // 사용하지 말자
            Console.WriteLine(한글변수);

            int a = 10;

            if (a is double) // is 문으로 type 확인이 가능
            {
                Console.WriteLine("a는 실수형");
            }
            else
            {
                Console.WriteLine("a는 실수형이 아님");
            }

            Console.WriteLine("a = " + a + "\n한글변수 = " + 한글변수); // 이런 식으로 사용 가능
            Console.WriteLine("a = {0}\n한글변수 = {1}", a, 한글변수); // c의 format 문의 대신 사용!

            int[] arr = { 100, 200, 500, 400, 300 };

            foreach (int y in arr) // C#에 들어오면서 새로 생긴 statement
            {
                Console.WriteLine(y + " foreach를 이용한 배열 출력");
            }
        }
    }
}
