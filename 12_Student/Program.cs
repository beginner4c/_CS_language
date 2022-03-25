using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _12_Student
{
    class Student
    {
        public Student()
        {

        }

        // data member는 보통 private으로 처리하고 member function으로 처리
        private String name;
        private int kor;
        private int eng;
        private int math;
        private int total;
        private double ave;
        // data member를 세팅하는 함수
        public void setData(String[] st)
        {
            this.name = st[0];
            this.kor = int.Parse(st[1]);
            this.eng = int.Parse(st[2]);
            this.math = int.Parse(st[2]);
        }
        // 합계 세팅 함수
        public void calculateTotal()
        {
            this.total = kor + eng + math;
        }
        // 평균 값 세팅 함수
        public void calculateAve()
        {
            this.ave = total / 3.0;
        }
        // 출력하는 함수

        public void print()
        {
            String format = String.Format("{0,7}{1,8}{2,10}{3,10}{4,10}{5,8:F1}",
                    name, kor, eng, math, total, ave);
            Console.WriteLine(format);
        }

        public static void print(Student[] stu)
        {
            Console.WriteLine("   성명    국어      영어      수학      합계      평균");

            for (int i = 0; i < stu.Length; i++)
                stu[i].print();

            Console.WriteLine("========================================================");            
        }

        // 합계 기준으로 정렬
        public static void sortByTotal(Student[] stu)
        {
            int n = stu.Length;

            for(int i = 0; i< n - 1; i++)
                for(int j =0; j<n-i-1; j++)
                    if(stu[j].total > stu[j + 1].total)
                    {
                        Student tmp;

                        tmp = stu[j];
                        stu[j] = stu[j + 1];
                        stu[j + 1] = tmp;
                    }
        }

        // 이름으로 비교해서 정렬
        public static void sortByName(Student[] stu)
        {
            int n = stu.Length;

            for(int i = 0; i< n-1; i++)
                for(int j = 0; j<n-i-1; j++)
                    if(stu[i].name.CompareTo(stu[j+1].name) > 0)
                    {
                        Student tmp;

                        tmp = stu[j];
                        stu[j] = stu[j + 1];
                        stu[j + 1] = tmp;
                    }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Student[] s;
            FileStream file; // System.IO 네임스페이스를 가져와야 사용 가능
            int n;

            // 파일을 가져오는 FileStream
            file = new FileStream("data.txt", FileMode.Open, FileAccess.Read); // 프로젝트 파일 bin/Debug 폴더 안에 data.txt 놓기
            // data.txt 는 5가 첫 줄이고 아래 줄에 이름과 정수형 숫자들이 있음

            StreamReader reader = new StreamReader(file); // 파일을 읽어오는 클래스
            String buffer = reader.ReadLine(); // ReadLine은 한 줄씩 읽어오는 함수

            n = int.Parse(buffer); // 문자열이기 때문에 정수형으로 casting

            Console.WriteLine(n);

            s = new Student[n]; // 배열 크기 5 지정

            for(int i = 0; i < n; i++)
            {
                buffer = reader.ReadLine(); // 한 줄 읽어옴
                char[] separator = new char[1]; // Split을 위한 separator 지정
                separator[0] = ' '; // 기준이 될 공백
                String[] st = buffer.Split(separator);

                s[i] = new Student();

                s[i].setData(st);
                // data를 다루는 함수를 따로 호출한다
                /*
                s[i].name = st[0];
                s[i].kor = int.Parse(st[1]);
                s[i].eng = int.Parse(st[2]);
                s[i].math = int.Parse(st[3]);
                */
            }

            reader.Close();

            for (int i = 0; i < n; i++) {
                s[i].calculateTotal();
                s[i].calculateAve();
                /* 이런 계산 부분도 함수로 처리
                s[i].total = s[i].kor + s[i].eng + s[i].math;
                s[i].ave = s[i].total / 3.0;
                */
            }

            Student.print(s);
            // 아래 부분 역시 함수로 처리하는 게 좋다
            /*
            String format = String.Format("{0,7}{1,8}{2,10}{3,10}{4,10}{5,8:F1}",
                s[i].name, s[i].kor, s[i].eng, s[i].math, s[i].total, s[i].ave);
            Console.WriteLine(format);
            */

            Student.sortByTotal(s);
            Student.print(s);
            Student.sortByName(s);
            Student.print(s);

            file.Close(); // 파일 풀어주기
        }
    }
}
