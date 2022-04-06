using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 이전보다 조금 더 유연해진 프로그램
// StringArray 클래스를 통해서 문자열들을 효율적으로 관리할 수 있게 만들었다
// 차후에 다른 프로그램을 만들 때도 사용할 수 있게 하는 상속 제도를 좀 더 보인다

namespace _36_another_Matrix
{
    class Matrix // 이전 프로그램에서 가져온 Matrix class
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

    class StringArray // String을 여러개 관리하기 위해 만든 class
    {
        private String[] pArray;
        private int nArray;
        public StringArray()
        {
            nArray = 0;
            pArray = null;
        }
        public StringArray(int n)
        {
            nArray = n;
            pArray = new String[n];
        }
        public StringArray(StringArray sa) // 들어온 StringArray에 deep copy를 실행하는 함수
        {
            nArray = sa.nArray;
            pArray = new String[nArray];
            for (int i = 0; i < nArray; i++)
            {
                pArray[i] = sa.pArray[i];
            }
        }
        public int size()
        {
            return nArray;
        }
        public String get(int i)
        {
            return pArray[i];
        }
        public void set(int i, String s)
        {
            pArray[i] = s;
        }
        public int getMaxStringLength() // 반복을 통해 제일 큰 길이를 반환하는 함수
        {
            int maxLength = 0;

            for (int i = 0; i < nArray; i++)
            {
                if (pArray[i].Length > maxLength)
                    maxLength = pArray[i].Length;
            }
            return maxLength;
        }
        public void readDataFromConsole() 
        {
            String buffer;

            for (int i = 0; i < nArray; i++)
            {
                Console.Write((i + 1) + "번째 이름은: ");
                buffer = Console.ReadLine();
                pArray[i] = buffer;
            }
        }
        public override String ToString() // override
        {
            String tmp = "";
            for (int i = 0; i < nArray; i++)
            {
                tmp = tmp + pArray[i] + "\n";
            }
            return tmp;
        }
    }
    class MatrixWithNames : Matrix // Matrix 클래스를 상속 받음
    {
        private StringArray rowNames;
        private StringArray colNames;
        private String unitName;
        private String question;
        public MatrixWithNames()
            : base()
        {
            unitName = "";
            question = "";
            rowNames = null;
            colNames = null;
        }
        public MatrixWithNames(int row, int col)
            : base(row, col)
        {
            unitName = "";
            question = "";
            rowNames = null;
            colNames = null;
        }
        public MatrixWithNames(int row, int col, StringArray rNames, StringArray cNames, String uName, String q)
            : base(row, col)
        {
            unitName = uName;
            question = q;
            rowNames = new StringArray(rNames);
            colNames = new StringArray(cNames);
        }
        public MatrixWithNames(Matrix m, StringArray rNames, StringArray cNames, String uName, String q)
            : base(m)
        {
            unitName = uName;
            question = q;
            rowNames = new StringArray(rNames);
            colNames = new StringArray(cNames);
        }
        public void setRowNames(StringArray names)
        {
            rowNames = new StringArray(names);
        }
        public void setColumnNames(StringArray names)
        {
            colNames = new StringArray(names);
        }
        public void setUnitName(String name)
        {
            unitName = name;
        }
        public void setQuestion(String name)
        {
            question = name;
        }
        public void readDataFromConsole() // 상위 클래스 이름과 동일하다
        {
            int row = m_row;
            int col = m_col;
            double[][] p = m_ptr;
            int i, j;

            for (i = 0; i < row; i++)
            {
                Console.WriteLine(rowNames.get(i) + "의");
                for (j = 0; j < col; j++)
                {
                    Console.Write("   " + colNames.get(j) + question + "? ");
                    p[i][j] = Double.Parse(Console.ReadLine());
                }
            }
        }
        public override String ToString()
        {
            int row = m_row;
            int col = m_col;
            double[][] p = m_ptr;

            String tmp = "       ";

            for (int i = 0; i < col; i++)
            {
                tmp = tmp + colNames.get(i) + " ";
            }

            tmp = tmp + "\n";

            for (int i = 0; i < row; i++)
            {
                tmp = tmp + rowNames.get(i) + " ";
                for (int j = 0; j < col; j++)
                {
                    tmp = tmp + p[i][j] + "    ";
                }
                tmp = tmp + "\n";
            }
            return tmp;
        }
    }

    class TestMatrixWithNames
    {
        // 어지간하면 메인에서 사용 스타일 비슷한 다른 메인으로 바꿔도 사용 가능해진다
        static void Main(string[] args)
        {
            int nProducts;

            Console.Write("제품의 종류는 몇가지 ? ");
            nProducts = int.Parse(Console.ReadLine());

            StringArray productNames = new StringArray(nProducts);

            Console.WriteLine("제품의 명칭:");

            productNames.readDataFromConsole();

            StringArray colNames = new StringArray(1);
            colNames.set(0, "단가");
            MatrixWithNames productPrices = new MatrixWithNames(nProducts, 1, productNames, colNames, "만원", "는 얼마");

            Console.WriteLine("각 제품의 단가:");

            productPrices.readDataFromConsole();

            int nClerks;

            Console.Write("판매원은 몇분 ? ");
            nClerks = int.Parse(Console.ReadLine());

            StringArray clerkNames = new StringArray(nClerks);

            Console.WriteLine("판매원들 성함:");

            clerkNames.readDataFromConsole();

            //	MatrixWithNames salesData = new MatrixWithNames(nClerks,nProducts,clerkNames,productNames,"개"," 판매량은"); // 졸라리 길어서 아래처럼 잘라놓음
            MatrixWithNames salesData = new MatrixWithNames(nClerks, nProducts); // nCLerks행 nProducts열 배열을 만든다
            salesData.setRowNames(clerkNames);
            salesData.setColumnNames(productNames);
            salesData.setUnitName("개");
            salesData.setQuestion(" 판매량은");

            Console.WriteLine("각 판매원들이 판매한 제품들의 수량:");

            salesData.readDataFromConsole();

            Console.WriteLine("\n지금까지 친 데이터를 확인.");

            Console.WriteLine("=== 제품 단가 ===");
            Console.Write(productPrices);
            Console.WriteLine("=================");

            Console.WriteLine("=== 판매 자료 ===");
            Console.Write(salesData);
            Console.WriteLine("=================");

            Matrix salesTotalPerClerk;

            salesTotalPerClerk = salesData.multiply(productPrices); // 행렬의 곱 실행

            Console.WriteLine("=== 결과 자료 ===");
            Console.Write(salesTotalPerClerk);
            Console.WriteLine("=================");

            StringArray summaryNames = new StringArray(1);
            summaryNames.set(0, "총판매액");
            MatrixWithNames anotherSalesTotalPerClerk = new MatrixWithNames(salesTotalPerClerk, clerkNames, summaryNames, "만원", "얼마"); 

            Console.WriteLine("=== 최종 결과 ===");
            Console.Write(anotherSalesTotalPerClerk);
            Console.WriteLine("=================");
        }
    }
}
