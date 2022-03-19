using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// C#이나 JAVA에서는 한 번 사용한 함수 이름을 TYPE 지정을 달리해 다시 사용이 가능하다
// 이를 function overlading이라고 한다
// 이름은 같을 수 있으나 argument나 type, class 등이 꼭 달라야 한다

namespace seoul
{
    class dongrae
    {
        // visibility(가시성) : public, private 같은 제도
        public static string whereAreYou()
        {
            return "4학년이 다시 배우는 C# 개념";
        }

    }
}

namespace _2_add_namespace
{
    class dongrae
    {
        // visibility(가시성) : public, private 같은 제도
        public static string whereAreYou()
        {
            return "4학년이 다시 배우는 C# 개념";
        }
        public static int add(int x, int y)
        {
            return 100 + x + y;
        }
    }
    class Program
    {
        static int add(int x, int y)
        {
            return x + y;
        }

        static int add(int x, int y, int z)
        {
            return x + y + z;
        }

        static double add(double x, double y)
        {
            return x + y;
        }

        static string whereAreYou()
        {
            return "4학년이 다시 배우는 C# 개념";
        }
        static void Main(string[] args)
        {
            int ans, ans3, ans4;
            double ans2;
            
            // 같은 함수명이지만 parameter가 다르고 argument가 다르기에 사용 가능
            ans = Program.add(1, 10);
            // ans = add(1, 10); 같은 class 내에 있기 때문에 Program 생략 가능
            Console.WriteLine(ans);

            ans2 = Program.add(5.5, 4.25);
            Console.WriteLine(ans2);

            ans3 = add(10, 20, 30); // 같은 class에 함수가 있기에 class를 생략해도 아무 이상 없이 실행된다
            Console.WriteLine(ans3);

            ans4 = dongrae.add(1, 10); // dongrae class 내부의 add 함수를 가지고 왔기에 결과가 다르다
            Console.WriteLine(ans4);

            Console.WriteLine(Program.whereAreYou());
            // Console.WriteLine(_2_add_namespace.Program.whereAreYou());와 같다
            Console.WriteLine(dongrae.whereAreYou()); // 같은 함수명이지만 class 가 다르므로 사용이 가능
            Console.WriteLine(seoul.dongrae.whereAreYou()); // class 명마저 같지만 namespace가 다르므로 사용이 가능
        }
    }
}
