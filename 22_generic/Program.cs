using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// generic class에 대해서 간단하게 파악

namespace _22_generic
{
    class Stack<T> // generic class의 선언 방법 - 지정되지 않은 type을 <> 내부에 지정해준다
    {
        // Attributes
        static int MAX = 100;
        /** an array to save stack contents 
         */
        private T[] _s; // 이런 방식으로 T는 자료형처럼 취급한다
        /** the index to point top of stack
         */
        private int _top;
        /** size of the stack
         */
        private int _size;
        // Operations
        /** initialization procedure for new stack
         */
        private void initialize()
        {
            // NOTE: We don't have to do this initialization with Java
            for (int i = 0; i < _size; i++)
            {
                _s[i] = default(T); // 명시된 type의 기본값을 세팅해주는 함수 default
            }
        }
        /** this function is called for stack overflow exception
         */
        private void overflowError()
        {
            Console.WriteLine("Stack overflow error occurs.");
            Environment.Exit(-1);
        }
        /** this function is called for stack empty exception
         */
        private void emptyError()
        {
            Console.WriteLine("Stack empty error occurs.");
            Environment.Exit(-1);
        }
        /** the constructor for stack object
         */
        public Stack()
            : this(MAX)
        {
        }
        /** the constructor for stack object
         */
        public Stack(int n)
        {
            if (n > MAX)
            {
                Console.WriteLine("Stack size must be less than " + MAX + ".");
                Environment.Exit(-1);
            }
            _s = new T[MAX];
            _size = n;
            _top = -1;
            initialize();
        }
        /**	the function to insert new item on stack
         */
        public void push(T item)
        {
            if (_top >= _size - 1) overflowError();
            _top++;
            _s[_top] = item;
        }
        /** the function to delete an item at the top position of the stack
         */
        public T pop()
        {
            if (_top == -1) emptyError();
            T value = _s[_top];
            _top--;
            return (value);
        }
        /** the function to get the top element of the stack
         */
        public T peek()
        {
            if (_top == -1) emptyError();
            return (_s[_top]);
        }
        /** the fuction to clear an exisiting stack
         */
        public void reset()
        {
            _top = -1;
            initialize();
        }
    }

    class IntStack
    {
        // Attributes
        static int MAX = 100;
        /** an array to save stack contents 
         */
        private int[] _s;
        /** the index to point top of stack
         */
        private int _top;
        /** size of the stack
         */
        private int _size;
        // Operations
        /** initialization procedure for new stack
         */
        private void initialize()
        {
            // NOTE: We don't have to do this initialization with Java
            for (int i = 0; i < _size; i++)
            {
                _s[i] = 0;
            }
        }
        /** this function is called for stack overflow exception
         */
        private void overflowError()
        {
            Console.WriteLine("Stack overflow error occurs.");
            Environment.Exit(-1);
        }
        /** this function is called for stack empty exception
         */
        private void emptyError()
        {
            Console.WriteLine("Stack empty error occurs.");
            Environment.Exit(-1);
        }
        /** the constructor for stack object
         */
        public IntStack()
            : this(MAX)
        {
        }
        /** the constructor for stack object
         */
        public IntStack(int n)
        {
            if (n > MAX)
            {
                Console.WriteLine("Stack size must be less than " + MAX + ".");
                Environment.Exit(-1);
            }
            _s = new int[MAX];
            _size = n;
            _top = -1;
            initialize();
        }
        /**	the function to insert new item on stack
         */
        public void push(int item)
        {
            if (_top >= _size - 1) overflowError();
            _top++;
            _s[_top] = item;
        }
        /** the function to delete an item at the top position of the stack
         */
        public int pop()
        {
            if (_top == -1) emptyError();
            int value = _s[_top];
            _top--;
            return (value);
        }
        /** the function to get the top element of the stack
         */
        public int peek()
        {
            if (_top == -1) emptyError();
            return (_s[_top]);
        }
        /** the fuction to clear an exisiting stack
         */
        public void reset()
        {
            _top = -1;
            initialize();
        }
    }

