using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 29번째 프로그램이 전부 static function으로 이루어져 있었다
// 그 static function 전부 클래스 내부에 member function으로 고쳐냄

namespace _30_matrix_test
{
    class Matrix
    {
        public Matrix(int row, int col) // constructor
        {
            m_ptr = new int[row, col];
            m_row = row;
            m_col = col;
        }
        // data member
        int[,] m_ptr;
        int m_row, m_col;

        public int row()
        {
            return m_row;
        }
        public int col()
        {
            return m_col;
        }

        public void set(int row_num, int col_num, int v)
        {
            m_ptr[row_num, col_num] = v;
        }

        public int get(int row_num, int col_num)
        {
            return m_ptr[row_num, col_num];
        }

        public void print()
        {
            for (int i = 0; i < this.m_row; i++)
            {
                for (int j = 0; j < this.m_col; j++)
                {
                    Console.Write(m_ptr[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public Matrix add(Matrix a)
        {
            Matrix c = new Matrix(a.row(), a.col());
            int res;

            if(m_row != a.row() || m_col != a.col())
            {
                Console.WriteLine("error occurs - size mismatch");
                Environment.Exit(-1);
            }

            for (int i = 0; i < c.row(); i++)
            {
                for (int j = 0; j < c.col(); j++)
                {
                    res = this.m_ptr[i, j] + a.get(i,j);
                    c.set(i, j, res);
                }
            }
            return c;
        }

        public Matrix subtract(Matrix a)
        {
            if (m_row != a.row() || m_col != a.col())
            {
                Console.WriteLine("error occurs - size mismatch");
                Environment.Exit(-1);
            }

            Matrix c = new Matrix(a.row(), a.col());
            int res;

            for (int i = 0; i < c.row(); i++)
            {
                for (int j = 0; j < c.col(); j++)
                {
                    res = this.m_ptr[i, j] - a.get(i, j);
                    c.set(i, j, res);
                }
            }
            return c;
        }

        public Matrix multiply(int x)
        {
            Matrix c = new Matrix(row(), col());

            for(int i = 0; i < row(); i++)
            {
                for(int j = 0; j < col(); j++)
                {
                    c.set(i, j, m_ptr[i, j]*x);
                }
            }
            return c;
        }

        public Matrix multiply(Matrix a)
        {
            if (col() != a.row())
            {
                Console.WriteLine("error occurs - size mismatch");
                Environment.Exit(-1);
            }

            Matrix c = new Matrix(row(), a.col());

            for (int i = 0; i < row(); i++)
            {
                for (int j = 0; j < a.col(); j++)
                {
                    int res = 0;
                    for (int k = 0; k < col(); k++)
                    {
                        res = res + m_ptr[i, k] * a.m_ptr[k, j];
                    }
                    c.set(i, j, res);
                }
            }
            return c;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            

            Matrix x = new Matrix(3, 4);

            x.set(0, 0, 1);
            x.set(0, 1, 2);
            x.set(0, 2, 3);
            x.set(0, 3, 4);
            x.set(1, 0, 5);
            x.set(1, 1, 6);
            x.set(1, 2, 7);
            x.set(1, 3, 8);
            x.set(2, 0, 9);
            x.set(2, 1, 10);
            x.set(2, 2, 11);
            x.set(2, 3, 12);

            Matrix y = new Matrix(3, 4);

            y.set(0, 0, 1);
            y.set(0, 1, 1);
            y.set(0, 2, 1);
            y.set(0, 3, 1);
            y.set(1, 0, 2);
            y.set(1, 1, 2);
            y.set(1, 2, 2);
            y.set(1, 3, 2);
            y.set(2, 0, 3);
            y.set(2, 1, 3);
            y.set(2, 2, 3);
            y.set(2, 3, 3);

            Matrix w = new Matrix(4, 2);

            w.set(0, 0, 1);
            w.set(0, 1, 1);
            w.set(1, 0, 1);
            w.set(1, 1, 1);
            w.set(2, 0, 2);
            w.set(2, 1, 2);
            w.set(3, 0, 2);
            w.set(3, 1, 2);

            Matrix z;

            x.print();
            y.print();

            z = x.add(y);
            z.print();

            z = x.subtract(y);
            z.print();

            z = x.multiply(4);
            z.print();

            z = x.multiply(w);
            z.print();
        }
    }
}
