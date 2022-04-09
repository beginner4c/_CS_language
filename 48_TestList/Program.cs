using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 이전 프로그램에서는 라이브러리에서 LinkedList를 가져왔지만 이건 만든 거
// Singly Linked List를 구현
// 열거자인 Enumerator도 라이브러리가 아닌 직접 구현

namespace _48_TestList
{
    class ListNode
    {
        public ListNode(int num) // 생성자
        {
            this.data = num;
        }
        public ListNode(int num, ListNode next) // LinkedList의 AddFirst에 사용할 생성자
        {
            this.data = num;
            this.pNext = next;
        }

        // 데이터 멤버
        public int data;
        public ListNode pNext;
    }
    class LinkedList
    {
        public LinkedList() // constructor
        {
            pHead = null;
            nCount = 0;
        }
        // data member
        private ListNode pHead; // 첫 번째 노드를 가르킴
        private int nCount; // node의 개수

        // linked list를 traverse 할 함수
        public override string ToString()
        {
            String s = "[ ";

            ListNode p = pHead;
            while (p != null)
            {
                s += p.data + " ";
                p = p.pNext;
            }
            s += "]";

            return s;
        }

        // 리스트 마지막에 데이터를 가진 노드를 새로 추가하는 함수
        public void AddLast(int num)
        {
            
            ListNode pNode = new ListNode(num);
            nCount++;

            if (pHead == null) // 리스트가 처음 만들어져 첫 번째 노드가 비어있을 때
            {
                pHead = pNode;
                return;
            }

            ListNode p = pHead;
            while(p.pNext != null)
            {
                p = p.pNext;
            }

            p.pNext = pNode;
        }

        // 맨 앞 노드인 pHead의 위치에 이전 노드를 뒤로 보내고 새 노드를 추가시키는 것
        public void AddFirst(int num)
        {
            ListNode pNode = new ListNode(num, pHead); // 만들 때 pNext에 지금 맨 앞 노드를 가지게
            nCount++;

            pHead = pNode;
        }

        public void Add(int index, int num)
        {
            // 인덱스가 범위에 벗어난 경우
            if(index < 0 || index > nCount)
            {
                Console.WriteLine("index out of bound error");
                return;
            }
            // 인덱스가 pHead, 맨 앞 노드를 가르키는 경우
            if (index == 0)
            {
                AddFirst(num);
                return;
            }

            // 인덱스를 맞춰 traverse 할 때
            int count = 1;
            ListNode pFollow = pHead; // 삽입할 위치의 이전 노드를 가르킬 노드
            ListNode pTraverse = pHead.pNext; // 삽입할 위치의 노드를 가르킬 노드


            while (count != index)
            {
                pFollow = pTraverse;
                pTraverse = pTraverse.pNext;
                count++;
            }
            // ListNode pNode = new ListNode(num);
            // pNode.pNext = pTraverse;

            ListNode pNode = new ListNode(num, pTraverse);
            pFollow.pNext = pNode;
            nCount++;
        }

        // 리스트 내의 node를 제거할 함수
        // 보통 remove 함수는 bool 형식이고 제거에 성공하면 true, 실패 시 false 반환
        public bool remove(int data)
        {
            // 리스트가 비어있는 경우
            if (pHead == null) // nCount 가 0인지 물어봐도 ㅇㅋ
            {
                Console.WriteLine("List is Empty \nNo data remove");
                return false;
            }

            // 리스트의 맨 앞인 pHead를 빼야하는 경우
            if (pHead.data == data)
            {
                pHead = pHead.pNext; // 두 번째 노드를 앞 노드로 땡겨옴
                nCount--;

                return true;
            }

            // 그 외 노드들을 빼야하는 경우
            ListNode pFollow = pHead; // 제거할 노드의 이전 노드
            ListNode pTraverse = pHead.pNext; // 제거할 노드를 찾는 노드
            while(pTraverse != null)
            {
                if (pTraverse.data == data)
                {
                    pFollow.pNext = pTraverse.pNext;
                    nCount--;

                    return true;
                }
                pFollow = pTraverse;
                pTraverse = pTraverse.pNext;
            }
            // 리스트 내에서 찾는 데이터가 없는 경우
            Console.WriteLine(data + " is not found");
            
            return false;
        }

        // Enumerator를 instantiation하는 함수
        public Enumerator GetEnumerator()
        {
            return new Enumerator(pHead);
        }
    }

    class Enumerator // 리스트를 traverse할 열거자 Enumerator
    {
        public Enumerator(ListNode pHead) // 생성자
        {
            ptr = pHead;
        }
        // 데이터 멤버
        ListNode ptr;
        int current;

        public int Current
        {
            get
            {
                return current;
            }
        }

        public bool MoveNext()
        {
            if (ptr == null)
                return false;

            current = ptr.data;
            ptr = ptr.pNext;

            return true;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList list;

            list = new LinkedList();
            Console.WriteLine(list.ToString()); // 비어있다

            list.remove(5); // 비어있는 리스트에 5를 빼라고 하면 불가능 메시지 출력하게

            /* // 그냥 공부때문에 이렇게 만드는 거지 실제로 이딴 식으로 사용은 절대 할 일 없다

            list.pHead = new ListNode(7);
            list.pHead.pNext = new ListNode(3);
            list.pHead.pNext.pNext = new ListNode(6);
            list.pHead.pNext.pNext.pNext = new ListNode(2);
            list.nCount = 4;
            */

            list.AddLast(7);
            list.AddLast(3);
            list.AddLast(6);
            list.AddLast(2);

            Console.WriteLine(list.ToString());

            list.AddLast(7);
            list.AddLast(8);
            list.AddLast(5);
            list.AddLast(1);

            Console.WriteLine(list.ToString());

            list.AddFirst(8);
            list.AddFirst(9);

            Console.WriteLine(list);

            // 맨 앞자리 노드를 제거하는 경우
            list.remove(9);
            Console.WriteLine(list);

            // pHead가 아닌 노드를 제거하는 일반적인 경우
            // 리스트 내에 같은 데이터가 여러 개 있어도 그 중 맨 앞 데이터 노드만 제거
            list.remove(7);
            Console.WriteLine(list);

            // 리스트 내에 없는 데이터를 제거할 때
            list.remove(10);
            Console.WriteLine(list);

            // 인덱스 위치 기준으로 데이터를 집어넣는 경우, 0번 부터 시작
            list.Add(3, 1000); // 3번 인덱스에 1000 삽입
            list.Add(1, 1000000); // 1번 인덱스에 1000000 삽입
            Console.WriteLine(list);

            // 없는 인덱스 위치를 특정한 경우
            list.Add(20, 20);

            // 열거자 Enumerator
            Enumerator e = list.GetEnumerator();
            while (e.MoveNext()) // Enumerator를 통해 list를 traverse하며 내부 데이터 출력
            {
                Console.Write(e.Current + " ");
            }
            Console.WriteLine();
        }
    }
}
