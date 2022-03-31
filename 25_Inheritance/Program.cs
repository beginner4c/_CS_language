using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25_Inheritance
{
    class ComplexNumber : Object // 원래 모든 클래스는 Object라는 클래스를 기본적으로 상속하고 있다
    {
        double x;
        double y;

        public ComplexNumber(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public double real()
        {
            return x;
        }

        public double imaginary()
        {
            return y;
        }

        public ComplexNumber add(ComplexNumber b)
        {
            return new ComplexNumber(this.x + b.x, this.y + b.y);
        }
        // static member function에는 this를 사용할 수가 없다
        public static ComplexNumber add(ComplexNumber a, ComplexNumber b)
        {
            return new ComplexNumber(a.x + b.x, a.y + b.y);
        }

        public ComplexNumber subtract(ComplexNumber b)
        {
            return new ComplexNumber(this.x - b.x, this.y - b.y);
        }
        public static ComplexNumber subtract(ComplexNumber a, ComplexNumber b)
        {
            return new ComplexNumber(a.x - b.x, a.y - b.y);
        }

        public ComplexNumber multiply(ComplexNumber b)
        {
            double realPart = this.x * b.x - this.y * b.y;
            double imaginaryPart = this.x * b.x + this.y * b.y;

            return new ComplexNumber(realPart, imaginaryPart);
        }
        public static ComplexNumber multiply(ComplexNumber a, ComplexNumber b)
        {
            double realPart = a.x * b.x - a.y * b.y;
            double imaginaryPart = a.x * b.x + a.y * b.y;

            return new ComplexNumber(realPart, imaginaryPart);
        }

        public double magnitude()
        {
            return Math.Sqrt(this.x * this.x + this.y * this.y);
        }

        public static double magnitude(ComplexNumber n)
        {
            return Math.Sqrt(n.x * n.x + n.y * n.y);
        }

        // object class의 ToString 함수를 override 한 것
        public override String ToString()
        {
            return "" + this.x + " + " + this.y + "i"; // 넘겨줄 때 String을 넘겨줘야 하기에 ""을 먼저 줘야한다
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ComplexNumber a = new ComplexNumber(-1.2, -1.5); // (-1.2) + (-1.5)i
            ComplexNumber b = new ComplexNumber(2.1, 3.2);
            ComplexNumber c;

            Console.WriteLine("magitude of a = " + a.magnitude()); // member function 으로 구현
            Console.WriteLine("magitude of a = " + ComplexNumber.magnitude(a)); // static member function 으로 구현

            c = a.add(b); // 일반 member function 사용하는 경우
            Console.WriteLine("a + b = " + c.real() + " + " + c.imaginary() + "i");
            c = ComplexNumber.add(a, b); // static member function 사용하는 경우
            Console.WriteLine("a + b = " + c.real() + " + " + c.imaginary() + "i");

            c = a.multiply(b);
            Console.WriteLine("a * b = " + c.real() + " * " + c.imaginary() + "i");
            c = ComplexNumber.multiply(a, b);
            Console.WriteLine("a * b = " + c.real() + " * " + c.imaginary() + "i");


            Console.WriteLine("==========");
            Console.WriteLine(a); // override를 하지 않는 경우 a의 클래스 이름이 출력된다
            Console.WriteLine(a.ToString()); // 위의 단순 a만 호출했을 때와 결과값이 똑같다

            Console.WriteLine(a + "," + b + "," + c); // 보통 객체의 상태값을 확인하는 데 사용한다
        }
    }
}
