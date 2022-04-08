using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections; // type 명시가 불가능하다, 꺼낼 때 type casting이 필요하다

// ArrayList 사용법
// 배열의 문제점인 크기 고정으로 인한 overflow 발생과 기억장소 낭비를 줄인 것

namespace _42_Collection_ArrayList
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList list = new ArrayList();
            list.Add("kim");
            list.Add("park");
            list.Add("lee");
            list.Add("kwon");
            list.Add("ban");

            // for문으로 ArrayList의 traverse 방법
            for (int i = 0; i < list.Count; i++) // count는 list 안에 개수를 가지고 있다
            {
                Console.WriteLine(list[i]);
            }

            Console.WriteLine("===");

            // foreach문으로 ArrayList의 traverse 방법
            foreach (String s in list)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine("===");

            // data를 하나하나 access 하는 ArrayList traverse 방법
            IEnumerator e = list.GetEnumerator();

            while (e.MoveNext())
            {
                Console.WriteLine(e.Current);
            }
        }
    }
}
