using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 전에 만든 matrix test 프로그램에 가변배열을 추가

namespace _31_matrix_DynamicArray
{
    class Matrix
    {
        
        public Matrix() // default constructor
        {
            m_row = 0;
            m_col = 0;
            m_ptr = null;
            m_precision = 0;
        }
        public Matrix(int row, int col) // constructor
        {
            m_ptr = new double[row][];
            m_row = row;
            m_col = col;
            m_precision = 0;

            for (int i = 0; i < m_row; i++)
            {
                m_ptr[i] = new double[m_col];
            }
        }
        // data member
        protected double[][] m_ptr;
        protected int m_row, m_col;
        protected int m_precision;

        public int row()
        {
            return m_row;
        }
        public int col()
        {
            return m_col;
        }
        public void set(int row_num, int col_num, double v)
        {
            m_ptr[row_num][col_num] = v;
        }

        public double get(int row_num, int col_num)
        {
            return m_ptr[row_num][col_num];
        }

        public void print()
        {
            for (int i = 0; i < this.m_row; i++)
            {
                for (int j = 0; j < this.m_col; j++)
                {
                    Console.Write(m_ptr[i][j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public Matrix add(Matrix a)
        {
            Matrix c = new Matrix(a.row(), a.col());
            double res;

            if (m_row != a.row() || m_col != a.col())
            {
                Console.WriteLine("error occurs - size mismatch");
                Environment.Exit(-1);
            }

            for (int i = 0; i < c.row(); i++)
            {
                for (int j = 0; j < c.col(); j++)
                {
                    res = m_ptr[i][j] + a.get(i, j);
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
            double res;

            for (int i = 0; i < c.row(); i++)
            {
                for (int j = 0; j < c.col(); j++)
                {
                    res = this.m_ptr[i][j] - a.get(i, j);
                    c.set(i, j, res);
                }
            }
            return c;
        }

        public Matrix multiply(int x)
        {
            Matrix c = new Matrix(row(), col());

            for (int i = 0; i < row(); i++)
            {
                for (int j = 0; j < col(); j++)
                {
                    c.set(i, j, m_ptr[i][j] * x);
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
                    double res = 0;
                    for (int k = 0; k < col(); k++)
                    {
                        res = res + m_ptr[i][k] * a.m_ptr[k][j];
                    }
                    c.set(i, j, res);
                }
            }
            return c;
        }

        public void readDataFromConsole()
        {
            int row = this.row();
            int col = this.col();

            double[][] p = m_ptr;
            
            for(int i = 0; i< row; i++)
            {
                for(int j =0;j<col; j++)
                {
                    double x;
                    Console.Write("data[" + i + "][" + j + "] = ");
                    x = Double.Parse(Console.ReadLine());
                    p[i][j] = x;
                }
            }
        }

        public override string ToString()
        {
            return "(" + this.row() +", " + this.col() + ") = ";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {


            Matrix x = new Matrix(3, 4);
            Console.WriteLine("Type Matrix " + nameof(x).ToUpper() + x);
            x.readDataFromConsole();

            Matrix y = new Matrix(3, 4);
            Console.WriteLine("Type Matrix " + nameof(y).ToUpper() + y);
            y.readDataFromConsole();

            Matrix w = new Matrix(4, 2);
            Console.WriteLine("Type Matrix " + nameof(w).ToUpper() + w);
            w.readDataFromConsole();

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