    class DoubleStack
    {
        // Attributes
        static int MAX = 100;
        /** an array to save stack contents 
         */
        private double[] _s;
        /** the index to point top of stack
         */
        private int _top;
        /** size of the stack
         */
        private int _size;
        // Operations
        /** initialization procedure for new stack
         */
        private void initialize()
        {
            // NOTE: We don't have to do this initialization with Java
            for (int i = 0; i < _size; i++)
            {
                _s[i] = 0;
            }
        }
        /** this function is called for stack overflow exception
         */
        private void overflowError()
        {
            Console.WriteLine("Stack overflow error occurs.");
            Environment.Exit(-1);
        }
        /** this function is called for stack empty exception
         */
        private void emptyError()
        {
            Console.WriteLine("Stack empty error occurs.");
            Environment.Exit(-1);
        }
        /** the constructor for stack object
         */
        public DoubleStack()
            : this(MAX)
        {
        }
        /** the constructor for stack object
         */
        public DoubleStack(int n)
        {
            if (n > MAX)
            {
                Console.WriteLine("Stack size must be less than " + MAX + ".");
                Environment.Exit(-1);
            }
            _s = new double[MAX];
            _size = n;
            _top = -1;
            initialize();
        }
        /**	the function to insert new item on stack
         */
        public void push(double item)
        {
            if (_top >= _size - 1) overflowError();
            _top++;
            _s[_top] = item;
        }
        /** the function to delete an item at the top position of the stack
         */
        public double pop()
        {
            if (_top == -1) emptyError();
            double value = _s[_top];
            _top--;
            return (value);
        }
        /** the function to get the top element of the stack
         */
        public double peek()
        {
            if (_top == -1) emptyError();
            return (_s[_top]);
        }
        /** the fuction to clear an exisiting stack
         */
        public void reset()
        {
            _top = -1;
            initialize();
        }
    }

    class StringStack
    {
        // Attributes
        static int MAX = 100;
        /** an array to save stack contents 
         */
        private String[] _s;
        /** the index to point top of stack
         */
        private int _top;
        /** size of the stack
         */
        private int _size;
        // Operations
        /** initialization procedure for new stack
         */
        private void initialize()
        {
            // NOTE: We don't have to do this initialization with Java
            for (int i = 0; i < _size; i++)
            {
                _s[i] = "";
            }
        }
        /** this function is called for stack overflow exception
         */
        private void overflowError()
        {
            Console.WriteLine("Stack overflow error occurs.");
            Environment.Exit(-1);
        }
        /** this function is called for stack empty exception
         */
        private void emptyError()
        {
            Console.WriteLine("Stack empty error occurs.");
            Environment.Exit(-1);
        }
        /** the constructor for stack object
         */
        public StringStack()
            : this(MAX)
        {
        }
        /** the constructor for stack object
         */
        public StringStack(int n)
        {
            if (n > MAX)
            {
                Console.WriteLine("Stack size must be less than " + MAX + ".");
                Environment.Exit(-1);
            }
            _s = new String[MAX];
            _size = n;
            _top = -1;
            initialize();
        }
        /**	the function to insert new item on stack
         */
        public void push(String item)
        {
            if (_top >= _size - 1) overflowError();
            _top++;
            _s[_top] = item;
        }
        /** the function to delete an item at the top position of the stack
         */
        public String pop()
        {
            if (_top == -1) emptyError();
            String value = _s[_top];
            _top--;
            return (value);
        }
        /** the function to get the top element of the stack
         */
        public String peek()
        {
            if (_top == -1) emptyError();
            return (_s[_top]);
        }
        /** the fuction to clear an exisiting stack
         */
        public void reset()
        {
            _top = -1;
            initialize();
        }
    }
    class TestStack
    {
        static void Main(string[] args)
        {
            // 아래처럼 class의 기능이 같을 때 받는 자료형이 다른 경우에 generic class로 같이 처리할 수 있다
            // generic class 사용으로 인해 코드의 길이가 짧아지고 read ability가 좋아진다
            IntStack a = new IntStack();
            a.push(10);
            a.push(20);
            a.pop();
            a.push(30);
            a.push(40);

            DoubleStack b = new DoubleStack();
            b.push(10.1);
            b.push(20.8);
            b.push(30.7);
            b.push(40.2);
            b.pop();

            StringStack c = new StringStack();
            c.push("박");
            c.push("신");
            b.pop();
            c.push("올");
            c.push("민");
            c.push("부");

            Console.WriteLine("top of stack a = " + a.peek());
            Console.WriteLine("top of stack b = " + b.peek());
            Console.WriteLine("top of stack c = " + c.peek());

            // 아래처럼 generic class를 사용할 경우 class를 여러개 만들지 않아도 처리가 가능하다
            // 물론 generic class를 만들어 줄 필요 없이 구현된 library를 가져오는 게 정상이다
            Stack<int> x = new Stack<int>();
            x.push(10);
            x.push(20);
            x.pop();
            x.push(30);
            x.push(40);

            Stack<double> y = new Stack<double>();
            y.push(10.1);
            y.push(20.8);
            y.push(30.7);
            y.push(40.2);
            y.pop();

            Console.WriteLine("\ntop of stack x = " + x.peek());
            Console.WriteLine("top of stack y = " + y.peek());
        }
    }
}
