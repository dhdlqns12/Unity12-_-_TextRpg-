//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Numerics;
//using System.Text;
//using System.Threading.Tasks;

//namespace Step_3
//{
//    internal class Step3
//    {
//        static int Add(int a, int b)
//        {
//            return a + b;
//        }

//        static void PrintItemPrice(string itemName, int price)
//        {
//            Console.WriteLine($"{itemName}의 가격은 {price}골드입니다.");
//        }

//        static void TakeDamage(int damage)
//        {
//            Console.WriteLine($"플레이어는 {damage}의 데미지를 입었습니다.");
//        }

//        static string GetFullName(string firstName, string lastName)
//        {
//            return firstName + " " + lastName;
//        }

//        static float GetAverage(int a, int b)
//        {
//            return (float)(a + b) / 2f;
//        }

//        static int ClaculateRamainingHp(int hp, int damage)
//        {
//            return hp - damage;
//        }

//        static bool isEven(int number)
//        {
//            if (number % 2 == 0)
//            {
//                return true;
//            }
//            else
//                return false;
//        }

//        static bool IsAdult(int age)
//        {
//            if (age >= 19)
//                return true;
//            else
//                return false;
//        }

//        static bool IsAlive(int hp)
//        {
//            if (hp > 0)
//                return true;
//            else
//                return false;
//        }

//        static void CheckHp(int hp)
//        {
//            if (IsAlive(hp))
//            {
//                Console.WriteLine("플레이어는 생존해 있습니다.");
//            }
//            else
//            {
//                Console.WriteLine("플레이어는 사망했습니다.");
//            }
//        }

//        static void Main()
//        {
//            Console.WriteLine(Add(1, 2));
//            Console.WriteLine(Add(5, 5));
//            Console.WriteLine(Add(100, 200));

//            PrintItemPrice("철검", 1000);
//            PrintItemPrice("가죽갑옷", 500);

//            int result1 = Add(10, 20);
//            int result2 = Add(result1, 50); //예상값 80
//            Console.WriteLine(result2);

//            int damage = 10 * 5;
//            TakeDamage(damage);

//            string fullName = GetFullName("John", "Doe");
//            Console.WriteLine(GetFullName("John", "Doe"));
//            Console.WriteLine(fullName);

//            Console.WriteLine(GetAverage(10, 20));
//            Console.WriteLine(GetAverage(5, 10));

//            int currentHp = 100;
//            currentHp = ClaculateRamainingHp(currentHp, 30);
//            Console.WriteLine(currentHp);
//            Console.WriteLine(isEven(10));
//            Console.WriteLine(isEven(7));

//            bool isAdult1 = IsAdult(20);
//            bool isAdult2 = IsAdult(15);

//            Console.WriteLine(isAdult1);
//            Console.WriteLine(isAdult2);

//            CheckHp(50);
//            CheckHp(0);
//        }
//    }
//}
