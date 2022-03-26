using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_PostfixEvaluator
{
    class Stack
    {
        static int MAX = 100; // 매크로 대신
        private int[] s; // 스택을 저장할 배열
        private int top; // 스택의 마지막 위치 지정
        private int size;

        // housekeeping function - 외부에서 사용될 일 없는 함수
        private void initalize()
        {
            for (int i = 0; i < s.Length; i++)
                s[i] = 0;
        }
        private void OverflowError()
        {
            Console.WriteLine("Stack OverFlow Error occurs");
            Environment.Exit(-1);
        }
        private void StackEmptyError()
        {
            Console.WriteLine("Stack Empty Error occurs");
            Environment.Exit(-1);
        }
        public Stack() // default constructor
            : this(MAX)
        {
        }
        public Stack(int n)
        {
            s = new int[n];
            top = -1;
            initalize();
            size = n;
        }

        public void push(int x) // 스택에 데이터를 넣는 함수
        {
            if (top >= size - 1)
                OverflowError(); // 오버 플로우 발생할 때 처리할 함수
            top++;
            s[top] = x;
        }

        public int pop() // 스택에서 데이터를 빼는 함수
        {
            if (top == -1)
                StackEmptyError();
            top--;
            return s[top + 1];
        }

        public void reset() // 배열과 내용을 초기화 함수
        {
            top = -1;
            this.initalize();
        }

        public bool isEmpty() // 스택이 비어있는지 확인 함수
        {
            if (top == -1)
                return true;
            else
                return false;
        }

        public int getCount() // 스택에 남은 데이터 갯수 확인 함수
        {
            return top + 1;
        }

        public int peek() // 스택 가장 끝에 들어온 데이터 확인(pop과 다르게 삭제x) 함수
        {
            return s[top];
        }

        public void print() // 스택 내부의 모든 데이터를 출력하는 함수
        {
            Console.Write("[ ");
            for (int i = 0; i <= top; i++)
            {
                Console.Write(s[i] + " ");
            }
            Console.WriteLine("]");
        }
    }
    class LineBuffer
    {
        public static int ID_QUIT = 1;
        public static int ID_PLUS = 2;
        public static int ID_MINUS = 3;
        public static int ID_MULTIPLY = 4;
        public static int ID_DIVIDE = 5;
        public static int ID_EOD = 6;
        public static int ID_OPERAND = 7;

        private String[] tokens;
        private int index;
        private int tokenValue;

        public LineBuffer(String text)
        {
            char[] separator = new char[1];
            separator[0] = ' ';

            tokens = text.Split(separator);

            index = 0;
            /*
            // 제대로 split 되었는지 확인
            for (int i = 0; i < tokens.Length; i++)
                Console.WriteLine(tokens[i]);
                */
        }

        public int getNextToken()
        {
            // 피연산자가 아닌 경우에 돌려줄 값들
            if (index >= tokens.Length)
                return ID_EOD;
            if (tokens[index].Equals("+"))
            {
                index++;
                return ID_PLUS;
            }
            if (tokens[index].Equals("-"))
            {
                index++;
                return ID_MINUS;
            }
            if (tokens[index].Equals("*"))
            {
                index++;
                return ID_MULTIPLY;
            }
            if (tokens[index].Equals("/"))
            {
                index++;
                return ID_DIVIDE;
            }

            // 피연산자인 경우 돌려 줄 값
            tokenValue = int.Parse(tokens[index]);
            index++;
            return ID_OPERAND;
        }

        public int getTokenValue()
        {
            return tokenValue;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Type postfix expression : (ex) 1 2 3 + + ");
            Stack operands = new Stack();
            while (true)
            {
                String aLine = Console.ReadLine();
                // Console.WriteLine(aLine); 제대로 읽어왔나 확인

                // Tokenizer buffer = new Tokenizer(aLine);
                LineBuffer buffer = new LineBuffer(aLine);

                while (true)
                {
                    int tokenID = buffer.getNextToken(); // tokenID에 
                    int value;
                    value = buffer.getTokenValue();

                    if (tokenID == LineBuffer.ID_OPERAND)
                    {
                        // 피연산자인 경우 스택에 넣는다
                        operands.push(value);

                        // tokenID가 피연산자면 7[12] 같은 형태로 출력
                        // Console.Write(tokenID + "[" + buffer.getTokenValue() + "] ");
                    }
                    // 피연산자가 아니면 tokenID만 출력
                    // Console.Write(tokenID + " ");
                    else if (tokenID == LineBuffer.ID_PLUS)
                    {
                        int a = operands.pop();
                        int b = operands.pop();
                        // 교환법칙에 주의해서 뒤에 나온 b가 앞서 계산되는게 맞다
                        operands.push(b + a);
                    }
                    else if (tokenID == LineBuffer.ID_MINUS)
                    {
                        int a = operands.pop();
                        int b = operands.pop();
                        // 교환법칙에 주의해서 뒤에 나온 b가 앞서 계산되는게 맞다
                        operands.push(b - a);
                    }
                    else if (tokenID == LineBuffer.ID_MULTIPLY)
                    {
                        int a = operands.pop();
                        int b = operands.pop();
                        // 교환법칙에 주의해서 뒤에 나온 b가 앞서 계산되는게 맞다
                        operands.push(b * a);
                    }
                    else if (tokenID == LineBuffer.ID_DIVIDE)
                    {
                        int a = operands.pop();
                        int b = operands.pop();
                        // 교환법칙에 주의해서 뒤에 나온 b가 앞서 계산되는게 맞다
                        operands.push(b / a);
                    }
                    else if (tokenID == LineBuffer.ID_EOD) // while문 나가는 조건 EOD
                    {
                        int data = operands.pop(); // 마지막에 스택에 남아있는 값 저장
                        if (operands.isEmpty()) // 만약 스택이 비어있다면
                        {
                            Console.WriteLine("= " + data);
                        }
                        else // 스택이 비어있지 않다면 (operator 개수가 모자란 경우)
                            Console.WriteLine("Incorrect Expression");
                        break;
                    }
                    //Console.Write(tokenID + " "); 확인용
                }
            }
        }
    }
}
