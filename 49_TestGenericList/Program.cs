using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 이전의 singly linked list를 범용성 있게 generic class로 만들어 낸 것
// 유연성을 위해서 입력도 따로 받게 되어있다
// Enumerator 대신 Java 스타일의 Iterator 사용

namespace _49_TestGenericList
{
    class ListNode<Type>
    {
        public Type data;
        public ListNode<Type> pNext;
        public ListNode(Type x)
        {
            data = x;
            pNext = null;
        }
        public ListNode(Type x, ListNode<Type> next)
        {
            data = x;
            pNext = next;
        }
    }

    class LinkedList<Type>
    {
        private ListNode<Type> pHead;
        private int nCount;
        public LinkedList()
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
        public void addFirst(Type data)
        {
            ListNode<Type> pNode = new ListNode<Type>(data, pHead);
            nCount++;
            pHead = pNode;
        }
        public void addLast(Type data)
        {
            ListNode<Type> pNode = new ListNode<Type>(data);
            nCount++;
            if (pHead == null)
            {
                pHead = pNode;
                return;
            }
            ListNode<Type> pTraverse = pHead;
            while (pTraverse.pNext != null)
            {
                pTraverse = pTraverse.pNext;
            }
            pTraverse.pNext = pNode;
        }
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
            ListNode<Type> pTraverse = pHead.pNext;
            while (pTraverse != null)
            {
                if (index == count) break;
                count++;
                pFollow = pTraverse;
                pTraverse = pTraverse.pNext;
            }
            ListNode<Type> pNode = new ListNode<Type>(data, pTraverse);
            nCount++;
            pFollow.pNext = pNode;
        }
        public bool remove(Type data)
        {
            if (isEmpty() == true)
            {
                Console.WriteLine("The list is empty. No data removed.");
                return false;
            }
            if (pHead != null && pHead.data.Equals(data))
            {
                ListNode<Type> pNextNode = pHead.pNext;
                pHead = pNextNode;
                nCount--;
                return true;
            }
            ListNode<Type> pFollow = pHead;
            ListNode<Type> pTraverse = pHead.pNext;
            while (pTraverse != null)
            {
                if (pTraverse.data.Equals(data))
                {
                    ListNode<Type> pNextNode = pTraverse.pNext;
                    pFollow.pNext = pNextNode;
                    nCount--;
                    return true;
                }
                pFollow = pTraverse;
                pTraverse = pTraverse.pNext;
            }
            Console.WriteLine(data + " is not found. No data removed.");
            return false;
        }
        public ListIterator<Type> listIterator()
        {
            return new ListIterator<Type>(pHead);
        }
        public override String ToString()
        {
            if (isEmpty() == true)
            {
                return "<>";
            }
            String tmp = "< ";
            ListNode<Type> pNode = pHead;
            while (pNode != null)
            {
                tmp = tmp + pNode.data;
                if (pNode.pNext != null)
                {
                    tmp = tmp + ", ";
                }
                else
                {
                    tmp = tmp + " >";
                }
                pNode = pNode.pNext;
            }
            return tmp;
        }
    }

    class ListIterator<Type>
    {
        ListNode<Type> ptr;
        public ListIterator(ListNode<Type> pHead)
        {
            ptr = pHead;
        }
        public bool hasNext()
        {
            if (ptr == null)
                return false;
            else
                return true;
        }
        public Type next()
        {
            Type data = ptr.data;
            ptr = ptr.pNext;
            return data;
        }
    }

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
