using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9_TestString
{
    class Program
    {
        static void Main(string[] args)
        {
            // String 생성
            String a = "Hello";
            String b = new String('x', 5); // x가 5개 들어간 String 객체 만들기
            String c = "world";
            String d = b;
            String e = String.Empty; // Empty가 ""와 같이 빈 문자열을 뜻한다

            String f = String.Format("f = {0} and {1}", a, c); // Format문 뒤의 내용을 저장
            Console.WriteLine("f = " + f);

            String p = (String)a.Clone(); // Clone의 return type이 object이기에 casting 해주어야 한다
            Console.WriteLine("p = " + p);

            int m = c.IndexOf("l"); // c String에서 l이 몇 번째에 있는지 값을 반환
            Console.WriteLine("m = " + m);

            if (a.CompareTo(b) > 0) // CompareTo의 반환값은 int 값이다
            {
                Console.WriteLine(a + " > " + b);
            }
            else if (a.CompareTo(b) < 0)
            {
                Console.WriteLine(a + " < " + b);
            }
            else
            {
                Console.WriteLine(a + " = " + b);
            }

            if (a.Equals(b)) // Equals 는 같으면 true를 다르면 false를 반환
                Console.WriteLine("a and b same");
            else
                Console.WriteLine("a and b different");

            char x = a[1]; // c언어의 문자열처럼 Hello 중 e를 가져온다
            // a[1] = 'x'; // 이와 같은 방식은 read-only 특성 때문에 불가능하다

            a = a.Replace('e', 'o'); // read-only 특성이 있기에 hello를 고친 게 아닌 새로운 hollo를 참조하는 것
            Console.WriteLine(a);

            b = a = "Hi, good day "; // a와 b가 같은 곳을 가르킨다
            c = a + b;
            d = d + " How are you?";

            // 이럴 때 garbage 발생이 많지만 알아서 처리 됨 ㅅㄱ 

            Console.WriteLine("a = " + a);
            Console.WriteLine("b = " + b);
            Console.WriteLine("c = " + c);
            Console.WriteLine("d = " + d);
            Console.WriteLine("e = " + e);
            Console.WriteLine("x = " + x);

            Console.WriteLine(a.Length); // a의 길이를 출력
            
        }
    }
}
