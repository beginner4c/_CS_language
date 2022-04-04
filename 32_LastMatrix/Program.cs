using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 기존 matrix와 크게 다른 건 없지만 copy 기능이 추가

namespace _32_LastMatrix
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
            // 뺄셈은 귀찮
            Matrix tmp = new Matrix(m_row, m_col);
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
    class TestMatrix
    {
        static int readInt()
        {
            String s = Console.ReadLine();
            return int.Parse(s);
        }
        static void Main(string[] args)
        {
            int m, n;
            int i, j;

            Console.WriteLine("2 차원 배열을 두 개를 입력:");
            Console.Write("행 값은 얼마인가용? ");
            m = readInt();
            Console.Write("열 값은 얼마인가용? ");
            n = readInt();
            Console.WriteLine("첫번째 배열 A에 들어갈 데이터:");

            Matrix A = new Matrix(m, n);

            for (i = 0; i < m; i++)
                for (j = 0; j < n; j++)
                {
                    double x;

                    Console.Write("A[" + i + "][" + j + "] = ");
                    x = readInt();
                    A.set(i, j, x);
                }
            Console.WriteLine("A = \n" + A);

            Console.WriteLine("두번째 배열 B에 들어갈 데이터:");

            Matrix B = new Matrix(m, n);

            B.readDataFromConsole();
            Console.WriteLine("B = \n" + B);

            Matrix X;

            X = A.add(B);
            Console.WriteLine("A + B = \n" + X);

            // 배열의 곱도?
            // c[i][j] = a[i][0]*b[0][j] + a[i][1]*b[1][j] + ... + a[i][k]*b[k][j]

            Console.WriteLine(n + "행 3열 짜리 배열에 들어갈 데이터:");

            Matrix C = new Matrix(n, 3);

            C.readDataFromConsole();
            Console.WriteLine("C = \n" + C);

            Matrix Y;

            Y = B.multiply(C);
            Console.WriteLine("B * C = \n" + Y);

            Y = B.multiply(10);
            Console.WriteLine("B * 10 = \n" + Y);

            A = B; // shallow copy, 얕은 복사 - 같은 reference를 공유하는 거

            A.set(B); // deep copy, 깊은 복사 - 같은 데이터를 가졌지만 다른 reference를 가진 구조
        }
    }
}
