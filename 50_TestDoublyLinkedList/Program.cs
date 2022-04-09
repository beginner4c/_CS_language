using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// doubly linked list를 라이브러리가 아닌 직접 구현
// 이전 싱글 링크드 리스트와 사용은 비슷하나 구조적인 변화가 발생한다
// chain형 더블 링크드 리스트이기 때문에 첫 노드의 이전 노드는 마지막 노드를 가르키고 있다

namespace _50_TestDoublyLinkedList
{
    class ListNode<Type>
    {
        // 데이터 멤버
        // 이전과 다른 점이라면 pPrev가 이전 노드를 가르킨다는 것
        private Type data;
        private ListNode<Type> pPrev;
        private ListNode<Type> pNext;
        public ListNode() // 생성자
        {
            data = default(Type);
            pPrev = this;
            pNext = this;
        }
        public ListNode(Type x) // 생성자
        {
            data = x;
            pPrev = this;
            pNext = this;
        }
        public Type getData()
        {
            return data;
        }
        public void setData(Type x)
        {
            data = x;
        }
        public ListNode<Type> getNext()
        {
            return pNext;
        }
        void setNext(ListNode<Type> p)
        {
            pNext = p;
        }
        public ListNode<Type> getPrev()
        {
            return pPrev;
        }
        public void setPrev(ListNode<Type> p)
        {
            pPrev = p;
        }
        // chain의 마지막 자리에 집어넣어야 하기 때문에 첫 번째 노드의 이전 노드와 기존 마지막 노드의 다음 노드가 수정된다
        // 추가되는 노드는 다음 노드로 첫 노드를, 이전 노드로 기존 마지막 노드를 가진다
        // this node is inserted before pNode
        // pNode must be understood as a chain
        public void insert(ListNode<Type> pNode)
        {
            pPrev = pNode.pPrev;
            pNext = pNode;
            pNode.pPrev.pNext = this;
            pNode.pPrev = this;
        }

        // 맨 첫 노드의 다음 노드에 노드를 추가시키는 함수
        // insert 함수와 비슷한 과정을 거쳐 두 번째 노드의 자리에 노드를 추가 시킨다
        // this node is appended just after pNode
        // pNode must be understood as a chain
        public void append(ListNode<Type> pNode)
        {
            pPrev = pNode;
            pNext = pNode.pNext;
            pNode.pNext.pPrev = this;
            pNode.pNext = this;
        }

        // 들어온 위치의 노드를 제거하는 함수
        // 실제 제거는 아니고 garbage로 남게 만듬
        public void remove()
        {
            this.pNext.pPrev = this.pPrev;
            this.pPrev.pNext = this.pNext;
        }
    };

    class LinkedList<Type>
    {
        // 데이터 멤버
        protected ListNode<Type> pHead;
        protected int nCount;
        public LinkedList() // 생성자
        {
            pHead = null;
            nCount = 0;
        }
        public bool isEmpty()
        {
            if (pHead == null) return true;
            else return false;
        }
        public int size()
        {
            return nCount;
        }
        // 첫 번째 노드를 교체
        public void addFirst(Type data)
        {
            addLast(data);
            pHead = pHead.getPrev();
        }
        // 마지막 노드를 추가
        public void addLast(Type data)
        {
            ListNode<Type> pNewNode = new ListNode<Type>(data);
            nCount++;
            if (pHead == null)
            {
                pHead = pNewNode;
                return;
            }
            pNewNode.insert(pHead);
        }
        // 인덱스 번호만큼 노드를 따라가 노드를 하나 추가
        public void add(int index, Type data)
        {
            if (index < 0 || index > nCount)
            {
                Console.WriteLine("index out of bound error - add(index,data) failed.");
                return;
            }
            if (index == 0)
            {
                addFirst(data);
                return;
            }
            int count = 1;
            ListNode<Type> pFollow = pHead;
            ListNode<Type> pTraverse = pHead.getNext();
            while (pTraverse != null)
            {
                if (index == count) break;
                count++;
                pFollow = pTraverse;
                pTraverse = pTraverse.getNext();
            }
            ListNode<Type> pNewNode = new ListNode<Type>(data);
            nCount++;
            pNewNode.append(pFollow);
        }

