using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 이진트리의 구현
// 트리는 라이브러리에 구현되어 있지 않다
// 전,중,후위 순회와 깊이 탐색, 개수 탐색, 정렬형 노드 추가 함수가 들어있다

namespace _52_BinaryTreeTest
{
    class TreeNode
    {
        // 생성자
        public TreeNode(int x)
        {
            data = x;
            lchild = rchild = null;
        }
        // 데이터 멤버
        public TreeNode lchild;
        int data;
        public TreeNode rchild;

        // 가진 노드의 개수를 구하는 함수
        public int getCount()
        {
            int n1 = 0; // 왼쪽 child의 갯수
            int n2 = 0; // 오른쪽 child의 갯수
            // 재귀해서 구한다
            if (lchild != null)
                n1 = lchild.getCount();
            if (rchild != null)
                n2 = rchild.getCount();

            return n1 + n2 + 1; // 1은 root이자 데이터 노드
        }

        // 트리의 깊이를 반환하는 함수
        public int getDepth()
        {
            int n1 = 0;
            int n2 = 0;
            // 재귀 구조를 잘 이해해야 한다
            if (lchild != null)
                n1 = lchild.getDepth();
            if (rchild != null)
                n2 = rchild.getDepth();
            // 더 많이 값을 반환한 쪽이 깊은 쪽이기 때문에 비교
            if (n1 > n2)
            {
                return n1 + 1;
            }
            else
            {
                return n2 + 1;
            }
        }
        // 이진 트리의 중위 순회
        public void inorder()
        {
            // 재귀 함수로 구현
            if (lchild != null)
                lchild.inorder();
            Console.Write(data);
            if (rchild != null)
                rchild.inorder();
        }
        // 전위 순회
        public void preorder()
        {
            // 재귀 함수로 구현
            Console.Write(data);
            if (lchild != null)
                lchild.inorder();
            if (rchild != null)
                rchild.inorder();
        }
        // 후위 순회
        public void postorder()
        {
            // 재귀 함수로 구현
            if (lchild != null)
                lchild.inorder();
            if (rchild != null)
                rchild.inorder();
            Console.Write(data);
        }

        // 값을 비교해 재귀하면서 맨 아래 새로운 노드 생성
        public void add(int x)
        {
            // 받아온 x값이 가진 data보다 작은 경우
            if (x < data)
            {
                if (lchild != null) // 비어있지 않으면 왼쪽 재귀
                    lchild.add(x);
                else // 비어있는 경우 새 노드 생성
                    lchild = new TreeNode(x);
            }
            else // x >= data
            {
                if (rchild != null) // 비어 있지 않으면 오른쪽 재귀
                    rchild.add(x);
                else // 비어 있는 경우 새 노드 생성
                    rchild = new TreeNode(x);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(4);

            /* // 절 대 이렇게 사용하지 않지만 일단 공부용
            root = new TreeNode(4);
            root.lchild = new TreeNode(3);
            root.lchild.lchild = new TreeNode(1);
            root.rchild = new TreeNode(7);
            root.rchild.lchild = new TreeNode(6);
            root.rchild.rchild = new TreeNode(9);
            root.rchild.rchild.lchild = new TreeNode(8);
            */
            // 이런 식으로 add 함수를 사용할 경우 정렬도 가능하다
            root.add(3);
            root.add(1);
            root.add(7);
            root.add(6);
            root.add(9);
            root.add(8);

            Console.WriteLine(root.getCount()); // 노드 갯수 출력
            Console.WriteLine(root.getDepth()); // 트리 깊이 출력
            root.inorder();
            Console.WriteLine();
            root.preorder();
            Console.WriteLine();
            root.postorder();
            Console.WriteLine();

            root.add(2);
            root.add(5);
        }
    }
}
