using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Object 클래스 내부의 함수들을 사용해봄
// ToString의 경우 override를 통해 주로 사용한다
// ReferenceEquals는 주어진 parameter들의 주소값을 비교한다
// MemberwiseClone은 멤버값은 같지만 주소값들이 다른 걸 복사한다 (단, access modifier가 protected이기 때문에 상속받은 클래스 내부에서만 사용 가능하다)
// GetType 함수는 type을 확인할 때 사용한다
// Equals 함수는 기본적으로 reference를 비교할 때 사용하는 함수지만 override해서 사용을 많이 한다

namespace _27_object
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
            return "hello";
        }

        // MemberwiseClone 함수는 내부 멤버값이 같지만 주소값이 다른 reference를 만들 때 사용한다
        // MemberwiseClone 함수의 경우 이런 식으로 상속받은 클래스 내부에서만 사용이 가능하다
        public ComplexNumber Clone()
        {
            return (ComplexNumber)this.MemberwiseClone();
        }
        // GetHashCode 함수는 hash table 크기를 맞추기 위해 override를 많이 한다
        public override int GetHashCode()
        {
            return base.GetHashCode() % 100; // 여기 숫자 100 이 테이블 크기 예시를 대신한다
        }

        public override bool Equals(Object obj) // 범용적으로 사용하기에 Object로 받는다
        {
            // 기본적으로 Object로 들어온 formal parameter 값을 type casting을 해주어야 한다
            ComplexNumber data = (ComplexNumber)obj; // type casting! 

            if (this.x == data.x && this.y == data.y) // 내부 data member를 확인하는 함수로 탈바꿈
                return true;
            else
                return false;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ComplexNumber a = new ComplexNumber(1.2, 1.5);
            ComplexNumber b = new ComplexNumber(2.1, 3.2);
            ComplexNumber c;
            ComplexNumber d = new ComplexNumber(2.1, 3.2);
            ComplexNumber e = a; // a의 주소값을 그대로 가져간다

            // MemberwiseClone은 protected 라는 Access Modifier를 가지고 있기에 직접 사용이 불가능하다
            // ComplexNumber f = (ComplexNumber)a.MemberwiseClone(); // 이런 방식은 불가능하다
            ComplexNumber f = e.Clone(); // 이런 식으로 함수를 통해 멤버값들이 같지만 주소값이 다른 reference를 생성하는 것이다

            Console.WriteLine(f);

            Console.WriteLine(a.GetType()); // RTTI Run Time Type Identification
            Console.WriteLine(b.GetType()); // 이 함수를 통해 type 확인 가능

            Console.WriteLine(a.GetHashCode()); // hash code 값을 출력해준다
            Console.WriteLine(b.GetHashCode()); // hash table의 크기를 맞춰줘야 해서 override 후 사용하는 게 일반적

            // ReferenceEquals 함수는 override 없이 사용하는 게 일반적
            // 같은 값이라도 주소값은 다르다
            if (Object.ReferenceEquals(b, d)) // reference 주소를 비교하는 함수
                Console.WriteLine("equal");
            else
                Console.WriteLine("not equal");

            // 저렇게 e = a 형식으로 만들어지면 주소값이 같아진다
            if (Object.ReferenceEquals(a, e)) // reference 주소를 비교하는 함수
                Console.WriteLine("equal");
            else
                Console.WriteLine("not equal");

            // 이렇게 c와 f는 멤버값들이 똑같지만 주소값은 다른 것을 확인할 수 있다
            if (Object.ReferenceEquals(e, f)) // reference 주소를 비교하는 함수
                Console.WriteLine("equal");
            else
                Console.WriteLine("not equal");

            // static member function으로 구현된 Equals 함수는 instance가 같은지 비교해준다
            // 기본적으로 reference만 비교하기 때문에 override를 많이 한다
            if (Equals(b, d))
                Console.WriteLine("equal");
            else
                Console.WriteLine("not equal"); // 멤버값들이 같아도 instance는 다르다

            // 일반적으로 Equals(a, b) 형태보다 많이 사용한다
            if (b.Equals(d))
                Console.WriteLine("equal");
            else
                Console.WriteLine("note equal");
            
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
            Console.WriteLine(a); // 이런 경우 클래스가 출력된다
            Console.WriteLine(a.ToString()); // 위의 단순 a만 호출했을 때와 결과값이 똑같다
        }
    }
}
