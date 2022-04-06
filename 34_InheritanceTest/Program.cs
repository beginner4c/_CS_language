using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _34_InheritanceTest
{
    class Point2D
    {
        public Point2D(int x, int y) // constructor
        {
            m_x = x;
            m_y = y;
        }

        // data member
        // protected는 하위 child class에서 사용할 수 있다
        protected int m_x;
        protected int m_y;

        public void setX(int x)
        {
            m_x = x;
        }

        public void setY(int y)
        {
            m_y = y;
        }

        public int getX()
        {
            return m_x;
        }

        public int getY()
        {
            return m_y;
        }
        public Point2D add(Point2D p)
        {
            Point2D tmp = new Point2D(getX() + p.getX(), getY() + p.getY());

            return tmp;
        }

        public void move(int dx, int dy) // child class에서 override가 발생할 때 최상위 parent class에서는 virtual을 붙여줘야 한다
        {
            m_x = m_x + dx;
            m_y = m_y + dy;
        }
        virtual public void move(int delta)
        {
            move(delta, delta);
        }

        virtual public double magnitude()
        {
            return Math.Sqrt(getX() * getX() + getY() * getY());
        }

        public override string ToString()
        {
            return "[" + getX() + ", " + getY() + "]";
        }
    }

    class Point3D : Point2D // Point2D를 상속받은 Point3D class를 생성
    {
        public Point3D(int x, int y, int z)
            : base(x,y) // Point2D의 constructor를 x,y 를 parameter로 호출
        {
            m_z = z;
        }

        // data member
        private int m_z;

        public void setZ(int z)
        {
            m_z = z;
        }
        public int getZ()
        {
            return m_z;
        }

        public Point3D add(Point3D p)
        {
            Point3D tmp = new Point3D(getX() + p.getX(), getY() + p.getY(), getZ() + p.getZ());
            return tmp;
        }

        public void move(int dx, int dy, int dz)
        {
            base.move(dx, dy);
            setZ(getZ() + dz);
        }
        // 상속받은 함수를 재정의
        public override void move(int delta) // 이런식으로 parent class에서 같은 parameter로 구현되는 함수는 override를 한다
        {
            move(delta, delta, delta);
        }

        public override double magnitude()
        {
            return Math.Sqrt(m_x * m_x + m_y * m_y + m_z * m_z);
        }

        public override string ToString()
        {
            return "[" + getX() + ", " + getY() + ", " + getZ() + "]";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Point2D p = new Point2D(10, 20);
            Point2D q = new Point2D(30, 40);
            Point2D r;

            p.setX(100);
            p.setY(200);

            r = p.add(q);

            Console.WriteLine("[" + r.getX() + ", " + r.getY() + "]");

            p.move(200, 300);
            q.move(1000);

            Console.WriteLine("p = " + p);
            Console.WriteLine("q = " + q);
            Console.WriteLine("r = " + r);
            Console.WriteLine(r.magnitude());

            // Point2D와 유사한 기능이 많은 Point3D
            Point3D pp = new Point3D(10, 20, 30);
            Point3D qq = new Point3D(30, 40, 50);
            Point3D rr;

            pp.setX(100);
            pp.setY(200);
            pp.setZ(300);

            rr = pp.add(qq);
            Console.WriteLine("[" + rr.getX() + ", " + rr.getY() + ", " + rr.getZ() + "]");

            pp.move(200, 300, 400);
            qq.move(1000);

            Console.WriteLine("pp = " + pp);
            Console.WriteLine("qq = " + qq);
            Console.WriteLine("rr = " + rr);
            Console.WriteLine(rr.magnitude());
        }
    }
}
