using System;
using System.Collections.Generic; // LinkedList<T> 가 여기 들어있다
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections; // IEnumerator도 여기 포함

// LinkedList 사용 방법
// 배열의 문제점인 insert/remove 시에 시간 낭비를 줄인 collection 객체
// 양방향 traverse가 가능한 double linked list이다

namespace _43_Collection_LinkedList
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
            LinkedList<Student> list = new LinkedList<Student>();

            list.AddLast(new Student("kim", 99, 'A'));
            list.AddLast(new Student("park", 10, 'F'));
            list.AddLast(new Student("lee", 70, 'C'));
            list.AddLast(new Student("kwon", 80, 'B'));
            list.AddLast(new Student("ban", 90, 'A'));

            // foreach문으로 LinkedList의 traverse 방법
            foreach (Student s in list)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine("===");

            // data를 하나하나 access 하는 LinkedList traverse 방법
            IEnumerator e = list.GetEnumerator();

            while (e.MoveNext())
            {
                Console.WriteLine(e.Current);
            }
        }
    }
}
