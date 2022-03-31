using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 클래스에 기본적으로 상속된 ToString을 override해서 사용

namespace _26_Inheritance
{
    class Stack<Type> // generic stack class
    {
        static int MAX = 100;
        protected Type[] _s;
        protected int _top;
        protected int _size;
        private void initialize()
        {
            for (int i = 0; i < _size; i++)
            {
                _s[i] = default(Type);
            }
        }
        private void overflowError()
        {
            Console.WriteLine("Stack Overflow Error");
            Environment.Exit(-1);
        }
        private void emptyError()
        {
            Console.WriteLine("Stack Empty Error");
            Environment.Exit(-1);
        }
        public Stack() :
            this(MAX)
        {
        }
        public Stack(int n)
        {
            _s = new Type[n];
            _size = n;
            _top = -1;
            initialize();
        }
        public void push(Type item)
        {
            if (_top >= _size - 1) overflowError();
            _top++;
            _s[_top] = item;
        }
        public Type pop()
        {
            if (_top == -1) emptyError();
            Type value = _s[_top];
            _top--;
            return (value);
        }
        public Type peek()
        {
            if (_top == -1) emptyError();
            return (_s[_top]);
        }
        public void reset()
        {
            _top = -1;
            initialize();
        }
        public bool isEmpty()
        {
            if (_top == -1) return true;
            else return false;
        }

        public override String ToString() // override를 통해서 내부 배열에 들어있는 내용을 출력하게 바뀌었다
        {
            String s = "[";

            for (int i = 0; i <= _top; i++)
            {
                if (i == _top)
                    s = s + _s[i];
                else
                    s = s + _s[i] + ", ";
            }
            s = s + "]";

            return s;
        }
    }
    class TestStack
    {
        static void Main(string[] args)
        {
            Stack<int> a = new Stack<int>(10);
            Stack<int> b = new Stack<int>(20);
            Stack<double> c = new Stack<double>(10);
            Stack<String> d = new Stack<String>(10);
            a.push(1);
            a.push(2);
            a.push(3);
            a.push(4);

            b.push(30);
            b.push(20);
            b.push(10);
            b.push(0);

            c.push(1.3);
            c.push(2.4);
            c.push(3.4);

            d.push("kim");
            d.push("lee");
            d.push("park");
            d.push("권");

            Console.WriteLine(a.pop());
            Console.WriteLine(a.pop());
            Console.WriteLine(b.pop());
            Console.WriteLine(b.pop());
            Console.WriteLine(c.pop());
            Console.WriteLine(c.peek());
            Console.WriteLine(d.peek());
            Console.WriteLine(d.pop());

            Console.WriteLine(a.ToString()); // ToString() 함수를 override하지 않으면 class 이름에 자료형이 표현된다
            Console.WriteLine(b);
            Console.WriteLine(c);
            Console.WriteLine(d);

            String x = "a = " + a; // 이런 식으로도 ToString 함수를 사용 가능하다
            Console.WriteLine(x);
        }
    }
}
