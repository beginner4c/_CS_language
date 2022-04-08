using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections; // Queue와 IEnumerator가 포함된 라이브러리

// Queue를 사용해봄

namespace _44_Collection_Queue
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
            Queue list = new Queue();
            list.Enqueue(new Student("kim", 99, 'A')); // Enqueue로 입력
            list.Enqueue(new Student("park", 20, 'F'));
            list.Enqueue(new Student("lee", 70, 'C'));
            list.Enqueue(new Student("kwon", 80, 'B'));
            list.Enqueue(new Student("ban", 90, 'A'));

            Student st = (Student)list.Dequeue(); // Dequeue의 경우 return type이 object이기에 type casting이 필요하다
            st = (Student)list.Dequeue();

            Console.WriteLine(st.ToString());

            // foreach문으로 Queue의 traverse 방법
            foreach (Student s in list)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine("===");

            // data를 하나하나 access 하는 Queue traverse 방법
            IEnumerator e = list.GetEnumerator();

            while (e.MoveNext())
            {
                Console.WriteLine(e.Current);
            }
        }
    }
}
