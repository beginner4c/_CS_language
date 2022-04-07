using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// dynamic binding 을 위한 abstract class, function 생성과 사용

namespace _39_zoo3
{
    abstract class Animal // abstract function을 사용하기 위해 abstract class로 생성
    {
        public Animal(String name)
        {
            this.name = name;
        }

        protected String name; // 공통적으로 사용하는 데이터 멤버를 선언
        protected int weight; // access modifier를 protected를 하면 부모 자식 간에 사용이 가능해진다

        protected void increaseWeight(int w) // 중복되는 코드 제거용 함수
        {
            weight += w;
        }
        public override string ToString() // 중복되는 코드 제거용 함수
        {
            String s = "";
            s += name + " " + "몸무게 : " + weight;
            return s;
        }

        // 내용물이 없는 하위 클래스에서 재정의하는 abstract 함수
        public abstract void makeSound(); // 직접 사용되는 일 없이 하위 클래스에서 override를 통해 구현되는 함수다


        // 직접 사용되는 일이 있고 override를 해야 할 함수의 경우 virtual 함수로 만들어줘야 한다
        public virtual void eat(int x) // 하위 클래스에서도 직접적으로 들어가는 코드가 있다
        {
            // weight += x;
            increaseWeight(x); // 공통으로 쓰기 위해서 도입
        }


    }

    class Lion : Animal
    {
        public Lion(String name)
            : base(name)// constructor
        {
            weight = 10;
            nPig = 0;
        }

        int nPig; // 먹은 돼지

        public override void makeSound() // abstract function을 쓰기 위해 override 한다
        {
            Console.WriteLine("으르렁?");
        }
        public override void eat(int pig)
        {
            nPig += pig;
            base.eat(10 * pig);
        }
        public void fart()
        {
            Console.WriteLine("뿡");
            increaseWeight(-1);
        }

        public override string ToString()
        {
            String s = base.ToString(); // 상위 클래스의 ToString 함수 호출
            s += " 돼지수 : " + nPig;
            return s;
        }
    }
    class Rabbit : Animal // Lion 클래스와 비슷한 내용의 Rabbit class
    {
        public Rabbit(String name)
            : base(name)// constructor
        {
            weight = 1;
            nCarrot = 0;
        }

        int nCarrot; // 먹은 당근

        public override void makeSound() // abstract function을 쓰기 위해 override 한다
        {
            Console.WriteLine("삑?");
        }
        public override void eat(int carrot)
        {
            nCarrot += carrot;
            base.eat(carrot);
        }
        public void dig() // Lion의 fart 함수와 다른 부분
        {
            Console.WriteLine("팍팍");
            increaseWeight(-1);
        }

        public override string ToString()
        {
            String s = base.ToString(); // 상위 클래스의 ToString 함수 호출
            s += " 당근 수 : " + nCarrot;
            return s;
        }
    }
    class Elephant : Animal
    {
        public Elephant(String name)
            : base(name)// constructor
        {
            weight = 100;
            nBanana = 0;
        }

        int nBanana; // 먹은 바나나

        public override void makeSound() // abstract function을 쓰기 위해 override 한다
        {
            Console.WriteLine("뿌우?");
        }
        public override void eat(int Banana)
        {
            nBanana += Banana;
            base.eat(5 * Banana);
        }
        public void shootWater()
        {
            Console.WriteLine("푸우?");
            increaseWeight(-2);
        }

        public override string ToString()
        {
            String s = base.ToString(); // 상위 클래스의 ToString 함수 호출
            s += " 바나나수 : " + nBanana;
            return s;
        }
    }
    class RandomNumber
    {
        static Random rand = new Random(); // Random 라이브러리 사용

        public static int getNext(int range)
        {
            int number = rand.Next(); // 무작위 정수 할당
            return number % range + 1; // modulo operator 사용
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 하위 클래스는 추상화 시킨 경우 상위 클래스의 객체를 인식할 수 있다
            // 이를 upcasting이라고 한다
            Animal l1 = new Lion("사원");
            Animal l2 = new Lion("사투");
            Animal l3 = new Lion("사쓰");

            Animal r1 = new Rabbit("토원");
            Animal r2 = new Rabbit("토투");

            Animal e1 = new Elephant("코원");
            Animal e2 = new Elephant("코투");
            Animal e3 = new Elephant("코쓰");

            // 위처럼 upcasting을 통한 객체의 생성이 이루어진 경우 dynamic binding이 필요하다
            // dynamic binding을 위해서 Animal class에 아래 함수들 작성
            l1.makeSound();
            l1.eat(RandomNumber.getNext(2)); // 최대값이 2 중에 랜덤으로
            l1.fart(); // 고유 함수들의 경우 dynamic binding을 통해서 해결이 불가능하다
            l2.makeSound();
            l2.eat(RandomNumber.getNext(2));
            l2.fart();
            l3.makeSound();
            l3.eat(RandomNumber.getNext(2));
            l3.fart();

            r1.makeSound();
            r1.eat(RandomNumber.getNext(10)); // 최대값이 10 중에 랜덤으로
            r1.dig(); // 고유 함수들의 경우 dynamic binding을 통해서 해결이 불가능하다
            r2.makeSound();
            r2.eat(RandomNumber.getNext(10));
            r2.dig();

            e1.makeSound();
            e1.eat(RandomNumber.getNext(100)); // 최대값이 2 중에 랜덤으로
            e1.shootWater(); // 고유 함수들의 경우 dynamic binding을 통해서 해결이 불가능하다
            e2.makeSound();
            e2.eat(RandomNumber.getNext(100));
            e2.shootWater();
            e3.makeSound();
            e3.eat(RandomNumber.getNext(100));
            e3.shootWater();

            for (int day = 0; day < 10; day++)
            {
                Console.WriteLine(l1.ToString());
                Console.WriteLine(l2.ToString());
                Console.WriteLine(l3.ToString());

                Console.WriteLine(r1.ToString());
                Console.WriteLine(r2.ToString());

                Console.WriteLine(e1.ToString());
                Console.WriteLine(e2.ToString());
                Console.WriteLine(e3.ToString());
            }
        }
    }
}
