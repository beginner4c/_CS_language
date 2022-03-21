using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _6_PointTest
{
    class Point
    {
        // constructor
        // argument가 없는 default constructor
        public Point()
            : this(0,0) // 여기 있는 constructor에 0,0을 넣은 다른 constructor를 호출
        {
        }

        // initalization을 실행하는 constructor
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        // data member : class 내에 소속된 data
        private int x, y;

        public int X // MS에서만 존재하는 property
        {
            get
            {
                return this.x;
            }
            set
            {
                value = this.x; // 보통 들어오는 값이 하나이기에 value 라는 걸로 고정
            }
        }

        public int getX()
        {
            return x;
        }
        public int setX(int n)
        {
            return this.x = n;
        }
        public int getY()
        {
            return y;
        }
        public int setY(int n)
        {
            return this.y = n;
        }

        // member function : class 내에 소속된 function
        public void findCenterPoint(Point q, Point r)
        {
            this.x = (q.x + r.x) / 2; // data member를 사용할 때는 this를 적어도 안적어도 상관없다
            this.y = (q.y + r.y) / 2;
        }

        // 객체에 바운드(bound)되어 있지 않은 함수
        // this가 없는 함수
        public static void add(Point p, int dx, int dy)
        {
            p.x = p.x + dx;
            p.y = p.y + dy;
        }

        // 같은 add지만 formal parameter가 다르면 이름이 같아도 된다
        public void add(int dx, int dy)
        {
            this.x = this.x + dx;
            this.y = this.y + dy;
        }

        // 객체에 바운드(bound)되어 있는 함수
        // this가 있는 함수
        public void add(int delta)
        {
            add(delta, delta);
        }

        public Point addPoint(Point p2)
        {
            Point p = new Point();
            p.x = this.x + p2.y;
            p.y = this.y + p2.x;
            return p;
        }

        public void printPoint(String name)
        {
            Console.WriteLine("{0} = ({1}, {2})", name, this.x, this.y);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Constructor 생성자
            Point pa = new Point(10, 10); // object instantiation
            Point pb = new Point(20, 30);
            Point pc = new Point();
            Point pd;

            /* 초기화(initialization)라고 한다
            pa.x = 10;
            pa.y = 10;

            pb.x = 20;
            pb.y = 30;
            */
            pa.setX(100);
            pa.setY(100);

            pb.setX(200);
            pb.setY(300);

            int xxx = pa.getX();
            int yyy = pa.getY();

            // property 사용
            pc.X = 100; // set
            int xx = pa.X; // get

            // function call => message sending
            // 일반 member function 호출
            pc.findCenterPoint(pa,pb); // 여기서 pc를 receiver라고 한다(혹은 객체, reference)
            // pa.add(100, 200); // 일반 member function 호출의 경우
            Point.add(pa, 100, 200); // static member function 호출의 경우 -> 실제로 사용하지 않는다
            pb.add(1000);
            pd = pa.addPoint(pb);
            pa.printPoint("A");
            pb.printPoint("B");
            pc.printPoint("C");
            pd.printPoint("D");
        }
    }
}
