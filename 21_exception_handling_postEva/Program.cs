using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21_exception_handling_postEva
{
    class StackException : Exception // Exception을 상속받은 StackException 생성
    {
        private String className, functionName, reason;

        public StackException(String cName, String fName, String reason)
        {
            this.className = cName;
            this.functionName = fName;
            this.reason = reason;
        }

        public String getClassName()
        {
            return className;
        }
        public String getFunctionName()
        {
            return functionName;
        }
        public String getReason()
        {
            return reason;
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
            Stack<int> operands = new Stack<int>(); // 라이브러리에 있는 generic class Stack 호출
            while (true)
            {
                String aLine = Console.ReadLine();
                // Console.WriteLine(aLine); 제대로 읽어왔나 확인

                // Tokenizer buffer = new Tokenizer(aLine);
                LineBuffer buffer = new LineBuffer(aLine);

                while (true)
                {
                    int tokenID = buffer.getNextToken(); // tokenID에 반환되는 정수를 통해 토큰을 구별

                    try // 일단 시도해보는 개념의 try 문
                    {
                        if (tokenID == LineBuffer.ID_OPERAND)
                        {
                            int value = buffer.getTokenValue();
                            // 피연산자인 경우 스택에 넣는다
                            operands.Push(value);

                            // tokenID가 피연산자면 7[12] 같은 형태로 출력
                            // Console.Write(tokenID + "[" + buffer.getTokenValue() + "] ");
                        }
                        // 피연산자가 아니면 tokenID만 출력
                        // Console.Write(tokenID + " ");
                        else if (tokenID == LineBuffer.ID_PLUS)
                        {
                            int a = operands.Pop();
                            int b = operands.Pop();
                            // 교환법칙에 주의해서 뒤에 나온 b가 앞서 계산되는게 맞다
                            operands.Push(b + a);
                        }
                        else if (tokenID == LineBuffer.ID_MINUS)
                        {
                            int a = operands.Pop();
                            int b = operands.Pop();
                            // 교환법칙에 주의해서 뒤에 나온 b가 앞서 계산되는게 맞다
                            operands.Push(b - a);
                        }
                        else if (tokenID == LineBuffer.ID_MULTIPLY)
                        {
                            int a = operands.Pop();
                            int b = operands.Pop();
                            // 교환법칙에 주의해서 뒤에 나온 b가 앞서 계산되는게 맞다
                            operands.Push(b * a);
                        }
                        else if (tokenID == LineBuffer.ID_DIVIDE)
                        {
                            int a = operands.Pop();
                            int b = operands.Pop();
                            // 교환법칙에 주의해서 뒤에 나온 b가 앞서 계산되는게 맞다
                            operands.Push(b / a);
                        }
                        else if (tokenID == LineBuffer.ID_EOD) // while문 나가는 조건 EOD
                        {
                            int data = operands.Pop(); // 마지막에 스택에 남아있는 값 저장
                            if (operands.Count == 0) // 만약 스택이 비어있다면
                            {
                                Console.WriteLine("= " + data);
                            }
                            else // 스택이 비어있지 않다면 (operator 개수가 모자란 경우)
                                Console.WriteLine("Incorrect Expression");

                            operands.Clear();
                            break;
                        }
                        else if (tokenID == LineBuffer.ID_QUIT) // 잘못 입력된 문자열이 있는 경우 종료
                        {
                            Environment.Exit(-1);
                        }
                    }
                    catch(InvalidOperationException ex) // 직접 만든 Exception이 아닌 Stack<>의 예외를 받는다
                    {
                        /* // try 문 중 StackException이 발생하면 작동
                        // ex) 1 2 3 + + + 
                        Console.WriteLine("A Stack Exception(" + ex.getReason() + ") was thrown by");
                        Console.WriteLine("the function " + ex.getFunctionName() + " of class");
                        Console.WriteLine(ex.getClassName() + ".");
                        Console.WriteLine("The stack will be reset. Please try again");
                        */

                        Console.WriteLine(ex); // 위처럼 하나하나 적어줄 필요 없이 ex를 넣어주기만 하면 작동한다
                        operands.Clear(); // stack 을 초기화하는 리셋
                        
                        Console.WriteLine("\nType postfix expression : (ex) 1 2 3 + + ");
                        
                        break; // while 문을 빠져나가기 위한 break
                    }
                    //Console.Write(tokenID + " "); 확인용
                }
            }
        }
    }
}
