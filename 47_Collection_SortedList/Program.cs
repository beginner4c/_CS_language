using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections; // SortedList와 IEnumerator가 있는 라이브러리

// SortedList의 사용법
// 이전의 Hashtable과 사용법이 다르지 않기에 이름만 바꾸어도 syntax error가 발생하지 않는다
// Hashtable과 SortedList의 사용 시 차이점은 Hashtable은 데이터가 적을 때, SortedList는 데이터가 많을 때 사용한다

namespace _47_Collection_SortedList
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
                return "[" + name + ", Total : " + total + ", Grade : " + grade + "]";
            }

            public char getGrade()
            {
                return grade;
            }
        }
        static void Main(string[] args)
        {
            SortedList list = new SortedList();

            // SortedList의 특징은 Add 시 key 값을 기준으로 자동 정렬을 실행한다는 점이다
            list.Add("kim", new Student("kim", 99, 'A'));
            list.Add("park", new Student("park", 10, 'F'));
            list.Add("lee", new Student("lee", 70, 'C'));
            list.Add("kwon", new Student("kwon", 80, 'B'));
            list.Add("ban", new Student("ban", 90, 'A'));

            // foreach문으로 SortedList의 traverse 방법
            // 다른 collection 객체와 다르게 DictionaryEntry 형식을 취해줘야 한다
            foreach (DictionaryEntry s in list)
            {
                Console.WriteLine(s.Key + " : " + s.Value); // key와 value 값으로 나누어 진다
            }

            Console.WriteLine("===");

            // data를 하나하나 access 하는 SortedList traverse 방법
            IEnumerator e = list.GetEnumerator();

            while (e.MoveNext())
            {
                DictionaryEntry s = (DictionaryEntry)e.Current; // 이렇게 따로 처리해준다
                Console.WriteLine(s.Key + " : " + s.Value);
            }

            // SortedList의 indexer 사용법
            Console.WriteLine(list["kwon"]); // key를 이용해 찾고 싶을 때, kwon의 key 값을 가지고 ToString 출력
            Student st = (Student)list["kwon"];

            Console.WriteLine("kwon의 학점 : " + st.getGrade());
        }
    }
}
