using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections; // 이곳에 ArrayList를 포함한 대부분의 collection 객체가 다 모여 있다

// 이전의 만든 class들은 그대로 두고 collection 객체만 따로 사용
// 조금 더 깔끔해지고 foreach문의 사용도 발생했다

namespace _41_zoo5
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
            // 배열에 들어간 것들은 Animal이지만 각자 다른 것들이 들어있다
            ArrayList list = new ArrayList(); // growable array를 라이브러리에서 만들어 놓은 것이 ArrayList이다
            // 사용하기 위해 using System.Collections를 추가해야 한다

            // 아래처럼 리스트에 아무거나 다 집어넣을 수 있다
            list.Add(new Lion("사원"));
            list.Add(new Lion("사투"));
            list.Add(new Lion("사쓰"));

            list.Add(new Rabbit("토원"));
            list.Add(new Rabbit("토투"));

            list.Add(new Elephant("코원"));
            list.Add(new Elephant("코투"));
            list.Add(new Elephant("코쓰"));

            for (int day = 0; day < 10; day++)
            {
                // 반복되면서 코드들이 굉장히 간소화되었다
                // 이게 dynamic binding의 장점
                foreach(Animal ptr in list) // 이런식으로 list의 길이만큼 반복하면서 list 내부의 자료를 Animal class의 ptr로 하나씩 옮겨 사용할 수 있게 한다
                {
                    // dynamic binding
                    ptr.makeSound(); // dynamic binding
                    int food = 0;

                    if (ptr is Lion) // RTTI RunTime Type Identification
                    {
                        food = RandomNumber.getNext(2); // 이런 식으로 parameter 값을 if문으로 제어해 사용 가능하다
                    }
                    else if (ptr is Rabbit)
                    {
                        food = RandomNumber.getNext(10);
                    }
                    else if (ptr is Elephant)
                    {
                        food = RandomNumber.getNext(100);
                    }
                    ptr.eat(food); // 이런 방식은 dynamic binding이다

                    if (ptr is Lion) // RTTI RunTime Type Identification
                    {
                        ((Lion)ptr).fart(); // 이런 식으로 downcasting을 통해 내부의 고유 함수도 사용할 수 있다
                        // down casting을 사용하려면 RTTI를 통해 확실히 class를 확인해야 한다
                    }
                    else if (ptr is Rabbit)
                    {
                        ((Rabbit)ptr).dig(); // 이런 식으로 사용하는 것은 static binding이다
                    }
                    else if (ptr is Elephant)
                    {
                        ((Elephant)ptr).shootWater();// 이런 식으로 사용하는 것은 static binding이다
                    }
                }
            }
            foreach (Animal ptr in list)
            {
                Console.WriteLine(ptr.ToString());
            }
        }
    }
}
