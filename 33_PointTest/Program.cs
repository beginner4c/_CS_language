using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 상속에 대한 기본적인 사용 이전 상속을 사용치 않고 복사를 통해 비슷한 기능을 사용하는 클래스 2개를 구현

namespace _33_PointTest
{
    class Point2D
    {
        public Point2D(int x, int y) // constructor
        {
            m_x = x;
            m_y = y;
        }

        // data member
        int m_x;
        int m_y;

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
        
        public void move (int dx, int dy)
        {
            m_x = m_x + dx;
            m_y = m_y + dy;
        }
        public void move (int delta)
        {
            move(delta, delta);
        }

        public double magnitude()
        {
            return Math.Sqrt(getX() * getX() + getY() * getY());
        }

        public override string ToString()
        {
            return "[" + getX() + ", " + getY() + "]";
        }
    }

    // Point2D class와 비슷한 기능을 하는 함수를 Point2D 내용을 복사해서 구현
    class Point3D
    {
        public Point3D(int x, int y, int z) // constructor
        {
            m_x = x;
            m_y = y;
            m_z = z;
        }

        // data member
        int m_x;
        int m_y;
        int m_z;

        public void setX(int x)
        {
            m_x = x;
        }

        public void setY(int y)
        {
            m_y = y;
        }
        public void setZ(int z)
        {
            m_z = z;
        }

        public int getX()
        {
            return m_x;
        }

        public int getY()
        {
            return m_y;
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
            m_x = m_x + dx;
            m_y = m_y + dy;
            m_z = m_z + dz;
        }
        public void move(int delta)
        {
            move(delta, delta, delta);
        }

        public double magnitude()
        {
            return Math.Sqrt(getX() * getX() + getY() * getY() + getZ() * getZ());
        }

        public override string ToString()
        {
            return "[" + getX() + ", " + getY() + ", " + getZ() +"]";
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
