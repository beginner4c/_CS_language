using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 복소수를 통해 일반 member function의 사용법, static member function의 사용법에 대한 차이점을 봤다
// 일반 member function 으로 프로그래밍 하는게 object oriented 스타일의 프로그래밍이다
// static member function은 어지간하면 하지 않도록 하자

namespace _24_ComplexNumberTest
{
    class ComplexNumber
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
    }
    class Program
    {
        static void Main(string[] args)
        {
            ComplexNumber a = new ComplexNumber(1.2, 1.5);
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

        }
    }
}
