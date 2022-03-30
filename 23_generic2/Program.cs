using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 라이브러리에 구현된 generic Stack class 사용

namespace _23_generic2
{
    class Program
    {
        static void Main(string[] args)
        {
            // 이렇게 따로 클래스 선언할 필요도 없이 System.Collections.Generic 라이브러리에 있는
            // generic Stack class를 불러오면 보기에도 사용하기에도 깔끔하다
            Stack<int> x = new Stack<int>();
            x.Push(10);
            x.Push(20);
            x.Pop();
            x.Push(30);
            x.Push(40);

            Stack<double> y = new Stack<double>();
            y.Push(10.1);
            y.Push(20.8);
            y.Push(30.7);
            y.Push(40.2);
            y.Pop();

            Stack<String> c = new Stack<String>();
            c.Push("박");
            c.Push("신");
            c.Pop();
            c.Push("올");
            c.Push("민");
            c.Push("부");
            
            Console.WriteLine("\ntop of stack x = " + x.Peek());
            Console.WriteLine("top of stack y = " + y.Peek());
            Console.WriteLine("top of stack y = " + c.Peek());

        }
    }
}