        // 첫 위치로 돌아오기 전에 데이터를 가진 노드를 제거한다
        public bool remove(Type data)
        {
            // 리스트가 빈 경우
            if (isEmpty() == true)
            {
                Console.WriteLine("The list is empty. No data removed.");
                return false;
            }
            // 첫 노드가 제거되어야 할 경우
            if (pHead != null && pHead.getData().Equals(data))
            {
                ListNode<Type> pNextNode = pHead.getNext();
                pHead.remove();
                nCount--;
                if (pNextNode == pHead) pHead = null;
                else pHead = pNextNode;
                return true;
            }
            // 제거될 노드가 첫 노드가 아니고 존재하는 경우
            ListNode<Type> pFollow = pHead;
            ListNode<Type> pTraverse = pHead.getNext();
            while (pTraverse != pHead)
            {
                if (pTraverse.getData().Equals(data))
                {
                    pTraverse.remove();
                    nCount--;
                    return true;
                }
                pFollow = pTraverse;
                pTraverse = pTraverse.getNext();
            }
            // 제거될 데이터를 가진 노드가 존재하지 않는 경우
            Console.WriteLine(data + " is not found. No data removed.");
            return false;
        }

        // 리스트를 traverse할 때 사용
        public ListIterator<Type> listIterator()
        {
            return new ListIterator<Type>(pHead);
        }
        // 출력용
        public override String ToString()
        {
            if (isEmpty() == true)
            {
                return "<>";
            }
            String tmp = "< ";
            ListNode<Type> pNode = pHead;
            for (int i = 0; i < nCount; i++)
            {
                tmp = tmp + pNode.getData();
                if (i < nCount - 1)
                {
                    tmp = tmp + ", ";
                }
                else
                {
                    tmp = tmp + " >";
                }
                pNode = pNode.getNext();
            }
            return tmp;
        }
    }

    // 리스트를 traverse할 클래스
    class ListIterator<Type>
    {
        // 데이터 멤버
        ListNode<Type> pHead;
        ListNode<Type> ptr;
        public ListIterator(ListNode<Type> pHead) // 생성자
        {
            this.pHead = pHead;
            ptr = null;
        }
        // 다음 노드가 있는지 물어봄
        public bool hasNext() 
        {
            if (ptr == null)
            {
                if (pHead == null)
                    return false;
                ptr = pHead;
                return true;
            }
            if (ptr == pHead)
                return false;
            else
                return true;
        }
        // 다음 노드로 넘어감
        public Type next()
        {
            Type data = ptr.getData();
            ptr = ptr.getNext();
            return data;
        }
    }

    // 이전 프로그램에서 복붙함
    class TestLinkedList
    {
        static int readInt()
        {
            String s = Console.ReadLine();
            return int.Parse(s);
        }
        static void Main(string[] args)
        {
            LinkedList<int> aList = new LinkedList<int>();
            while (true)
            {
                int select;
                Console.Write("What do you want ? \n<1>addFront, <2>addTail, <3>remove, <4>quit : ");
                select = readInt();
                if (select < 1 || select > 3)
                {
                    break;
                }
                Console.Write("Type data : ");
                int data;
                data = readInt();
                switch (select)
                {
                    case 1:
                        aList.addFirst(data);
                        Console.WriteLine(aList);
                        break;
                    case 2:
                        aList.addLast(data);
                        Console.WriteLine(aList);
                        break;
                    case 3:
                        if (aList.remove(data) == true)
                        {
                            Console.WriteLine(aList);
                        }
                        break;
                    default:
                        Console.WriteLine(aList);
                        break;
                }
            }
            // test other operations
            Console.WriteLine("size of the list = " + aList.size());

            Console.WriteLine("The list can be traversed like the following style.");
            ListIterator<int> i = aList.listIterator();
            while (i.hasNext())
            {
                int data = i.next();
                Console.WriteLine(data);
            }

            aList.add(2, 1000);
            Console.WriteLine(aList);
        }
    }
}
