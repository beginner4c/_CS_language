using System;
using System.Collections.Generic; // Stack의 generic 클래스 존재, 사용 권고
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections; // Stack과 IEnumerator

// collection 객체 중 stack을 사용

namespace _45_Collection_Stack
{
    class Program
    {
        class Student
        {
            public Student(String name, int total, char grade)
            {
                this.name = name;
                this.total = total;
                this.grade = grade;
            }

            String name;
            int total;
            char grade;

            public override string ToString()
            {
                return "[" + name + ", Total : " + total + ", grade : " + grade + "]";
            }
        }
        static void Main(string[] args)
        {
            Stack<Student> list = new Stack<Student>();

            list.Push(new Student("kim", 99, 'A'));
            list.Push(new Student("park", 10, 'F'));
            list.Push(new Student("lee", 70, 'C'));
            list.Push(new Student("kwon", 80, 'B'));
            list.Push(new Student("ban", 90, 'A'));

            Student st = (Student)list.Pop();
            st = list.Pop();

            // foreach문으로 Stack의 traverse 방법
            foreach (Student s in list)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine("===");

            // data를 하나하나 access 하는 Stack traverse 방법
            IEnumerator e = list.GetEnumerator();

            while (e.MoveNext())
            {
                Console.WriteLine(e.Current);
            }
        }
    }
}
