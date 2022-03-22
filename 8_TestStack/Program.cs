using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// stack을 허접하게 구현

namespace _8_TestStack
{
    class Stack
    {
        static int MAX = 100; // 매크로 대신
        private int[] s; // 스택을 저장할 배열
        private int top; // 스택의 마지막 위치 지정
        private int size;

        // housekeeping function - 외부에서 사용될 일 없는 함수
        private void initalize()
        {
            for (int i = 0; i < s.Length; i++)
                s[i] = 0;
        }
        private void OverflowError()
        {
            Console.WriteLine("Stack OverFlow Error occurs");
            Environment.Exit(-1);
        }
        private void StackEmptyError()
        {
            Console.WriteLine("Stack Empty Error occurs");
            Environment.Exit(-1);
        }
        public Stack() // default constructor
            : this(MAX)
        {
        }
        public Stack(int n)
        {
            s = new int[n];
            top = -1;
            initalize();
            size = n;
        }

        public void push(int x) // 스택에 데이터를 넣는 함수
        {
            if (top >= size - 1)
                OverflowError(); // 오버 플로우 발생할 때 처리할 함수
            top++;
            s[top] = x;
        }

        public int pop() // 스택에서 데이터를 빼는 함수
        {
            if (top == -1)
                StackEmptyError();
            top--;
            return s[top+1];
        }

        public void reset() // 배열과 내용을 초기화 함수
        {
            top = -1;
            this.initalize();
        }

        public bool isEmpty() // 스택이 비어있는지 확인 함수
        {
            if (top == -1)
                return true;
            else
                return false;
        }

        public int getCount() // 스택에 남은 데이터 갯수 확인 함수
        {
            return top + 1;
        }

        public int peek() // 스택 가장 끝에 들어온 데이터 확인(pop과 다르게 삭제x) 함수
        {
            return s[top];
        }

        public void print() // 스택 내부의 모든 데이터를 출력하는 함수
        {
            Console.Write("[ ");
            for(int i = 0; i<= top; i++)
            {
                Console.Write(s[i] + " ");
            }
            Console.WriteLine("]");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Stack a = new Stack(1000);
            Stack b = new Stack(4);

            a.push(10);
            a.push(20);

            int x = a.pop();

            a.push(30);
            a.push(40);

            b.push(100);
            b.push(200);
            b.push(300);
            b.push(400);
            // b.push(500);

            int y = b.pop();

            Console.WriteLine("top of a = {0}, top of b = {1}", a.peek(), b.peek());
            Console.WriteLine("x = {0}, y = {1}", x, y);

            b.reset(); // b.clear();
            b.push(10);

            if (b.isEmpty())
                Console.WriteLine("empty");
            else
                Console.WriteLine("not empty");

            Console.WriteLine("count of a = {0}, count of b = {1}", a.getCount(), b.getCount());

            a.print();
            b.print();
        }
    }
}
