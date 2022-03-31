using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// bitwise 연산을 사용
// 효율성을 위해서 사용한다

namespace _28_bitwise
{ /*
        class Student // bitwise operator를 사용하지 않은 클래스
        {
            private String ms_name;
            private bool mb_male;
            private bool mb_rich;
            private bool mb_tall;
            private bool mb_cute;
            public Student()
            {
                ms_name = "";
                mb_male = mb_rich = mb_tall = mb_cute = false;
            }
            public Student(String s)
            {
                ms_name = s;
                mb_male = mb_rich = mb_tall = mb_cute = false;
            }
            public Student(String s, bool male, bool rich, bool tall, bool cute)
            {
                ms_name = s;
                setMale(male);
                setRich(rich);
                setTall(tall);
                setCute(cute);
            }
            public String getName()
            {
                return ms_name;
            }
            public void setMale(bool flag)
            {
                mb_male = flag;
            }
            public void setRich(bool flag)
            {
                mb_rich = flag;
            }
            public void setTall(bool flag)
            {
                mb_tall = flag;
            }
            public void setCute(bool flag)
            {
                mb_cute = flag;
            }
            public bool isMale()
            {
                return mb_male;
            }
            public bool isRich()
            {
                return mb_rich;
            }
            public bool isTall()
            {
                return mb_tall;
            }
            public bool isCute()
            {
                return mb_cute;
            }
            public override String ToString()
            {
                String tmp = "";
                tmp = tmp + ms_name + " is ";
                if (isMale()) tmp = tmp + "a boy and he is ";
                else tmp = tmp + "a girl and she is ";
                if (isRich()) tmp = tmp + "rich, ";
                else tmp = tmp + "poor, ";
                if (isTall()) tmp = tmp + "tall and ";
                else tmp = tmp + "short and ";
                if (isCute()) tmp = tmp + "cute.";
                else tmp = tmp + "ugly.";
                return tmp;
            }
            public void readDataFromConsole()
            {
                String buffer = Console.ReadLine();
                char[] delemeter = new char[1];
                delemeter[0] = ' ';
                String[] data = buffer.Split(delemeter);

                ms_name = data[0];

                if (data[1].Equals("1")) setMale(true);
                else setMale(false);
                if (data[2].Equals("1")) setRich(true);
                else setRich(false);
                if (data[3].Equals("1")) setTall(true);
                else setTall(false);
                if (data[4].Equals("1")) setCute(true);
                else setCute(false);
            }
        }
    */
    class Student // bitwise operator를 사용한 클래스
    {
        // 위의 클래스와 specification은 동일하게 유지
        // bitwise 연산에서는 매크로를 정의해서 많이 사용한다
        // 윈도우 프로그래밍에서는 bitwise 연산을 많이 사용한다
        static int MALE_MASK = 1 << 0; // 미리 이런 식으로 매크로 정의 하는 경우가 많다
        static int RICH_MASK = 1 << 1;
        static int TALL_MASK = 1 << 2;
        static int CUTE_MASK = 1 << 3;
        private String ms_name;
        private int m_data;
        public Student()
        {
            ms_name = "";
            m_data = 0;
        }
        public Student(String s)
        {
            ms_name = s;
            m_data = 0;
        }
        public Student(String s, bool male, bool rich, bool tall, bool cute)
        {
            ms_name = s;
            setMale(male);
            setRich(rich);
            setTall(tall);
            setCute(cute);
        }
        public String getName()
        {
            return ms_name;
        }

        // bitwise 연산을 통해서 메모리 사용을 많이 줄여냈다
        public void setMale(bool flag)
        {
            if (flag)
                m_data = m_data | MALE_MASK; // 1 << 0
            else
                m_data = m_data & ~MALE_MASK;
        }
        public void setRich(bool flag)
        {
            if (flag)
                m_data = m_data | RICH_MASK; // 1 << 1
            else
                m_data = m_data & ~RICH_MASK;
        }
        public void setTall(bool flag)
        {
            if (flag)
                m_data = m_data | TALL_MASK; // 1 << 2
            else
                m_data = m_data & ~TALL_MASK;
        }
        public void setCute(bool flag)
        {
            if (flag) m_data = m_data | CUTE_MASK; // 1 << 3
            else m_data = m_data & ~CUTE_MASK;
        }
        public bool isMale()
        {
            if ((m_data & MALE_MASK) != 0)
                return true;
            else
                return false;
        }
        public bool isRich()
        {
            if ((m_data & RICH_MASK) != 0)
                return true;
            else
                return false;
        }
        public bool isTall()
        {
            if ((m_data & TALL_MASK) != 0)
                return true;
            else
                return false;
        }
        public bool isCute()
        {
            if ((m_data & CUTE_MASK) != 0)
                return true;
            else
                return false;
        }
        public override String ToString()
        {
            String tmp = "";
            tmp = tmp + ms_name + " is ";
            if (isMale())
                tmp = tmp + "a boy and he is ";
            else
                tmp = tmp + "a girl and she is ";
            if (isRich())
                tmp = tmp + "rich, ";
            else
                tmp = tmp + "poor, ";
            if (isTall())
                tmp = tmp + "tall and ";
            else
                tmp = tmp + "short and ";
            if (isCute())
                tmp = tmp + "cute.";
            else
                tmp = tmp + "ugly.";
            return tmp;
        }
        public void readDataFromConsole() // 입력을 읽어주는 함수
        {
            String buffer = Console.ReadLine();
            char[] delemeter = new char[1];
            delemeter[0] = ' ';
            String[] data = buffer.Split(delemeter);

            ms_name = data[0];

            if (data[1].Equals("1"))
                setMale(true);
            else
                setMale(false);
            if (data[2].Equals("1"))
                setRich(true);
            else
                setRich(false);
            if (data[3].Equals("1"))
                setTall(true);
            else
                setTall(false);
            if (data[4].Equals("1"))
                setCute(true);
            else
                setCute(false);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Student x = new Student("kim");
            Student y = new Student("lee", true, false, true, true);
            Student z = new Student("park", false, false, true, false);

            x.setRich(true);
            x.setCute(true);

            y.setMale(false);
            y.setRich(true);

            z.setTall(false);
            z.setCute(true);

            Console.WriteLine(x);
            Console.WriteLine(y);
            Console.WriteLine(z);

            Student[] st = new Student[5];

            Console.WriteLine("Type information for 5 students as \"park 0 1 0 1\"");

            int i;
            for (i = 0; i < 5; i++)
            {
                st[i] = new Student();
                st[i].readDataFromConsole();
            }

            Console.WriteLine("== favorite spouse candidates list ==");
            for (i = 0; i < 5; i++)
            {
                if (st[i].isRich() && st[i].isCute()) // 돈도 많고 귀여우면 출력
                {
                    Console.WriteLine(st[i].getName());
                }
            }
        }
    }
}
