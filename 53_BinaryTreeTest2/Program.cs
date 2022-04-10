using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 이전 이진 트리에서 구조를 가져왔다
// BinaryTree class를 이용해 TreeNode를 간접적으로 이용할 수 있게

namespace _53_BinaryTreeTest2
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
    class BinaryTree
    {
        // 생성자 
        public BinaryTree()
        {
            root = null;
        }
        public BinaryTree(int root)
        {
            setRoot(root);
        }
        // 데이터 멤버
        TreeNode root;

        public void setRoot(int root)
        {
            this.root = new TreeNode(root);
        }
        
        public void add(int x)
        {
            // setRoot를 실행하지 않은 경우
            if(root == null)
            {
                setRoot(x);
            }
            else
            {
                root.add(x); // TreeNode class의 add 함수로 대체
            }
        }

        // 아래는 TreeNode 클래스의 함수를 복붙한 거 
        // TreeNode의 구현부를 호출해서 사용하게 한다
        public int getCount()
        {
            if (root == null)
                return 0;
            else
                return root.getCount();  
        }

        // 트리의 깊이를 반환하는 함수
        public int getDepth()
        {
            if (root == null)
                return 0;
            else
                return root.getDepth();
        }
        // 이진 트리의 중위 순회
        public void inorder()
        {
            if (root == null)
            {
                Console.WriteLine("Tree is Empty");
                return;
            }
            else
                root.inorder();
        }
        // 전위 순회
        public void preorder()
        {
            if (root == null)
            {
                Console.WriteLine("Tree is Empty");
                return;
            }
            else
                root.preorder();
        }
        // 후위 순회
        public void postorder()
        {
            if (root == null)
            {
                Console.WriteLine("Tree is Empty");
                return;
            }
            else
                root.postorder();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree();

            tree.setRoot(4);

            tree.add(3);
            tree.add(7);
            tree.add(1);
            tree.add(6);
            tree.add(9);
            tree.add(8);

            Console.WriteLine(tree.getCount());
            Console.WriteLine(tree.getDepth());
            Console.WriteLine("=========");

            tree.inorder();
            Console.WriteLine();

            tree.add(2);

            tree.preorder();
            Console.WriteLine();

            tree.add(5);

            tree.postorder();
            Console.WriteLine();
        }
    }
}
