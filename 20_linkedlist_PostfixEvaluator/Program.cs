using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 기존의 배열을 이용한 스택을 사용한 postfixEvaluator에서 linkelist 스택으로 컬렉션 객체를 변경

namespace _20_linkedlist_PostfixEvaluator
{
    class Stack
    {
        // main 함수 안에서 StackItem를 직접 사용할 수 없게 숨긴다 (사용할 필요가 없기 때문)
        // 이걸 inner class라고 한다
        public class StackItem
        {
            public StackItem(int num) // constructor
            {
                this.data = num;
                next = null;
            }

            private int data;
            private StackItem next; // 다음 노드를 가르킬 reference
                                   // 데이터를 처리할 함수
            public int getData() // 노드의 데이터를 반환
            {
                return data;
            }
            public void setData(int num) // 노드의 데이터를 삽입
            {
                this.data = num;
            }
            // 연결될 노드를 처리할 함수
            public StackItem getNext() // 다음 노드 주소를 반환
            {
                return next;
            }

            public void setNext(StackItem node) // 다음 노드를 세팅
            {
                this.next = node;
            }

        }
        public Stack() // default constructor
        {
            initalize();
        }

        private StackItem top;

        // housekeeping function - 외부에서 사용될 일 없는 함수
        private void initalize() // 초기화
        {
            top = null;
        }
        private void OverflowError()
        {
           
        }
        private void EmptyError()
        {
            Console.WriteLine("Empty Error occurs");
            Environment.Exit(-1);
        }
        

        public void push(int x) // 스택에 데이터를 넣는 함수
        {
           if(top == null)
            {
                top = new StackItem(x); // 정수 x가 삽입된 리스트 노드 생성해 reference에 넣어준다
            }
            else
            {
                StackItem item = new StackItem(x); // 정수 x가 들어간 새 리스트 노드 만들기

                item.setNext(top); // item.next = top; 과 같은 의미, item의 next가 기존의 top이 가르키는 리스트 노드를 가르키게 된다
                top = item; // top이 새로 만든 리스트 노드를 가르키게 된다
            }
        }

        public int pop() // 스택에서 데이터를 빼는 함수
        {
            if (top == null) // top이 비어있으면 에러 호출
                EmptyError();

            StackItem topItem = top; // 기존에 top이 가르키는 걸 topItem에 임시 저장
            top = top.getNext(); // top = top.next; 와 같다

            return topItem.getData(); // 임시저장된 주소를 return
        }

        public void reset() // 배열과 내용을 초기화 함수
        {
            top = null; // top 이 가르키는 주소를 null로 바꿔버리면 그만
        }

        public bool isEmpty() // 스택이 비어있는지 확인 함수
        {
           if (top == null)
            {
                return true;
            }
            return false;
        }

        public int getCount() // 스택에 남은 데이터 갯수 확인 함수
        {
            int n = 0;
            // traverse를 통해 해결
            // 이 경우 노드가 많으면 시간이 오래 걸린다
            StackItem tmp = top;

            while(tmp != null)
            {
                n++;
                tmp = tmp.getNext();
            }

            return n;
        }

        public int peek() // 스택 가장 끝에 들어온 데이터 확인(pop과 다르게 삭제x) 함수
        {
            if (top == null)
                EmptyError();

            return top.getData();
        }

        public void print() // 스택 내부의 모든 데이터를 출력하는 함수
        {
            StackItem tmp = top;
            while(tmp != top)
            {
                Console.Write(tmp.getData() + " ");
                tmp = tmp.getNext();
            }
            Console.WriteLine();
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

        private static int BUFSIZ = 256;

        private int tokenValue;
        private int position;
        private char[] text;

        public LineBuffer(String s)
        {
            this.text = new char[BUFSIZ];

            for (int i = 0; i < s.Length; i++)
                text[i] = s.ElementAt(i);

            text[s.Length] = '\0';
            position = 0;
            tokenValue = 0;
        }

        public int getNextToken()
        {
            while (text[position] == ' ')
                position++;

            if (text[position] == '\0') // 읽어온 문자열이 끝난 경우
                return ID_EOD;

            if (text[position] == '+')
            {
                position++;
                return ID_PLUS;
            }
            if (text[position] == '*')
            {
                position++;
                return ID_MULTIPLY;
            }
            if (text[position] == '/')
            {
                position++;
                return ID_DIVIDE;
            }
            // 문자가 -에 뒤에 숫자가 없는 두 가지 경우에 마이너스 반환
            if ((text[position] == '-' && text[position + 1] == ' ') ||
                (text[position] == '-' && text[position + 1] == '\0'))
            {
                position++;
                return ID_MINUS;
            }

            String buffer = "";

            if (text[position] == '-') // 위의 minus operator 판단은 끝났으니 - 만나면 buffer에 삽입
            {
                buffer = buffer + "-";
                position++;
            }

            while (text[position] >= '0' && text[position] <= '9') // 정해진 숫자 문자 안에서는 반복
            {
                buffer = buffer + text[position];
                position++;
            }

            tokenValue = int.Parse(buffer); // casting

            if (text[position] != ' ' && text[position] != '\0') // 잘못 입력된 a 같은 문자열이 있는 경우 종료
                return ID_QUIT;

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
                    int value = buffer.getTokenValue();

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
                    else if (tokenID == LineBuffer.ID_QUIT) // 잘못 입력된 문자열이 있는 경우 종료
                    {
                        Environment.Exit(-1);
                    }
                    //Console.Write(tokenID + " "); 확인용
                }
            }
        }
    }
}
