using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 기존에 있던 Matrix class를 활용해 새로운 상속 class 생성

namespace _35_ProductMatrix
{
    class Matrix
    {
        protected double[][] m_ptr;
        protected int m_row;
        protected int m_col;
        protected int m_precision;
        protected void copy(Matrix m)
        {
            int i, j;

            m_row = m.m_row;
            m_col = m.m_col;
            m_precision = m.m_precision;
            m_ptr = new double[m_row][];
            for (i = 0; i < m_row; i++)
                m_ptr[i] = new double[m_col];

            for (i = 0; i < m_row; i++)
                for (j = 0; j < m_col; j++)
                    m_ptr[i][j] = m.m_ptr[i][j];
        }
        protected int getMaxDataWidth()
        {
            return 0;
        }
        public Matrix()
        {
            m_row = 0;
            m_col = 0;
            m_ptr = null;
            m_precision = 0; // 마치 정수형 인것처럼 출력
        }
        public Matrix(int row, int col)
        {
            m_row = row;
            m_col = col;
            m_precision = 0;
            m_ptr = new double[row][];
            for (int i = 0; i < row; i++)
                m_ptr[i] = new double[col];
        }
        public Matrix(Matrix m)
        {
            copy(m);
        }
        public int row()
        {
            return m_row;
        }
        public int column()
        {
            return m_col;
        }
        public void setPrecision(int x)
        {
            m_precision = x;
        }
        public double get(int i, int j)
        {
            return m_ptr[i][j];
        }
        public void set(int i, int j, double v)
        {
            m_ptr[i][j] = v;
        }
        public Matrix set(Matrix m)
        {
            copy(m);
            return this;
        }
        public Matrix add(Matrix m)
        {
            if (m_row != m.m_row || m_col != m.m_col)
            {
                Console.WriteLine("error occurs! - size mismatch");
                Environment.Exit(-1);
            }

            Matrix tmp = new Matrix(m_row, m_col);

            for (int i = 0; i < m_row; i++)
                for (int j = 0; j < m_col; j++)
                    tmp.m_ptr[i][j] = m_ptr[i][j] + m.m_ptr[i][j];

            return tmp;
        }
        public Matrix subtract(Matrix m)
        {
            Matrix tmp = new Matrix(m_row, m_col);
            for (int i = 0; i < m_row; i++)
                for (int j = 0; j < m_col; j++)
                    tmp.m_ptr[i][j] = m_ptr[i][j] - m.m_ptr[i][j];

            return tmp;
        }
        public Matrix multiply(Matrix m)
        {
            if (m_col != m.m_row)
            {
                Console.WriteLine("error occurs! - size mismatch for multplication");
                Environment.Exit(-1);
            }

            Matrix tmp = new Matrix(m_row, m.m_col);

            for (int i = 0; i < m_row; i++)
                for (int j = 0; j < m.m_col; j++)
                {
                    double sum = 0;
                    for (int k = 0; k < m_col; k++)
                        sum = sum + m_ptr[i][k] * m.m_ptr[k][j];
                    tmp.m_ptr[i][j] = sum;
                }

            return tmp;
        }
        public Matrix multiply(double x)
        {
            Matrix tmp = new Matrix(m_row, m_col);

            for (int i = 0; i < m_row; i++)
                for (int j = 0; j < m_col; j++)
                    tmp.m_ptr[i][j] = m_ptr[i][j] * x;

            return tmp;
        }
        public void readDataFromConsole()
        {
            int row = m_row;
            int col = m_col;
            double[][] p = m_ptr;
            int i, j;

            for (i = 0; i < row; i++)
                for (j = 0; j < col; j++)
                {
                    double x;
                    Console.Write("data[" + i + "][" + j + "] = ");
                    x = Double.Parse(Console.ReadLine());
                    p[i][j] = x;
                }
        }
        public override String ToString()
        {
            String tmp = "";
            int row = m_row;
            int col = m_col;
            double[][] p = m_ptr;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    tmp = tmp + p[i][j] + " ";
                }
                tmp = tmp + "\n";
            }
            return tmp;
        }
    }
    class ProductMatrix : Matrix // 기존의 Matrix를 상속받은 ProductMatrix class
    {
        public ProductMatrix() // constructor를 부모 class에서 가져온다
            : base()
        {

        }
        public ProductMatrix(int row, int col) // constructor를 부모 class에서 가져온다
            : base(row, col)
        {
        }
        public void readDataFromConsole() // override 없이도 사용은 가능하지만 부모 클래스의 동일 이름의 class에는 접근하기 힘들다
        {
            int row = m_row;
            int col = m_col;
            double[][] p = m_ptr;
            int i;

            for (i = 0; i < row; i++)
            {
                Console.WriteLine((i + 1) + "번째 사원이 ...");
                Console.Write("   냉장고는 몇 대? ");
                p[i][0] = Double.Parse(Console.ReadLine());
                Console.Write("   에어콘은 몇 대? ");
                p[i][1] = Double.Parse(Console.ReadLine());
                Console.Write("   선풍기는 몇 대? ");
                p[i][2] = Double.Parse(Console.ReadLine());
            }
        }
        public override String ToString() // object class의 함수 재정의
        {
            String tmp = "";
            int row = m_row;
            int col = m_col;
            double[][] p = m_ptr;
            int i;

            tmp = tmp + "          냉장고 에어콘 선풍기\n";
            for (i = 0; i < row; i++)
            {
                tmp = tmp + (i + 1) + "번 사원";
                tmp = tmp + "    " + (int)p[i][0] + "대";
                tmp = tmp + "    " + (int)p[i][1] + "대";
                tmp = tmp + "    " + (int)p[i][2] + "대";
                tmp = tmp + "\n";
            }
            tmp = tmp + "\n";
            return tmp;
        }
    }
    class TestProductMatrix
    {
        static void Main(string[] args)
        {
            int m;
            int n = 3; // 사원별 냉장고, 에어콘, 선풍기 판매수량 
            int i;

            Console.WriteLine("메트릭스 한번 사용");
            Console.Write("사원 수는 몇명? ");
            m = int.Parse(Console.ReadLine());
            Console.WriteLine("각 사원들의 매출 수를 입력");

            ProductMatrix A = new ProductMatrix(m, n);

            A.readDataFromConsole();
            Console.WriteLine("\n이정도 팔았다\n" + A);

            Matrix B = new Matrix(n, 1);

            B.set(0, 0, 100); // 냉장고 가격 100 만원
            B.set(1, 0, 50); // 에어콘 가격 50 만원
            B.set(2, 0, 10); // 선풍기 가격 10 만원

            Matrix C;

            C = A.multiply(B);
            Console.WriteLine("그렇다면 ...");
            for (i = 0; i < C.row(); i++)
            {
                Console.Write((i + 1) + "번 사원은 ");
                Console.WriteLine((int)C.get(i, 0) + "만원 만큼 판매했다");
            }
        }
    }
}
