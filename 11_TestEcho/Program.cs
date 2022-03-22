using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// ReadLine을 사용해보는 내용

namespace _11_TestEcho
{
    class Program
    {
        static void Main(string[] args)
        {
            String buffer;

            Console.WriteLine("Am empty line stops this program");
            Console.WriteLine("Type characters and <Enter> key : ");
            while (true)
            {
                buffer = Console.ReadLine(); // 문자열을 입력받음
                if (buffer.Length == 0) // 빈 문자열이 입력되면 종료
                    break;
                Console.WriteLine(buffer);
            }
            Console.WriteLine("BYE");

            // 잘 사용하지 않지만 이렇게도 사용이 가능하다

            char c;
            int i;
            double f;
            String s;

            Console.WriteLine("type a char, an integer, a floating number and a string : ");

            buffer = String.Empty; // 문자열의 내용을 초기화

            buffer = Console.ReadLine(); // 입력된 문자열을 buffer에 저장

            // c의 scanf 대신에 써먹는 방법
            char[] separators = new char[1];
            separators[0] = ' '; // 공백 저장
            String[] st = buffer.Split(separators); // buffer의 내용을 공백을 기준으로 쪼개서 배열로 저장

            for (int x = 0; x < st.Length; x++)
                Console.WriteLine(st[x]); // 저장된 배열을 각자 출력

            // 배열에 저장된 문자열들을 자료형에 맞게 따로 저장
            String tmp;
            tmp = st[0];
            c = tmp.ElementAt(0);

            tmp = st[1];
            i = int.Parse(tmp); // Parse는 atoi("123")과 같은 일을 한다

            tmp = st[2];
            f = double.Parse(tmp); // atof("12.34")와 같은 역할

            s = st[3];
        }
    }
}
