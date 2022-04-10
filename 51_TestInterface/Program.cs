using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Interface를 사용
// 이 프로그램에서는 인터페이스를 상속한 클래스를 통해 스택에 다양한 클래스를 인스턴스한 객체들을 집어넣는다
// 동적 바인딩의 구현
// 이렇게 만들어졌을 때 스택에 새로운 구조의 클래스를 집어넣고 싶으면 스택의 구조를 바꿀 필요가 없다
// 단지 새로운 구조의 클래스에 상속만 더하면 된다
// 인터페이스를 잘 사용한다면 보수 유지가 쉬워질 수 있다

namespace _51_TestInterface
{
    // 인터페이스는 데이터 멤버와 함수의 내용(function body)이 없는 특수한 클래스이다
    // 특이한 점은 인터페이스의 함수는 무조건 재정의를 해야한다
    interface StackItem
    {
        StackItem getNextItem(); // 내용이 없다
        void setNextItem(StackItem item); // 선언만 하고 내용이 없다
    }

    class Stack
    {
        // 데이터 멤버
        StackItem top;

        public Stack() // 생성자
        {
            top = null;
        }

        public void push(StackItem item)
        {
            if (top == null) top = item;
            else
            {
                // 스택 구조에 맞게 탑을 마지막 item으로 기존의 것은 계속 다음으로 미룬다
                item.setNextItem(top);
                top = item;
            }
        }
        public StackItem pop()
        {
            if (top == null)
            {
                Console.WriteLine("stack is empty");
                Environment.Exit(-1);
            }
            StackItem topItem = top;
            top = top.getNextItem();
            return topItem;
        }
        public void printAll() // 출력 함수
        {
            Console.Write("This stack has : ");
            StackItem item = top;
            while (item != null)
            {
                // 각 클래스들마다 ToString 함수가 재정의 되어 있기 때문에 원하는 출력이 가능하다
                Console.Write(item + " ");
                item = item.getNextItem();
            }
            Console.WriteLine();
        }
    }

    // 인터페이스를 상속하는 클래스
    class DefaultStackItem : StackItem
    {
        // 데이터 멤버
        protected StackItem next;

        // 인터페이스에 정의된 함수를 재정의한다
        public StackItem getNextItem()
        {
            return next;
        }
        // 인터페이스 함수 재정의
        public void setNextItem(StackItem item)
        {
            next = item;
        }
    }

    // 인터페이스를 상속한 클래스를 다시 상속한 클래스
    // 정수형 자료
    class IntItem : DefaultStackItem
    {
        // 데이터 멤버
        int i;
        public IntItem(int i)
        {
            this.i = i;
            next = null; // DefaultStackItem에 정의되어 있다
        }
        public override String ToString()
        {
            return i + "";
        }
    }

    // 인터페이스를 상속한 클래스를 다시 상속한 클래스
    // 문자열 자료
    class StringItem : DefaultStackItem
    {
        String s;
        public StringItem(String s)
        {
            this.s = s;
            next = null; // DefaultStackItem에 정의되어 있다
        }
        public override String ToString()
        {
            return s;
        }
    }

    // 인터페이스를 상속한 클래스를 다시 상속한 클래스
    // 복소수 자료
    class ComplexNumberItem : DefaultStackItem
    {
        double real;
        double imaginary;
        public ComplexNumberItem(double r, double i)
        {
            real = r;
            imaginary = i;
            next = null; // DefaultStackItem에 정의되어 있다
        }
        public override String ToString()
        {
            return real + "+" + imaginary + "i";
        }
    }

    // 스택에 넣을 새로운 클래스를 나중에 정의했다
    class PointItem : DefaultStackItem
    {
        public PointItem(int x, int y) // 생성자
        {
            this.x = x;
            this.y = y;
        }

        // 데이터 멤버
        int x, y;

        public override string ToString()
        {
            return "(" + x + ", " + y + ")";
        }
    }

    class StackTest
    {
        static void Main(string[] args)
        {
            // 스택에 다양한 객체들을 집어넣는다
            // 스택에 들어가는 클래스들이 인터페이스 클래스인 StackItem을 DefaultStackItem 클래스를 통해 상속받았기에 가능하다
            Stack aStack = new Stack();
            aStack.push(new IntItem(10));
            aStack.push(new StringItem("kim"));
            aStack.push(new ComplexNumberItem(1.5, 5.9));
            aStack.push(new PointItem(2, 3)); // 해당 PointItem 클래스는 다른 클래스들이 완성되어 구현된 후에 만들어졌다
            aStack.push(new ComplexNumberItem(2.4, 7.1));
            aStack.push(new StringItem("lee"));
            aStack.push(new IntItem(9));
            aStack.push(new PointItem(2, 3));
            Console.WriteLine("Item removed : " + aStack.pop());
            Console.WriteLine("Item removed : " + aStack.pop());
            Console.WriteLine("Item removed : " + aStack.pop());
            aStack.printAll();
        }
    }
}
