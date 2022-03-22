using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// String과 StringBuilder의 가장 큰 차이는 read-only의 차이
// StringBuilder는 쓰기가 가능하다

namespace _10_TestStringBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder b = new StringBuilder("hello");

            Console.WriteLine(b);
            Console.WriteLine(b.Length);
            b[2] = 'o'; // String 객체와 다르게 이런 방식의 수정이 가능하다
            Console.WriteLine(b);

            // String 객체와 StringBuilder의 차이(내용을 수정할 때)
            // StringBuilder는 문자열을 수정할 때 garbage 발생이 없고 속도가 빠르다
            // JAVA에서는 stringbuffer로 구현되어 있다

            // String의 경우
            String s = "hello";
            long start = DateTime.Now.Ticks; // 시작 시간 저장

            for (int i = 0; i < 20000; i++) // garbage가 계속 생성되면서 hello가 뒤에 붙음
                s = s + "hello";

            for (int i = 0; i < 11; i++)
                if (i % 2 == 0) // 역시 반복적으로 garbage가 생성됨
                    s = s.Replace('o', 'a'); 
                else
                    s = s.Replace('a', 'o');

            Console.WriteLine(s.Length); // 이 작업이 끝난 후에 s의 길이 출력
            s = s.Remove(20, s.Length - 20); // 문자열의 20번 째 자리부터 문자열 길이보다 20 작은 길이만큼 삭제
            // 간단하게 문자열 20개만 남기고 삭제

            long end = DateTime.Now.Ticks; // 끝 시간 저장
            Console.WriteLine("s : {0}, delay time : {1}", s, end - start); // 문자열 출력, 시간 측정


            // StringBuilder의 경우
            StringBuilder sb = new StringBuilder("hello");
            start = DateTime.Now.Ticks; // 시작 시간 저장

            for (int i = 0; i < 20000; i++) 
                sb.Append("hello"); // hello 문자열을 더해준다

            for (int i = 0; i < 11; i++)
                if (i % 2 == 0) // 역시 반복적으로 garbage가 생성됨
                    sb = sb.Replace('o', 'a');
                else
                    sb = sb.Replace('a', 'o');

            sb = sb.Remove(20, sb.Length - 20);
            end = DateTime.Now.Ticks; // 끝 시간 저장

            Console.WriteLine("sb : {0}, delay time : {1}", sb, end - start); // 문자열 출력, 시간 측정
        }
    }
}
