using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 배열과 linked list의 비교 확인

namespace _19_compare_Link_Array
{
    class ListNode
    {
        public ListNode(int v) // constructor
        {
            this.data = v;
            this.next = null;
        }

        public int data;
        public ListNode next; // 다음 노드를 가르킬 reference
    }
    class Program
    {
        // 배열 출력용 함수
        static void print(int[] x)
        {
            for (int i = 0; i < x.Length; i++)
                Console.Write(x[i] + " ");
            Console.WriteLine();
        }

        // linked list 출력용 함수
        static void print(ListNode root)
        {
            ListNode tmp = root; // tmp에 root 주소를 저장

            while (tmp != null) // tmp 주소가 null을 가르키면
            {
                Console.Write(tmp.data + " ");
                tmp = tmp.next; // tmp의 주소를 다음 주소로 가져온다
            }

            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            // 배열의 경우

            int[] x = new int[100];
            // 크기는 100이지만 4개 밖에 사용하지 않아 나머지 공간이 낭비된다
            x[0] = 5;
            x[1] = 1;
            x[2] = 3;
            x[3] = 4;

            print(x); // 배열 출력

            // LinkeList의 경우
            // 절대로 이렇게 사용할 경우는 없겠지만 불필요한 공간 혹은 overflow가 발생하지 않는다

            ListNode link = new ListNode(5); // 5의 값을 가진 노드 생성
            link.next = new ListNode(8); // 8의 값을 가진 노드를 root node의 next 객체에 삽입
            link.next.next = new ListNode(10); // 내부의 주소를 쫓아 객체 삽입
            link.next.next.next = new ListNode(7);

            print(link);
        }
    }
}
